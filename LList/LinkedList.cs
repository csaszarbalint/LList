using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LList
{
    public class LinkedMember<T>
    {
        public T Data { get; set; }
        public LinkedMember<T> Next { get; set; }
        public LinkedMember<T> Previous { get; set; }
    }

    public class LinkedList<T>
    {
        public LinkedMember<T> Head { get; private set; }

        public LinkedMember<T> Tail { get; private set; }

        public int Length { get; private set; }

        public LinkedList()
        {
            Head = null;
            Tail = null;
            Length = 0;
        }

        #region LinkedMember handling
        private LinkedMember<T> GetMemberAt(int index)
        {
            LinkedMember<T> member = null;

            if (index < 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            if (index < Length / 2)
            {
                member = Head;
                while (index != 0 && member.Next != null)
                {
                    member = member.Next;
                    index--;
                }
            }
            else
            {
                member = Tail;
                while (index < Length-1 && member.Previous != null)
                {
                    member = member.Previous;
                    index++;
                }
            }

            return member;
        }
        private LinkedMember<T> SearchMember(Predicate<LinkedMember<T>> action, out int index)
        {
            var member = Head;
            index = -1;
            int count = 0;
            if (member != null)
            {
                var hasFound = false;
                do
                {
                    if (action(member) == true)
                    {
                        hasFound = true;
                        break;
                    }
                    member = member.Next;
                    count++;
                } while (member.Next != null);

                if (hasFound)
                {
                    index = count;
                }
                else
                {
                    member = null;
                }
            }

            return member;
        }
        private void RemoveMember(LinkedMember<T> member)
        {
            if (member != null)
            {
                if (member == Head)
                {
                    Head = member.Next;
                    Head.Previous = null;
                }
                else if (member == Tail)
                {
                    Tail = member.Previous;
                    Tail.Next = null;
                }
                else
                {
                    var prev = member.Previous;
                    var next = member.Next;
                    prev.Next = next;
                    next.Previous = prev;
                }
                Length--;
            }
        }
        #endregion

        public void Add(T data)
        {
            Insert(-1, data);
        }
        public void Insert(int index, T data)
        {
            if (Head == null)
            {
                if (index == -1 || index == 0)
                {
                    Head = new LinkedMember<T>
                    {
                        Data = data,
                        Previous = null,
                        Next = null
                    };
                    Tail = Head;
                    Length++;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                var member = new LinkedMember<T> { Data = data };
                if (index == 0)
                {
                    member.Previous = null;
                    member.Next = Head;
                    Head.Previous = member;
                    Head = member;
                }
                else if (index == -1)
                {
                    member.Next = null;
                    member.Previous = Tail;
                    Tail.Next = member;
                    Tail = member;
                }
                else
                {
                    var prev = GetMemberAt(index);
                    var next = prev.Next;
                    member.Previous = prev;
                    member.Next = next;
                    prev.Next = member;
                    next.Previous = member;
                }
                Length++;
            }
        }
        public void Remove(T item)
        {
            var member = SearchMember(m => m.Data.Equals(item), out _);
            RemoveMember(member);
        }
        public T RemoveAt(int index)
        {
            var member = GetMemberAt(index);
            RemoveMember(member);
            return member.Data;
        }
        public T Get(int index)
        {
            var member = GetMemberAt(index);
            return member != null ? member.Data : default;
        }

        public T Search(Predicate<T> predicate)
        {
            var member = SearchMember(m => predicate(m.Data), out _);
            return member != null ? member.Data : default;
        }

        public int IndexOf(T data)
        {
            SearchMember(m => m.Data.Equals(data), out var ix);
            return ix;
        }

        public void ForEach(Action<T> action)
        {
            var member = Head;
            if (member != null)
            {
                while (true)
                {
                    action(member.Data);
                    if (member.Next == null) break;
                    member = member.Next;
                }
            }
        }

        public List<T> ToList()
        {
            var list = new List<T>();
            ForEach(t => list.Add(t));
            return list;
        }

        public override string ToString()
        {
            return string.Join(", ", ToList());
        }
    }
}
