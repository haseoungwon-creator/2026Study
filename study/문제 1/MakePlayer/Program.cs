namespace MakePlayer
{
    internal class Program
    {

        class Player
        {
            int hp;
            string name;
            public void Attack()
            {
                hp -= 10;
            }
        }
        static void Main(string[] args)
        {
            Player player = new Player();
            player.Attack();//1번 문제
        }
    }
}
