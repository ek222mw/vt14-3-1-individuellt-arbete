using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndividuelltArbete_Emil_K.Model
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