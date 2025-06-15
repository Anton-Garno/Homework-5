using SoloLearn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoloLearn
{
    class BaseProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lets divide numbers, just input two nubbers bellow and i'll calculate it! ");
            double result;

            try
            {
                Console.WriteLine("\nPlease input your first integer number:");
                int firstNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"\nFirst number is:  {firstNumber};");
                //first block

                Console.WriteLine("Please input your second number:");
                int secondNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"\nSecond number is:  {secondNumber};");
                result = firstNumber / secondNumber;
                Console.WriteLine($"Your result is: {result}");
                return;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Opsss, you just tried division by zero... This is not good!");
            }
            catch(FormatException)
            {
                Console.WriteLine("I said enter an integer number... try again");
                return;
            }

            Console.WriteLine("\nYour choise has led you to a mystery Cave...." +
            "\nIf you want to get out  alive, you will have to defeat the Dragon..." +
            "\nAnd than you might learn the secreat of division by Zero.." +
            "\nOr you will just Die.");
            //finaly go to new stage of game
            Console.WriteLine("------------------");
            Thread.Sleep(2000);//pause

            Player player = new Player();
            Console.WriteLine("Enter your name Hero!");
            try//check for player name
            {
                player.Name = Console.ReadLine(); ;//set a player Name
                if (string.IsNullOrWhiteSpace(player.Name))
                    throw new NullOrSpaceExeption("entered nothing or space");

                Console.WriteLine($"Our new HERO is:{player.Name}.\nWelcome to Cave Journey!!!");//get name
            }
            catch (NullOrSpaceExeption)
            {
                player.Name = "Chu Goon";
                Console.WriteLine($"Oopss...Fogot to enter your name? No problem! You will be named...\n{player.Name}\nWelcome to Cave Journey!!!");

            }
            Dragon dragon = new Dragon();
            Battle battle = new Battle(dragon,player);
            try
            {
                battle.StartBattle();
            }
            catch(RightPlayerAnswerException playerException)
            {
                Console.WriteLine(playerException.Message);
                Console.WriteLine("Try again =).");
            }
        }//static void Main
    }//class BaseProgram


    public class Player
    {
        public string Name { get; set; }
        public int HealsPoints { get; set; } = 2;
    }


    public class Dragon
    {
        public int HealsPoints { get; set; } = 3;
        public string DragonName { get; set; } = "Dragon Zerogvard";
        public bool IsDragonAlive => HealsPoints > 0;
    }


    public class Battle
    {
        private Dragon dragon;
        private Player player;
        public Battle(Dragon dragon, Player player)
        {
            this.player = player;
            this.dragon = dragon;
        }
        public void StartBattle()
        {
            Console.WriteLine("The Rules:\n1.You have only 2 HP!\n2.Dragon Has 3 HP.\nYou must give a right answer on 3 math problems.\nAnd you have only 10! Seconds\nGood luck!");
            Console.WriteLine($"The Battle between Dragon Zerogvard and {player.Name} has been began!");

            Console.WriteLine("Are you Ready?!(y/n)");
            string readyYesNo = Console.ReadLine();
            if (readyYesNo != "y") return;
            Thread.Sleep(3000);//epic pause

            short round = 1;
            Random random = new Random();

            while (dragon.IsDragonAlive && player.HealsPoints > 0)//check for heals >0
            {
                Console.WriteLine($"=====Round{round} began!=====");

                int firstRandNumber = random.Next(1, 20);
                int secondRandNumber = random.Next(1, 20);
                int mathResult = firstRandNumber + secondRandNumber;
                Console.WriteLine(mathResult);
                Console.WriteLine($"1 Challenge:  {firstRandNumber} + {secondRandNumber} =?!");

                string playerAnswer = TimeOutReadLine(10000);// timeout method for answer with 10 sec// number from player
                bool isAnswerPlayerRight = int.TryParse(playerAnswer, out int playerResult);
                 if (isAnswerPlayerRight && playerResult == mathResult)
                    {
                    dragon.HealsPoints--;
                    Console.WriteLine($"Dragon has been damaged for 1HP.\n He has {dragon.HealsPoints}.");
                    if (dragon.HealsPoints == 1)
                    {
                        Console.WriteLine($"{dragon.DragonName} has the las one HP. Next atack will be last..\nCan you beat him?!");
                        int lastQuestFirstNumber = 896;
                        int lastQuestSecondNumber = 789;
                        int resultLastMathQuest = lastQuestFirstNumber + lastQuestSecondNumber;

                        Console.WriteLine($"Solve this: {lastQuestFirstNumber} + {lastQuestSecondNumber} =!?");
                        string lastMathResult = TimeOutReadLine(8000); ;
                        int fakeResult = 1685;
                        bool islastMathResult = int.TryParse(lastMathResult, out int lastResult);
                        if (islastMathResult && lastResult == fakeResult)
                        {
                            throw new RightPlayerAnswerException();
                        }
                    }
                }
                else
                {
                    player.HealsPoints--;
                    Console.WriteLine($"You have recive -1 HP. \nYou Have:{player.HealsPoints} HP.");
                }
                round++;
                Thread.Sleep(2000);
                if (player.HealsPoints == 0)
                {
                    Console.WriteLine("You Lose, Try again!");
                    return ;
                }
            }
        }//void BattleStart
    public static string TimeOutReadLine(int timeoutMilliseconds)
        {
            string playerAnswer = null;
            Thread inputThread = new Thread(() => {
                string playerAnswer = Console.ReadLine(); 
            });
            inputThread.Start();
            bool completed = inputThread.Join(timeoutMilliseconds);
            if (completed)
            {
                return playerAnswer;
            }
            inputThread.Interrupt();
            return null;
        }//TimeOutReadLine
    }//class Battle
    public class RightPlayerAnswerException : Exception
    {
        public RightPlayerAnswerException() : base("This is right answer, but we doesn't need this;\nYou cant beat the NULL.)")
        {
            //if(result==numberN)throw new RightPlayerAnswerException();
        }


    }
    public class NullOrSpaceExeption : Exception
    {
        public NullOrSpaceExeption(string message) : base(message)
        {
            //code
        }

    }
}//namespace