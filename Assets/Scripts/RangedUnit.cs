//Note to check the override of the ToString function again, not sure of the formating.(Small thing)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class RangedUnit : Unit
    {
        public string Name
        {
            get { return base.name; }
            set { base.name = value; }
        }
        public Vector3 Movement
        {
            get { return base.movement; }
            set { base.movement = value; }
        }
        
        public int Health
        {
            get { return base.health; }
            set { base.health = value; }
        }
        public int MaxHealth
        {
            get { return base.maxHealth; }
        }
        public int Attack
        {
            get { return base.attack; }
            set { base.attack = value; }
        }

        public int AttackRange
        {
            get { return base.attackRange; }
            set { base.attackRange = value; }
        }
        public int Speed
        {
            get { return base.speed; }
            set { base.speed = value; }
        }
        public int Faction
        {
            get { return base.faction; }
        }
        //public string Symbol
        //{  Not Used at the moment
        //    get { return base.symbol; }
        //    set { base.symbol = value; }
        //}
        public bool IsAttacking
        {
            get { return base.isAttacking; }
            set { base.isAttacking = value; }
        }
        public bool IsDead
        {
            get { return base.isDead; }
            set { base.isDead = value; }
        }
        public RangedUnit(Vector3 _movement, string _name, int _health, int _attack, int _attackRange, int _speed, int _faction)
        {
            Movement = _movement;
            Name = _name;
            Health = _health;
            base.maxHealth = _health;
            Attack = _attack;
            AttackRange = _attackRange;
            Speed = _speed;
            base.faction = _faction;
            IsAttacking = false;
            IsDead = false;

        }
        public override (Unit, int) Closest(List<Unit> units)
        {
            throw new NotImplementedException();
        }

        public override void Combat(Unit attacker)
        {
            throw new NotImplementedException();
        }

        public override void Death()
        {
            IsDead = true;
            Health = 0;
            IsAttacking = false;
        }

        public override bool InRange(Unit other)
        {
            throw new NotImplementedException();
        }

        public override void Move(Vector3 _movement,int dir)
        {
            //Handles the movement of the units
            //N.B. using the x and z co-ordinates as it is a 3d program and y is vertical up or down not forward or back.
            switch (dir)
            {
                case 0: _movement.z++; break; //North (Swaped)
                case 1: _movement.x++; break; //East
                case 2: _movement.z--; break; //South (Swaped)
                case 3: _movement.x--; break; //West
                default: break;
            }
        }

        public override string ToString()
        {
            //Override of the ToString Funciton in order to return the required string output when needed with ease.
            string temp = "";
            temp += "Ranged: ";
            temp += Name;
            //temp += "{" + Symbol + "}";
            temp += "(" + Movement.x + "," + Movement.y + "," + Movement.z + ")";
            temp += Health + ", " + Attack + ", " + AttackRange + ", " + Speed;
            temp += (IsDead ? " DEAD!" : " ALIVE!");
            return temp;
        }
    }
    
}
