using System;
using UnityEngine;

namespace GameSystem
{
    public class Ammo : MonoBehaviour
    {
        public Camera cam;

        public Transform camTransform;

        private Transform _transform;
        
        private Rigidbody _rigidBody;

        private float _planeYPosition;
        
        private readonly Vector3 _defaultPosition = new Vector3(0, 0, 1.1f);

        private const string TargetTag = "Target";
        
        private Ray _ray;

        private  Vector3 _startPos;
        
        private Vector3 _finalPos;

        private Vector3 _currentPos;

        private float _force;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _rigidBody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            ResetAmmoPosition();
            _planeYPosition = GameManager.Plane != null ? GameManager.Plane.transform.position.y : FindObjectOfType<GameManager>().planeInEditor.position.y;
        }

        private void ResetAmmoPosition()
        {
            _rigidBody.useGravity = false;
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.angularVelocity = Vector3.zero;
            _transform.rotation = Quaternion.identity;
            _transform.SetParent(camTransform);
            _transform.transform.localPosition = _defaultPosition;
        }
        
        private void Shoot()
        {
            _transform.SetParent(null);
            _rigidBody.useGravity = true;
            _force = Math.Abs(_startPos.y - _finalPos.y);
            _rigidBody.AddForce(0, _force * 10, _force * 10, ForceMode.Impulse);
        }

        private void Update()
        {
            if (_transform.position.y < _planeYPosition - 3)
                ResetAmmoPosition();
        }

        private void OnCollisionEnter(Collision other)
        {
            ResetAmmoPosition();
            
            if (other.transform.CompareTag(TargetTag))
                Destroy(other.gameObject);
        }

        private void OnMouseDown() => _startPos = transform.position;

        private void OnMouseUp()
        {
            _finalPos = transform.position;
            Shoot();
        }

        private void OnMouseDrag()
        {
            _ray = cam.ScreenPointToRay(Input.mousePosition);

            _currentPos.y = _ray.direction.y > _startPos.y ? _startPos.y : _ray.direction.y ;
            _currentPos.z = _currentPos.y + 1.1f;
            _currentPos.x = _ray.direction.x;

            transform.position = Vector3.Lerp(transform.position, _currentPos, Time.deltaTime * 300);
        }
    }
}