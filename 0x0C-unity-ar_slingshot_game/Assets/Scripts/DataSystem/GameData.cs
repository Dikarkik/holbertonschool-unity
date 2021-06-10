using UnityEngine;

namespace DataSystem
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData")]
    public class GameData : ScriptableObject
    {
        public int ammoDefaultValue = 7;

        public int ammoCount;

        public int destroyedTargets;

        public void ResetAmmoCount() => ammoCount = ammoDefaultValue;
    }
}