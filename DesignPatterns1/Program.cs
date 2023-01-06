using System;

namespace DesignPatterns1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Duck donald = new MallardDuck();
            donald.performFly(); // “flap flap”
            donald.setFlyBehaviour(new FlyWithRocket());
            donald.performFly(); // “Zoooom!”
            */
            ToyMachine tm = new ToyMachine(5);
            tm.insertCoin();
            tm.ejectCoin();
            tm.insertCoin();
            tm.turnCrank();
            tm.insertCoin();
            tm.turnCrank();
            tm.insertCoin();
            tm.turnCrank();
            tm.insertCoin();
            tm.turnCrank();
            tm.insertCoin();
            tm.turnCrank();
            tm.insertCoin();
            tm.turnCrank();

        }
    }
    abstract class Duck
    {
        protected FlyBehaviour flyBehaviour;
        protected QuackBehaviour quackBehaviour;

        public void performFly()
        {
            flyBehaviour.fly();
        }
        public void performQuack()
        {
            quackBehaviour.quack();
        }
        public void swim()
        { // all ducks swim
            Console.WriteLine("Splish splash");
        }

        public void setFlyBehaviour(FlyBehaviour fb)
        {
            flyBehaviour = fb;
        }
    }
    class MallardDuck : Duck
    {
        public MallardDuck()
        { // constructor
            flyBehaviour = new FlyWithWings();
            quackBehaviour = new Quack();
        }
    }

    class RubberDuck : Duck
    {
        public RubberDuck()
        { // constructor
            flyBehaviour = new FlyUnable();
            quackBehaviour = new QuackSqueak();
        }
    }


    //Fly Strategy Design Pattern
    public interface FlyBehaviour
    {
        void fly();
    }

    class FlyWithWings : FlyBehaviour
    {
        public void fly()
        {
            Console.WriteLine("Flap flap");
        }

    }

    class FlyWithRocket : FlyBehaviour
    {
        public void fly()
        {
            Console.WriteLine("Zooooom!");
        }

    }

    class FlyUnable : FlyBehaviour
    {
        public void fly()
        {
            Console.WriteLine("Cannot fly");
        }
    }
    //Quack Strategy Design Pattern
    public interface QuackBehaviour
    {
        void quack();
    }

    class Quack : QuackBehaviour
    {
        public void quack()
        {
            Console.WriteLine("Quack");
        }

    }


    class QuackSqueak : QuackBehaviour
    {
        public void quack()
        {
            Console.WriteLine("Squeak");
        }
    }
    class QuackSilence : QuackBehaviour
    {
        public void quack()
        {
            Console.WriteLine("No sound");
        }

    }

}
