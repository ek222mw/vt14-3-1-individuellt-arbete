using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndividuelltArbete_Emil_K.Model
{
    public class TekniskInfo
    {
        // Egenskapernas namn och typ ges av tabellen
        // TekniskInfo i databasen.

        public int TekniskInfoID { get; set; }

        public int FormatID { get; set; }

        [Required(ErrorMessage = "En TekniskInfo måste anges.")]
        [StringLength(600, ErrorMessage = "TekniskInfo kan bestå av som mest 600 tecken.")]
        public string TekniskInfo { get; set; }

    }
}