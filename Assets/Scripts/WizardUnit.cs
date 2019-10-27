using System;
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
            throw new NotImplementedException();
        }

        public override void Move(Vector3 _movement, int dir)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
