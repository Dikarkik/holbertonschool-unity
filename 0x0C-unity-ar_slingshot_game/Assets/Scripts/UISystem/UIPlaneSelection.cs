using EventNotifier;
using UnityEngine;

namespace UISystem
{
    public class UIPlaneSelection : MonoBehaviour
    {
        public GameObject instructions;
    
        public GameObject confirmSelection;
        
        private void Start()
        {
            instructions.SetActive(true);
            confirmSelection.SetActive(false);
        }

        private void OnEnable()
        {
            StartingEvents.OnPlaneSelection += OnPlaneSelection;
            StartingEvents.OnConfirmPlaneSelection += OnConfirmPlaneSelection;
            StartingEvents.OnCancelPlaneSelection += OnCancelPlaneSelection;
        }
        
        private void OnDisable()
        {
            StartingEvents.OnPlaneSelection -= OnPlaneSelection;
            StartingEvents.OnConfirmPlaneSelection -= OnConfirmPlaneSelection;
            StartingEvents.OnCancelPlaneSelection -= OnCancelPlaneSelection;
        }

        private void OnPlaneSelection()
        {
            instructions.SetActive(false);
            confirmSelection.SetActive(true);
        }
        
        private void OnConfirmPlaneSelection()
        {
            confirmSelection.SetActive(false);
        }
        
        private void OnCancelPlaneSelection()
        {
            instructions.SetActive(true);
            confirmSelection.SetActive(false);
        }
    }
}