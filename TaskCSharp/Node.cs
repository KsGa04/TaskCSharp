﻿namespace TaskCSharp
{
    public class Node
    {
        public char Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(char value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
}
