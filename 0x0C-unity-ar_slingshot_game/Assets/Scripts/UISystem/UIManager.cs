using EventNotifier;
using UnityEngine;

namespace UISystem
{
    public class UIManager : MonoBehaviour
    {
        public GameObject startGameButton;
        public GameObject playAgainButton;
        public GameObject gamePanel;
        public GameObject score;
        
        private void Start()
        {
            startGameButton.SetActive(false);
            playAgainButton.SetActive(false);
            gamePanel.SetActive(false);
            score.SetActive(false);
        }

        private void OnEnable()
        {
            GameEvents.OnPrepareGame += DisplayStartGameButton; // will be unsubscribed after first time
            GameEvents.OnStartGame += DisplayGamePanel;
            GameEvents.OnFinishGame += DisplayPlayAgainButton;
        }
        
        private void OnDisable()
        {
            GameEvents.OnPrepareGame -= DisplayStartGameButton;
            GameEvents.OnStartGame -= DisplayGamePanel;
            GameEvents.OnFinishGame -= DisplayPlayAgainButton;
        }

        private void DisplayGamePanel()
        {
            gamePanel.SetActive(true);
            score.SetActive(true);
        }
        
        private void DisplayPlayAgainButton() => playAgainButton.SetActive(true);
        
        private void DisplayStartGameButton()
        {
            GameEvents.OnPrepareGame -= DisplayStartGameButton;
            startGameButton.SetActive(true);
        }
    }
}