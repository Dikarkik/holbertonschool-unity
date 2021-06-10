using UnityEngine;

namespace DataSystem
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData")]
    public class GameData : ScriptableObject
    {
        public int targetsToInstantiate = 5;
        
        public int ammoDefaultValue = 7;

        public int ammoCount;

        public int destroyedTargets;

        public int score;

        public void ResetValues()
        {
            ammoCount = ammoDefaultValue;
            destroyedTargets = 0;
            score = 0;
        }
    }
}