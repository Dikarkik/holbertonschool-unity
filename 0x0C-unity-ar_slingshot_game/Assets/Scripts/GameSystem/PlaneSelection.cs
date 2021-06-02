using System.Collections.Generic;
using DataSystem;
using EventNotifier;
using UnityEngine;
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

        private ARRaycastManager _raycastManager;

        private ARPlaneManager _planeManager;
    
        private static List<ARRaycastHit> _hits = new List<ARRaycastHit>();

        private void Awake()
        {
            _raycastManager = GetComponent<ARRaycastManager>();
            _planeManager = GetComponent<ARPlaneManager>();
        }

        private void OnEnable() => StartingEvents.OnConfirmPlaneSelection += OnConfirmPlaneSelection;
    
        private void OnDisable() => StartingEvents.OnConfirmPlaneSelection -= OnConfirmPlaneSelection;

        void Update()
        {
            if (Input.touchCount == 0)
                return;

            if (_raycastManager.Raycast(Input.GetTouch(0).position, _hits, TrackableType.Planes))
            {
                // Raycast hits are sorted by distance, so the first one
                // will be the closest hit.
                OnPlaneSelection((ARPlane)_hits[0].trackable);
            }
        }

        private void OnPlaneSelection(ARPlane plane)
        {
            // Reset the material color in the previous plane
            if (_selectedPlane != null)
                _meshRenderer.material = normalPlane;

            _selectedPlane = plane;
            _meshRenderer = _selectedPlane.GetComponent<MeshRenderer>();
            _meshRenderer.material = selectedPlane;
            
            StartingEvents.OnPlaneSelectionEvent();
        }
    
        private void OnConfirmPlaneSelection()
        {
            if (_selectedPlane == null)
                Debug.Log("seleccionar plano para poder jugar");
            else
            {
                GameData.SetPlane(_selectedPlane);
                
                foreach (var plane in _planeManager.trackables)
                {
                    if (plane != _selectedPlane)
                        plane.gameObject.SetActive(false);
                }

                _planeManager.enabled = false;
                this.enabled = false;
            }
        }
    }
}