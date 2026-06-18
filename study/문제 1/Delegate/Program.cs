using System.Security.Principal;

namespace Delegate
{
    internal class Program
    {

        delegate void MyDelegate();

        static event MyDelegate OnAttack;

        static void Attack()
        {
            Console.WriteLine("attack");
        }


        static void SoundPlay()
        {
            Console.WriteLine("sound play");
        }
        static void Main(string[] args)
        {
            OnAttack += Attack;
            OnAttack += SoundPlay;

            OnAttack();
        }
    }
}
