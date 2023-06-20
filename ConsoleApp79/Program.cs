using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public bool IsAvailable { get; set; }

    public Book(string title, string author, string genre)
    {
        Title = title;
        Author = author;
        Genre = genre;
        IsAvailable = true;
    }
}

class LibraryApp
{
    static List<Book> library = new List<Book>();

    static void Main()
    {
        Console.WriteLine("Welcome to Library Management App!");

        bool continueManaging = true;

        while (continueManaging)
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Add a new book");
            Console.WriteLine("2. Search for a book");
            Console.WriteLine("3. Borrow a book");
            Console.WriteLine("4. Return a book");
            Console.WriteLine("5. View all books");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    SearchBook();
                    break;
                case "3":
                    BorrowBook();
                    break;
                case "4":
                    ReturnBook();
                    break;
                case "5":
                    ViewBooks();
                    break;
                case "6":
                    continueManaging = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine("\nThank you for using the Library Management App!");
    }

    static void AddBook()
    {
        Console.WriteLine("\nEnter the details of the book:");
        Console.Write("Title: ");
        string title = Console.ReadLine();
        Console.Write("Author: ");
        string author = Console.ReadLine();
        Console.Write("Genre: ");
        string genre = Console.ReadLine();

        Book book = new Book(title, author, genre);
        library.Add(book);

        Console.WriteLine("\nBook added to the library.");
    }

    static void SearchBook()
    {
        Console.Write("\nEnter the title or author of the book: ");
        string searchQuery = Console.ReadLine();

        List<Book> searchResults = new List<Book>();

        foreach (Book book in library)
        {
            if (book.Title.ToLower().Contains(searchQuery.ToLower()) || book.Author.ToLower().Contains(searchQuery.ToLower()))
            {
                searchResults.Add(book);
            }
        }

        if (searchResults.Count > 0)
        {
            Console.WriteLine("\nSearch results:");
            foreach (Book book in searchResults)
            {
                Console.WriteLine($"Title: {book.Title}\nAuthor: {book.Author}\nGenre: {book.Genre}\nAvailability: {(book.IsAvailable ? "Available" : "Not Available")}\n");
            }
        }
        else
        {
            Console.WriteLine("\nNo books found matching the search criteria.");
        }
    }

    static void BorrowBook()
    {
        Console.Write("\nEnter the title of the book you want to borrow: ");
        string title = Console.ReadLine();

        bool bookFound = false;

        foreach (Book book in library)
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                if (book.IsAvailable)
                {
                    book.IsAvailable = false;
                    Console.WriteLine($"\nYou have borrowed the book '{book.Title}'. Enjoy your reading!");
                }
                else
                {
                    Console.WriteLine($"\nThe book '{book.Title}' is currently not available.");
                }

                bookFound = true;
                break;
            }
        }

        if (!bookFound)
        {
            Console.WriteLine("\nBook not found in the library.");
        }
    }

    static void ReturnBook()
    {
        Console.Write("\nEnter the title of the book you want to return: ");
        string title = Console.ReadLine();

        bool bookFound = false;

        foreach (Book book in library)
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                if (!book.IsAvailable)
                {
                    book.IsAvailable = true;
                    Console.WriteLine($"\nYou have returned the book '{book.Title}'. Thank you!");
                }
                else
                {
                    Console.WriteLine($"\nThe book '{book.Title}' is already available in the library.");
                }

                bookFound = true;
                break;
            }
        }

        if (!bookFound)
        {
            Console.WriteLine("\nBook not found in the library.");
        }
    }

    static void ViewBooks()
    {
        if (library.Count > 0)
        {
            Console.WriteLine("\nLibrary Books:");
            foreach (Book book in library)
            {
                Console.WriteLine($"Title: {book.Title}\nAuthor: {book.Author}\nGenre: {book.Genre}\nAvailability: {(book.IsAvailable ? "Available" : "Not Available")}\n");
            }
        }
        else
        {
            Console.WriteLine("\nThe library has no books currently.");
        }
    }
}
