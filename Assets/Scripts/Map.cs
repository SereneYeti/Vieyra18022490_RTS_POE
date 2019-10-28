using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class Map
    {
        List<Unit> units = new List<Unit>();
        List<Building> buildings = new List<Building>();
        public GameObject Melee;
        public GameObject Ranged;
        public GameObject Wizard;
        public GameObject ResourceBuilding;
        public GameObject FactoryBuilding;
        System.Random rnd = new System.Random();
        Vector3 Position;
        public int numBuildings; //Used only for resource buildings 2 Factory buildings will always spawn
        public int numUnits;//used for testing is units will spawn in as it is intended to change units to spawn from the buldings with resources automaticals and random
        
        public Map(int _numBuildings, int _numUnits, GameObject _Melee, GameObject _Ranged, GameObject _Wizard, GameObject _ResourceBuilding, GameObject _FactoryBuilding)
        {
            numBuildings = _numBuildings;
            numUnits = _numUnits;
            Melee = _Melee;
            Ranged = _Ranged;
            Wizard = _Wizard;
            ResourceBuilding = _ResourceBuilding;
            FactoryBuilding = _FactoryBuilding;
            Position.y = 1;
        }

        public void GenerateBuildings(int rB_fB)
        {
            for(int i = 0; i < 5; i++) //Resource Buildings
            {
                ResourceBuilding rb1 = new ResourceBuilding(ResourceBuilding,"resourceBuilding1_"+Convert.ToString(i),100,0,10,1000); //Faction 0
                Position.x = rnd.Next(0, 20);
                Position.z = rnd.Next(0, 20);
                ResourceBuilding.transform.Translate(Position);
                buildings.Add(rb1);
                ResourceBuilding rb2 = new ResourceBuilding(ResourceBuilding, "resourceBuilding2_" + Convert.ToString(i), 100, 1, 10, 1000); //Faction 1
                Position.x = rnd.Next(0, 20);
                Position.z = rnd.Next(0, 20);
                ResourceBuilding.transform.Translate(Position);
                buildings.Add(rb2);
            }
            for(int j = 0; j < 2; j++) //Factory Building
            {
                FactoryBuilding fb1 = new FactoryBuilding(FactoryBuilding,"FactoryBuilding1_" + Convert.ToString(j),100,0); //Faction 0
                {
                    Position.x = rnd.Next(0, 20);
                    Position.z = rnd.Next(0, 20);
                    ResourceBuilding.transform.Translate(Position);
                }               
                buildings.Add(fb1);
                FactoryBuilding fb2 = new FactoryBuilding(FactoryBuilding, "FactoryBuilding1_" + Convert.ToString(j), 100, 1); //Faction 1
                {
                    Position.x = rnd.Next(0, 20);
                    Position.z = rnd.Next(0, 20);
                    ResourceBuilding.transform.Translate(Position);
                }
                buildings.Add(fb2);
            }
        }
    }
}
