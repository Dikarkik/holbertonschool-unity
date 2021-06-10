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
            startGameButton.SetActive(Application.isEditor);
            playAgainButton.SetActive(false);
            gamePanel.SetActive(false);
            score.SetActive(false);
        }

        private void OnEnable()
        {
            GameEvents.OnStartGame += DisplayGamePanel;
            GameEvents.OnFinishGame += DisplayPlayAgainButton;
        }
        
        private void OnDisable()
        {
            GameEvents.OnStartGame -= DisplayGamePanel;
            GameEvents.OnFinishGame -= DisplayPlayAgainButton;

        }

        private void DisplayGamePanel()
        {
            gamePanel.SetActive(true);
            score.SetActive(true);
        }
        
        private void DisplayPlayAgainButton() => playAgainButton.SetActive(true);
    }
}
