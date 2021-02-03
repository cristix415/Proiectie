using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProiectareCantari
{
    public class Verses
    {
        public int book_number { get; set; }
        public int chapter { get; set; }
        public int verse { get; set; }
        public string text { get; set; }
        public Verses(int book_number, int chapter, int verse, string text)
        {
            this.book_number = book_number;
            this.chapter = chapter;
            this.verse = verse;
            this.text = text;

        }
    }
    public class Book
    {
        public int book_number { get; set; }
        public string short_name { get; set; }
        public string long_name { get; set; }
        public Book(int book_number, string short_name, string long_name)
        {
            this.book_number = book_number;
            this.short_name = short_name;
            this.long_name = long_name;
        }
    }
}
