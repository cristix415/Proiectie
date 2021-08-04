using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProiectareCantari
{
    // obiectul Cantare
    public class Cantare
    {
        public int Id { get; set; }
        public string Titlu { get; set; }
        public string Versuri { get; set; }
        public int FlagBetel { get; set; }
        public Cantare(string titlu, string versuri, int flag)
        {
            this.Titlu = titlu;
            this.Versuri = versuri;
            this.FlagBetel = flag;
        }
        public Cantare(int id, string titlu, string versuri, int flag)
        {
            this.Id = id;
            this.Titlu = titlu;
            this.Versuri = versuri;
            this.FlagBetel = flag;
        }
    }
}
