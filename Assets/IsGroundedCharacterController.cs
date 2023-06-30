using UnityEngine;

namespace MovingPerson
{
    [RequireComponent(typeof(CharacterController))]
    public class IsGroundedCharacterController : MonoBehaviour
    {
        private IGroundedHandler _isGroundedHandler;

        private CharacterController _characterController;

        private void Awake()
        {
            _isGroundedHandler = GetComponent<IGroundedHandler>();
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            _isGroundedHandler.RaiseOnGroundedCheck(_characterController.isGrounded);
            // Debug.Log(_characterController.isGrounded);
        }

    }
}
