using DataSystem;
using EventNotifier;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace GameSystem
{
    // Doesn't work
    public class TryRaycast : MonoBehaviour
    {
        /*
        public Material normalPlane;

        public Material selectedPlane;
        
        private ARPlane _selectedPlane;
    
        private MeshRenderer _meshRenderer;
        
        public ARPlaneManager _planeManager;
        
        private RaycastHit _hit;

        private Ray _ray;

        public Camera _camera;

        private readonly string _planeTag = "Plane";
        
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
            if (Input.touchCount == 0)
                return;

            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit))
            {
                if (_hit.transform.CompareTag(_planeTag))
                {
                    OnPlaneSelection(_hit.transform.gameObject);
                }
            }
        }

        private void OnPlaneSelection(GameObject touchedPlane)
        {
            _planeManager.enabled = false;

            foreach (var plane in _planeManager.trackables)
            {
                if (touchedPlane == plane.gameObject)
                    _selectedPlane = plane;
            }
            
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
        }*/
    }
}
