﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02CSharpInlämningsuppgift
{
    public class Admin 
    {



        public static void Test()
        {
            Console.Clear();
            Console.WriteLine("You are in Admin class");


            Program prodDisplay = new Program();
            List<Products> productsList = prodDisplay.ReadProducts();

            for (int y = 0; y < productsList.Count; y++)
            {
                //Console.SetCursorPosition(30, y);
                Console.WriteLine(productsList[y]);
            }

            Console.WriteLine("hello");

            Console.ReadKey();
        }

    }
}
