using EventNotifier;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UISystem
{
    public class UIStartGameButton : MonoBehaviour, IPointerUpHandler
    {
        public void OnPointerUp(PointerEventData eventData)
        {
            StartingEvents.OnStartGameEvent();
            gameObject.SetActive(false);
        }
    }
}