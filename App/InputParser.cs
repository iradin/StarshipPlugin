using Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StarshipPlugin
{
    public class InputParser
    {
        private readonly IShip _ship;
        public InputParser(IShip ship)
        {
            _ship = ship;
            PrintHelp();
        }

        public void PrintHelp()
        {
            Console.WriteLine("1: List Weapons");
            Console.WriteLine("2: <weaponId>: Arm weapon <weaponId>");
            Console.WriteLine("3: <weaponId>: Fire weapon <weaponId>");
            Console.WriteLine("4: <weaponId>: Disarm weapon <weaponId>");
            Console.WriteLine("5: <weaponId> <ammoAmmount>: Load weapon <weaponId> with <ammoAmmount>");
            Console.WriteLine("6: Get ship speed");
            Console.WriteLine("7: <speed>: Set ship speed to <speed>");
            Console.WriteLine("8: Ready warp drive");
            Console.WriteLine("9: <longitude> <latitude>: Warp to <longitude> <latitude>");
            Console.WriteLine("10: Display ship type");
            Console.WriteLine("11: Display help");
            Console.WriteLine("0: Exit application");
        }
        public void ParseInput(string[] args)
        {
            if (args.Length <= 0)
                Console.WriteLine("Invalid input");

            switch (args[0])
            {
                case "1":
                    ListWeapons();
                    return;
                case "2":
                    if (args.Length > 1)
                    {
                        ArmWeapon(args[1]);
                        return;
                    }
                    break;
                case "3":
                    if (args.Length > 1)
                    {
                        FireWeapon(args[1]);
                        return;
                    }
                    break;
                case "4":
                    if (args.Length > 1)
                    {
                        DisarmWeapon(args[1]);
                        return;
                    }
                    break;
                case "5":
                    if(args.Length > 2)
                    {
                        LoadWeapon(args[1], args[2]);
                        return;
                    }
                    break;
                case "6":
                    GetSpeed();
                    return;
                case "7":
                    if (args.Length > 1)
                    {
                        SetSpeed(args[1]);
                        return;
                    }
                    break;
                case "8":
                    ReadyWarpDrive();
                    return;
                case "9":
                    if (args.Length > 2)
                    {
                        Warp(args[1], args[2]);
                        return;
                    }
                    break;
                case "10":
                    Console.WriteLine(_ship.GetShipType());
                    return;
                case "11":
                    PrintHelp();
                    return;
                case "0":
                    ExitApplication();
                    return;
            }
            Console.WriteLine("Invalid input");
        }

        public void ExitApplication()
        {
            Environment.Exit(0);
        }

        public void ListWeapons()
        {
            if (_ship.GetWeapons() != null)
            {
                foreach (var weapon in _ship.GetWeapons())
                {
                    Console.WriteLine(weapon.GetType().ToString() + ": " + weapon.GetWeaponId().ToString());
                }
            }
            else Console.WriteLine("No weapons equipped");
        }

        public int ParseInt(string rawValue)
        {
            int weaponId;
            if (!int.TryParse(rawValue, out weaponId))
            {
                return -1;
            }
            return weaponId;
        }

        public void ArmWeapon(string rawWeaponId)
        {
            int weaponId = ParseInt(rawWeaponId);
            if (weaponId == -1)
            {
                Console.WriteLine("Invalid weapon ID");
            }
            else
            {
                _ship.ArmWeapon(weaponId);
            }
        }

        public void FireWeapon(string rawWeaponId)
        {
            int weaponId = ParseInt(rawWeaponId);
            if (weaponId == -1)
            {
                Console.WriteLine("Invalid weapon ID");
            }
            else
            {
                _ship.FireWeapon(weaponId);
            }
        }

        public void DisarmWeapon(string rawWeaponId)
        {
            int weaponId = ParseInt(rawWeaponId);
            if (weaponId == -1)
            {
                Console.WriteLine("Invalid weapon ID");
            }
            else
            {
                _ship.DisarmWeapon(weaponId);
            }
        }

        public void LoadWeapon(string rawWeaponId, string rawAmmoAmmount)
        {
            int weaponId = ParseInt(rawWeaponId);
            int ammoAmmount = ParseInt(rawAmmoAmmount);
            if (weaponId == -1)
                Console.WriteLine("Invalid weapon ID");
            else if (ammoAmmount == -1)
                Console.WriteLine("Invalid ammo ammount");
            else
                _ship.LoadWeapon(weaponId, ammoAmmount);
        }

        public void GetSpeed()
        {
            Console.WriteLine($"Current ship speed is: {_ship.GetSpeed()}");
        }

        public void SetSpeed(string rawSpeed)
        {
            int speed;
            if (!int.TryParse(rawSpeed, out speed))
            {
                Console.WriteLine("Invalid speed value");
            }
            else
            {
                _ship.SetSpeed(speed);
            }
        }

        public void ReadyWarpDrive()
        {
            _ship.ReadyWarpDrive();
        }

        public void Warp(string rawLongitude, string rawLatitude)
        {
            bool isInvalid = false;
            string output = "Invalid ";
            double longitude;
            double latitude;
            if (!double.TryParse(rawLongitude, out longitude))
            {
                output += "longitude ";
                isInvalid = true;
            }
            if (!double.TryParse(rawLatitude, out latitude))
            {
                if (output.Contains("longitude"))
                    output += "and ";
                output += "latitude";
                isInvalid = true;
            }

            if (isInvalid)
            {
                Console.WriteLine(output);
            }
            else
            {
                _ship.WarpToLocation(longitude, latitude);
            }
        }
    }
}
