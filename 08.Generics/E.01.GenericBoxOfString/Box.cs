using System;
using System.Collections.Generic;
using System.Text;

namespace E._01.GenericBoxOfString
{
    public class Box<T>
    {
        public List<T> Items { get; set; }

        public Box()
        {
            Items = new List<T>();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in Items)
            {
                stringBuilder.AppendLine($"{typeof(T)}: {item}");
            }

            return stringBuilder.ToString();
        }
    }
}
