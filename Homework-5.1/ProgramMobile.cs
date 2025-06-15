using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

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
            
            //Console.ReadLine();
            
        }//static void Main
    }//class BaseProgram
    
    
    public class Player{
        public string Name { get; set; }
        public short Heals;
        public void PlayerHeals(){
            Heals = 2;
            if (Heals == 0){
                Console.WriteLine("oops, it seems you couldn't figure out the secret of dividing by zero.\nTry again!");
            }
        }
    }
    
    public class Dragon{
        public short HealsPoints{get;set;}=3;
        public string DragonName{get;set;}="Dragon Zerogvard";
		 public bool IsDragonAlive=>HealsPoint>0;
        }
        
        
        public class Battle{
            private Dragon dragon;
            private Player player;
            public void BattleList(Dragon dragon,Player player){
                this.player = player;
                this.dragon = dragon;
            }
            public void StartBattle(){
                
            }
        }
        
        
        
        
        
    public class RightPlayerAnswer: Exeption{
        public RightPlayerAnswerException(){
            :base("This is right answer, but we doesn't need this;)");
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