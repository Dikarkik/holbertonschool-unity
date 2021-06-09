using UnityEngine;

namespace UISystem
{
    public class UIManager : MonoBehaviour
    {
        public GameObject startGameButton;
        
        private void Start() => startGameButton.SetActive(Application.isEditor);
    }
}
