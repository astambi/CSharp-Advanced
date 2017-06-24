using System;
using System.Collections.Generic;
using System.Linq;

namespace E08_HandsOfCards
{
    public class HandsOfCards
    {
        public static void Main()
        {
            var playersValues = CalcPlayersValues(GetPlayersCards());
            PrintPlayersValues(playersValues);
        }

        private static void PrintPlayersValues(Dictionary<string, long> playerCardsValues)
        {
            foreach (var kvp in playerCardsValues)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}"); // player, cards value
            }
        }

        private static Dictionary<string, long> CalcPlayersValues(Dictionary<string, HashSet<string>> playerCards)
        {
            var playerCardsValues = new Dictionary<string, long>();
            var cardTypes = new Dictionary<char, int>() { { 'S', 4 }, { 'H', 3 }, { 'D', 2 }, { 'C', 1 } };
            var cardPowers = GetCardPowers();

            foreach (var kvp in playerCards)
            {
                var player = kvp.Key;
                var cards = kvp.Value;
                long cardsValue = 0;

                foreach (var card in cards)
                {
                    var cardType = card[card.Length - 1];
                    var cardPower = card.Substring(0, card.Length - 1);
                    if (cardPowers.ContainsKey(cardPower) && cardTypes.ContainsKey(cardType))
                    {
                        cardsValue += cardPowers[cardPower] * cardTypes[cardType];
                    }
                }
                playerCardsValues[player] = cardsValue;
            }
            return playerCardsValues;
        }

        private static Dictionary<string, int> GetCardPowers()
        {
            var cardPowers = new Dictionary<string, int>() { { "J", 11 }, { "Q", 12 }, { "K", 13 }, { "A", 14 } };
            for (int i = 2; i <= 10; i++)
            {
                cardPowers[i.ToString()] = i;
            }
            return cardPowers;
        }

        private static Dictionary<string, HashSet<string>> GetPlayersCards()
        {
            var playerCards = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                string input = Console.ReadLine().Trim();
                if (input == "JOKER") break;

                var args = input
                          .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(x => x.Trim())
                          .ToArray();
                string player = args[0];
                var cards = args[1]
                           .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(x => x.Trim());
                if (!playerCards.ContainsKey(player))
                {
                    playerCards[player] = new HashSet<string>();
                }
                playerCards[player].UnionWith(new HashSet<string>(cards));
            }
            return playerCards;
        }
    }
}
