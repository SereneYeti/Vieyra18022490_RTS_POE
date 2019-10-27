using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class MeleeUnit : Unit
    {
        public string Name
        {
            get { return base.name; }
            set { base.name = value; }
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
        public float Direction //0 is north and the cardianl points follow in order and ending with West at 3
        {
            get { return base.direction; }
            set { base.direction = value; }
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
        public GameObject GameUnit
        {
            get { return base.gameUnit; }
            set { base.gameUnit = value; }
        }
        public MeleeUnit( string _name, float _health, float _attack, float _speed, float _direction, float _faction, GameObject _gameObject)
        {
            //Position = _position;
            Name = _name;
            Health = _health;
            base.maxHealth = _health;
            Attack = _attack;
            AttackRange = 1f;
            Speed = _speed;
            Direction = _direction;
            base.faction = _faction;
            IsAttacking = false;
            IsDead = false;
            GameUnit = _gameObject;
        }
        public override (Unit, float) Closest(List<Unit> units)
        {
            //Finds the closes unit around for combat
            float shortest = 100f; //Radius for combat
            Unit closest = this;
            //Closest Unit and Distance                    
            foreach (Unit u in units)
            {
                if (u is MeleeUnit && u != this)
                {
                    MeleeUnit otherMu = (MeleeUnit)u;
                    float distance = Math.Abs(this.Position.x - otherMu.Position.x)
                               + Math.Abs(this.Position.z - otherMu.Position.z);
                    if (distance < shortest)
                    {
                        shortest = distance;
                        closest = otherMu;
                    }
                }
                else if (u is RangedUnit && u != this)
                {
                    RangedUnit otherRu = (RangedUnit)u;
                    float distance = Math.Abs(this.Position.x - otherRu.Position.x)
                               + Math.Abs(this.Position.z - otherRu.Position.z);
                    if (distance < shortest)
                    {
                        shortest = distance;
                        closest = otherRu;
                    }
                }
                else if (u is WizardUnit && u != this)
                {
                    WizardUnit otherWu = (WizardUnit)u;
                    float distance = Math.Abs(this.Position.x - otherWu.Position.x)
                               + Math.Abs(this.Position.z - otherWu.Position.z);
                    if (distance < shortest)
                    {
                        shortest = distance;
                        closest = otherWu;
                    }
                }

            }
            return (closest, shortest);
        }
        public override void Combat(Unit attacker)
        {
            //Handles the combat between two units
            if (attacker is MeleeUnit)
            {
                Health = Health - ((MeleeUnit)attacker).Attack;
            }
            else if (attacker is RangedUnit)
            {
                RangedUnit ru = (RangedUnit)attacker;
                Health = Health - (ru.Attack - ru.AttackRange);
            }
            else if (attacker is WizardUnit)
            {
                WizardUnit wu = (WizardUnit)attacker;
                Health = Health - (wu.Attack - wu.AttackRange);
            }

            if (Health <= 0)
            {   //This is when the Death method is called as no health remaining has been confirmed

                Death(); //DEATH !!!
            }
        }
        public override void Death()
        {
            IsDead = true;
            Health = 0f;
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

            distance = Math.Abs(Position.x - otherPosition.x) + Math.Abs(Position.z - otherPosition.z);

            if (distance <= AttackRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void Move(Vector3 _position,float dir)
        {   //Handles the movement of the units as unity is being used we can use a vector which keeps track of the movement now and has a x,y & z pos. 
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
        {   //Override of the ToString Funciton in order to return the required string output when needed with ease. 
            string temp = "";
            temp += "Melee:";
            //temp += Name;
            //temp += "{" + Symbol + "}";
            temp += "(" + GameUnit.transform.position.x + "," + GameUnit.transform.position.y + "," + GameUnit.transform.position.z + ")";
            temp += Health + ", " + Attack + ", " + AttackRange + ", " + Speed;
            temp += (IsDead ? " DEAD!" : " ALIVE!");
            return temp;
        }
    }
}
