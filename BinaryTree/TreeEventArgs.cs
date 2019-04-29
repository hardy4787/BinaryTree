using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class TreeEventArgs<T>
    {
        public string Message { get; }
        public T Item { get; }
        public TreeEventArgs(T item, string Message)
        {
            this.Item = item;
            this.Message = Message;
        }
        public TreeEventArgs() { }
        public override string ToString()
        {
            return Message;
        }
    }
}
