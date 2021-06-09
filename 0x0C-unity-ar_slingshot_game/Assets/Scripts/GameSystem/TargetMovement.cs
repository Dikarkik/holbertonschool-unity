using UnityEngine;
using UnityEngine.AI;

namespace GameSystem
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class TargetMovement : MonoBehaviour
    {
        public NavMeshAgent agent;
        
        private Vector3 _destination;

        private void Start()
        {
            SetDestination();
            _destination.y = transform.position.y;
        }

        private void SetDestination()
        {
            _destination.x = Random.Range(transform.position.x - 2, transform.position.x + 2);
            _destination.z = Random.Range(transform.position.z - 2, transform.position.z + 2);
            agent.SetDestination(_destination);
            
            Invoke(nameof(SetDestination), Random.Range(3, 6));
        }
    }
}