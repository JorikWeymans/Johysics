//Created by Jorik Weymans 2020

using System.Runtime.CompilerServices;
using UnityEngine;

namespace Jorik
{
    [RequireComponent(typeof(Rigidbody))]
	public sealed class SimpleCharacterController : MonoBehaviour
    {
        [SerializeField] private float _Speed = 10.0f;
        [SerializeField] private float _RotationSpeed = 2.0f;
        private Rigidbody _Cont = null;
        private Camera _MainCamera = null;

        private void Awake()
        {
            _Cont = GetComponent<Rigidbody>();
            _MainCamera = Camera.main;
        }

        private void FixedUpdate()
        {
            Vector3 xValue = _MainCamera.transform.right.normalized * Input.GetAxis("Horizontal") * _Speed;
            Vector3 yValue = _MainCamera.transform.up.normalized * Input.GetAxis("Vertical") * _Speed;

            Vector3 newPos =  transform.position + xValue + yValue;

            _Cont.MovePosition(newPos);

            



        }
	}
}

