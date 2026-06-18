using System;

namespace TakeSkill
{
    internal class Program
    {

        interface IDamageable
        {
            void TakeDamage(int dmg);

        }

        interface IHealable
        {
            void Heal(int amount);
        }

        class Character
        {
            private int hp;

            public int HP
            {
                get { return hp; }
                set
                {
                    hp = value;
                    if (hp <= 0)
                    {
                        Die();
                    }
                }
            }

            private void Die()
            {
                Console.WriteLine("Character has died.");
            }
        }

        static class SkillSystem
        {
            public static void UseHeal(IHealable target, int amount)
            {
                target.Heal(amount);
            }

            public static void UseDamage(IDamageable target, int dmg)
            {
                target.TakeDamage(dmg);
            }
        }

        class Player : Character
        {
            public void TakeDamage(int dmg)
            {
                HP -= dmg;
            }

            public void Heal(int amount)
            {
                HP += amount;
            }

           



        }
        class Enemy : Character
        {
            public void TakeDamage(int dmg)
            {
                HP -= dmg;
            }

        }
        static void Main(string[] args)
        {
            
        }
    }
}
