using System;

class LibraryManager
{
    // Maximum number of books in the library
    const int MaxBooks = 5;
    static string[] books = new string[MaxBooks];

    // Track borrowed books by user (max 3)
    const int MaxBorrowed = 3;
    static string[] borrowedBooks = new string[MaxBorrowed];

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Choose an action: add, remove, search, borrow, checkin, exit");
            string action = Console.ReadLine().ToLower();

            if (action == "add")
            {
                AddBook();
            }
            else if (action == "remove")
            {
                RemoveBook();
            }
            else if (action == "search")
            {
                SearchBook();
            }
            else if (action == "borrow")
            {
                BorrowBook();
            }
            else if (action == "checkin")
            {
                CheckInBook();
            }
            else if (action == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid action. Please type 'add', 'remove', 'search', 'borrow', 'checkin', or 'exit'.");
            }

            // Display the list of books
            DisplayBooks();
            DisplayBorrowedBooks();
        }
    }

    // Adds a book to the first available slot
    static void AddBook()
    {
        int emptyIndex = Array.FindIndex(books, string.IsNullOrEmpty);
        if (emptyIndex == -1)
        {
            Console.WriteLine("The library is full. No more books can be added.");
            return;
        }
        Console.WriteLine("Enter the title of the book to add:");
        string newBook = Console.ReadLine();
        books[emptyIndex] = newBook;
    }

    // Removes a book by title
    static void RemoveBook()
    {
        if (Array.TrueForAll(books, string.IsNullOrEmpty))
        {
            Console.WriteLine("The library is empty. No books to remove.");
            return;
        }
        Console.WriteLine("Enter the title of the book to remove:");
        string removeBook = Console.ReadLine();
        int bookIndex = Array.FindIndex(books, b => b == removeBook);
        if (bookIndex != -1)
        {
            books[bookIndex] = "";
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    // Search for a book by title
    static void SearchBook()
    {
        Console.WriteLine("Enter the title of the book to search:");
        string searchTitle = Console.ReadLine();
        bool found = Array.Exists(books, b => b == searchTitle);
        if (found)
        {
            Console.WriteLine($"'{searchTitle}' is available in the library.");
        }
        else
        {
            Console.WriteLine($"'{searchTitle}' is not in the collection.");
        }
    }

    // Borrow a book (limit to 3 at a time)
    static void BorrowBook()
    {
        int borrowedCount = Array.FindAll(borrowedBooks, b => !string.IsNullOrEmpty(b)).Length;
        if (borrowedCount >= MaxBorrowed)
        {
            Console.WriteLine("You have reached the borrowing limit (3 books). Return a book before borrowing another.");
            return;
        }
        Console.WriteLine("Enter the title of the book to borrow:");
        string borrowTitle = Console.ReadLine();
        int bookIndex = Array.FindIndex(books, b => b == borrowTitle);
        if (bookIndex == -1)
        {
            Console.WriteLine("Book not found in the library.");
            return;
        }
        // Check if already borrowed
        if (Array.Exists(borrowedBooks, b => b == borrowTitle))
        {
            Console.WriteLine("You have already borrowed this book.");
            return;
        }
        // Mark as borrowed (remove from library, add to borrowed)
        books[bookIndex] = "";
        int emptyBorrowIndex = Array.FindIndex(borrowedBooks, string.IsNullOrEmpty);
        borrowedBooks[emptyBorrowIndex] = borrowTitle;
        Console.WriteLine($"You have borrowed '{borrowTitle}'.");
    }

    // Check in a borrowed book
    static void CheckInBook()
    {
        Console.WriteLine("Enter the title of the book to check in:");
        string checkinTitle = Console.ReadLine();
        int borrowedIndex = Array.FindIndex(borrowedBooks, b => b == checkinTitle);
        if (borrowedIndex == -1)
        {
            Console.WriteLine("This book is not currently checked out.");
            return;
        }
        // Find empty slot in library
        int emptyIndex = Array.FindIndex(books, string.IsNullOrEmpty);
        if (emptyIndex == -1)
        {
            Console.WriteLine("The library is full. Cannot check in the book.");
            return;
        }
        books[emptyIndex] = checkinTitle;
        borrowedBooks[borrowedIndex] = "";
        Console.WriteLine($"You have checked in '{checkinTitle}'.");
    }

    // Displays all available books
    static void DisplayBooks()
    {
        Console.WriteLine("Available books:");
        bool anyBook = false;
        foreach (var book in books)
        {
            if (!string.IsNullOrEmpty(book))
            {
                Console.WriteLine(book);
                anyBook = true;
            }
        }
        if (!anyBook)
        {
            Console.WriteLine("(none)");
        }
    }

    // Display borrowed books
    static void DisplayBorrowedBooks()
    {
        Console.WriteLine("Your borrowed books:");
        bool anyBorrowed = false;
        foreach (var book in borrowedBooks)
        {
            if (!string.IsNullOrEmpty(book))
            {
                Console.WriteLine(book);
                anyBorrowed = true;
            }
        }
        if (!anyBorrowed)
        {
            Console.WriteLine("(none)");
        }
    }
}