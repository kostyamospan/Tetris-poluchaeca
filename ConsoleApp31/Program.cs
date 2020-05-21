﻿using System;

namespace ConsoleApp67
{
    class Program
    {

        static void Main(string[] args)
        {
            var handler = new KeyboardLayoutEvents();

            handler.OnLeftArrowPressed += (sender,arg) => Console.WriteLine("Left button pressed");
            handler.OnRightArrowPressed += (sender,arg) => Console.WriteLine("Right button pressed");
            handler.OnUpArrowPressed += (sender,arg) => Console.WriteLine("Up button pressed");
            handler.OnDownArrowPressed += (sender,arg) => Console.WriteLine("Down button pressed");

            do
            {

            } while (true);     
        }
    }
}