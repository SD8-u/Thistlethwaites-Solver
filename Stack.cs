using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubik_s_Cube
{
    public class Stack<T>
    {
        private int topOfStack;
        private T[] stackArray;
        public Stack(int maxSize)
        {
            stackArray = new T[maxSize];
            topOfStack = -1;
        }

        public bool isStackEmpty()
        {
            return topOfStack == -1;
        }

        //Controls the addition of items to the stack
        public void Push(T item)
        {
            //The pointer is incremented
            topOfStack++;
            if(topOfStack != stackArray.Length)
            {
                stackArray[topOfStack] = item;
            }
            else
            {
                //An error is output if an attempt is made to over-fill the stack
                topOfStack--;
                throw new InvalidOperationException("Cannot execute operation. Stack is full.");
            }
        }

        //If Pop is executed, the top item is removed and returned
        public T Pop()
        {
            topOfStack--;
            if(topOfStack != -2)
            {
                return stackArray[topOfStack + 1];
            }
            else
            {
                //Similarly an error is returned if the stack is empty.
                topOfStack++;
                throw new InvalidOperationException("Cannot execute operation. Stack is empty.");
            }
        }

        //Peek enables the top item to be returned without removing it from the stack
        public T Peek()
        {
            if(topOfStack != -1)
            {
                return stackArray[topOfStack];
            }
            else
            {
                throw new InvalidOperationException("Cannot execute operation. Stack is empty.");
            }
        }
    }
}
