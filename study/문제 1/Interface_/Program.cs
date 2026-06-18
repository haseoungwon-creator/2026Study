namespace Interface_
{
    internal class Program
    {
        interface IDamageable
        {
            public void TakeDamage(int dmg);
        }

        class Player : IDamageable
        {
            public int hp = 100;


            
            public void TakeDamage(int dmg)
            {
                hp-=dmg;
            }
        }

        class Enemy : IDamageable
        {
            public int hp=100;

            public void TakeDamage(int dmg)
            {
                hp -= dmg;
            }
        }
        static void Main(string[] args)
        {
            Player player = new Player();
            Enemy enemy = new Enemy();

            player.TakeDamage(10);
            Console.WriteLine(player.hp);
        }
    }
}
