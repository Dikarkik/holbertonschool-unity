using System;
using UnityEngine;
using UnityEngine.AI;

namespace GameSystem
{
    public class NavigationBaker : MonoBehaviour
    {
        public NavMeshSurface navMeshSurface;
        public GameObject targetPrefab;
        public int targets = 5;

        private void OnEnable()
        {
            throw new NotImplementedException();
        }

        public void BakeNavMesh(Vector3 planeCenter)
        {
            navMeshSurface.BuildNavMesh();

            for (int i = 0; i < targets; i++)
            {
                Instantiate(targetPrefab, planeCenter, Quaternion.identity);
            }
        }
    }
}