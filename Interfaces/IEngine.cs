namespace Interfaces
{
    public interface IEngine
    {
        int GetMaxSpeed();
        bool IsWarpDriveEnabled();
        void SetSpeed(int speed);
        void SpoolWarpDrive();
        int Warp();
    }
}