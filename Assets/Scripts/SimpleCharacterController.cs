//Created by Jorik Weymans 2020

using System.Runtime.CompilerServices;
using UnityEngine;

namespace Jorik
{
    [RequireComponent(typeof(CharacterController))]
	public sealed class SimpleCharacterController : MonoBehaviour
    {
        [SerializeField] private float _Speed = 10.0f;

        private CharacterController _Cont = null;
        private Camera _MainCamera = null;

        private void Awake()
        {
            _Cont = GetComponent<CharacterController>();
            _MainCamera = Camera.main;
        }

        private void FixedUpdate()
        {
            Vector2 xValue = _MainCamera.transform.right.normalized * Input.GetAxis("Horizontal") * _Speed;
            Vector2 yValue = _MainCamera.transform.up.normalized * Input.GetAxis("Vertical") * _Speed;

            _Cont.Move(xValue  + yValue);
            
        }
	}
}

