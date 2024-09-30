using _02CSharpInlämningsuppgift.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;  // Make sure to include this namespace for file operations

namespace _02CSharpInlämningsuppgift.AdminFolder
{
    public class DeleteProduct
    {
        public static void DeleteProdcutFromList()
        {
            try
            {
                bool state = true;
                while (state)
                {

                    Console.Clear();
                    List<Products> productsList = ProdInfoReader.ReadProducts();
                    List<string> list = new List<string>();
                    string path = "../../../Files/Products.txt";
                    int horiz = 30;

                    Console.SetCursorPosition(horiz, 0);
                    Console.WriteLine("PLUs- Product - Price");
                    // display list of all product
                    foreach (string item in File.ReadAllLines(path))
                    {
                        list.Add(item);
                    }

                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.SetCursorPosition(horiz, i + 1);
                        Console.WriteLine(list[i]);
                    }

                    Console.SetCursorPosition(0, 0);
                    Console.Write("Enter PLU code: ");
                    string pluCode = Console.ReadLine();

                    // Read all lines from the file
                    string[] lines = File.ReadAllLines(path);

                    var filteredLines = lines.Where(line => !line.Contains(pluCode)).ToArray();
                    File.WriteAllLines(path, filteredLines);
                    Console.Clear();
                    Console.WriteLine("Product with PLU code " + pluCode + " has been removed or edited.");
                    Console.WriteLine("Press any key to return to menue...");
                    state = false;
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
            }
        }

    }

}



