using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20.Graf
{
    public class MyStack
    {
        Node top;
        Node tail;

        public MyStack()                  // конструктор
        {
            top = null; tail = null;
        }

        public void Push(object data)     // положить в стек
        {
            top = new Node(top, data);
            if (top.next == null)
                tail = top;
        }

        public void Clear()
        {
            top = null; tail = null;
        }

        public object Pop()               // взять из стека
        {
            if (top == null) throw new
                InvalidOperationException();
            object result = top.data;
            top = top.next;
            return result;
        }

        public bool isEmpty()             // проверка на пустоту
        {
            return top == null;
        }

        public class Node                 // узел
        {
            public Node next;
            public object data;
            public Node(Node next, object data)// конструктор
            {
                this.next = next;
                this.data = data;
            }
        }

        public void PushQueue(object inf) // положить в хвост очереди
        {
            Node p = new Node(null, inf);
            if (isEmpty())
            {
                top = p; tail = p;
            }
            else
            {
                tail.next = p; tail = p;
            }
        }

        public string StackToStr()
        {
            string result = "";
            while (!isEmpty())
                result += Convert.ToString(Pop()) + " ";
            return result;
        }
    }
}
