namespace Interfaces
{
    public interface IWeapon
    {
        void LoadWeapon(int amountOfAmmunition);
        int GetRemainingAmmo();
        void ArmWeapon();
        void DisarmWeapon();
        void FireWeapon();
        int GetWeaponId();
    }
}