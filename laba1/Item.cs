using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    internal class Item
    {
        public int value = 0; //само значение
        public Item next = null; //ссылка на след item
        public Item prev = null; //ссылка на пред item

        //базовый конструктор как класс, тк значение передается по ссылке. работа идет из области в памяти
        public Item(int value, Item next, Item prev)
        {
            this.value = value;
            this.next = next;
            this.prev = prev;
        }
    }
}
