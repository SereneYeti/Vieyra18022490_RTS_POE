using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class FactoryBuilding : Building
    {
        public float Health
        {
            get { return base.health; }
            set { base.health = value; }
        }
        public float MaxHealth
        {
            get { return base.maxHealth; }
        }
        public float Faction
        {
            get { return base.faction; }
        }
        public string Name
        {
            get { return base.name; }
            set { base.name = value; }
        }
        public bool Destroyed
        {
            get { return base.destroyed; }
            set { base.destroyed = value; }
        }
        public GameObject GameUnit
        {
            get { return base.gameUnit; }
            set { base.gameUnit = value; }
        }

        public float meleeCost { get; set; } = 10f;
        public float rangedCost { get; set; } = 10f;
        public float wizardCost { get; set; } = 20f;
        public float resourcesRemaining;
        System.Random r = new System.Random();
        
        public FactoryBuilding(GameObject _gameUnit, string _name, float _health, float _faction, float _resourcesRemaining)
        {
            GameUnit = _gameUnit;
            Name = _name;
            Health = _health;
            base.maxHealth = _health;
            base.faction = _faction;
            Destroyed = false;
            resourcesRemaining = _resourcesRemaining;
        }
       
        public void ProduceUnit()
        {
            
            if((r.Next(0, 3) == 0)&&(resourcesRemaining-meleeCost)>=0) //0 Melee
            {
                //code or function for unit generation here
            }
            else if((r.Next(0, 3) == 0) && (resourcesRemaining - rangedCost) >= 0) // 1 Ranged
            {
                //code or function for unit generation here
            }
            else if((r.Next(0, 3) == 0) && (resourcesRemaining - wizardCost) >= 0) // 2 Wizard
            {
                //code or function for unit generation here
            }
        }

        public override void Destruction()
        {
            Destroyed = true;
            Health = 0;
        }

        public override string ToString()
        {
            //Override of the ToString Funciton in order to return the required string output when needed with ease.
            string temp = "";
            temp += "Factory Building: ";
            //temp += Name;
            //temp += "{" + Symbol + "}";
            temp += "(" + GameUnit.transform.position.x + "," + GameUnit.transform.position.y + "," + GameUnit.transform.position.z + ")";
            temp += Health;
            temp += (Destroyed ? ", (DESTROYED!)\n" : ", (WORKING!)\n");
            return temp;
        }
    }
}
