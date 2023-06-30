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

        private void Awake()
        {
            _moveEventsHandler = GetComponent<IMoveHandler>();

            _charContoroller = GetComponent<CharacterController>();

          
        }


        private void Move(Vector3 direction, float speed, bool isJumping = false)
        {
            _charContoroller.Move(speed * Time.deltaTime * direction);
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

        private void OnEnable()
        {
            _moveEventsHandler.OnMoveEvent += Move;
            _moveEventsHandler.OnRotationEvent += Rotate;
        }
        private void OnDisable()
        {
            _moveEventsHandler.OnMoveEvent -= Move;
            _moveEventsHandler.OnRotationEvent -= Rotate;
        }
    }
}
