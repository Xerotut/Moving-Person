using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class FootprintDetector : MonoBehaviour
    {

        public event Action<Vector3> OnRequestFootprint;

        [SerializeField] private LayerMaskFilter _filter;


        private void OnTriggerEnter(Collider other)
        {
            if (LayerMasksUtility.IsTouchingLayer(_filter.Mask, other.gameObject.layer))
            {
                OnRequestFootprint?.Invoke(transform.position);
            }
        }

    }
}
