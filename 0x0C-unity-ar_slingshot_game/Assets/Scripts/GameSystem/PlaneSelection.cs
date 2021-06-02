﻿using System.Collections.Generic;
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
        
        private bool _canClick = true; // Because UnityEngine.XR.ARFoundation.ARRaycastManager.Raycast doesn't handle LayerMask

        private ARPlane _selectedPlane;
    
        private MeshRenderer _meshRenderer;
        
        private ARPlaneManager _planeManager;
        
        private ARRaycastManager _raycastManager;
        
        private static List<ARRaycastHit> _hits = new List<ARRaycastHit>();

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
            if (Input.touchCount == 0 || !_canClick)
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
            _canClick = false;
            _planeManager.enabled = false;
            
            _selectedPlane = plane;
            _meshRenderer = _selectedPlane.GetComponent<MeshRenderer>();
            _meshRenderer.material = selectedPlane;
            
            StartingEvents.OnPlaneSelectionEvent();
        }
    
        private void OnConfirmPlaneSelection()
        {
            GameData.SetPlane(_selectedPlane);
                
            foreach (var plane in _planeManager.trackables)
            {
                if (plane != _selectedPlane)
                    plane.gameObject.SetActive(false);
            }

            this.enabled = false;
        }

        private void OnCancelPlaneSelection()
        {
            _meshRenderer.material = normalPlane;
            _planeManager.enabled = true;

            // To avoid plane selections immediately after press "Cancel" button
            Invoke(nameof(CanClick), 0.4f);
        }

        private void CanClick() => _canClick = true;
    }
}