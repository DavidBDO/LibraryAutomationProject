using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalQA
{
    public class Book
    {
        //Books are available for kids or adults.
     public enum BookType
        {
            KidsBook,  //Book for Kids
            AdultBook   //Book for adults
        }

    public enum BookStatus
        {
            InLibrary,  // The book is in the library
            PreOrderd,   // The book was orderd
            OutLibrary,  // The book is outside of the library

        }

        private string id;
        private BookStatus status;
        private BookType type;
        public string ID
        {
            get { return id; }
            set { this.id = value; }
        }

        public BookType Type
        {
            get { return type; }
        }

        public BookStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public Book (string book_id , BookType bookType , BookStatus bookStatus)
        {
            id = book_id;
            type = bookType;
            status = bookStatus;
        }
    }
}
