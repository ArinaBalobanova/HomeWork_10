using System;
using System.Collections;

namespace Лабораторная_11.Classes
{
    internal class Creator
    {
        private static Hashtable buildings = new Hashtable();
        static Creator() { }
        public static Building CreateBuild(double height, int floors, int apartments, int entrances)
        {
            Building newBuilding = new Building(height, floors, apartments, entrances);
            buildings[newBuilding.GetBuildingId()] = newBuilding;
            return newBuilding;
        }
        public static bool RemoveBuilding(int buildingId)
        {
            if (buildings.ContainsKey(buildingId))
            {
                buildings.Remove(buildingId);
                return true;
            }
            return false;
        }
        public static void PrintBuildings()
        {
            foreach (DictionaryEntry entry in buildings)
            {
                ((Building)entry.Value).PrintBuildingInfo();
                Console.WriteLine();
            }
        }
    }
}
