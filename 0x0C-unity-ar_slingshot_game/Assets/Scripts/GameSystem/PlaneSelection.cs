using System.Collections.Generic;
using EventNotifier;
using UnityEngine;
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

        private void Awake()
        {
            _raycastManager = GetComponent<ARRaycastManager>();
            _planeManager = GetComponent<ARPlaneManager>();
        }

        private void OnEnable()
        {
            StartingEvents.OnConfirmPlaneSelection += OnConfirmPlaneSelection;
            StartingEvents.OnCancelPlaneSelection += OnCancelPlaneSelection;
        }

        private void OnDisable()
        {
            StartingEvents.OnConfirmPlaneSelection -= OnConfirmPlaneSelection;
            StartingEvents.OnCancelPlaneSelection -= OnCancelPlaneSelection;
        }

        void Update()
        {
            // Invalid touch
            if (Input.touchCount == 0) return;
            
            _touch = Input.GetTouch(0);
            
            if (_touch.phase != TouchPhase.Began || IsPointerOverUI(_touch)) return;
            
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
            _planeManager.enabled = false;
            
            _selectedPlane = plane;
            _meshRenderer = _selectedPlane.GetComponent<MeshRenderer>();
            _meshRenderer.material = selectedPlane;
            
            StartingEvents.OnPlaneSelectionEvent();
        }
    
        private void OnConfirmPlaneSelection()
        {
            foreach (var plane in _planeManager.trackables)
            {
                if (plane != _selectedPlane)
                    plane.gameObject.SetActive(false);
            }
            
            _selectedPlane.GetComponent<NavigationBaker>().BakeNavMesh(_selectedPlane.center);
            
            this.enabled = false;
        }

        private void OnCancelPlaneSelection()
        {
            _meshRenderer.material = normalPlane;
            _planeManager.enabled = true;
        }
    }
}