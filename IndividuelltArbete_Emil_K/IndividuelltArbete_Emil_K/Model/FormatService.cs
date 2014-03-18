using IndividuelltArbete_Emil_K.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndividuelltArbete_Emil_K.Model
{
    public class FormatService
    {
        #region Format

        private FormatDAL _formatDAL;

        private FormatDAL FormatDAL
        {
            // Ett FormatDAL-objekt skapas först då det behövs för första 
            // gången.
            get { return _formatDAL ?? (_formatDAL = new FormatDAL()); }
        }

        /// <summary>
        /// Tar bort specifierad format ur databasen.
        /// </summary>
        /// <param name="format">format som ska tas bort.</param>
        public void DeleteFormat(int formatid)
        {
            FormatDAL.DeleteFormats(formatid);
        }

        /// <summary>
        /// Hämtar ett format med ett specifikt formatnummer från databasen.
        /// </summary>
        /// <param name="formatId">Format nummer.</param>
        /// <returns>Ett format-objekt innehållande formatuppgifter.</returns>
        public Formats GetFormat(int formatId)
        {
            return FormatDAL.GetFormatById(formatId);
        }

        /// <summary>
        /// Hämtar alla format som finns lagrade i databasen.
        /// </summary>
        /// <returns>Lista med referenser till format-objekt innehållande formatuppgifter.</returns>
        public IEnumerable<Formats> GetFormats()
        {
            return FormatDAL.GetFormats();
        }

        /// <summary>
        /// Spara ett formats formatuppgifter i databasen.
        /// </summary>
        /// <param name="format">Formatuppgifter som ska sparas.</param>
        public void SaveFormats(Formats format)
        {
            ICollection<ValidationResult> validationResults;
            if (!format.Validate(out validationResults)) // Använder "extension method" för valideringen!
            {                                              // Klassen finns under App_Infrastructure.
                // ...kastas ett undantag med ett allmänt felmeddelande samt en referens 
                // till samlingen med resultat av valideringen.
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            // Format-objektet sparas antingen genom att en ny post 
            // skapas eller genom att en befintlig post uppdateras.
            if (format.FormatID == 0) // Ny post om FormatId är 0.
            {
                FormatDAL.InsertFormat(format);
            }
            else
            {
                FormatDAL.UpdateFormat(format);
            }
        }

        #endregion
    }
}