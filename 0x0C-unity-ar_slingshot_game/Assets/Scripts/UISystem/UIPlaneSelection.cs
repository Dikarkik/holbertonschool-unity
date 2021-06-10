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
            confirmSelection.SetActive(false);
            instructions.SetActive(!Application.isEditor);
        }

        private void OnEnable()
        {
            GameEvents.OnPlaneSelection += OnPlaneSelection;
            GameEvents.OnConfirmPlaneSelection += OnConfirmPlaneSelection;
            GameEvents.OnCancelPlaneSelection += OnCancelPlaneSelection;
        }
        
        private void OnDisable()
        {
            GameEvents.OnPlaneSelection -= OnPlaneSelection;
            GameEvents.OnConfirmPlaneSelection -= OnConfirmPlaneSelection;
            GameEvents.OnCancelPlaneSelection -= OnCancelPlaneSelection;
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