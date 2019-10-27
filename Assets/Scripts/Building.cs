using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Building
    {
        //Used for the sake of re-use and inheritance
        //protected Vector3 position;
        protected float health;
        protected float maxHealth;
        protected float faction;
        //protected string symbol;
        protected string name;
        protected bool destroyed;
        //Used to keep track of the Game Object
        protected GameObject gameUnit;
        public abstract void Destruction();
        public abstract override string ToString();

    }
}
