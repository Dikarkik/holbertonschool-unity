using System;
using EventNotifier;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.ARFoundation;

namespace GameSystem
{
    public class GameManager : MonoBehaviour
    {
        public static ARPlane Plane;
        
        public Transform planeInEditor;

        public int targets = 5;
        
        public GameObject targetPrefab;

        public GameObject ammo;

        private void Awake() => ammo.SetActive(false);

        private void OnEnable()
        {
            StartingEvents.OnPrepareGame += InstantiateTargets;
            StartingEvents.OnStartGame += EnableAmmo;
        }

        private void OnDisable()
        {
            StartingEvents.OnPrepareGame -= InstantiateTargets;
            StartingEvents.OnStartGame -= EnableAmmo;
        }

        private void Start()
        {
            if (Application.isEditor)
            {
                planeInEditor.gameObject.SetActive(true);
                planeInEditor.GetComponent<NavMeshSurface>().BuildNavMesh();
                StartingEvents.OnPrepareGameEvent();
            }
            else
                planeInEditor.gameObject.SetActive(false);
        }

        private void InstantiateTargets()
        {
            Vector3 pos = Plane != null ? Plane.center : planeInEditor.position;

            for (int i = 0; i < targets; i++)
            {
                Instantiate(targetPrefab, pos, Quaternion.identity);
            }
        }

        private void EnableAmmo() => ammo.SetActive(true);
    }
}