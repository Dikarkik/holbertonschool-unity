using EventNotifier;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UISystem
{
    public class UICancelPlaneButton : MonoBehaviour, IPointerUpHandler
    {
        public void OnPointerUp(PointerEventData eventData)
        {
            GameEvents.OnCancelPlaneSelectionEvent();
        }
    }
}