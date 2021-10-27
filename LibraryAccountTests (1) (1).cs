using FinalQA;
using NUnit.Framework;

namespace QaFinal.NunitTest
{
  
    [TestFixture]
    public class LibraryAccountTests
    {
        [Timeout(50)]
        [Test]
        public void loanBook_AvailableBook_returnsTrue()
        {
            // Arrange
            Reader testCustomer = new Reader("Some", "One", Reader.ReaderType.Kid);
            LibraryAccount testLibraryAccount = new LibraryAccount(testCustomer);
            Book bookToLoan = new Book("A-597", Book.BookType.KidsBook, Book.BookStatus.InLibrary);

            //Act
            bool ActualResult = testLibraryAccount.loanBook(bookToLoan, testCustomer);


            //Assert
            Assert.That(ActualResult && testLibraryAccount.LoanBooks.Contains(bookToLoan), Is.True, "LoanBook func is wrong");
        }


        [Test]

        public void orderdBook_InLibrary_returnsTrue()
        {
            // Arrange
            Reader testCustomer = new Reader("Haim", "Shaim", Reader.ReaderType.Kid);
            LibraryAccount testLibraryAccount = new LibraryAccount(testCustomer);
            Book bookToOrder = new Book("Jungle Dreams", Book.BookType.KidsBook, Book.BookStatus.InLibrary);

            //Act
            bool ActualResult = testLibraryAccount.orderBook(bookToOrder, testCustomer);


            //Assert
            Assert.That(ActualResult && testLibraryAccount.OrderdBooks.Contains(bookToOrder), Is.True,"OrderBook func is wrong");
                
                
               
        }


        [Test]
        
        public void CancelOrder_BookInOrders_returnsTrue()
        {
            // Arrange
            Reader testCustomer = new Reader("Kruv", "Magnuv", Reader.ReaderType.Adult);
            LibraryAccount testLibraryAccount = new LibraryAccount(testCustomer);
            Book bookToCancel = new Book("Refael", Book.BookType.KidsBook, Book.BookStatus.OutLibrary);
            testLibraryAccount.OrderdBooks.Add(bookToCancel);


            //Act
            bool ActualResult = testLibraryAccount.cancelOrderBook(bookToCancel, testCustomer);


            //Assert
         
            Assert.That(ActualResult && !(testLibraryAccount.OrderdBooks.Contains(bookToCancel)), Is.True, "CancelBook func is wrong");
        }
    }
}
