using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    interface TMState
    {
        void insertCoin();
        void ejectCoin();
        void turnCrank();
        void restock(int amount);
    }
    class ToyMachine
    {
        private TMState outOfStockState;
        private TMState idleState;
        private TMState hasCoinState;
        //private TMState WinnerState;
        private TMState state;
        private int stock = 0;

        public void setState(TMState state)
        {
            this.state = state;
        }

        public ToyMachine(int amount)
        {
            // create the TMState objects
            outOfStockState = new OutOfStockState(this);
            idleState = new IdleState(this);
            hasCoinState = new HasCoinState(this);
            //winnerState = new WinnerState(this);
            stock = amount;
            if (stock > 0)
                state = idleState;
            else
                state = outOfStockState;
        }
        public void insertCoin()
        {
            state.insertCoin();
        }

        public void ejectCoin()
        {
            state.ejectCoin();
        }

        public void turnCrank()
        {
            state.turnCrank();
        }

        public void restock(int amount)
        {
            state.restock(amount);
        }
        public void addStock(int amount)
        {
            stock += amount;
        }
        public int getStock()
        {
            return stock;
        }
        public void dispense(int amount)
        {
            stock -= amount;
        }
        public TMState getHasCoinState()
        {
            return hasCoinState;
        }
        public TMState getIdleState()
        {
            return idleState;
        }
        public TMState getOutOfStockState()
        {
            return outOfStockState;
        }

        class IdleState : TMState
        {
            private ToyMachine myMachine;
            public IdleState(ToyMachine machine)
            {
                myMachine = machine;
            }
            public void insertCoin()
            {
                myMachine.setState(
                          myMachine.getHasCoinState());
                // 10% chance
                /*
                if ((myMachine.getWinner() == true) &&
                    (stock >= 2))
                            myMachine.setState(
                              myMachine.getWinnerState());
                        else
                            myMachine.setState(
                              myMachine.getHasCoinState());
                */

            }
            public void ejectCoin()
            {
                Console.WriteLine("You can’t eject your coin, you haven’t inserted one yet!");
            }

            public void turnCrank()
            {
                Console.WriteLine("You can’t turn the crank, you haven’t inserted a coin yet!");
            }

            public void restock(int amount)
            {
                myMachine.addStock(amount);
            }

        }

        class WinnerState : TMState
        {
            private ToyMachine myMachine;
            public WinnerState(ToyMachine machine)
            {
                myMachine = machine;
            }

            public void insertCoin()
            {
                Console.WriteLine("You can’t insert another coin!");
            }

            public void ejectCoin()
            {
                Console.WriteLine("Coin returned.");
                myMachine.setState(myMachine.getIdleState());
            }

            public void turnCrank()
            {
                myMachine.dispense(2); // reduces stock by two
                Console.WriteLine("You win! Two for you!");
                if (myMachine.getStock() > 0)
                    myMachine.setState(myMachine.getIdleState());
                else
                    myMachine.setState(myMachine.getOutOfStockState());
            }

            public void restock(int amount)
            {
                Console.WriteLine("You can’t restock while a customer is buying a toy!");
            }
        }
        class OutOfStockState : TMState
        {
            private ToyMachine myMachine;
            public OutOfStockState(ToyMachine tm)
            {
                myMachine = tm;
            }
            public void insertCoin()
            {

                Console.WriteLine("Item is out of stock. You can’t insert coin!");
            }
            public void ejectCoin()
            {
                Console.WriteLine("Coin returned.");
                myMachine.setState(myMachine.getIdleState());
            }

            public void turnCrank()
            {
                Console.WriteLine("Item is out of stock. You can’t turn the crank!");
            }

            public void restock(int amount)
            {
                myMachine.addStock(amount);
                myMachine.setState(myMachine.getIdleState());
            }
        }
        class HasCoinState : TMState
        {
            // myMachine, constructor
            private ToyMachine myMachine;
            public HasCoinState(ToyMachine tm)
            {
                myMachine = tm;
            }
            public void insertCoin()
            {

                Console.WriteLine("Coin is already inserted.");
            }
            public void ejectCoin()
            {
                Console.WriteLine("Coin returned.");
                myMachine.setState(myMachine.getIdleState());
            }

            public void turnCrank()
            {
                myMachine.dispense(1); // reduces stock by one
                Console.WriteLine("One toy dispensed");
                if (myMachine.getStock() > 0)
                    myMachine.setState(myMachine.getIdleState());
                else
                    myMachine.setState(myMachine.getOutOfStockState());
            }

            public void restock(int amount)
            {
                Console.WriteLine("You can’t restock while a customer is buying a toy!");
            }

        }

    }
}
