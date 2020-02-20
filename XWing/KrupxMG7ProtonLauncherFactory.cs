using Autofac;
using Interfaces;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace XWing
{
    public class KrupxMG7ProtonLauncherFactory : WeaponFactory
    {
        public KrupxMG7ProtonLauncherFactory(ILifetimeScope scope) : base(scope)
        {
        }

        public override IWeapon Create()
        {
            var newWeaponId = weaponId;
            weaponId++;
            return _scope.Resolve<KrupxMG7ProtonLauncher>(new NamedParameter("weaponId", newWeaponId));
        }
    }
}
