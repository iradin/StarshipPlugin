using Autofac;
using Interfaces;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace XWing
{
    public class KX9LaserCannonFactory : WeaponFactory
    {
        public KX9LaserCannonFactory(ILifetimeScope scope) : base(scope)
        {

        }

        public override IWeapon Create()
        {
            var newWeaponId = weaponId;
            weaponId++;
            return _scope.Resolve<KX9LaserCannon>(new NamedParameter("weaponId", newWeaponId));
        }
    }
}
