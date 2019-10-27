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
        public Vector3 Position
        {
            get { return base.position; }
            set { base.position = value; }
        }
        
        public float Health
        {
            get { return base.health; }
            set { base.health = value; }
        }
        public float MaxHealth
        {
            get { return base.maxHealth; }
        }
        public float Attack
        {
            get { return base.attack; }
            set { base.attack = value; }
        }

        public float AttackRange
        {
            get { return base.attackRange; }
            set { base.attackRange = value; }
        }
        public float Speed
        {
            get { return base.speed; }
            set { base.speed = value; }
        }
        public float Faction
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
        public RangedUnit(Vector3 _postion, string _name, float _health, float _attack, float _attackRange, float _speed, float _faction)
        {
            Position = _postion;
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
            //Checks wether units are in range of each other so they can fight
            float distance;
            //int otherX = 0;
            //int otherY = 0;
            Vector3 otherPosition = new Vector3();
            if (other is MeleeUnit)
            {
                otherPosition = ((MeleeUnit)other).Position;
            }
            else if (other is RangedUnit)
            {
                otherPosition = ((RangedUnit)other).Position;
            }

            distance = Math.Abs(Position.x - otherPosition.x) + Math.Abs(Position.y - otherPosition.y);

            if (distance <= AttackRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Move(Vector3 _position,int dir)
        {
            //Handles the movement of the units
            //N.B. using the x and z co-ordinates as it is a 3d program and y is vertical up or down not forward or back.
            switch (dir)
            {
                case 0: _position.z++; break; //North (Swaped)
                case 1: _position.x++; break; //East
                case 2: _position.z--; break; //South (Swaped)
                case 3: _position.x--; break; //West
                default: break;
            }
        }

        public override string ToString()
        {
            //Override of the ToString Funciton in order to return the required string output when needed with ease.
            string temp = "";
            temp += "Ranged: ";
            //temp += Name;
            //temp += "{" + Symbol + "}";
            temp += "(" + Position.x + "," + Position.y + "," + Position.z + ")";
            temp += Health + ", " + Attack + ", " + AttackRange + ", " + Speed;
            temp += (IsDead ? " DEAD!" : " ALIVE!");
            return temp;
        }
    }
    
}
