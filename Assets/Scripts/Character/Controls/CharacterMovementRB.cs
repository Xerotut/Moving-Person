using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterMovementRB : MonoBehaviour
    {
        private IMoveHandler _moveEventsHandler;



        private Rigidbody _charRB;



        private void Awake()
        {
            _moveEventsHandler = GetComponent<IMoveHandler>();

            _charRB = GetComponent<Rigidbody>();


        }

       

        private void Move(Vector3 direction, float speed)
        {
            Vector3 newVelocity = new Vector3(speed * direction.x, _charRB.velocity.y, speed * direction.z);
            _charRB.velocity = newVelocity;

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


        private void Jump(float jumpForce)
        {
            Vector3 jumpDir = new Vector3(0, jumpForce, 0);
            _charRB.AddForce(jumpDir, ForceMode.Impulse);
        }

        private void OnEnable()
        {
            _moveEventsHandler.OnMoveEvent += Move;
            _moveEventsHandler.OnRotationEvent += Rotate;
            _moveEventsHandler.OnJumpEvent += Jump;
        }
        private void OnDisable()
        {
            _moveEventsHandler.OnMoveEvent -= Move;
            _moveEventsHandler.OnRotationEvent -= Rotate;
            _moveEventsHandler.OnJumpEvent -= Jump;
        }
    }
}
