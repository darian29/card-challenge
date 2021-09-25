using System;
using Models.Card;
using Constants.SuitsConst;
using Constants.NumberConst;
using System.Collections.Generic;

namespace Controller.CardController
{
    public class CardController {
        
        private List<Card> deck;
        private Random rng = new Random();

        public CardController (){
            deck = new List<Card>();
            PrepareDeck();
        }
        public void PrepareDeck(){
            //Create Card List
            Console.WriteLine("Creating Deck");
            SuitsConst suitConsts = new SuitsConst();
            NumberConst numberConst = new NumberConst();
            deck = new List<Card>();
            for (int numberIndex=0; numberIndex < numberConst.numbers.Length; numberIndex++) {
                for (int suitsIndex = 0; suitsIndex < suitConsts.Suits.Length; suitsIndex++){
                    deck.Add(new Card(numberConst.numbers[numberIndex],suitConsts.Suits[suitsIndex]));
                }
            }
        //Deck Complete
        Console.WriteLine("Deck Completed");
        }

        public void Shuffle(){
            if (deck == null){
                PrepareDeck();
            }
            int deckTotal = deck.Count;
            if (deckTotal == 0){
                PrepareDeck();
            }
            for (int i =0; i < deckTotal; i++){
                int randomPosition = rng.Next(0,deckTotal);
                deck = Swap(i,randomPosition,deck);
            }
        }

        private List<Card> Swap (int start, int end, List<Card> list){
                Card temp = deck[end];
                deck[end] = deck[start];
                deck[start]= temp;
                return deck;
        }
        public Card DealOneCard(){
            if ( GetDeckTotal() > 0 ){
                Card temp = deck[0];
                deck.RemoveAt(0);
                return temp;
            } else {
                return null;
            }
        } 

        public int GetDeckTotal() {
            return deck.Count;
        }
        
        public void PrintDeck(){
            for(int cardIndex = 0; cardIndex < deck.Count; cardIndex ++){
                Console.WriteLine(cardIndex+1 + "- " + deck[cardIndex].GetCard());
            }
        }
    }
}