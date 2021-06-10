using DataSystem;
using EventNotifier;
using UnityEngine;
using TMPro;

namespace UISystem
{
    public class UIScore : MonoBehaviour
    {
        public GameData data;
        public TMP_Text score;
        
        private void OnEnable() => GameEvents.OnUpdateScore += UpdateScore;
        
        private void OnDisable() => GameEvents.OnUpdateScore -= UpdateScore;
        
        private void UpdateScore() => score.SetText(data.score.ToString());
    }
}