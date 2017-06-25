using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_NumberWars
{
    public class NumberWars
    {
        public const int maxTurns = 1000000;

        // TODO Time limit 70/ 100
        public static void Main()
        {
            var playerCards = GetPlayerCards();
            var turns = 0;

            while (IsContinuingGame(playerCards, turns))
            {
                turns++;

                // Each player draws a card
                var currentCards = new List<string>[2];
                for (int i = 0; i < playerCards.Length; i++)
                {
                    currentCards[i] = new List<string>();
                    currentCards[i].Add(playerCards[i].Dequeue());
                }

                // Get cards number & letter
                var cardNumbers = new int[2];
                var cardLetters = new char[2];
                for (int i = 0; i < playerCards.Length; i++)
                {
                    var card = currentCards[i][0]; // first card
                    cardNumbers[i] = GetNumber(card);
                    cardLetters[i] = GetLetter(card);
                }

                // Determine winner => bigger card number 
                // Winner gets drawn cards from both players

                if (cardNumbers[0] > cardNumbers[1]) // winner Player 1
                {
                    playerCards[0] = UpdateWinnerCards(playerCards[0], currentCards);
                }
                else if (cardNumbers[0] < cardNumbers[1]) // winner Player 2
                {
                    playerCards[1] = UpdateWinnerCards(playerCards[1], currentCards);
                }
                else // draw => players continue drawing 3 more cards until one of them wins or loses
                {
                    while (IsContinuingGame(playerCards, turns))
                    {
                        // initialize new cards
                        var newCards = new List<string>[2];
                        for (int i = 0; i < 2; i++)
                        {
                            newCards[i] = new List<string>();
                        }

                        // draw 3 new cards
                        for (int t = 0; t < 3; t++)
                        {
                            for (int i = 0; i < playerCards.Length; i++)
                            {
                                if (playerCards[i].Count == 0) continue;

                                var drawnCard = playerCards[i].Dequeue();
                                newCards[i].Add(drawnCard);
                                currentCards[i].Add(drawnCard);
                                // add new card to current cards => the winner receives all current cards
                            }
                        }

                        // Calc Sum Letters of new cards
                        var sumLetters = new int[2];
                        for (int i = 0; i < sumLetters.Length; i++)
                        {
                            sumLetters[i] = CalcSumLetters(newCards[i]);
                        }

                        // Determine Winner => having max sum of 3 cards letters (position in alphabet)
                        if (sumLetters[0] > sumLetters[1]) // winner Player 1
                        {
                            playerCards[0] = UpdateWinnerCards(playerCards[0], currentCards);
                            break;
                        }
                        else if (sumLetters[0] < sumLetters[1]) // winner Player 1
                        {
                            playerCards[1] = UpdateWinnerCards(playerCards[1], currentCards);
                            break;
                        }
                        // if no one wins => drawing new 3 cards
                    }
                }
            }

            PrintGameResult(playerCards, turns);
        }

        private static Queue<string>[] GetPlayerCards()
        {
            var playerCards = new Queue<string>[2];
            for (int i = 0; i < playerCards.Length; i++)
            {
                playerCards[i] = new Queue<string>(
                    Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries));
            }

            return playerCards;
        }

        private static void PrintGameResult(Queue<string>[] playerCards, int turns)
        {
            if (playerCards[0].Count == 0 && playerCards[1].Count == 0)
                Console.WriteLine($"Draw after {turns} turns");
            else if (playerCards[0].Count == 0)
                Console.WriteLine($"Second player wins after {turns} turns");
            else if (playerCards[1].Count == 0)
                Console.WriteLine($"First player wins after {turns} turns");
            else if (turns == maxTurns)
            {
                if (playerCards[0].Count > playerCards[1].Count)
                    Console.WriteLine($"First player wins after {turns} turns");
                else if (playerCards[0].Count < playerCards[1].Count)
                    Console.WriteLine($"Second player wins after {turns} turns");
                else
                    Console.WriteLine($"Draw after {turns} turns");
            }
        }

        private static Queue<string> UpdateWinnerCards(Queue<string> cardsWinner, List<string>[] cardsBothPlayers)
        {
            var cardsToAdd = cardsBothPlayers[0]
                            .Concat(cardsBothPlayers[1])
                            .OrderByDescending(c => GetNumber(c))
                            .ThenByDescending(c => GetLetter(c))
                            .ToList();
            foreach (var card in cardsToAdd)
            {
                cardsWinner.Enqueue(card);
            }
            return cardsWinner;
        }

        private static int CalcSumLetters(List<string> cards)
        {
            var sum = 0;
            foreach (var card in cards)
            {
                sum += char.ToLower(GetLetter(card)) - 'a' + 1;
            }
            return sum;
        }

        private static char GetLetter(string card)
        {
            return card[card.Length - 1];
        }

        private static int GetNumber(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }

        private static bool IsContinuingGame(Queue<string>[] playerCards, int turns)
        {
            return playerCards[0].Any() && playerCards[1].Any() && turns < maxTurns;
        }
    }
}
