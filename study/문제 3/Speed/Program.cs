using System.Security.AccessControl;

namespace Speed
{
    internal class Program
    {

        interface ITakeDamage
        {
            void TakeDamage(int damage);
        }

        interface IAttack
        {
            void Attack(Character target);
        }

        interface IShowStatus
        {
            void ShowStatus();
        }

        class Character : ITakeDamage, IAttack, IShowStatus
        {
            protected int hp;
            public int damage;
            public string name;

            public Character(string name, int hp, int damage)
            {
                this.name = name;
                this.hp = hp;
                this.damage = damage;
            }

            public void TakeDamage(int damage)
            {
                hp -= damage;
                Console.WriteLine($"{name}이 {damage} 데미지를 받았다!");
            }

            public void Attack(Character target)
            {
                target.TakeDamage(damage);
                Console.WriteLine($"{name}이 {target.name}을 공격했다!");
            }

            public void ShowStatus()
            {
                Console.WriteLine($"{name} / HP: {hp} / ATK: {damage}");
            }
        }


        static void Main(string[] args)
        {
            Character player = new Character("Player", 100, 10);
            Character monster = new Character("Monster", 50, 5);

            player.Attack(monster);
            monster.Attack(player);

            player.ShowStatus();
            monster.ShowStatus();
        }
    }
}
