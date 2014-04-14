using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.Model
{
    public class TitelFormat
    {
        // Egenskapernas namn och typ ges av tabellen
        // Titelformat i databasen.

        public int TitelFormatID { get; set; }

        public int TitelID { get; set; }

        public int FormatID { get; set; }
    }
}