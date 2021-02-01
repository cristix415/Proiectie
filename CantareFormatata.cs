using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ProiectareCantari
{
    class CantareFormatata
    {
        [Browsable(false)]
        public int Id { get; set; }
        public string Titlu { get; set; }
        [Browsable(false)]
        public string TextulTOT { get; set; }
        [Browsable(false)]
        public string Ending { get; set; }

        [Browsable(false)]
        public IList<string> ListaStrofe { get; set; }

        [Browsable(false)]
        public IList<string>  listaCor { get; set; }
        [Browsable(false)]
        public Cantare Cantare { get; set; }
    }
}
