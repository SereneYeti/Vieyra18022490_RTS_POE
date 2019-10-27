using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Unit 
    {
        //Abstract class with no code implemented 
        //Used for the sake of re-use and inheritance        
        protected Vector3 position;
        protected float health;
        protected float maxHealth;
        protected float speed;
        protected float attack;
        protected float attackRange;
        protected float faction;
        //protected string symbol;
        protected string name;
        protected bool isAttacking;
        protected bool isDead;
        //Used to keep track of the Game Object
        protected GameObject gameUnit;
        
        
        public abstract void Move(Vector3 _position,int dir);
        public abstract void Combat(Unit attacker);
        public abstract bool InRange(Unit other);
        public abstract (Unit, float) Closest(List<Unit> units);
        public abstract void Death();
        public abstract override string ToString();

    }
}
