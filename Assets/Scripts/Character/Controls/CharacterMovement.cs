using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
   
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement : MonoBehaviour
    {
        private IMoveHandler _moveEventsHandler;

        private CharacterController _charContoroller;

        private bool _wantsToJump = false;
        private float _jumpForce =0;

        private void Awake()
        {
            _moveEventsHandler = GetComponent<IMoveHandler>();

            _charContoroller = GetComponent<CharacterController>();

          
        }

        private void Update()
        {
            _wantsToJump = false;
        }

        private void Move(Vector3 direction, float speed)
        {
            _charContoroller.Move(speed * Time.deltaTime * direction);

            if (_wantsToJump)
            {
                Jump();
            }
        }

        private void Rotate(Vector3 direction, float turnSpeed)
        {
            if (direction != Vector3.zero)
            {
                Quaternion currentRotation = transform.rotation;

                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, turnSpeed);
            }
        }

        private void SetJump(float jumpForce)
        {
            _wantsToJump = true; 
            _jumpForce = jumpForce;
        }

        private void Jump()
        {

        }

        private void OnEnable()
        {
            _moveEventsHandler.OnMoveEvent += Move;
            _moveEventsHandler.OnRotationEvent += Rotate;
            _moveEventsHandler.OnJumpEvent += SetJump;
        }
        private void OnDisable()
        {
            _moveEventsHandler.OnMoveEvent -= Move;
            _moveEventsHandler.OnRotationEvent -= Rotate;
        }
    }
}
