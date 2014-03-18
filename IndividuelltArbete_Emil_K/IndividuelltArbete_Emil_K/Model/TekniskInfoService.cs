using IndividuelltArbete_Emil_K.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndividuelltArbete_Emil_K.Model
{
    public class TekniskInfoService
    {
        #region TekniskInfo

        private TekniskInfoDAL _tekniskinfoDAL;

        private TekniskInfoDAL TekniskInfoDAL
        {
            // Ett TekniskInfoDAL-objekt skapas först då det behövs för första 
            // gången.
            get { return _tekniskinfoDAL ?? (_tekniskinfoDAL = new TekniskInfoDAL()); }
        }

        /// <summary>
        /// Tar bort specifierad teknisk info ur databasen.
        /// </summary>
        /// <param name="Tekniskinfo">teknisk info som ska tas bort.</param>
        public void DeleteTekniskInfo(int tekniskinfoid)
        {
            TekniskInfoDAL.DeleteTekniskInfo(tekniskinfoid);
        }

        /// <summary>
        /// Hämtar en teknisk info med ett specifikt teknisk info nummer från databasen.
        /// </summary>
        /// <param name="TekniskInfoID">Teknisk info nummer.</param>
        /// <returns>Ett teknisk info-objekt innehållande teknisk info uppgifter.</returns>
        public TekniskInfos GetTekniskInfo(int tekniskinfoId)
        {
            return TekniskInfoDAL.GetTekniskInfoById(tekniskinfoId);
        }

        /// <summary>
        /// Hämtar all teknisk info som finns lagrade i databasen.
        /// </summary>
        /// <returns>Lista med referenser till teknisk info-objekt innehållande teknisk info uppgifter.</returns>
        public IEnumerable<TekniskInfos> GetTekniskInfos()
        {
            return TekniskInfoDAL.GetTekniskInfos();
        }

        /// <summary>
        /// Spara en teknisk info teknisk info uppgifter i databasen.
        /// </summary>
        /// <param name="Teknisk info">Teknisk info uppgifter som ska sparas.</param>
        public void SaveTekniskInfos(TekniskInfos tekniskinfo)
        {
            
            ICollection<ValidationResult> validationResults;
            if (!tekniskinfo.Validate(out validationResults)) // Använder "extension method" för valideringen!
            {                                              // Klassen finns under App_Infrastructure.
                // ...kastas ett undantag med ett allmänt felmeddelande samt en referens 
                // till samlingen med resultat av valideringen.
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            // Teknisk info-objektet sparas antingen genom att en ny post 
            // skapas eller genom att en befintlig post uppdateras.
            if (tekniskinfo.TekniskInfoID == 0) // Ny post om TekniskInfoId är 0!
            {
                TekniskInfoDAL.InsertTekniskInfo(tekniskinfo);
            }
            else
            {
                TekniskInfoDAL.UpdateTekniskInfo(tekniskinfo);
            }
        }

        #endregion
    }
}