namespace HpSave
{
    internal class Program
    {
        class Player
        {
            private int hp;

            public int HP
            {
                get
                {
                    return hp;
                }
                set
                {
                    if(hp<=0) hp = 0;
                }
            }

            public void Attack()
            {
                HP -= 10;
            }


            public
            static void Main(string[] args)
            {
                Player player = new Player();
                player.HP = 100;
                player.HP = -10;

                player.Attack();

                Console.WriteLine(player.HP);
            }
        }
    }
}
