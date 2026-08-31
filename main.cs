using System;
using System.Runtime.InteropServices;

namespace mainTeaRex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, TeaRex!");
            [DLLImport(@"E:\Projects\tea_rex\programopen.cs")];
            static extern void openProgram();
        }
    }
}