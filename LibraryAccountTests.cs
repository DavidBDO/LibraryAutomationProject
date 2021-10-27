using FinalQA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace FinalQa.MsTest
{
    [TestClass]
    public class LibraryAccountTests
    {
        

        [TestMethod]
        public void loanBook_AvailableBook_returnsTrue()    //�������� ����� ��� ���� ���� ������ ����� ������
        {
            // Arrange
            Reader testCustomer = new Reader("Some", "One", Reader.ReaderType.Kid);
            LibraryAccount testLibraryAccount = new LibraryAccount(testCustomer);
            Book bookToLoan = new Book("A-597", Book.BookType.KidsBook, Book.BookStatus.InLibrary);

            //Act
            bool ActualResult = testLibraryAccount.loanBook(bookToLoan, testCustomer);


            //Assert
            Assert.IsTrue(ActualResult && testLibraryAccount.LoanBooks.Contains(bookToLoan), "LoanBook func is wrong");
        }



        [TestMethod]
        public void loanBook_BookOutsideLibrary_returnTrue() //��� ���� ���� ������
        
        {
            // Arrange
            Reader testCustomer = new Reader("Some", "One", Reader.ReaderType.Kid);
            LibraryAccount testLibraryAccount = new LibraryAccount(testCustomer);
            Book bookToLoan = new Book("A-597", Book.BookType.KidsBook, Book.BookStatus.OutLibrary);

            //Act&Assert

            Assert.ThrowsException<System.InvalidOperationException>(() => testLibraryAccount.loanBook(bookToLoan, testCustomer));
            
        }


        [TestMethod]
        public void loanBook_OwnerHaveMoreThan_3_Books_returnTrue() //��� ����� �� ���� �3 ����� ������ ������� ���

        {
            // Arrange
            Reader testCustomer = new Reader("Some", "One", Reader.ReaderType.Kid);
            LibraryAccount testLibraryAccount = new LibraryAccount(testCustomer);
            Book bookToLoan1 = new Book("A-597", Book.BookType.KidsBook, Book.BookStatus.InLibrary);
            Book bookToLoan2 = new Book("B-333", Book.BookType.KidsBook, Book.BookStatus.InLibrary);
            Book bookToLoan3 = new Book("C-597", Book.BookType.KidsBook, Book.BookStatus.InLibrary);
            Book bookToLoan4 = new Book("D-597", Book.BookType.KidsBook, Book.BookStatus.InLibrary);
            testLibraryAccount.LoanBooks.Add(bookToLoan1);
            testLibraryAccount.LoanBooks.Add(bookToLoan2);
            testLibraryAccount.LoanBooks.Add(bookToLoan3);

            // Act&Assert

            Assert.ThrowsException<System.InvalidOperationException>(() => testLibraryAccount.loanBook(bookToLoan4, testCustomer));
        }


        [TestMethod]
        public void loanBook_OwnerHaveDebt_returnTrue() //��� ����� �� ��� �������

        {
            // Arrange
            Reader testCustomer = new Reader("Some", "One", Reader.ReaderType.Kid);
            LibraryAccount testLibraryAccount = new LibraryAccount(testCustomer);
            Book bookToLoan1 = new Book("A-597", Book.BookType.KidsBook, Book.BookStatus.InLibrary);
            testLibraryAccount.OwnerDebt = -150;


            // Act && Assert

            Assert.ThrowsException<System.InvalidOperationException>(() => testLibraryAccount.loanBook(bookToLoan1, testCustomer));

        }


        [TestMethod]
        public void CancelOrder_BookInOrders_returnsTrue() //��� ����� ���� ���� �� ����� ���� ������
        {
            // Arrange
            Reader testCustomer = new Reader("Kruv", "Magnuv", Reader.ReaderType.Adult);
            LibraryAccount testLibraryAccount = new LibraryAccount(testCustomer);
            Book bookToCancel = new Book("Refael", Book.BookType.KidsBook, Book.BookStatus.OutLibrary);
            testLibraryAccount.OrderdBooks.Add(bookToCancel);


            //Act
            bool ActualResult = testLibraryAccount.cancelOrderBook(bookToCancel, testCustomer);


            //Assert

            Assert.IsTrue(ActualResult && !(testLibraryAccount.OrderdBooks.Contains(bookToCancel)), "CancelBook func is wrong");
        }
        [TestMethod]

        public void OrderBook_AvailableBook_returnsTrue() //��� ���� ������ ���� ������ �� ����� �� ����� ������ ����
        {
            // Arrange
            Reader testCustomer = new Reader("Some", "One", Reader.ReaderType.Kid);
            LibraryAccount testLibraryAccount = new LibraryAccount(testCustomer);
            Book bookToOrder = new Book("A-597", Book.BookType.KidsBook, Book.BookStatus.InLibrary);

            //Act
            bool ActualResult = testLibraryAccount.orderBook(bookToOrder, testCustomer);


            //Assert
            Assert.IsTrue(ActualResult && testLibraryAccount.OrderdBooks.Contains(bookToOrder), "LoanBook func is wrong");
        }
        [TestMethod]
        public void OrderBook_CostumerIsKid_returnTrue() //��� ����� ��� ��� ����� ������ ��� �� �������
        {
            // Arrange
            Reader testCustomer = new Reader("Kruv", "Magnuv", Reader.ReaderType.Kid);
            LibraryAccount testLibraryAccount = new LibraryAccount(testCustomer);
            Book BookToOrder = new Book("Refael", Book.BookType.AdultBook, Book.BookStatus.InLibrary);

            //Act && Assert


            Assert.ThrowsException<System.InvalidOperationException>(() => testLibraryAccount.orderBook(BookToOrder, testCustomer));

        }
        [TestMethod]
        public void OrderBook_CostumerIsAdult_returnTrue() //��� ����� ��� ����� ����� ������ ��� �� �����
        {
            // Arrange
            Reader testCustomer = new Reader("Kruv", "Magnuv", Reader.ReaderType.Adult);
            LibraryAccount testLibraryAccount = new LibraryAccount(testCustomer);
            Book BookToOrder = new Book("Refael", Book.BookType.KidsBook, Book.BookStatus.InLibrary);

            //Act && Assert

            Assert.ThrowsException<System.InvalidOperationException>(() => testLibraryAccount.orderBook(BookToOrder, testCustomer));

        }

        [TestMethod]
        [DataRow("Josef","Topik")]
        [DataRow("Haim","Moshe")]
        [DataRow("KOKOTip","Lolipop")]
        public void OrderBook_BookOutsideLibrary_returnTrue(string FirstName,string LastName) //��� ���� ������ ���� ���� ������ ����� ���� ������

        {
            // Arrange
            Reader testCustomer = new Reader(FirstName,LastName, Reader.ReaderType.Kid);
            LibraryAccount testLibraryAccount = new LibraryAccount(testCustomer);
            Book bookToOrder = new Book("A-597", Book.BookType.KidsBook, Book.BookStatus.OutLibrary);

          
            //Act && Assert
            Assert.ThrowsException<System.InvalidOperationException>(() => testLibraryAccount.orderBook(bookToOrder, testCustomer));

        }

        [TestMethod]
        public void orderdBook_InLibrary_returnsTrue() //��� ���� ������ ��� ���� ������ ����� ������
        {
            // Arrange
            Reader testCustomer = new Reader("Haim", "Shaim", Reader.ReaderType.Kid);
            LibraryAccount testLibraryAccount = new LibraryAccount(testCustomer);
            Book bookToOrder = new Book("Jungle Dreams", Book.BookType.KidsBook, Book.BookStatus.InLibrary);

            //Act
            bool ActualResult = testLibraryAccount.orderBook(bookToOrder, testCustomer);


            //Assert
            Assert.IsTrue(ActualResult && testLibraryAccount.OrderdBooks.Contains(bookToOrder),  "OrderBook func is wrong");

        }

        [TestMethod]
        [DataRow("MobiDik")]
        [DataRow("Tinkerbel")]
        [DataRow("CVHop")]
        [DataRow("TInki")]

        public void orderdBook_OwnerHaveMoreThan_3_Books_returnTrue(string BookName) //��� ����� ������ �� ���� �� ���� �3 ����� ������ ������ ��������

        {
            // Arrange
            Reader testCustomer = new Reader("Some", "One", Reader.ReaderType.Kid);
            LibraryAccount testLibraryAccount = new LibraryAccount(testCustomer);
            Book BookToOrder1 = new Book(BookName, Book.BookType.KidsBook, Book.BookStatus.InLibrary);
            Book BookToOrder2 = new Book(BookName, Book.BookType.KidsBook, Book.BookStatus.InLibrary);
            Book BookToOrder3 = new Book(BookName, Book.BookType.KidsBook, Book.BookStatus.InLibrary);
            Book BookToOrder4 = new Book(BookName, Book.BookType.KidsBook, Book.BookStatus.InLibrary);
            testLibraryAccount.OrderdBooks.Add(BookToOrder1);
            testLibraryAccount.OrderdBooks.Add(BookToOrder2);
            testLibraryAccount.OrderdBooks.Add(BookToOrder3);


        
            //Act && Assert 
            Assert.ThrowsException<System.InvalidOperationException>(() => testLibraryAccount.orderBook(BookToOrder4, testCustomer));

        }
        [TestMethod]
        public void OrderBook_OwnerHaveDept_returnTrue() //��� ����� ������ �� ���� �� ��� ������

        {
            // Arrange
            Reader testCustomer = new Reader("Some", "One", Reader.ReaderType.Kid);
            LibraryAccount testLibraryAccount = new LibraryAccount(testCustomer);
            Book bookToOrder = new Book("A-597", Book.BookType.KidsBook, Book.BookStatus.InLibrary);
            testLibraryAccount.OwnerDebt = -150;



            //Act && Assert


            Assert.ThrowsException<System.InvalidOperationException>(() => testLibraryAccount.orderBook(bookToOrder, testCustomer));

        }








        [TestMethod]
        [DataRow("momo","Shlomo","ref")]
        [DataRow("josh", "jay", "sinderella")]
        [DataRow("jermi", "si", "Superman")]
        public void returnBook_OwnerTryToReturnThatHeNeverTake_returnsTrue(string firstname,string lastname,string bookname) //��� ����� ���� ������ ��� ��� ��� ����� ����� ����  ������ ������ ���
        {
            // Arrange
            Reader testCustomer = new Reader(firstname, lastname, Reader.ReaderType.Adult);
            LibraryAccount testLibraryAccount = new LibraryAccount(testCustomer);
            Book bookToReturn = new Book(bookname, Book.BookType.KidsBook, Book.BookStatus.OutLibrary);
            testLibraryAccount.LoanBooks.Add(bookToReturn);
         


            //Act
            bool ActualResult = testLibraryAccount.returnBook(bookToReturn);


            //Assert

            Assert.AreNotEqual((ActualResult, testLibraryAccount.LoanBooks.Contains(bookToReturn)), "CancelBook func is wrong");
        }



    }
}
