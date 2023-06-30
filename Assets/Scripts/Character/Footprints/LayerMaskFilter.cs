using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    [CreateAssetMenu(fileName ="Layer Mask Filter", menuName = "Moving Person/Layer Mask Filter")]
    public class LayerMaskFilter : ScriptableObject
    {
        [field: SerializeField] public LayerMask Mask { get;private set; }
    }
}
