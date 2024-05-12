using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP
{
    class LinkedList
    {
        public Node First { get; private set; }
        public Node Last { get; set; }
        private List<Node> max;
        private List<Node> min;

        public LinkedList()
        {
            First = null;
            Last = First;
            max = new List<Node>();
            min = new List<Node>();
        }

        public void Append(int value)
        {
            // If the list is empty
            if (Last == null)
            {
                Last = new Node(value);
                First = Last;

                max.Add(Last);
                min.Add(Last);
            }

            else
            {
                Last.Next = new Node(value);
                Last = Last.Next;

                int maxLastIndex = max.Count - 1;
                int minLastIndex = min.Count - 1;
                if (value >= max[maxLastIndex].Value)
                {
                    max.Add(Last);
                }

                if (value <= min[minLastIndex].Value)
                {
                    min.Add(Last);
                }

            }

        }

        public void Prepend(int value)
        {
            First = new Node(value, First);

            if (Last == null)
            {
                Last = First;

                max.Add(First);
                min.Add(First);
            }

            else
            {
                int maxLastIndex = max.Count - 1;
                int minLastIndex = min.Count - 1;
                if (value >= max[maxLastIndex].Value)
                {
                    max.Add(First);
                }

                if (value <= min[minLastIndex].Value)
                {
                    min.Add(First);
                }
            }

            
        }

        public int Pop()
        {
            int maxLastIndex = max.Count - 1;
            int minLastIndex = min.Count - 1;
            if ((max.Count != 0) && (max[maxLastIndex] == Last))
            {
                max.RemoveAt(maxLastIndex);
            } 
            
            if ((min.Count != 0) && (min[minLastIndex] == Last))
            {
                min.RemoveAt(minLastIndex);
            }

            Node preLast = First;
            int value = -1;

            if (First == Last)
            {
                if (Last == null)
                {
                    return value;
                }

                else
                {
                    value = Last.Value;
                    First = null;
                    // First = First.Next;
                    Last = First;
                    return value;
                }
            }

            while (preLast.Next != Last)
            {
                preLast = preLast.Next;
            }


            value = Last.Value;
            preLast.Next = null;
            // preLast.Next = Last.Next;
            Last = preLast;
            return value;

        }

        public int Unqueue()
        {
            int maxLastIndex = max.Count - 1;
            int minLastIndex = min.Count - 1;
            if ((max.Count != 0) && (max[maxLastIndex] == First))
            {
                max.RemoveAt(maxLastIndex);
            }

            if ((min.Count != 0) && (min[minLastIndex] == First))
            {
                min.RemoveAt(minLastIndex);
            }

            int value = -1;

            if (First == Last)
            {
                if (First == null)
                {
                    return value;
                }

                else
                {
                    value = First.Value;
                    First = null;
                    // First = First.Next;
                    Last = First;
                    return value;
                }

            }

            value = First.Value;
            First = First.Next;
            return value;
        }

        public IEnumerable<int> ToList()
        {
            Node p = First;

            while (p != null)
            {
                yield return p.Value;
                p = p.Next;
            }
        }

        public bool IsCircular()
        {
            return Last.Next == First;
        }

        private Node Insert(Node pos, int val)
        {
            if (pos == null)
            {
                First = new Node(val, First);
                pos = First;
                return pos;
            }

            Node newnode = new Node(val, pos.Next);
            pos.Next = newnode;
            pos = newnode;
            return pos;

            //if (pos == null)
            //{
            //    Prepend(val);
            //    pos = First;
            //    return pos;
            //}

            //Append(val);
            //pos = Last;
            //return pos;
        }

        private void InsertIntoPartialSortedList(Node untilPos)
        {
            Node prev = null;
            Node pos = First;

            while ((pos != untilPos) && (untilPos.Value > pos.Value))
            {
                prev = pos;
                pos = pos.Next;

            }

            Insert(prev, untilPos.Value); 
        }

        private Node Remove(Node pos)
        {
            if (pos == First)
            {
                First = First.Next;
                pos = First;
                return pos;
            }

            Node prev = First;

            while (prev.Next != pos)
            {
                prev = prev.Next;
            }

            prev.Next = pos.Next;
            pos.Next = null;
            pos = prev.Next;
            return pos;

            //if (pos == First)
            //{
            //    Unqueue();
            //    pos = First;
            //    return pos;
            //}

            //Pop();
            //pos = Last.Next;
            //return pos;

        }

        public void Sort()
        {

            Node untilPos = First;
            while (untilPos != null)
            {
                InsertIntoPartialSortedList(untilPos);
                untilPos = Remove(untilPos);
            }

            Node p = First;
            while (p.Next != null)
            {
                p = p.Next;
            }

            Last = p;
        }

        public Node GetMaxNode()
        {
            if (max.Count != 0)
            {
                return max[max.Count - 1];
            }

            return null;
        }

        public Node GetMinNode()
        {
            if (min.Count != 0)
            {
                return min[min.Count - 1];
            }

            return null;
        }
    }
            
                   
}
