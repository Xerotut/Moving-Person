using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public interface IWeaponHandler
    {
        public event Action<bool> OnAim;

        public void RaiseAimEvent(bool isAiming);
    }
}
