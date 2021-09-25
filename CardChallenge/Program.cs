using System;
using Controller.CardController;
using Models.Card;

namespace card_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Card Game!!!!");
            CardController cardGame = new CardController();
            
            string userCommand = "";
            while(userCommand != "exit"){
                Console.WriteLine("Enter your command (shuffle or deal)");
                Console.WriteLine("************************************");
                userCommand = Console.ReadLine();
                switch (userCommand)
                {
                    case "shuffle":
                        cardGame.Shuffle();
                        Console.WriteLine("Deck Suffled!!!!");
                    break;
                    case "deal":
                        Console.WriteLine("Your Card is " + cardGame.DealOneCard().GetCard());
                    break;
                    case "help":
                        Console.WriteLine("Please type one of the following commands");
                        Console.WriteLine("Command: shuffle / Shuffle the deck of cards, if deck is empty, it gets a new one ");
                        Console.WriteLine("Command deal / Deal one card to the user");
                        Console.WriteLine("Command show deck / Show the house deck");
                        Console.WriteLine("Command exit / Finish the game");
                    break;
                    case "show deck":
                    case "print":
                        cardGame.PrintDeck();
                    break;
                    default:
                        Console.WriteLine("Command not found");
                    break;
                }
                 Console.WriteLine("************************************");

            }
           
        }
    }
}
