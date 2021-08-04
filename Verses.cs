using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ProiectareCantari
{
    public class Verses
    {
        [Browsable(false)]
        public int book_number { get; set; }
        [Browsable(false)]
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
        public string short_name;

        public string Short_name
        {
            get
            {
                {                    
                    var ttt = short_name.Split();
                    if (ttt.Length > 1)
                        return ttt[0] + ttt[1];
                    else
                        return ttt[0];
                };
            }
            set { short_name = value; }
        }



        public string long_name { get; set; }
        public Book(int book_number, string short_name, string long_name)
        {
            this.book_number = book_number;
            this.Short_name = short_name;
            this.long_name = long_name;
        }
    }
}
