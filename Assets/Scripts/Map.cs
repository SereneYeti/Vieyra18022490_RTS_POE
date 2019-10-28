using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class Map : MonoBehaviour
    {
        List<Unit> units = new List<Unit>();
        List<Building> buildings = new List<Building>();

        public GameObject Melee1;
        public GameObject Ranged1;
        public GameObject Wizard1;
        public GameObject resourceBuilding1;
        public GameObject factoryBuilding1;
        public GameObject Melee2;
        public GameObject Ranged2;
        public GameObject Wizard2;
        public GameObject resourceBuilding2;
        public GameObject factoryBuilding2;
        public GameObject Wizard3;
        public GameObject Barrier;

        public static System.Random rnd = new System.Random();
        Vector3 Position;
        public float meleeCost { get; set; } = 10f;
        public float rangedCost { get; set; } = 10f;
        public float wizardCost { get; set; } = 20f;
        public float resourcesGenerated { get; set; } = 0f;


        //public Map(int _numBuildings, int _numUnits, GameObject _Melee, GameObject _Ranged, GameObject _Wizard, GameObject _ResourceBuilding, GameObject _FactoryBuilding)
        //{
        //    numBuildings = _numBuildings;
        //    numUnits = _numUnits;
        //    Melee = _Melee;
        //    Ranged = _Ranged;
        //    Wizard = _Wizard;
        //    resourceBuilding = _ResourceBuilding;
        //    FactoryBuilding = _FactoryBuilding;
        //    Position.y = 1;
        //}

        // Start is called before the first frame update
        void Start()
        {
            Position.y = 1;
            GenerateBuildings(2, 1);
            DisplayBuildings();
        }

        // Update is called once per frame
        void Update()
        {
            foreach(Building b in buildings)
            {
                if(b is ResourceBuilding)
                {
                    ResourceBuilding rb = (ResourceBuilding)b;
                    resourcesGenerated = rb.GenerateResources();
                }
            }
            GenerateUnits();            
            Display();
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i] is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)units[i];
                    if (mu.Health <= mu.MaxHealth * 0.25) // Running Away
                    {
                        mu.Move(Position,rnd.Next(0, 4));
                    }
                    else
                    {
                        (Unit closest, float distanceTo) = mu.Closest(units);

                        //Check In Range
                        if (distanceTo <= mu.AttackRange)
                        {
                            mu.IsAttacking = true;
                            mu.Combat(closest);
                        }
                        else //Move Towards
                        {
                            if (closest is MeleeUnit)
                            {
                                MeleeUnit closestMu = (MeleeUnit)closest;
                                if (mu.GameUnit.transform.position.x > closestMu.GameUnit.transform.position.x) //North
                                {
                                    mu.Move(Position,0);
                                }
                                else if (mu.GameUnit.transform.position.x < closestMu.GameUnit.transform.position.x) //South
                                {
                                    mu.Move(Position, 2);
                                }
                                else if (mu.GameUnit.transform.position.z > closestMu.GameUnit.transform.position.z) //West
                                {
                                    mu.Move(Position, 3);
                                }
                                else if (mu.GameUnit.transform.position.z < closestMu.GameUnit.transform.position.z) //East
                                {
                                    mu.Move(Position, 1);
                                }
                            }
                            else if (closest is RangedUnit)
                            {
                                RangedUnit closestRu = (RangedUnit)closest;
                                if (mu.GameUnit.transform.position.x > closestRu.GameUnit.transform.position.x) //North
                                {
                                    mu.Move(Position, 0);
                                }
                                else if (mu.GameUnit.transform.position.x < closestRu.GameUnit.transform.position.x) //South
                                {
                                    mu.Move(Position, 2);
                                }
                                else if (mu.GameUnit.transform.position.z > closestRu.GameUnit.transform.position.z) //West
                                {
                                    mu.Move(Position, 3);
                                }
                                else if (mu.GameUnit.transform.position.z < closestRu.GameUnit.transform.position.z) //East
                                {
                                    mu.Move(Position, 1);
                                }
                            }
                            else if (closest is WizardUnit)
                            {
                                WizardUnit closestWu = (WizardUnit)closest;
                                if (mu.GameUnit.transform.position.x > closestWu.GameUnit.transform.position.x) //North
                                {
                                    mu.Move(Position, 0);
                                }
                                else if (mu.GameUnit.transform.position.x < closestWu.GameUnit.transform.position.x) //South
                                {
                                    mu.Move(Position, 2);
                                }
                                else if (mu.GameUnit.transform.position.z > closestWu.GameUnit.transform.position.z) //West
                                {
                                    mu.Move(Position, 3);
                                }
                                else if (mu.GameUnit.transform.position.z < closestWu.GameUnit.transform.position.z) //East
                                {
                                    mu.Move(Position, 1);
                                }
                            }
                        }

                    }
                }
                else if (units[i] is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)units[i];
                    /* if (ru.Health <= ru.MaxHealth * 0.25) // Running Away is commented out to make for a more interesting battle - and some insta-deaths
                     {
                         ru.Move(r.Next(0, 4));
                     }
                     else
                     {*/
                    (Unit closest, float distanceTo) = ru.Closest(units);

                    //Check In Range
                    if (distanceTo <= ru.AttackRange)
                    {
                        ru.IsAttacking = true;
                        ru.Combat(closest);
                    }
                    else //Move Towards
                    {
                        if (closest is MeleeUnit)
                        {
                            MeleeUnit closestMu = (MeleeUnit)closest;
                            if (ru.GameUnit.transform.position.x > closestMu.GameUnit.transform.position.x) //North
                            {
                                ru.Move(Position, 0);
                            }
                            else if (ru.GameUnit.transform.position.x < closestMu.GameUnit.transform.position.x) //South
                            {
                                ru.Move(Position, 2);
                            }
                            else if (ru.GameUnit.transform.position.z > closestMu.GameUnit.transform.position.z) //West
                            {
                                ru.Move(Position, 3);
                            }
                            else if (ru.GameUnit.transform.position.z < closestMu.GameUnit.transform.position.z) //East
                            {
                                ru.Move(Position, 1);
                            }
                        }
                        else if (closest is RangedUnit)
                        {
                            RangedUnit closestRu = (RangedUnit)closest;
                            if (ru.GameUnit.transform.position.x > closestRu.GameUnit.transform.position.x) //North
                            {
                                ru.Move(Position, 0);
                            }
                            else if (ru.GameUnit.transform.position.x < closestRu.GameUnit.transform.position.x) //South
                            {
                                ru.Move(Position, 2);
                            }
                            else if (ru.GameUnit.transform.position.z > closestRu.GameUnit.transform.position.z) //West
                            {
                                ru.Move(Position, 3);
                            }
                            else if (ru.GameUnit.transform.position.z < closestRu.GameUnit.transform.position.z) //East
                            {
                                ru.Move(Position, 1);
                            }
                        }
                        else if (closest is WizardUnit)
                        {
                            WizardUnit closestWu = (WizardUnit)closest;
                            if (ru.GameUnit.transform.position.x > closestWu.GameUnit.transform.position.x) //North
                            {
                                ru.Move(Position, 0);
                            }
                            else if (ru.GameUnit.transform.position.x < closestWu.GameUnit.transform.position.x) //South
                            {
                                ru.Move(Position, 2);
                            }
                            else if (ru.GameUnit.transform.position.z > closestWu.GameUnit.transform.position.z) //West
                            {
                                ru.Move(Position, 3);
                            }
                            else if (ru.GameUnit.transform.position.z < closestWu.GameUnit.transform.position.z) //East
                            {
                                ru.Move(Position, 1);
                            }
                        }

                    }

                    //  }

                }
                else if (units[i] is WizardUnit)
                {
                    WizardUnit wu = (WizardUnit)units[i];
                    if (wu.Health <= wu.MaxHealth * 0.5) // Running Away
                    {
                        wu.Move(Position, rnd.Next(0, 4));
                    }
                    else
                    {
                        (Unit closest, float distanceTo) = wu.Closest(units);

                        //Check In Range
                        if (distanceTo <= wu.AttackRange)
                        {
                            wu.IsAttacking = true;
                            wu.Combat(closest);
                        }
                        else //Move Towards
                        {
                            if (closest is MeleeUnit)
                            {
                                MeleeUnit closestMu = (MeleeUnit)closest;
                                if (wu.GameUnit.transform.position.x > closestMu.GameUnit.transform.position.x) //North
                                {
                                    wu.Move(Position, 0);
                                }
                                else if (wu.GameUnit.transform.position.x < closestMu.GameUnit.transform.position.x) //South
                                {
                                    wu.Move(Position,2);
                                }
                                else if (wu.GameUnit.transform.position.z > closestMu.GameUnit.transform.position.z) //West
                                {
                                    wu.Move(Position, 3);
                                }
                                else if (wu.GameUnit.transform.position.z < closestMu.GameUnit.transform.position.z) //East
                                {
                                    wu.Move(Position, 1);
                                }
                            }
                            else if (closest is RangedUnit)
                            {
                                RangedUnit closestRu = (RangedUnit)closest;
                                if (wu.GameUnit.transform.position.x > closestRu.GameUnit.transform.position.x) //North
                                {
                                    wu.Move(Position, 0);
                                }
                                else if (wu.GameUnit.transform.position.x < closestRu.GameUnit.transform.position.x) //South
                                {
                                    wu.Move(Position, 2);
                                }
                                else if (wu.GameUnit.transform.position.z > closestRu.GameUnit.transform.position.z) //West
                                {
                                    wu.Move(Position, 3);
                                }
                                else if (wu.GameUnit.transform.position.z < closestRu.GameUnit.transform.position.z) //East
                                {
                                    wu.Move(Position, 1);
                                }
                            }
                            else if (closest is WizardUnit)
                            {
                                WizardUnit closestWu = (WizardUnit)closest;
                                if (wu.GameUnit.transform.position.x > closestWu.GameUnit.transform.position.x) //North
                                {
                                    wu.Move(Position, 0);
                                }
                                else if (wu.GameUnit.transform.position.x < closestWu.GameUnit.transform.position.x) //South
                                {
                                    wu.Move(Position, 2);
                                }
                                else if (wu.GameUnit.transform.position.z > closestWu.GameUnit.transform.position.z) //West
                                {
                                    wu.Move(Position, 3);
                                }
                                else if (wu.GameUnit.transform.position.z < closestWu.GameUnit.transform.position.z) //East
                                {
                                    wu.Move(Position, 1);
                                }
                            }
                        }

                    }
                }

            }
        }

        public void GenerateBuildings(int rB, int fB)
        {
            for(int i = 0; i < rB; i++) //Resource Buildings
            {
                {
                    if(Position.x == rnd.Next(1, 30) || (Position.z == rnd.Next(1, 30)))
                    {
                        Position.x = rnd.Next(1, 30);
                        Position.z = rnd.Next(1, 30);
                        resourceBuilding1.transform.position = Position;
                    }
                    else
                    {
                        Position.x = rnd.Next(1, 30);
                        Position.z = rnd.Next(1, 30);
                        resourceBuilding1.transform.position = Position;
                    }
                    
                }               
                ResourceBuilding rb1 = new ResourceBuilding(resourceBuilding1,"resourceBuilding1_"+Convert.ToString(i),100,0,10,100); //Faction 0               
                //resourceBuilding1.transform.Translate(Position);
                buildings.Add(rb1);

                if (Position.x == rnd.Next(1, 30) || (Position.z == rnd.Next(1, 30)))
                {
                    Position.x = rnd.Next(1, 30);
                    Position.z = rnd.Next(1, 30);
                    resourceBuilding2.transform.position = Position;
                }
                else
                {
                    Position.x = rnd.Next(1, 30);
                    Position.z = rnd.Next(1, 30);
                    resourceBuilding2.transform.position = Position;
                }
                ResourceBuilding rb2 = new ResourceBuilding(resourceBuilding2, "resourceBuilding2_" + Convert.ToString(i), 100, 1, 10, 1000); //Faction 1
                //Position.x = rnd.Next(0, 5);
                //Position.z = rnd.Next(0, 5);
                //resourceBuilding2.transform.Translate(Position);
                buildings.Add(rb2);
            }
            for(int j = 0; j < fB; j++) //Factory Building
            {
                {
                    Position.x = rnd.Next(1, 30);
                    Position.z = rnd.Next(1, 30);
                    factoryBuilding1.transform.position = Position;
                }
                FactoryBuilding fb1 = new FactoryBuilding(factoryBuilding1,"FactoryBuilding1_" + Convert.ToString(j),100,0); //Faction 0

                {
                    Position.x = rnd.Next(1, 30);
                    Position.z = rnd.Next(1, 30);
                    factoryBuilding2.transform.position = Position;
                }
                buildings.Add(fb1);
                FactoryBuilding fb2 = new FactoryBuilding(factoryBuilding2, "FactoryBuilding1_" + Convert.ToString(j), 100, 1); //Faction 1
                
                buildings.Add(fb2);
            }

        }

        public void GenerateUnits()
        {
            Vector3 pos = new Vector3();
            foreach(Building b in buildings)
            {
                if(((((resourcesGenerated - meleeCost)>=0)||(resourcesGenerated - rangedCost) >= 0)||(resourcesGenerated - wizardCost) >= 0)&&(rnd.Next(0,3)==0)) //Melee
                {
                    ResourceBuilding rb = (ResourceBuilding)b;
                    if (rb.Faction == 0)
                    {
                        foreach(Building b1 in buildings)
                        {
                            if(b1 is FactoryBuilding)
                            {
                                FactoryBuilding fb = (FactoryBuilding)b1;
                                if(fb.Faction ==0)
                                {
                                    pos = fb.GameUnit.transform.position;
                                    pos.x += rnd.Next(1, 30);
                                    pos.z += rnd.Next(1, 30);
                                    Melee1.transform.position = pos;
                                    MeleeUnit mu = new MeleeUnit("MeleeUnit1_", 30, 10, 1, 1, 0, Melee1);
                                    mu.Name += mu.count;
                                    units.Add(mu);
                                }
                            }
                        }
                       
                    }
                    else if (rb.Faction == 1)
                    {
                        foreach (Building b1 in buildings)
                        {
                            if (b1 is FactoryBuilding)
                            {
                                FactoryBuilding fb = (FactoryBuilding)b1;
                                if (fb.Faction == 0)
                                {
                                    pos = fb.GameUnit.transform.position;
                                    pos.x += rnd.Next(1, 30);
                                    pos.z += rnd.Next(1, 30);
                                    Melee2.transform.position = pos;
                                    MeleeUnit mu = new MeleeUnit("MeleeUnit2_", 30, 10, 1, 1, 1, Melee2);
                                    mu.Name += mu.count;
                                    units.Add(mu);
                                }
                            }
                        }                        
                    }                    
                        
                    
                }
                else if (((((resourcesGenerated - meleeCost) >= 0) || (resourcesGenerated - rangedCost) >= 0) || (resourcesGenerated - wizardCost) >= 0) && (rnd.Next(0, 3) == 1)) //Ranged
                {
                    ResourceBuilding rb = (ResourceBuilding)b;
                    if (rb.Faction == 0)
                    {
                        foreach (Building b1 in buildings)
                        {
                            if (b1 is FactoryBuilding)
                            {
                                FactoryBuilding fb = (FactoryBuilding)b1;
                                if (fb.Faction == 0)
                                {
                                    pos = fb.GameUnit.transform.position;
                                    pos.x += rnd.Next(1, 30);
                                    pos.z += rnd.Next(1, 30);
                                    Ranged1.transform.position = pos;
                                    RangedUnit ru = new RangedUnit(Ranged1, "RangedUnit1_", 20, 15, 5, 1, 0);
                                    ru.Name += ru.count;
                                    units.Add(ru);
                                }
                            }
                        }
                        
                    }
                    else if (rb.Faction == 1)
                    {
                        foreach (Building b1 in buildings)
                        {
                            if (b1 is FactoryBuilding)
                            {
                                FactoryBuilding fb = (FactoryBuilding)b1;
                                if (fb.Faction == 0)
                                {
                                    pos = fb.GameUnit.transform.position;
                                    pos.x += rnd.Next(1, 30);
                                    pos.z += rnd.Next(1, 30);
                                    Ranged2.transform.position = pos;
                                    RangedUnit ru = new RangedUnit(Ranged2, "RangedUnit2_", 20, 15, 5, 1, 1);
                                    ru.Name += ru.count;
                                    units.Add(ru);
                                }
                            }
                        }                        
                    }
                }
                else if (((((resourcesGenerated - meleeCost) >= 0) || (resourcesGenerated - rangedCost) >= 0) || (resourcesGenerated - wizardCost) >= 0) && (rnd.Next(0, 3) == 2))
                {
                    ResourceBuilding rb = (ResourceBuilding)b;
                    if (rb.Faction == 0)
                    {
                        foreach (Building b1 in buildings)
                        {
                            if (b1 is FactoryBuilding)
                            {
                                FactoryBuilding fb = (FactoryBuilding)b1;
                                if (fb.Faction == 0)
                                {
                                    pos = fb.GameUnit.transform.position;
                                    pos.x += rnd.Next(1, 30);
                                    pos.z += rnd.Next(1, 30);
                                    Wizard1.transform.position = pos;
                                    WizardUnit wu = new WizardUnit(Wizard1, "WizardUnit1_", 20, 10, 5, 1, 0);
                                    wu.Name += wu.count;
                                    units.Add(wu);
                                }
                            }
                        }                        
                    }
                    else if (rb.Faction == 1)
                    {
                        foreach (Building b1 in buildings)
                        {
                            if (b1 is FactoryBuilding)
                            {                                
                                FactoryBuilding fb = (FactoryBuilding)b1;
                                if (fb.Faction == 0)
                                {
                                    pos = fb.GameUnit.transform.position;
                                    pos.x += rnd.Next(1, 30);
                                    pos.z += rnd.Next(1, 30);
                                    Wizard2.transform.position = pos;
                                    WizardUnit wu = new WizardUnit(Wizard2, "WizardUnit2_", 20, 10, 5, 1, 1);
                                    wu.Name += wu.count;
                                    units.Add(wu);
                                }
                            }
                        }                        
                    }                    
                }
            }
        }

        private void DisplayBuildings()
        {
            foreach (Building b in buildings)
            {
                if (b is ResourceBuilding)
                {
                    ResourceBuilding rb = (ResourceBuilding)b;
                    Instantiate(rb.GameUnit, rb.GameUnit.transform.position, Quaternion.identity);
                }
                else if (b is FactoryBuilding)
                {
                    FactoryBuilding fb = (FactoryBuilding)b;
                    Instantiate(fb.GameUnit, fb.GameUnit.transform.position, Quaternion.identity);
                }
            }

            //Instantiating the outer barrier
            Vector3 temp = new Vector3(0f, 1f, 0f);
            for(int i =0; i <= 60; i++)
            {
                {//For the negative positions needed
                    temp.x = i;
                    Instantiate(Barrier, temp, Quaternion.identity);
                }              
            }
            for (int j = 0; j <= 60; j++)
            {
                {//For the negative positions needed
                    temp.z = j;
                    Instantiate(Barrier, temp, Quaternion.identity);
                }
            }
            for (int k = 60; k >= 0; k--)
            {
                {//For the negative positions needed
                    temp.x = k;
                    Instantiate(Barrier, temp, Quaternion.identity);
                }
            }
            for (int l = 60; l >= 0; l--)
            {
                {//For the negative positions needed
                    temp.z = l;
                    Instantiate(Barrier, temp, Quaternion.identity);
                }
            }
        }
        private void Display()
        {
            foreach (Unit u in units)
            {
                if (u is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)u;
                    Instantiate(mu.GameUnit, mu.GameUnit.transform.position, Quaternion.identity);
                }
                else if (u is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)u;
                    Instantiate(ru.GameUnit, ru.GameUnit.transform.position, Quaternion.identity);
                }
                else if (u is WizardUnit)
                {
                    WizardUnit wu = (WizardUnit)u;
                    Instantiate(wu.GameUnit, wu.GameUnit.transform.position, Quaternion.identity);
                }
            }
        }
    }
}
