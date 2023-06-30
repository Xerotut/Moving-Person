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


        private float _gravity;

        private void Awake()
        {
            _moveEventsHandler = GetComponent<IMoveHandler>();
            IStats statsHandler  = GetComponent<IStats>();
            _gravity = statsHandler.GetStats().Gravity;

            _charContoroller = GetComponent<CharacterController>();

          
        }

        private void Update()
        {
        }

        private void Move(Vector3 direction, float speed)
        {
            
            Vector3 moveSpeed = new Vector3(speed * direction.x, direction.y, speed * direction.z);
            if (moveSpeed.y == 0)
            {
                moveSpeed.y = _gravity;
            }

           
            _charContoroller.Move(moveSpeed * Time.deltaTime);
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
