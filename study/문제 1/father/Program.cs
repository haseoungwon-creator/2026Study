namespace father
{
    internal class Program
    {

        class Character
        {
            int hp;
            public void Move()
            {
                Console.WriteLine("movemove");
            }
        }

        class Player : Character
        {
            public int hp= 100;

            public void Attack()
            {
                Console.WriteLine("hit");
            }
        }

        class Enemy : Character
        {
            public int hp=20;

            public void Patrol()
            {
                Console.WriteLine("what");
            }
        }
        static void Main(string[] args)
        {
            Player player = new Player();
            Enemy enemy = new Enemy();

            player.Attack();
            enemy.Patrol();
            player.Move();
            enemy.Move();
        }
    }
}
