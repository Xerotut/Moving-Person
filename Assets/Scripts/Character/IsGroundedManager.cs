using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class IsGroundedManager : MonoBehaviour
    {
        [SerializeField] private Collider _groundCheck;

        [SerializeField] private LayerMask _whatIsGround;

        private IGroundedHandler _isGroundedHandler;

        private void Awake()
        {
            _isGroundedHandler = GetComponent<IGroundedHandler>();
        }

        private void FixedUpdate()
        {
            Collider[] overlappingColliders = Physics.OverlapBox(_groundCheck.bounds.center, _groundCheck.bounds.extents / 2, Quaternion.identity, _whatIsGround);

            if (overlappingColliders.Length > 0)
            {
                _isGroundedHandler.RaiseOnGroundedCheck(true);
                return;
            }
            _isGroundedHandler.RaiseOnGroundedCheck(false);
        }
    }
}
