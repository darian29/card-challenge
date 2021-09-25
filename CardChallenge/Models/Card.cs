using System;

namespace Models.Card
{
    public class Card {
        private string number;
        private string suit;

        public Card(string number, string suit){
            this.number = number;
            this.suit = suit;
        }
        public string getNumber(){
            return this.number;
        }
        public string getSuit(){
            return this.suit;
        }
        public string GetCard(){
            return number +" of " + suit;
        }
    }
}