using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class AimStatus : Transition
    {
        public AimStatus(IWeaponHandler weaponHandler)
        {
            weaponHandler.OnAim += isAiming => _isAiming = isAiming;
        }

        protected bool _isAiming;
    }

    public class StartedAiming : AimStatus
    {
        public StartedAiming(IWeaponHandler weaponHandler) : base(weaponHandler) { }

        protected override bool CheckConditionUpdate() => _isAiming;
    }
    public class StopedAiming : AimStatus
    {
        public StopedAiming(IWeaponHandler weaponHandler) : base(weaponHandler) { }

        protected override bool CheckConditionUpdate() => !_isAiming;
    }
}
