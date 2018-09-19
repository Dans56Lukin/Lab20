using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL1
{
    class Queue<T>
    {
        Node<T> head { get; set; }
        Node<T> tail { get; set; }
        int count { get; set; }

        //добавление в очередь
        public void Enqueue(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> tempNode = tail;
            tail = node;
            if (count == 0)
                head = tail;
            else
                tempNode.Next = tail;
            count++;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public string Delete()
        {
            if (count == 0)
                throw new InvalidOperationException();
            Node<T> g = head;
            string s = "";
            int i = 0;
            int k = 0;
            while (head != null)
            {
                if (Convert.ToInt32(head.Data) < 0)
                {
                    k = i;
                }
                head = head.Next;
                i++;
            }
            i = 0;
            head = g;
            while (head != null)
            {
                if (k == i)
                {
                    head = head.Next;
                }
                if (head != null)
                {
                    s = s + " " + Convert.ToInt32(head.Data);
                    head = head.Next;
                }
                i++;
            }
            return s;
        }
    }
}
