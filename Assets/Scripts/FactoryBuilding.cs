using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool IsDead
        {
            get { return base.destroyed; }
            set { base.destroyed = value; }
        }
        public GameObject GameUnit
        {
            get { return base.gameUnit; }
            set { base.gameUnit = value; }
        }
        public override void Destruction()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
