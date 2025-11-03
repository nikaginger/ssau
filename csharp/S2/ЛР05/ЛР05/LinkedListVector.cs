using LR_5;
using System;

namespace LR_5
{
    [Serializable]
    class LinkedListVector : IVectorable, IComparable, ICloneable
    {

        private Node start;

        [Serializable]
        public class Node
        {
            public int value = 0;
            public Node link = null;
        }

        public LinkedListVector()
        {
            start = new Node();
            Node curNode = start;
            for (int i = 0; i < 4; i++)
            {
                curNode.link = new Node();
                curNode = curNode.link;
            }
        }
        public LinkedListVector(int len)
        {
            start = new Node();
            Node curNode = start;
            for (int i = 0; i < len - 1; i++)
            {
                curNode.link = new Node();
                curNode = curNode.link;
            }
        }

        public int this[int index]
        {
            get
            {
                if (0 <= index && index <= Length)
                {
                    Node curNode = start;
                    for (int i = 0; i < index; i++)
                    {
                        curNode = curNode.link;
                    }
                    return curNode.value;
                }
                else
                {
                    throw new Exception("Vector index out of range");
                }
            }
            set
            {
                if (0 <= index && index <= Length)
                {
                    Node curNode = start;
                    for (int i = 0; i < index; i++)
                    {
                        curNode = curNode.link;
                    }
                    curNode.value = value;
                }
                else
                {
                    throw new Exception("Vector index out of range");
                }
            }
        }

        public int Length
        {
            get
            {
                if (start == null)
                {
                    return -1;
                }
                int length = 1;
                Node curNode = start;
                while (curNode.link != null)
                {
                    curNode = curNode.link;
                    length++;
                }
                return length;
            }
            set {; }
        }

        public double GetNorm()
        {
            double norm = 0;
            Node curNode = start;
            for (int i = 0; i < Length; i++)
            {
                norm += Math.Pow(curNode.value, 2);
                curNode = curNode.link;
            }
            return Math.Sqrt(norm);
        }

        public void AddTop(int newElemValue)
        {
            Node temp = new Node();
            temp.value = newElemValue;
            temp.link = start;
            start = temp;
        }

        public void AddEnd(int newElemValue)
        {
            Node curNode = start;
            while (curNode.link != null)
            {
                curNode = curNode.link;
            }
            curNode.link = new Node();
            curNode.link.value = newElemValue;
        }

        public void AddByIndex(int index, int newElemValue)
        {
            if (0 <= index && index <= Length)
            {
                Node curNode = start;
                for (int i = 0; i < index - 1; i++)
                {
                    curNode = curNode.link;
                }
                Node temp = new Node();
                temp.value = newElemValue;
                temp.link = curNode.link;
                curNode.link = temp;
            }
            else
            {
                throw new Exception("Vector index out of range");
            }
        }

        public void DeleteTop()
        {
            start = start.link;
        }

        public void DeleteEnd()
        {
            Node curNode = start;
            for (int i = 0; i < Length - 2; i++)
            {
                curNode = curNode.link;
            }
            curNode.link = null;
        }

        public void DeleteByIndex(int index)
        {
            if (0 <= index && index <= Length)
            {
                Node curNode = start;
                for (int i = 0; i < index - 2; i++)
                {
                    curNode = curNode.link;
                }
                curNode.link = curNode.link.link;
            }
            else
            {
                throw new Exception("Vector index out of range");
            }
        }

        public override string ToString()
        {
            string res = Convert.ToString(Length) + ' ';
            for (int i = 0; i < Length; i++)
            {
                res += Convert.ToString(this[i]) + ' ';
            }
            return res;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() is IVectorable || Length != ((IVectorable)obj).Length)
            {
                return false;
            }
            Node cureNode = start;
            for (int i = 0; i < Length; i++)
            {
                if (cureNode.value != ((IVectorable)obj)[i]) return false;
                cureNode = cureNode.link;
            }
            return true;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is IVectorable))
            {
                throw new Exception("Object is not IVectorable");
            }
            else
            {
                if (Length < ((IVectorable)obj).Length)
                {
                    return -1;
                }
                else if (Length > ((IVectorable)obj).Length)
                {
                    return 1;
                }
                return 0;
            }
        }

        public Object Clone()
        {
            LinkedListVector clone = new LinkedListVector(Length);
            Node curNode = start;
            for (int i = 0; i < Length; i++)
            {
                clone[i] = curNode.value;
                curNode = curNode.link;
            }
            return clone;
        }
    }
}


