﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndividuelltArbete_Emil_K.Model
{
    public class Format
    {
        // Egenskapernas namn och typ ges av tabellen
        // Format i databasen.

        public int FormatID { get; set; }

        [Required(ErrorMessage = "Ett Format måste anges.")]
        [StringLength(20, ErrorMessage = "Ett format kan bestå av som mest 20 tecken.")]
        public string Format { get; set; }
    }
}