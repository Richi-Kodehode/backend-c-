
Console.WriteLine("Starting Renting Service");

RentingService rentingService = new RentingService();

while (true)
{
  string? input = Console.ReadLine();
  if (input == null)
  {
    Environment.Exit(1);
  }

  switch (input)
  {
    case "list":
      Dictionary<Book, int> availableBooks = rentingService.ListAllBooks();
      foreach (var bookEntry in availableBooks)
      {
        Console.WriteLine(bookEntry.Key.Title);
      }
      break;
    case "borrow":
      string? bookTitleInput = Console.ReadLine();
      if (bookTitleInput == null)
      {
        Environment.Exit(1);
      }

      BorrowReciept? reciept = rentingService.BorrowBook(bookTitleInput);

      if (reciept == null)
      {
        Console.WriteLine($"No book with title {bookTitleInput} found");
      }
      else
      {
        Console.WriteLine($"Rental active. Please return it by: {reciept.DueDate}");
      }

      break;
    case "return":
        Console.WriteLine("Enter the title of the book you want to return:");
        string? returnBookTitleInput = Console.ReadLine();

        if (returnBookTitleInput == null)
        {
            Environment.Exit(1);
        }

        ReturnReciept? returnReciept = rentingService.ReturnBook(returnBookTitleInput);

        if (returnReciept == null)
        {
            Console.WriteLine($"No active rental found for book '{returnBookTitleInput}'.");
        }
        else
        {
            Console.WriteLine($"Book '{returnBookTitleInput}' returned successfully on {returnReciept.BookTitle}");
        }
        break;
    default:
      Console.WriteLine("Invalid Input");
      break;
  }
}
