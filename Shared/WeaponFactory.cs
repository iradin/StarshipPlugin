using Autofac;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class WeaponFactory : IWeaponFactory
    {
        protected static int weaponId;
        protected readonly ILifetimeScope _scope;
        public WeaponFactory(ILifetimeScope scope)
        {
            weaponId = 0;
            _scope = scope;
        }
        public virtual IWeapon Create()
        {
            var newWeaponId = weaponId;
            weaponId++;
            return _scope.Resolve<IWeapon>(new NamedParameter("weaponId", newWeaponId));
        }
    }
}
