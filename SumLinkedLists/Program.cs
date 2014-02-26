using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumLinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list1 = new LinkedList<int>();

            list1.AddLast(1);
            list1.AddLast(2);
            list1.AddLast(3);

            LinkedList<int> list2 = new LinkedList<int>();

            list2.AddLast(4);

            LinkedList<int> result = Sum(list1, list2);
            //LinkedList<int> result = SumWithSingleLinkedList(list1, list2);

            LinkedListNode<int> node = result.First;

            while (node != null)
            {
                Console.Write(node.Value + " ");
                node = node.Next;
            }
        }

        static LinkedList<int> SumWithSingleLinkedList(LinkedList<int> list1, LinkedList<int> list2)
        {
            LinkedList<int> output = new LinkedList<int>();

            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();

            LinkedListNode<int> current1 = list1.First;
            LinkedListNode<int> current2 = list2.First;

            bool IsCarryPresent = false;

            while (current1 != null)
            {
                stack1.Push(current1.Value);
                current1 = current1.Next;
            }

            while (current2 != null)
            {
                stack2.Push(current2.Value);
                current2 = current2.Next;
            }

            while (stack1.Count > 0 && stack2.Count > 0)
            {
                int sum = stack1.Pop() + stack2.Pop();

                if (IsCarryPresent)
                {
                    sum++;
                }

                if (sum / 10 > 0)
                {
                    IsCarryPresent = true;
                }
                else
                {
                    IsCarryPresent = false;
                }

                output.AddFirst(sum % 10);
            }

            if (stack1.Count > 0)
            {
                CopyRemainingNodes(stack1, output, IsCarryPresent);
            }
            else if (stack2.Count > 0)
            {
                CopyRemainingNodes(stack2, output, IsCarryPresent);
            }
            else
            {
                if (IsCarryPresent)
                {
                    output.AddFirst(1);
                }
            }

            return output;
        }

        private static void CopyRemainingNodes(Stack<int> stack, LinkedList<int> output, bool IsCarryPresent)
        {
            while (stack.Count > 0)
            {
                int sum = 0;
                sum = stack.Pop();

                if (IsCarryPresent)
                {
                    sum++;
                }

                if (sum / 10 > 0)
                {
                    IsCarryPresent = true;
                }
                else
                {
                    IsCarryPresent = false;
                }

                output.AddFirst(sum % 10);
            }

            if (IsCarryPresent)
            {
                output.AddFirst(1);
            }
        }

        static LinkedList<int> Sum(LinkedList<int> list1, LinkedList<int> list2)
        {
            bool IsCarryPresent = false;

            LinkedList<int> output = new LinkedList<int>();

            LinkedListNode<int> current1 = list1.Last;

            LinkedListNode<int> current2 = list2.Last;

            while (current1 != null && current2 != null)
            {
                int sum = current1.Value + current2.Value;

                if (IsCarryPresent)
                {
                    sum++;
                }

                if (sum / 10 > 0)
                {
                    IsCarryPresent = true;
                }
                else
                {
                    IsCarryPresent = false;
                }

                output.AddFirst(sum % 10);

                current1 = current1.Previous;
                current2 = current2.Previous;
            }

            if (current1 != null)
            {
                CopyRemainingNodes(current1, output, IsCarryPresent);
            }
            else if (current2 != null)
            {
                CopyRemainingNodes(current2, output, IsCarryPresent);
            }
            else
            {
                // If carry is still present then create a new node
                if (IsCarryPresent)
                {
                    output.AddFirst(1);
                }
            }

            return output;
        }

        private static void CopyRemainingNodes(LinkedListNode<int> current, LinkedList<int> output, bool IsCarryPresent)
        {
            while (current != null)
            {
                int sum = current.Value;

                if (IsCarryPresent)
                {
                    sum++;
                }

                if (sum / 10 > 0)
                {
                    IsCarryPresent = true;
                }
                else
                {
                    IsCarryPresent = false;
                }

                output.AddFirst(sum % 10);

                current = current.Previous;
            }

            if (IsCarryPresent)
            {
                output.AddFirst(1);
            }
        }
    }
}
