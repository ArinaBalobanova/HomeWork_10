﻿using System.Collections;

namespace libr2
{
    class Building
    {
        private static int lastnumberOfBuilding = 0; // Последний использованный номер здания
        private int numberOfBuilding;
        private double height;
        private int floors;
        private int apartments;
        private int entrances;

        internal Building(double height, int floors, int apartments, int entrances)
        {
            this.numberOfBuilding = GenerateNumberOfBuilding();
            this.height = height;
            this.floors = floors;
            this.apartments = apartments;
            this.entrances = entrances;
        }
        private static int GenerateNumberOfBuilding()
        {
            return ++lastnumberOfBuilding;
        }
        public double FloorHeight()
        {
            return height / floors;
        }
        public int ApartmentsPerEntrance()
        {
            return apartments / entrances;
        }
        public int ApartmentsPerFloor()
        {
            return apartments / floors;
        }
        public int GetBuildingId()
        {
            return numberOfBuilding;
        }
        public double GetHeight()
        {
            return height;
        }
        public int GetFloors()
        {
            return floors;
        }
        public int GetApartments()
        {
            return apartments;
        }
        public int GetEntrances()
        {
            return entrances;
        }

        public void PrintBuildingInfo()
        {
            Console.WriteLine($"Уникальный номер здания: {numberOfBuilding}");
            Console.WriteLine($"Высота здания: {height}");
            Console.WriteLine($"Этажность: {floors}");
            Console.WriteLine($"Количество квартир: {apartments}");
            Console.WriteLine($"Количество подъездов: {entrances}");
        }
    }
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
