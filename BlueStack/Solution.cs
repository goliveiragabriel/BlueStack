using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueStack
{
    public class Solution
    {
        static void Main(String[] args)
        {
            Stack stack = new Stack();
            //
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Min();
            //
            stack.Push(38);
            stack.Push(34);
            stack.Push(22);
            stack.Min();
            //
            stack.Push(1);
            stack.Push(0);
            stack.Min();
        }
    }
}
