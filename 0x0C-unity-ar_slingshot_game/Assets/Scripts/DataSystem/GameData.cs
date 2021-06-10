using UnityEngine;

namespace DataSystem
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData")]
    public class GameData : ScriptableObject
    {
        public const int AmmoDefaultValue = 7;

        public int ammoCount;

        public int destroyedTargets;

        private static GameData _instance;
        
        private void OnEnable()
        {
            if (_instance == null)
                _instance = this;
        }

        public static void ResetAmmoCount() => _instance.ammoCount = AmmoDefaultValue;

        public static void DecreaseAmmo() => _instance.ammoCount--;

        public static int GetAmmoCount() => _instance.ammoCount;

        public static int GetDestroyedTargets() => _instance.destroyedTargets;

        public static void TargetDestroyed() => _instance.destroyedTargets++;
    }
}