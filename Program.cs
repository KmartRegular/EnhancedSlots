using System.ComponentModel.Design;
using System.Numerics;

namespace Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = new string[10] {"Cherry", "Lemon", "Plum", "Grapes", "Melon", "Banana", "Orange", "Seven", "Bell", "Diamond"};
            Random random = new Random();
            
            int bet = 10;
            BigInteger chips = 1000;
            
            do
            {
                int d3multi;
                int d2multi;
                int d1multi;
                int T7multi;
                int won3multi;
                int won2multi;

                //Multiplier per win type
                d3multi = 100;
                d2multi = 5;
                d1multi = 3;
                T7multi = 50;
                won3multi = 25;
                won2multi = 1;

                Console.WriteLine("Enhanced Slots by: Ian Williams");
                Console.WriteLine();
                Console.WriteLine($"You have {chips} chips");
                Console.WriteLine("Type your bet");

                string betinput = Console.ReadLine();
                Console.WriteLine();
                if (int.TryParse(betinput, out bet)) 
                {
                    if (chips >= bet)
                    {
                        bool won3;
                        won3 = false;
                        bool won2;
                        won2 = false;

                        bool D3;
                        D3 = false;
                        bool D2;
                        D2 = false;
                        bool D1;
                        D1 = false;

                        bool Won7;
                        Won7 = false;

                        string symbol1 = words[random.Next(0, words.Length)];
                        string symbol2 = words[random.Next(0, words.Length)];
                        string symbol3 = words[random.Next(0, words.Length)];

                        Console.Write($"{symbol1} ");
                        Thread.Sleep(1000);
                        Console.Write($"{symbol2} ");
                        Thread.Sleep(1500);
                        Console.Write($"{symbol3} ");
                        Console.WriteLine();
                        Thread.Sleep(1500);
                        chips -= bet;

                        if (symbol1.Equals("Diamond") && symbol2.Equals("Diamond") && symbol3.Equals("Diamond"))
                        {   //Jackpot
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("You got three diamonds!!!");
                            Console.ResetColor();
                            Console.WriteLine("Jackpot!!!");
                            Thread.Sleep(5000);
                            Console.Clear();
                            chips += bet * d3multi;
                            D3 = true;
                        }
                        if (symbol1.Equals("Diamond") && symbol2.Equals("Diamond") || symbol2.Equals("Diamond") && symbol3.Equals("Diamond") || symbol1.Equals("Diamond") && symbol3.Equals("Diamond"))
                        {   
                            if (D3 == false)
                            {
                                //Two Diamonds
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("You got two diamonds!!!");
                                Console.ResetColor();
                                Console.WriteLine("You Win!!!");
                                Thread.Sleep(2000);
                                Console.Clear();
                                chips += bet * d2multi;
                                D2 = true;
                            }
                        }
                        if (D3 == false && D2 == false)
                        {
                            if (symbol1.Equals("Diamond") || symbol2.Equals("Diamond") || symbol3.Equals("Diamond"))
                            {
                                //One Diamond
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("You got one diamond!");
                                Console.ResetColor();
                                Console.WriteLine("You Win!!!");
                                Thread.Sleep(2000);
                                Console.Clear();
                                chips += bet * d1multi;
                                D1 = true;
                            }
                        }
                        if (symbol1.Equals("Seven") && symbol2.Equals("Seven") && symbol3.Equals("Seven"))
                        {
                            //Triple seven
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("TRIPLE SEVEN!!!!");
                            Console.ResetColor();
                            Console.WriteLine("Big Win!!!");
                            Thread.Sleep(2000);
                            chips += bet * T7multi;
                            Won7 = true;
                        }
                        if (symbol1 == symbol2 && symbol2 == symbol3 && D3 == false && Won7 == false)
                        {
                            //Three of a kind
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Three of a kind!");
                            Console.ResetColor();
                            Console.WriteLine("Big Win!!!");
                            Thread.Sleep(2000);
                            Console.Clear();
                            chips += bet * won3multi;
                            won3 = true;
                        }
                        if (symbol1.Equals(symbol2) || symbol2.Equals(symbol3) || symbol3.Equals(symbol1) && won3 == false && D3 == false && D2 == false && D1 == false)
                        {   
                            if (won3 == false && D2 == false && D1 == false)
                            {
                                //Two of a kind A.K.A Mercy
                                Console.WriteLine();
                                Console.WriteLine("Two of a kind!");
                                Console.WriteLine("You got half your bet back");
                                Thread.Sleep(2000);
                                Console.Clear();
                                chips += bet * won2multi/2;
                                won2 = true;
                            }
                        }
                        if (won3 == false)
                        {
                            if (won2 == false && D3 == false && D2 == false && D1 == false)
                            {
                                //LOSE!!!!!
                                Console.WriteLine();
                                Console.WriteLine("You lose.");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid bet");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            } while (chips >= 1);
            if (chips <= 0)
            {
                Console.WriteLine("You lost all your chips at the casino");
                Thread.Sleep(2000);
                Console.WriteLine("For the sake of immersion imagine your life sucks now");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }
    }
}