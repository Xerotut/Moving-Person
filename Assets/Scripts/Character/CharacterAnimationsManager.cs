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
        [SerializeField] private string _isAimingName = "IsAiming";


        [SerializeField]private Rigidbody _charRB;

        private Vector2 _moveInput;
        private bool _isGrounded;
        private bool _isAiming; 

        IGroundedHandler _isGroundedHandler;
        IWeaponHandler _weaponHandler;

        private void Awake()
        {
            _isGroundedHandler = GetComponent<IGroundedHandler>();
            _weaponHandler = GetComponent<IWeaponHandler>();
        }

        private void Update()
        {
            float inputMagnitude = Mathf.Clamp01(_moveInput.magnitude);
            _animator.SetFloat(_moveInputMagnitudeName, inputMagnitude);

            _animator.SetBool(_isGroundedName, _isGrounded);
            
            _animator.SetBool(_isAimingName, _isAiming);
        }

        
        private void SetMoveInput(Vector2 input)
        {
            _moveInput = input;
        }
        private void SetIsGrounded(bool isGrounded)
        {
            _isGrounded = isGrounded;
        }
        private void SetIsAiming(bool isAiming)
        {
            _isAiming = isAiming;
        }
        

        private void OnEnable()
        {
            InputReader.OnMove += SetMoveInput;
            _weaponHandler.OnAim += SetIsAiming;
            _isGroundedHandler.OnGroundedCheck += SetIsGrounded;
        }

        private void OnDisable()
        {
            InputReader.OnMove -= SetMoveInput;
            _weaponHandler.OnAim -= SetIsAiming;
            _isGroundedHandler.OnGroundedCheck -= SetIsGrounded;
        }
    }
}
