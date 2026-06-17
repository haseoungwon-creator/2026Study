namespace game
{
    internal class Program
    {

        interface Idamageable
        {
            public void TakeDamage(int dmg);
        }
        interface IAttackable
        {
            public void Attack(Idamageable target);
        }

        class Character 
        {
            private int hp;

            public int HP
            {
                get { return hp; }
                set { hp = value;
                    if (hp < 0) Die();
                }
            }

            public void Die()
            {
                Console.WriteLine("dead");
            }
        }

        class Player : Character, Idamageable, IAttackable
        {
            public void Attack(Idamageable target)
            {
                target.TakeDamage(10);
            }

            public void TakeDamage(int dmg)
            {
                HP -= dmg;
            }
        }

        class Enemy : Character, Idamageable
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
