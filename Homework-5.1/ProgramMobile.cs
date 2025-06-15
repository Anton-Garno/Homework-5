using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SoloLearn
{
    class BaseProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lets divide numbers, just input two nubbers bellow and i'll calculate it! ");

            Console.WriteLine("\nPlease input your first integer number:");
            int firstNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\nFirst number is:  {firstNumber};");
            //first block

            Console.WriteLine("Please input your second number:");
            int secondNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\nSecond number is:  {secondNumber};");
            //second block

            double result;

            try{
                result = firstNumber / secondNumber;
                Console.WriteLine($"Your result is: {result}");
            }
            catch (DivideByZeroException){
                Console.WriteLine("Opsss, you just tried division by zero... This is not good!");
            }
            catch{
                Console.WriteLine("I said enter an integer number... try again");
            }
            finally{
                Console.WriteLine("\nYour choise has led you to a mystery Cave...." +
                "\nIf you want to get out  alive, you will have to defeat the Dragon..." +
                "\nAnd than you might learn the secreat of division by Zero.." +
                "\nOr you will just Die.");
            }
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
        }//static void Main
    }//class BaseProgram
    
    
    public class Player{
        public string Name { get; set; }
        public short HealsPoints{get;set;}=2;
        }
    }
    
    public class Dragon{
        public short HealsPoints{get;set;}=3;
        public string DragonName{get;set;}="Dragon Zerogvard";
		 public bool IsDragonAlive=>HealsPoints>0;
        }
        
        
        public class Battle{
            private Dragon dragon;
            private Player player;
            public void BattleList(Dragon dragon,Player player){
                this.player = player;
                this.dragon = dragon;
            }
            public void StartBattle(){
			Console.WriteLine("The Rules:\n1.You have only 2 HP!\n2.Dragon Has 3 HP.\nYou must give a right answer on 3 math problems.\nAnd you have only 5! Seconds\nGood luck!");
			Console.WriteLine($"The Battle between{dragon.DragonName} and {player.Player} has been began!");

Console.WriteLine("Are you Ready?!(y/n)");
string readyYesNo = Console.ReadLine();
if(ready != "y") return;
Thread.Sleep(3000);//epic pause
short round = 1;
Random random = new Random();
while(dragon.HealsPoints && player.HealsPoints >0){
	Console.WriteLine($"=====Round{round} began!=====")
	int firstRandNumber = random.Next(1,20);
	int secondRandomNumber = random.Next(1,20);
	int mathResult = firstRandNumber + secondRandNumber;
	Console.WriteLine($"1 Challenge:  {firstRandNumber} + {secondRandNumber} =?!");
	string playerAnswer = Console.ReadLine();
	if(playerAnswer== null){
	    player.HealsPoints
	}
	else if(int.TryParse(playerAnswer, out int playerResult)&&playerResult==mathResult){
    dragon.HealsPoints--;
    else{
        
    }
}

}

            }
        }
        
        
        
        
        
    public class RightPlayerAnswerException: Exception{
        public RightPlayerAnswerException():base("This is right answer, but we doesn't need this;)"){
    //if(result==numberN)throw new RightPlayerAnswerException();
}

        
    }
    public class NullOrSpaceExeption : Exception
    {
        public NullOrSpaceExeption(string message):base(message){
    //code
}

    }
    }//namespace