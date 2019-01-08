using System;
using console_library.Models;

namespace console_library
{
    class Program
    {
        public enum Menus
        {
            CheckoutBook,
            ReturnBook

        }
        static void Main(string[] args)
        {
            Book becoming = new Book("Becoming", "Michelle Obama");
            Book wta = new Book("Winners Take All", "Anand Giridharadas");
            Library myLibrary = new Library("Aubrey's Library");
           
            Console.Clear();
            Console.WriteLine("Welcome to the Library!");

            bool inLibrary = true;
            Enum activeMenu = Menus.CheckoutBook;

            myLibrary.AddBook(becoming);
            myLibrary.AddBook(wta);

            while (inLibrary)
            {
                switch (activeMenu)
                {
                    case Menus.CheckoutBook:
                        myLibrary.PrintBooks();
                        break;
                    case Menus.ReturnBook:
                        myLibrary.PrintCheckedOut();
                        break;
                }

                string selection = Console.ReadLine();
                // myLibrary.Checkout(selection);

                switch (selection)
                {
                    case "return":
                        Console.Clear();
                        activeMenu = Menus.ReturnBook;
                        break;
                    case "available":
                        Console.Clear();
                        activeMenu = Menus.CheckoutBook;
                        break;
                    default:
                        if (activeMenu.Equals(Menus.CheckoutBook))
                        {
                            myLibrary.Checkout(selection);
                        }
                        else
                        {
                            myLibrary.ReturnBook(selection);
                        }
                        break;
                }

                Console.WriteLine("\nAvailable Books:");
               


            }

        }
    }
}
