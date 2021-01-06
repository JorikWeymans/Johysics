//Created by Jorik Weymans 2020

using Jorik.Utilities;
using UnityEngine;

namespace Jorik
{
    [RequireComponent(typeof(Rigidbody))]
	public sealed class FixedJoint : MonoBehaviour
    {
        [SerializeField] private Transform _Parent = null;

        private Rigidbody _Body = null;
        private Matrix4x4 _DifferenceMatrix = Matrix4x4.identity;
        private void Awake()
        {
            _Body = GetComponent<Rigidbody>();

            Vector3 distanceDifference = transform.position - _Parent.position;
            Debug.Log(_Parent.localToWorldMatrix);

            //Quaternion angleDifference = transform.localToWorldMatrix.GetRotation() *
            //                             Quaternion.Inverse(_Parent.localToWorldMatrix.GetRotation());
            
            _DifferenceMatrix.SetTRS(distanceDifference, Quaternion.identity, Vector3.one);

        }
        private void FixedUpdate()
        {
            Matrix4x4 desiredMatrix = _Parent.localToWorldMatrix * _DifferenceMatrix;

            _Body.MovePosition(desiredMatrix.GetTranslation());
            _Body.MoveRotation(desiredMatrix.GetRotation());
        }
    }
}

