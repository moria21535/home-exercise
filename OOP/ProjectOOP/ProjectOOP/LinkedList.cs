using System.Collections.Generic;

namespace ProjectOOP
{
    class LinkedList
    {
        public Node First { get; private set; }
        public Node Last { get; set; }
        private Node max;
        private Node min;

        public LinkedList()
        {
            First = null;
            Last = First;
            max = null;
            min = null;
        }

        public void Append(int value)
        {
            // If the list is empty
            if (Last == null)
            {
                Last = new Node(value);
                First = Last;

                max = Last;
                min = Last;
            }

            else
            {
                Last.Next = new Node(value);
                Last = Last.Next;

                if (value > max.Value)
                {
                    max = Last;
                }

                else if (value < min.Value)
                {
                    min = Last;
                }
            }
        }

        public void Prepend(int value)
        {
            First = new Node(value, First);

            if (Last == null)
            {
                Last = First;

                max = First;
                min = First;
            }

            else
            {
                if (value > max.Value)
                {
                    max = First;
                }

                else if (value < min.Value)
                {
                    min = First;
                }
            }  
        }

        public int Pop()
        {
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
                    Last = First;

                    max = First;
                    min = First;

                    return value;
                }
            }

            while (preLast.Next != Last)
            {
                preLast = preLast.Next;
            }

            value = Last.Value;
            preLast.Next = null;

            if (max == Last)
            {
                FindMax();
            }

            else if (min == Last)
            {
                FindMin();
            }

            Last = preLast;
            return value;
        }

        public int Unqueue()
        {
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
                    Last = First;

                    min = First;
                    max = First;

                    return value;
                }
            }

            value = First.Value;
            Node removeNode = First;
            First = First.Next;

            if (max == removeNode)
            {
                FindMax();
            }

            else if (min == removeNode)
            {
                FindMin();
            }

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

        private void FindMax()
        {
            Node p = First.Next;
            max = First;

            while (p != null)
            {
                if (p.Value > max.Value)
                {
                    max = p;
                }

                p = p.Next;
            }
        }

        private void FindMin()
        {
            Node p = First.Next;
            min = First;

            while (p != null)
            {
                if (p.Value < min.Value)
                {
                    min = p;
                }

                p = p.Next;
            }
        }

        public Node GetMaxNode()
        {
            return max;
        }

        public Node GetMinNode()
        {
            return min;
        }
    }
                 
}
