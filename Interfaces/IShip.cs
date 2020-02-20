namespace Interfaces
{
    public interface IShip
    {
        IWeapon[] GetWeapons();
        void FireWeapon(int weaponId);
        void ArmWeapon(int weaponId);
        void DisarmWeapon(int weaponId);
        void LoadWeapon(int weaponId, int ammoAmmount);
        void SetSpeed(int kps);
        double GetSpeed();
        void WarpToLocation(double galacticLongitude, double galacticLatitude);
        void ReadyWarpDrive();
        string GetShipType();
    }
}