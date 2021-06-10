using DataSystem;
using EventNotifier;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.ARFoundation;

namespace GameSystem
{
    public class GameManager : MonoBehaviour
    {
        public GameData data;
        
        public static ARPlane Plane;
        
        public Transform planeInEditor;

        public int targetToInstantiate = 5;
        
        public GameObject targetPrefab;

        public GameObject ammo;

        private GameObject[] _targets;

        private void Awake()
        {
            ammo.SetActive(false);
            _targets = new GameObject[targetToInstantiate];
        }

        private void OnEnable()
        {
            GameEvents.OnPrepareGame += ResetValues;
            GameEvents.OnPrepareGame += InstantiateTargets;
            GameEvents.OnStartGame += EnableAmmo;
            GameEvents.OnAmmoFired += AmmoFired;
            GameEvents.OnTargetDestroyed += TargetDestroyed;
            GameEvents.OnFinishGame += CheckWinOrLose;
        }

        private void OnDisable()
        {
            GameEvents.OnPrepareGame -= ResetValues;
            GameEvents.OnPrepareGame -= InstantiateTargets;
            GameEvents.OnStartGame -= EnableAmmo;
            GameEvents.OnAmmoFired -= AmmoFired;
            GameEvents.OnTargetDestroyed -= TargetDestroyed;
            GameEvents.OnFinishGame -= CheckWinOrLose;
        }

        private void Start()
        {
            if (Application.isEditor)
            {
                planeInEditor.gameObject.SetActive(true);
                planeInEditor.GetComponent<NavMeshSurface>().BuildNavMesh();
                GameEvents.OnPrepareGameEvent();
            }
            else
                planeInEditor.gameObject.SetActive(false);
        }
        
        // Reset ammo count, score, targets
        private void ResetValues()
        {
            data.ResetAmmoCount();
            // Reset Score
        }
        
        private void InstantiateTargets()
        {
            // Delete previous targets
            for (int i = 0; i < _targets.Length; i++)
                if (_targets[i] != null) Destroy(_targets[i]);
            
            Vector3 pos = Plane != null ? Plane.center : planeInEditor.position;
            
            for (int i = 0; i < targetToInstantiate; i++)
                _targets[i] = Instantiate(targetPrefab, pos, Quaternion.identity);
        }

        private void EnableAmmo() => ammo.SetActive(true);

        private void AmmoFired() => data.ammoCount--;

        private void TargetDestroyed() => data.destroyedTargets++;

        private void CheckWinOrLose()
        {
            if (data.destroyedTargets == targetToInstantiate)
                Debug.Log("win");
            else
                Debug.Log("Lose");
        }
    }
}