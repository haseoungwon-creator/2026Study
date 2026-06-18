using System.Security.Cryptography.X509Certificates;

namespace TAKEDAMAGE
{
    internal class Program
    {
        interface IDamageable
        {
            void TakeDamage(int dmg);
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
            public void Die()
            {
                Console.WriteLine("Character is dead");
            }
        }
       
            class Player : Character
            {
                public void Attack(IDamageable target, int dmg)
                {
                    HitSystem.Hit(target, dmg);
                }
            }
        

        static class HitSystem
        {
            public static void Hit(IDamageable target, int dmg)
            {
                target.TakeDamage(dmg);
            }
        }

        class Enemy : Character, IDamageable
        {
            public void TakeDamage(int dmg)
            {
                HP -= dmg;
            }
        }


        static void Main(string[] args)
        {
            Player player = new Player();
            Enemy enemy = new Enemy();

            player.HP = 100;
            enemy.HP = 50;

            player.Attack(enemy,40);
            player.Attack(enemy, 20);

        }
    }
}
