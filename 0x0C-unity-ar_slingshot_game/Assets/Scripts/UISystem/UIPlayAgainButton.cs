using EventNotifier;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UISystem
{
    public class UIPlayAgainButton : MonoBehaviour, IPointerUpHandler
    {
        public void OnPointerUp(PointerEventData eventData)
        {
            GameEvents.OnPrepareGameEvent();
            GameEvents.OnStartGameEvent();
            gameObject.SetActive(false);
        }
    }
}