using IndividuelltArbete_Emil_K.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndividuelltArbete_Emil_K.Model
{
    public class Service
    {

        #region Titel

        private TitelDAL _titelDAL;

        private TitelDAL TitelDAL
        {
            // Ett TitelDAL-objekt skapas först då det behövs för första 
            // gången (lazy initialization, http://en.wikipedia.org/wiki/Lazy_initialization).
            get { return _titelDAL ?? (_titelDAL = new TitelDAL()); }
        }

        /// <summary>
        /// Tar bort specifierad titel ur databasen.
        /// </summary>
        /// <param name="customer">titel som ska tas bort.</param>
        public void DeleteTitel(int titelid)
        {
            TitelDAL.DeleteTitel(titelid);
        }

        /// <summary>
        /// Hämtar en titel med ett specifikt titelnummer från databasen.
        /// </summary>
        /// <param name="customerId">Kundens kundnummer.</param>
        /// <returns>Ett titel-objekt innehållande titeluppgifter.</returns>
        public Titel GetTitel(int titelId)
        {
            return TitelDAL.GetTitelsById(titelId);
        }

        /// <summary>
        /// Hämtar alla titlar som finns lagrade i databasen.
        /// </summary>
        /// <returns>Lista med referenser till titel-objekt innehållande titeluppgifter.</returns>
        public IEnumerable<Titel> GetTitels()
        {
            return TitelDAL.GetTitels();
        }

        /// <summary>
        /// Spara en titels titeluppgifter i databasen.
        /// </summary>
        /// <param name="customer">Kunduppgifter som ska sparas.</param>
        public void SaveTitels(Titel titel)
        {
            //var validationContext = new ValidationContext(customer);
            //var validationResults = new List<ValidationResult>();
            //if (!Validator.TryValidateObject(customer, validationContext, validationResults, true))
            //{
            //    // Uppfyller inte objektet affärsreglerna kastas ett undantag med
            //    // ett allmänt felmeddelande samt en referens till samlingen med
            //    // resultat av valideringen.
            //    var ex = new ValidationException("Objektet klarade inte valideringen.");
            //    ex.Data.Add("ValidationResults", validationResults);
            //    throw ex;
            //}

            // Uppfyller inte objektet affärsreglerna...
            ICollection<ValidationResult> validationResults;
            if (!titel.Validate(out validationResults)) // Använder "extension method" för valideringen!
            {                                              // Klassen finns under App_Infrastructure.
                // ...kastas ett undantag med ett allmänt felmeddelande samt en referens 
                // till samlingen med resultat av valideringen.
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            // Titel-objektet sparas antingen genom att en ny post 
            // skapas eller genom att en befintlig post uppdateras.
            if (titel.TitelID == 0) // Ny post om CustomerId är 0!
            {
                TitelDAL.InsertTitel(titel);
            }
            else
            {
                TitelDAL.UpdateTitel(titel);
            }
        }

        #endregion
    }
}