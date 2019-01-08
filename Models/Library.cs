using System;
using System.Collections.Generic;

namespace console_library.Models
{
    public class Library
    {
        public string Name { get; private set; }
        public List<Book> Books { get; set; }

        public List<Book> CheckedOut { get; set; }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }


        public Library(string name)
        {
            Name = name; 
            Books = new List<Book>();
            CheckedOut = new List<Book>();
        }

         public void PrintBooks()
        {
            for (int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine($"{i+1} {Books[i].Title} - {Books[i].Author}");
            }
           
        }
        
        public void PrintCheckedOut()
        {
             for (int i = 0; i < CheckedOut.Count; i++)
            {
                Console.WriteLine($"{i+1} {CheckedOut[i].Title} - {CheckedOut[i].Author}");
            }
        }

        private Book ValidateUserSelection(string selection, List<Book> bookList)
        {
            int bookIndex;
            bool valid = Int32.TryParse(selection, out bookIndex);
            if (!valid || bookIndex < 0 || bookIndex > bookList.Count)
            {
                Console.Clear();
                System.Console.WriteLine("please make a valid selection");
                return null;
            }
            return bookList[bookIndex-1];
        }

        public void Checkout(string selection)
        {
            Book selectedBook = ValidateUserSelection(selection, Books);
            
            if (selectedBook == null)
            {
                Console.Clear();
                System.Console.WriteLine("Invalid Selection");
                return;
            }
            if (!selectedBook.Available)
            {
                System.Console.WriteLine($"{selectedBook.Title} isn't available. sorry.");
            }
            else 
            {
                selectedBook.Available = false;
                CheckedOut.Add(selectedBook);
                Books.Remove(selectedBook);
                Console.WriteLine("Checked Out!");
            }
        }

        public void ReturnBook(string selection)
        {
            Book selectedBook = ValidateUserSelection(selection, CheckedOut);
            if (selectedBook == null)
            {
                System.Console.WriteLine("Invalid Selection, please make a valid selection!");
                return;
            }
            if (selectedBook.Available)
            {
                System.Console.WriteLine($"That must be your copy of {selectedBook.Title}.");
                return;
            }
            selectedBook.Available = true;
            Books.Add(selectedBook);
            CheckedOut.Remove(selectedBook);
            Console.Clear();
            System.Console.WriteLine("Successfully Returned Book!");

    
        }
    }




    }