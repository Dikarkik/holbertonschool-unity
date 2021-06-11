using System;
using DataSystem;
using EventNotifier;
using UnityEngine;

namespace GameSystem
{
    public class Ammo : MonoBehaviour
    {
        public GameData data;
        
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
            if (data.ammoCount == 0)
            {
                GameEvents.OnFinishGameEvent();
                gameObject.SetActive(false);
            }
            
            _rigidBody.useGravity = false;
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.angularVelocity = Vector3.zero;
            _transform.SetParent(camTransform);
            _transform.localRotation = Quaternion.identity;
            _transform.localPosition = _defaultPosition;
        }
        
        private void Shoot()
        {
            _transform.SetParent(null);
            _rigidBody.useGravity = true;
            _force = Math.Abs(_startPos.y - _finalPos.y);
            _rigidBody.AddRelativeForce(0, _force * 10, _force * 10, ForceMode.Impulse);
            GameEvents.OnAmmoFiredEvent();
        }

        private void Update()
        {
            if (_transform.position.y < _planeYPosition - 3)
                ResetAmmoPosition();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag(TargetTag))
            {
                Destroy(other.gameObject);
                GameEvents.OnTargetDestroyedEvent();
            }

            ResetAmmoPosition();
        }

        private void OnMouseDown()
        {
            _startPos = transform.localPosition;
        }

        private void OnMouseUp()
        {
            _finalPos = transform.localPosition;
            Shoot();
        }

        private void OnMouseDrag()
        {
            _ray = cam.ScreenPointToRay(Input.mousePosition);
            var direction = transform.InverseTransformDirection(_ray.direction);

            _currentPos.y = direction.y > _startPos.y ? _startPos.y : direction.y ;
            _currentPos.z = _currentPos.y + 1.1f;
            _currentPos.x = direction.x;
            
            transform.localPosition = Vector3.Lerp(transform.localPosition, _currentPos, Time.deltaTime * 300);
        }
    }
}