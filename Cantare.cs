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
    public class cantec {        
        public string titlu { get; set; }
        public string autor { get; set; }
        public string ordine { get; set; }
        public List<continut> continut { get; set; }
    }
    public class genericCantare {
        public cantec cantec { get; set; }
    }
    public class cantecc
    {
        public string text { get; set; }
        public string id { get; set; }
        public string titlu { get; set; }
        public string autor { get; set; }
        public string ordine { get; set; }
       // public List<continut> continut { get; set; }
    }
    public class continut
    {
        public string tip { get; set; }
        public string text { get; set; }
    }
    public class cantarile
    {
        public List <cantecc> cantari { get; set; }        
    }

}
