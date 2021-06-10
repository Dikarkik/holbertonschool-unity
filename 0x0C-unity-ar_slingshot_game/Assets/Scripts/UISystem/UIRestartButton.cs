using EventNotifier;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UISystem
{
    public class UIRestartButton : MonoBehaviour, IPointerUpHandler
    {
        public void OnPointerUp(PointerEventData eventData)
        {
            GameEvents.OnPrepareGameEvent();
            GameEvents.OnStartGame();
        }
    }
}