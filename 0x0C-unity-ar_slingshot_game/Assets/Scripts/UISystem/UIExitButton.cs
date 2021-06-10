using UnityEngine;
using UnityEngine.EventSystems;

namespace UISystem
{
    public class UIExitButton : MonoBehaviour, IPointerUpHandler
    {
        public void OnPointerUp(PointerEventData eventData)
        {
            Application.Quit();
        }
    }
}