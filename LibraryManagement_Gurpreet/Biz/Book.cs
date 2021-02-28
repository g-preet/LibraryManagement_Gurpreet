using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement_Gurpreet.Biz
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}
