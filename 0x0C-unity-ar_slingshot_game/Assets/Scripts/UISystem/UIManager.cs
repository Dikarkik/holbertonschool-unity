using System;
using EventNotifier;
using UnityEngine;

namespace UISystem
{
    public class UIManager : MonoBehaviour
    {
        public GameObject startGameButton;
        public GameObject gamePanel;
        
        private void Start()
        {
            startGameButton.SetActive(Application.isEditor);
            gamePanel.SetActive(false);
        }

        private void OnEnable()
        {
            GameEvents.OnStartGame += DisplayGamePanel;
        }
        
        private void OnDisable()
        {
            GameEvents.OnStartGame -= DisplayGamePanel;
        }

        private void DisplayGamePanel()
        {
            gamePanel.SetActive(true);
        }
    }
}
