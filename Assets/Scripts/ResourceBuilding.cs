using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    //public enum ResourceType
    //{
    //    Iron,
    //    Grain,
    //    Water
    //}
    class ResourceBuilding : Building
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
        public float resourcesPerRound { get; set; }
        public float resourcesRemaining { get; set; }
        public float resourcesGenerated { get; set; }
        private string resourceInfo;
        public ResourceBuilding(GameObject _gameUnit, string _name, float _health, float _faction, float _resourcesPerRound, float _resourcesRemaing)
        {
            GameUnit = _gameUnit;
            Name = _name;
            Health = _health;
            base.maxHealth = _health;
            base.faction = _faction;
            Destroyed = false;
            resourcesPerRound = _resourcesPerRound;
            resourcesRemaining = _resourcesRemaing;
            resourcesGenerated = 0;
        }  
        public (float rR, float rG) GenerateResources()
        {
            if(((resourcesRemaining - resourcesPerRound)>=0f)&&(Destroyed == false))
            {
                resourcesGenerated += resourcesPerRound;
                resourcesRemaining -= resourcesPerRound;
            }
            resourceInfo = "Resources Remaining: " + resourcesPerRound + "\nResources per round: " + resourcesGenerated
                + "\nResources Generated: " + resourcesRemaining;
            return (resourcesRemaining, resourcesGenerated);
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
            temp += "Resource Building: ";
            //temp += Name;
            //temp += "{" + Symbol + "}";
            temp += "(" + GameUnit.transform.position.x + "," + GameUnit.transform.position.y + "," + GameUnit.transform.position.z + ")";
            temp += Health;
            temp += (Destroyed ? ", (DESTROYED!)\n" : ", (WORKING!)\n");
            temp += resourceInfo;
            return temp;
        }
    }
}
