using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalQA
{
    public class LibraryAccount
    {



        public Reader Owner; //The Account Owner
        public List<Book> LoanBooks; // Loand Books
        public List<Book> OrderdBooks; // Pre orderd books
        public double OwnerDebt;

        public LibraryAccount(Reader accountOwner)
        {
            LoanBooks = new List<Book>();
            OrderdBooks = new List<Book>();
            OwnerDebt = 0;
        }

        public bool loanBook(Book bookToLoan,Reader Owner)
        {
            //VALIDTION #1 - if the customer already has this book
            if (LoanBooks.Contains(bookToLoan))
            {
                throw new InvalidOperationException("Customer has this book already");
            }

            //VALIDTION #2 - if the costumer is a kid and the book is a adults book
            if (bookToLoan.Type == Book.BookType.AdultBook && Owner.Type == Reader.ReaderType.Kid)
            {
                throw new InvalidOperationException("This book is for adult, you are too young.");
            }

            //VALIDITION #3 - if the book status is out of the library 
            if (bookToLoan.Status == Book.BookStatus.OutLibrary)
            {
                throw new InvalidOperationException("This book is outside the library.");
            }

            //VALIDATION #4 - if the costumer is adult and the book is a kids book 
            if (bookToLoan.Type == Book.BookType.KidsBook && Owner.Type == Reader.ReaderType.Adult)
            {
                throw new InvalidOperationException("This book is for kids, you are old man. Please grow up.");
            }

            //VALIDATION #5 - if the costumer whos trying to order dont have more then 3 books in his Loans book list.
            if(LoanBooks.Count()>=3)
            {
                throw new InvalidOperationException("You have loand more then 3 Books, You are greedy.");
            }
            
            //VALIDATION #6 - if the costumer whos trying to loan have a Debt to the library.
            if(OwnerDebt<0)
            {
                throw new InvalidOperationException("You have a Debt to the library.");
            }


            LoanBooks.Add(bookToLoan);
            bookToLoan.Status = Book.BookStatus.OutLibrary;

            return true;
        }

        public bool returnBook(Book bookToReturn)
        {


            //VALIDATION #1 - if the costumer is trying to return a book he never toke.
            if (!LoanBooks.Contains(bookToReturn))
            {
                throw new InvalidOperationException("Book cannot be returnd since it was not taken");
            }

            LoanBooks.Remove(bookToReturn);
            bookToReturn.Status = Book.BookStatus.InLibrary;
            return true;
        }

        public bool orderBook(Book bookToOrder,Reader Owner)
        {
            //VALIDATION #1 - if the book status is not InLibrary or PreOrderd
            if (bookToOrder.Status == Book.BookStatus.OutLibrary)
            {
                throw new InvalidOperationException("The book cannot be orderd beacuse its outside the library.");
            }

            //VALIDATION #2 - if the costumer is a kid whos trying to order adult books.
            if (Owner.Type == Reader.ReaderType.Kid && bookToOrder.Type == Book.BookType.AdultBook)
            {
                throw new InvalidOperationException("This book is for adult you small baby");
            }

            //VALIDATION #3 -  if the costumer is adult whos trying to order kids books.
            if (Owner.Type == Reader.ReaderType.Adult && bookToOrder.Type == Book.BookType.KidsBook)
            {
                throw new InvalidOperationException("This book is for kids , please grow up!");
            }

            //VALIDATION #4 - if the costumer whos trying to order dont have more then 3 books in his Order book list.
            if (OrderdBooks.Count() >= 3)
            {
                throw new InvalidOperationException("You have orderd more then 3 Books, relax.");
            }

            //VALIDATION #5 - if the costumer whos trying to order have a Debt to the library.
            if (OwnerDebt < 0)
            {
                throw new InvalidOperationException("You have a Debt to the library.");
            }


            bookToOrder.Status = Book.BookStatus.PreOrderd;
            OrderdBooks.Add(bookToOrder);
            return true;
        }

        public bool cancelOrderBook(Book bookToCancel,Reader Owner)
        {
            //VALIDATION #1 - if the costumer has the book in his orderd books list.
            if (!OrderdBooks.Contains(bookToCancel))
            {
                throw new InvalidOperationException("you dont have this book in your order list.");
            }


            bookToCancel.Status = Book.BookStatus.InLibrary;
            OrderdBooks.Remove(bookToCancel);
            return true;
        }



    }
}
