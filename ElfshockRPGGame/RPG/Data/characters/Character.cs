﻿using RPG.Data.characters.contracts;

namespace RPG.Data.characters
{
    public abstract class Character : ICharacter
    {
        protected int _x;
        protected int _y;

        protected int _strength;
        protected int _agility;
        protected int _intelligence;
        protected int _range;

        protected int _health;
        protected int _mana;
        protected int _damage;

        protected char _symbol;

        public Character()
        {

        }

        public void Setup()
        {
            Health = Strength * 5;
            Mana = Intelligence * 3;
            Damage = Agility * 2;
        }

        public int Strength
        {
            get => _strength;
            set => _strength = value;
        }
        public int Agility
        {
            get => _agility;
            set => _agility = value;
        }
        public int Intelligence
        {
            get => _intelligence;
            set => _intelligence = value;
        }
        public int Range
        {
            get => _range;
            set => _range = value;
        }

        public char Symbol
        {
            get => _symbol;
            set => _symbol = value;
        }

        public int Health
        {
            get => _health;
            set => _health = value;
        }
        public int Mana
        {
            get => _mana;
            set => _mana = value;
        }
        public int Damage
        {
            get => _damage;
            set => _damage = value;
        }

        public virtual void Attack(Character enemy)
        {
            enemy.Health -= Damage;
        }

        public void Move(int dx, int dy)
        {
            _x += dx;
            _y += dy;
        }

        public (int x, int y) GetPosition()
        {
            return (_x, _y);
        }

        public void SetPosition(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}
