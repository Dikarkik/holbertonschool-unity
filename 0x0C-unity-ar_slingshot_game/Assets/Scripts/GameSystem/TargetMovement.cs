using UnityEngine;
using UnityEngine.AI;

namespace GameSystem
{
    public class TargetMovement : MonoBehaviour
    {
        public NavMeshAgent agent;
        private Vector3 _destination;
        
        private void Start() => SetDestination();

        private void SetDestination()
        {
            _destination.x = Random.Range(transform.position.x - 7, transform.position.x + 7);
            _destination.z = Random.Range(transform.position.z - 7, transform.position.z + 7);
            agent.SetDestination(_destination);

            Invoke(nameof(TargetMovement), Random.Range(3, 6));
        }
    }
}