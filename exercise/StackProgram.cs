using System;
using System.Collections.Generic;

namespace InheritanceExercise
{
    public class Stack
    {
        private readonly List<object> _stack;

        public Stack()
        {
            _stack = new List<object>();
        }
        public void Push(object obj)
        {
            if (obj == null)
            {
                throw new InvalidOperationException("Cannot add null object to stack!");
            }

            _stack.Add(obj);
        }

        public object Pop()
        {
            if (_stack.Count == 0)
            { 
                throw new InvalidOperationException("Stack is empty!");
            }

            var lastIdx = _stack.Count - 1;
            var obj = _stack[lastIdx];
            _stack.RemoveAt(lastIdx);

            return obj;
        }
        public void Clear()
        {
            _stack.Clear();
        }
    }
    class StackProgram
    {
        public static void Main(string[] args)
        {
            var stack = new Stack();
            var minVal = 0;
            var maxVal = 5;

            for (var i = minVal; i <= maxVal; i++)
                stack.Push(i);

            for (var i = minVal; i <= maxVal; i++)
                Console.WriteLine(stack.Pop());

            stack.Clear();

            for (var i = minVal; i <= maxVal; i++)
                Console.WriteLine(stack.Pop());
        }
    }
}