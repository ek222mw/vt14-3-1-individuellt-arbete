using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndividuelltArbete_Emil_K.Model
{
    public class Title
    {
        // Egenskapernas namn och typ ges av tabellen
        // Titel i databasen.

        public int TitelID { get; set; }

       // public int Top10ID { get; set; }

      //  public int BetygID { get; set; }

        public int TekniskInfoID { get; set; }

        [Required(ErrorMessage = "En beskrivning måste anges.")]
        [StringLength(1000, ErrorMessage = "Beskrivningen kan bestå av som mest 1000 tecken.")]
        public string Beskrivning { get; set; }

        [Required(ErrorMessage = "En Titel måste anges.")]
        [StringLength(50, ErrorMessage = "Titeln kan bestå av som mest 50 tecken.")]
        public string Titel { get; set; }

       
        
        [Required(ErrorMessage = "Ett produktionsår måste anges.")]
        public DateTime Produktionsar { get; set; }

        [Required(ErrorMessage = "Ett Produktionsbolag måste anges.")]
        [StringLength(40, ErrorMessage = "Produktionsbolaget kan bestå av som mest 40 tecken.")]
        public string Produktionsbolag { get; set; }

        [Required(ErrorMessage = "En Genre måste anges.")]
        [StringLength(20, ErrorMessage = "Genren kan bestå av som mest 20 tecken.")]
        public string Genre { get; set; }
    }
}