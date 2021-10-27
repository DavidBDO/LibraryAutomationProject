using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalQA
{
    class Program
    {
        static void Main(string[] args)
        {

            Reader testCustomer = new Reader("Some", "One", Reader.ReaderType.Kid);
            LibraryAccount testLibraryAccount = new LibraryAccount(testCustomer);
            Book bookToLoan = new Book("A-597", Book.BookType.KidsBook, Book.BookStatus.InLibrary);
            Console.WriteLine(testLibraryAccount.loanBook(bookToLoan, testCustomer));

        }
    }
}
