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

        System.Random rnd = new System.Random();
        Vector3 Position;
        public float meleeCost { get; set; } = 10f;
        public float rangedCost { get; set; } = 10f;
        public float wizardCost { get; set; } = 20f;


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
            Display();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void GenerateBuildings(int rB, int fB)
        {
            for(int i = 0; i < rB; i++) //Resource Buildings
            {
                Position.x = rnd.Next(0, 20);
                Position.z = rnd.Next(0, 20);
                resourceBuilding1.transform.position = Position;
                ResourceBuilding rb1 = new ResourceBuilding(resourceBuilding1,"resourceBuilding1_"+Convert.ToString(i),100,0,10,100); //Faction 0               
                //resourceBuilding1.transform.Translate(Position);
                buildings.Add(rb1);
                Position.x = rnd.Next(0, 20);
                Position.z = rnd.Next(0, 20);
                resourceBuilding2.transform.position = Position;
                ResourceBuilding rb2 = new ResourceBuilding(resourceBuilding2, "resourceBuilding2_" + Convert.ToString(i), 100, 1, 10, 1000); //Faction 1
                //Position.x = rnd.Next(0, 5);
                //Position.z = rnd.Next(0, 5);
                //resourceBuilding2.transform.Translate(Position);
                buildings.Add(rb2);
            }
            for(int j = 0; j < fB; j++) //Factory Building
            {
                {
                    Position.x = rnd.Next(0, 20);
                    Position.z = rnd.Next(0, 20);
                    factoryBuilding1.transform.position = Position;
                }
                FactoryBuilding fb1 = new FactoryBuilding(factoryBuilding1,"FactoryBuilding1_" + Convert.ToString(j),100,0); //Faction 0

                {
                    Position.x = rnd.Next(0, 20);
                    Position.z = rnd.Next(0, 20);
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
                ResourceBuilding rb = (ResourceBuilding)b;
                if(((((rb.GenerateResources()-meleeCost)>=0)||(rb.GenerateResources() - rangedCost) >= 0)||(rb.GenerateResources() - wizardCost) >= 0)&&(rnd.Next(0,3)==0)) //Melee
                {
                    if(rb.Faction == 0)
                    {
                        foreach(Building b1 in buildings)
                        {
                            if(b1 is FactoryBuilding)
                            {
                                FactoryBuilding fb = (FactoryBuilding)b1;
                                if(fb.Faction ==0)
                                {
                                    pos = fb.GameUnit.transform.position;
                                    pos.x++;
                                    pos.z++;
                                    Melee1.transform.position = pos;
                                    MeleeUnit mu = new MeleeUnit("MeleeUnit1_", 30, 10, 1, 1, 0, Melee1,fb);
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
                                    pos.x++;
                                    pos.z++;
                                    Melee2.transform.position = pos;
                                    MeleeUnit mu = new MeleeUnit("MeleeUnit2_", 30, 10, 1, 1, 1, Melee2, fb);
                                    mu.Name += mu.count;
                                    units.Add(mu);
                                }
                            }
                        }                        
                    }                    
                        
                    
                }
                else if (((((rb.GenerateResources() - meleeCost) >= 0) || (rb.GenerateResources() - rangedCost) >= 0) || (rb.GenerateResources() - wizardCost) >= 0) && (rnd.Next(0, 3) == 1)) //Ranged
                {
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
                                    pos.x++;
                                    pos.z++;
                                    Ranged1.transform.position = pos;
                                    RangedUnit ru = new RangedUnit(Ranged1, "RangedUnit1_", 20, 15, 5, 1, 0,fb);
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
                                    pos.x++;
                                    pos.z++;
                                    Ranged2.transform.position = pos;
                                    RangedUnit ru = new RangedUnit(Ranged2, "RangedUnit2_", 20, 15, 5, 1, 1, fb);
                                    ru.Name += ru.count;
                                    units.Add(ru);
                                }
                            }
                        }                        
                    }
                }
                else if (((((rb.GenerateResources() - meleeCost) >= 0) || (rb.GenerateResources() - rangedCost) >= 0) || (rb.GenerateResources() - wizardCost) >= 0) && (rnd.Next(0, 3) == 2))
                {
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
                                    pos.x++;
                                    pos.z++;
                                    Wizard1.transform.position = pos;
                                    WizardUnit wu = new WizardUnit(Wizard1, "WizardUnit1_", 20, 10, 5, 1, 0,fb);
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
                                    pos.x++;
                                    pos.z++;
                                    Wizard2.transform.position = pos;
                                    WizardUnit wu = new WizardUnit(Wizard2, "WizardUnit2_", 20, 10, 5, 1, 1,fb);
                                    wu.Name += wu.count;
                                    units.Add(wu);
                                }
                            }
                        }                        
                    }                    
                }
            }
        }

        private void Display()
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

            foreach(Unit u in units)
            {
                if(u is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)u;
                    Instantiate(mu.GameUnit,mu.GameUnit.transform.position,Quaternion.identity);
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
