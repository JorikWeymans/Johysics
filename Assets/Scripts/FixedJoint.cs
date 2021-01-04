//Created by Jorik Weymans 2020

using UnityEngine;

namespace Jorik
{
    [RequireComponent(typeof(Rigidbody))]
	public sealed class FixedJoint : MonoBehaviour
    {
        [SerializeField] private Transform _Parent = null;

        private Rigidbody _Body = null;
        private Vector3 _DistanceVec = Vector3.zero;
        private void Awake()
        {
            _Body = GetComponent<Rigidbody>();
            _DistanceVec = transform.position - _Parent.position;

        }
        private void FixedUpdate()
        {
            _Body.MovePosition(_Parent.position + _DistanceVec);
        }
    }
}

