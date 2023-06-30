using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class CharacterAnimationsManager : MonoBehaviour
    {
        [SerializeField] Animator _animator;


        [SerializeField] private string _moveInputMagnitudeName = "InputMagnitude";
        [SerializeField] private string _isGroundedName = "IsGrounded";
        [SerializeField] private string _verticalVelocityName = "Vertical Velocity";


        [SerializeField]private CharacterController _characterController;

        private Vector2 _moveInput;

       

        private void Update()
        {
            float inputMagnitude = Mathf.Clamp01(_moveInput.magnitude);
            _animator.SetFloat(_moveInputMagnitudeName, inputMagnitude);
            
            float verticalVelocity = _characterController.velocity.y;
            _animator.SetFloat(_verticalVelocityName, verticalVelocity);


            _animator.SetBool(_isGroundedName, _characterController.isGrounded);
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
