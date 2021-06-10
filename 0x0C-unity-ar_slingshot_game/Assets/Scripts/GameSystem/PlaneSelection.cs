using System;
using System.Collections.Generic;
using EventNotifier;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace GameSystem
{
    public class PlaneSelection : MonoBehaviour
    {
        public Material normalPlane;

        public Material selectedPlane;
        
        private ARPlane _selectedPlane;
    
        private MeshRenderer _meshRenderer;
        
        private ARPlaneManager _planeManager;
        
        private ARRaycastManager _raycastManager;
        
        private List<ARRaycastHit> _hits = new List<ARRaycastHit>();

        private Touch _touch;

        private bool _canClick = true;

        private void Awake()
        {
            _raycastManager = GetComponent<ARRaycastManager>();
            _planeManager = GetComponent<ARPlaneManager>();
        }

        private void Start() => this.enabled = !Application.isEditor;

        private void OnEnable()
        {
            GameEvents.OnConfirmPlaneSelection += OnConfirmPlaneSelection;
            GameEvents.OnCancelPlaneSelection += OnCancelPlaneSelection;
        }

        private void OnDisable()
        {
            GameEvents.OnConfirmPlaneSelection -= OnConfirmPlaneSelection;
            GameEvents.OnCancelPlaneSelection -= OnCancelPlaneSelection;
        }

        void Update()
        {
            // Invalid touch
            if (Input.touchCount == 0 || !_canClick) return;
            
            _touch = Input.GetTouch(0);
        
            if (IsPointerOverUI(_touch)) return;
            
            // Touch Planes
            if (_raycastManager.Raycast(_touch.position, _hits, TrackableType.Planes))
            {
                // Raycast hits are sorted by distance, so the first one
                // will be the closest hit.
                OnPlaneSelection((ARPlane)_hits[0].trackable);
            }
        }
        
        private bool IsPointerOverUI(Touch touch)
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = new Vector2(touch.position.x, touch.position.y);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            return results.Count > 0;
        }

        private void OnPlaneSelection(ARPlane plane)
        {
            _canClick = false;
            _planeManager.enabled = false;
            
            _selectedPlane = plane;
            _meshRenderer = _selectedPlane.GetComponent<MeshRenderer>();
            _meshRenderer.material = selectedPlane;
            
            GameEvents.OnPlaneSelectionEvent();
        }
    
        private void OnConfirmPlaneSelection()
        {
            foreach (var plane in _planeManager.trackables)
            {
                if (plane != _selectedPlane)
                    plane.gameObject.SetActive(false);
            }

            GameManager.Plane = _selectedPlane;
            _selectedPlane.GetComponent<NavMeshSurface>().BuildNavMesh();
            GameEvents.OnPrepareGameEvent();
            
            this.enabled = false;
        }

        private void OnCancelPlaneSelection()
        {
            _meshRenderer.material = normalPlane;
            _planeManager.enabled = true;
            Invoke(nameof(EnableClick), 0.3f); 
        }

        private void EnableClick() => _canClick = true;
    }
}