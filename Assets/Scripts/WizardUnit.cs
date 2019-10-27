﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class WizardUnit : Unit
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
        public WizardUnit(GameObject _gameUnit, string _name, float _health, float _attack, float _attackRange, float _speed, float _faction)
        {
            GameUnit = _gameUnit;
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
        public override (Unit, float) Closest(List<Unit> units)
        {
            throw new NotImplementedException();
        }

        public override void Combat(Unit attacker)
        {
            throw new NotImplementedException();
        }

        public override void Death()
        {
            throw new NotImplementedException();
        }

        public override bool InRange(Unit other)
        {
            //Checks wether units are in range of each other so they can fight
            float distance;
            //int otherX = 0;
            //int otherY = 0;
            GameObject otherUnit = new GameObject();
            if (other is MeleeUnit)
            {
                otherUnit = ((MeleeUnit)other).GameUnit;
            }
            else if (other is RangedUnit)
            {
                otherUnit = ((RangedUnit)other).GameUnit;
            }
            else if (other is WizardUnit)
            {
                otherUnit = ((WizardUnit)other).GameUnit;
            }

            distance = Math.Abs(GameUnit.transform.position.x - otherUnit.transform.position.x) + Math.Abs(GameUnit.transform.position.z - otherUnit.transform.position.z);

            if (distance <= AttackRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Move(Vector3 _position, float dir)
        {
            //Handles the movement of the units
            //N.B. using the x and z co-ordinates as it is a 3d program and y is vertical up or down not forward or back.
            switch (dir)
            {
                case 0: _position.z++; GameUnit.transform.position = _position; break; //North (Swaped)
                case 1: _position.x++; GameUnit.transform.position = _position; break; //East
                case 2: _position.z--; GameUnit.transform.position = _position; break; //South (Swaped)
                case 3: _position.x--; GameUnit.transform.position = _position; break; //West
                default: break;
            }
        }

        public override string ToString()
        {
            //Override of the ToString Funciton in order to return the required string output when needed with ease.
            string temp = "";
            temp += "Wizard: ";
            //temp += Name;
            //temp += "{" + Symbol + "}";
            temp += "(" + GameUnit.transform.position.x + "," + GameUnit.transform.position.y + "," + GameUnit.transform.position.z + ")";
            temp += Health + ", " + Attack + ", " + AttackRange + ", " + Speed;
            temp += (IsDead ? " DEAD!" : " ALIVE!");
            return temp;
        }
    }
}
