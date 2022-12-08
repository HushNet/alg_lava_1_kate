using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    internal class Program
    {

        public static int N_op = 0;

        static void Main(string[] args)
        {
            Deck deck = new Deck();


            deck.PushStart(2);
            deck.PushStart(5);
            deck.PushStart(6);
            deck.PushStart(3);
            deck.PushStart(3);
            deck.PushStart(1);
            deck.PushStart(0);
            
            InsertionSort(deck);
            
            deck.Print();

            Console.WriteLine();
            Console.WriteLine(deck.GetNop() + N_op);

            Console.ReadLine();
        }
        
        static void Swap(Deck deck, int i, int j)
        {
            N_op += 1;
            var temp = deck.Get(i);
            deck.Set(i, deck.Get(j));
            deck.Set(j, temp);
            
        }
        
        static void InsertionSort(Deck deck)
        {
            int x;
            int j;
            for (int i = 1; i < deck.size; i++) // 2 + n * (
            {
                N_op += 1;
                x = deck.Get(i); // 7 + n * 18 
                N_op += 1;
                j = i; // 1
                N_op += 2; 
                while (j > 0 && deck.Get(j-1) > x) // 
                {
                    Swap(deck, j, j - 1);
                    N_op += 1;
                    j -= 1;
                }
                deck.Set(j, x);
            }
        }
    }
}
