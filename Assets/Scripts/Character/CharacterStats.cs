using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    [CreateAssetMenu(fileName = "New Character Stats", menuName = "Moving Person/Character Stats")]
    public class CharacterStats : ScriptableObject
    {

        [field: SerializeField] public float MaxSpeed {get; private set;}
        [field: Range(0f, 1f)][field: SerializeField] public float RotationSpeed {get; private set;}

    }
}