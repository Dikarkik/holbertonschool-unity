using EventNotifier;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UISystem
{
    public class UIConfirmPlaneButton : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            StartingEvents.OnConfirmPlaneSelectionEvent();
        }
    }
}
