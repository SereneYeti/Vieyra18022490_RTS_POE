using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class MeleeUnit : Unit
    {
        public string Name
        {
            get { return base.name; }
            set { base.name = value; }
        }
        public int XPos
        {
            get { return base.xPos; }
            set { base.xPos = value; }
        }
        public int YPos
        {
            get { return base.yPos; }
            set { base.yPos = value; }
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
        public MeleeUnit(int x, int y, string _name, int _health, int _attack, int _speed, int _faction)
        {
            XPos = x;
            YPos = y;
            Name = _name;
            Health = _health;
            base.maxHealth = _health;
            Attack = _attack;
            AttackRange = 1;
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

        public override void Move(int dir)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
