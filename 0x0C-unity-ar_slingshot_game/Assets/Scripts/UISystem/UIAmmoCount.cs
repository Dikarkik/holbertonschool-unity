﻿using DataSystem;
using EventNotifier;
using UnityEngine;

namespace UISystem
{
    public class UIAmmoCount : MonoBehaviour
    {
        public GameObject[] ammoImages;

        private void OnEnable()
        {
            GameEvents.OnStartGame += ResetAmmoCount;
            GameEvents.OnAmmoFired += UpdateAmmoCount;
        }
        
        private void OnDisable()
        {
            GameEvents.OnStartGame -= ResetAmmoCount;
            GameEvents.OnAmmoFired -= UpdateAmmoCount;
        }

        private void ResetAmmoCount()
        {
            for (int i = 0; i < ammoImages.Length; i++)
                ammoImages[i].SetActive(true);
        }
        
        private void UpdateAmmoCount()
        {
            var index = GameData.GetAmmoCount() > 0 ? GameData.GetAmmoCount() : 0;
            ammoImages[index].SetActive(false);
        }
    }
}