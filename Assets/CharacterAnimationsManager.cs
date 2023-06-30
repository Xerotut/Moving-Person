using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class CharacterAnimationsManager : MonoBehaviour
    {
        [SerializeField] Animator _animator;


        [SerializeField] private string _moveInputMagnitudeName = "InputMagnitude";

        private Vector2 _moveInput;

        private void Awake()
        {
            
        }

        private void Update()
        {
            float inputMagnitude = Mathf.Clamp01(_moveInput.magnitude);
            _animator.SetFloat(_moveInputMagnitudeName, inputMagnitude);
        }

        
        private void SetMoveInput(Vector2 input)
        {
            _moveInput = input;
        }

        private void OnEnable()
        {
            InputReader.OnMove += SetMoveInput;
        }
        private void OnDisable()
        {
            InputReader.OnMove -= SetMoveInput;
        }
    }
}
