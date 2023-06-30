
using UnityEngine;

namespace MovingPerson
{
    public static class LayerMasksUtility
    {

        public static bool IsTouchingLayer(LayerMask expectedLayer, int gameObjectLayer)
        {
            return (expectedLayer & 1 << gameObjectLayer) == 1 << gameObjectLayer;
        }

    }
}
