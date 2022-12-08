using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    // что есть: очередь - указатели - сорт пузырьком
    // мне надо: указатели - дек - простая вставка
    internal class Deck
    {
        private Item head = null;
        private Item tail = null;
        public int size = 0;
        public static int N_op = 0;

        //добавляет в конец списка новый эл-т
        public void PushStart(int value) // 9
        {
            N_op += 4;
            Item item = new Item(value, head, null); // 1

            N_op += 2;
            if (size == 1) // 2
                tail = head;

            N_op += 2;
            if (head != null) // 2
                head.prev = item; // 2

            N_op += 2;
            head = item; // 1
            size++; // 1
        }

        public void PushEnd(int value) // 7
        {
            N_op += 3;
            Item item = new Item(value, null, tail); // 1

            N_op += 2;
            if (head == null) // 2
            {
                head = item;
            };

            N_op += 2;
            if (tail != null) // 2
            {
                tail.next = item;
            }

            N_op += 2;
            tail = item; // 1
            size++; // 1
        }

        //извлечение первого эл-та из начала списка
        public int PopStart() // 6
        {
            N_op += 2;
            if (head == null) 
            {
                throw new Exception($"Queue is empty!!!");
            }

            N_op += 2;
            int val = head.value; // 1
            head = head.next; // 1

            N_op += 2;
            if (size == 1) tail = null; // 2

            N_op += 1;

            size--; // 1
            N_op += 1;
            return val; // 1
        }

        public int PopEnd() // 7
        {
            if (tail == null)
            {
                throw new Exception("Queue is empty!!!");
            }
            
            N_op += 3;
            int val = tail.value; // 1
            tail.prev.next = null; // 1
            tail = tail.prev; // 1
            
            N_op += 3;
            if (size == 1) tail = null; // 2
            size--; // 1
            
            N_op += 1;
            return val; // 1
        }


        public int Get(int index) // 2 + n/2  * (13 + 2) + 2 + n/2  * (13 + 2) + 1 + 1 = 6 + n * 18
        {
            for (int i = 0; i < index; i++) // 2 + n/2 * (13 + 2)
            {
                PushEnd(PopStart()); // 13
            }

            N_op++;
            int val = head.value; // 1
            for (int i = index; i < size; i++) // 2 + n/2  * (13 + 2)
            {
                PushEnd(PopStart()); // 13
            }
            N_op += 1;
            return val; // 1
        }

        public void Set(int index, int newValue) // 2 + n/2 * (13 + 2) +  2 + n/2 * (13 + 2) + 1 = 5 + n * 18
        {
            for (int i = 0; i < index; i++) // 2 + n/2 * (13 + 2)
            {
                PushEnd(PopStart()); // 13
            }
            N_op += 1;
            head.value = newValue; // 1
            for (int i = index; i < size; i++) // 2 + n/2 * (13 + 2)
            {
                PushEnd(PopStart()); // 13
            }
        }


        public void Print()
        {
            Item current = head;
            while (current != null)
            {
                Console.Write(" " + current.value);
                current = current.next;
            }
        }

        public int GetNop()
        {
            return N_op;
        }
    }
}