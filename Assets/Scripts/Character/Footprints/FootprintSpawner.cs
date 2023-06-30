using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace MovingPerson
{
    public class FootprintSpawner : MonoBehaviour
    {
        [SerializeField] private FootprintDetector _leftLeg;
        [SerializeField] private FootprintDetector _rightLeg;
        [SerializeField] private GameObject _footprint;
        [SerializeField] private int _maxFootprints;

        GameObject[] _footprintsArray;
        private Vector3 _targetPos;

        private int _footprintIndex =0;

        private void Awake()
        {
            _footprintsArray = new GameObject[_maxFootprints];
            for (int i =0; i<_footprintsArray.Length; i++)
            {
                GameObject footprint = Instantiate(_footprint);
                footprint.SetActive(false);
                _footprintsArray[i] = footprint;
            }

        }

        private void RequestFootprint(Vector3 position)
        {
            _targetPos = position;
            PlaceFootprint(_footprintsArray[_footprintIndex]);
            _footprintIndex++;
            if (_footprintIndex >=_maxFootprints) _footprintIndex = 0;
        }

        private void PlaceFootprint(GameObject footprintInstance)
        {
            footprintInstance.SetActive(true);
            footprintInstance.transform.position = _targetPos;
        }


        

        private void OnEnable()
        {
            _leftLeg.OnRequestFootprint += RequestFootprint;
            _rightLeg.OnRequestFootprint += RequestFootprint;
        }
        private void OnDisable()
        {
            _leftLeg.OnRequestFootprint -= RequestFootprint;
            _rightLeg.OnRequestFootprint -= RequestFootprint;
        }
    }
}
