using EventNotifier;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UISystem
{
    public class UIConfirmPlaneButton : MonoBehaviour, IPointerUpHandler
    {
        public void OnPointerUp(PointerEventData eventData)
        {
            GameEvents.OnConfirmPlaneSelectionEvent();
        }
    }
}