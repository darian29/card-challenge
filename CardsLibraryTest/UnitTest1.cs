using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller.CardController;
using Models.Card;
using System.Collections.Generic;

namespace CardsLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        CardController cardGame = new CardController();

        [TestMethod]
        public void EmptyDeckShuffle()
        {
            cardGame.Shuffle();
            Assert.AreEqual(cardGame.GetDeckTotal(),52,
                "Deck does not have right size");
        }

        [TestMethod]
        public void DeckCreationCount()
        {
            cardGame.PrepareDeck();
            Assert.AreEqual(cardGame.GetDeckTotal(),52,
                "Deck does not have right size");
        }
        [TestMethod]
        public void DealOneCard()
        {
            cardGame.PrepareDeck();
            Card temp = cardGame.DealOneCard();
            Assert.IsNotNull(temp,String.Format("Expected for '{0}': true;",
                                     "cardGame.DealOneCard()"));
        }
        [TestMethod]
        public void DealOneCardValidType()
        {
            cardGame.PrepareDeck();
            Card temp = cardGame.DealOneCard();
            Assert.IsInstanceOfType(temp,typeof (Card));
        }
        [TestMethod]
        public void DealOneCardReduceDeck()
        {
            cardGame.PrepareDeck();
            int initialDeckCount = cardGame.GetDeckTotal();
            Card temp = cardGame.DealOneCard();
            Assert.AreNotEqual(initialDeckCount,cardGame.GetDeckTotal());
        }
        [TestMethod]
        public void DealOneCardOnEmptyDeck()
        {
            cardGame.PrepareDeck();
            Card temp;
            for (int i=0; i < 52; i++){
                temp = cardGame.DealOneCard();
            }
            Assert.IsNull(cardGame.DealOneCard());
        }
        [TestMethod]
        public void ShuffleDeck()
        {
            List<string> orderDeckList = new List<string>();
            List<string> shuffleDeckList = new List<string>();
            cardGame.PrepareDeck();
            for (int i=0; i < cardGame.GetDeckTotal(); i++){
                orderDeckList.Add(cardGame.DealOneCard().GetCard());
            }
            cardGame.PrepareDeck();
            cardGame.Shuffle();
            for (int i=0; i < cardGame.GetDeckTotal(); i++){
                shuffleDeckList.Add(cardGame.DealOneCard().GetCard());
            }
            string orderedDeck = string.Join(",",orderDeckList);
            string shuffledDeck = string.Join(",",shuffleDeckList);
            Assert.AreNotEqual(orderedDeck,shuffledDeck, String.Format("The two arrays are equal. OrderDeck: {0}, SuffleDeck: {1}",orderedDeck,shuffledDeck));
        }
        [TestMethod]
        public void PrepareDeckGiveOrderedCards()
        {
            List<string> orderDeckList = new List<string>();
            List<string> shuffleDeckList = new List<string>();
            cardGame.PrepareDeck();
            for (int i=0; i < cardGame.GetDeckTotal(); i++){
                orderDeckList.Add(cardGame.DealOneCard().GetCard());
            }
            cardGame.PrepareDeck();
            for (int i=0; i < cardGame.GetDeckTotal(); i++){
                shuffleDeckList.Add(cardGame.DealOneCard().GetCard());
            }
            string orderedDeck = string.Join(",",orderDeckList);
            string shuffledDeck = string.Join(",",shuffleDeckList);
            Assert.AreEqual(orderedDeck,shuffledDeck, String.Format("The two arrays are equal. OrderDeck: {0}, SuffleDeck: {1}",orderedDeck,shuffledDeck));
        }
        [TestMethod]
        public void EmptyDeck()
        {
            cardGame.PrepareDeck();
            int totalCards = cardGame.GetDeckTotal();
            for (int i=0; i < totalCards; i++){
                Card temp = cardGame.DealOneCard();
            }
            int newDeckCount = cardGame.GetDeckTotal();
            Assert.AreEqual(newDeckCount,0);
        }
        [TestMethod]
        public void EmptyDeckOnShuffle()
        {
            cardGame.PrepareDeck();
            int totalCards = cardGame.GetDeckTotal();
            for (int i=0; i < totalCards; i++){
                Card temp = cardGame.DealOneCard();
            }
            cardGame.Shuffle();
            int newTotalCard = cardGame.GetDeckTotal();
            Assert.AreEqual(totalCards,newTotalCard);
        }
    }
}
