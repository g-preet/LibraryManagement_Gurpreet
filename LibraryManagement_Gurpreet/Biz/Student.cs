using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement_Gurpreet.Biz
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Class { get; set; }
        public int AuthorID { get; set; }
        public int BookID { get; set; }
        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
