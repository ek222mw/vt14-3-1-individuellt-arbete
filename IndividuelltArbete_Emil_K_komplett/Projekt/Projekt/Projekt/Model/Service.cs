using Projekt.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Model
{
    public class Service
    {
        #region Fält
        private static TitelDAL _titelDAL;
        private static TitelFormatDAL _titelformatDAL;
        private static FormatDAL _FormatDAL;
        #endregion


        #region Egenskaper

        private TitelDAL TitelDAL
        {
            get
            {
                return _titelDAL ?? (_titelDAL = new TitelDAL());
            }
        }

        private TitelFormatDAL TitelFormatDAL
        {
            get
            {
                return _titelformatDAL ?? (_titelformatDAL = new TitelFormatDAL());
            }
        }

        private FormatDAL FormatDAL
        {
            get
            {
                return _FormatDAL ?? (_FormatDAL = new FormatDAL());
            }
        }
        #endregion


        #region Format


        public IEnumerable<Formats> GetFormats()
        {
            return FormatDAL.GetFormats();
        }
        #endregion


        #region Title

        public Title GetTitel(int TitelID)
        {
            return TitelDAL.GetTitelById(TitelID);
        }

        public IEnumerable<Title> GetTitels()
        {
            return TitelDAL.GetTitels();
        }

        public void DeleteTitel(int TitelID)
        {
            TitelDAL.DeleteTitel(TitelID);
        }

        public IEnumerable<Formats> GetFormatIDByTitleID(int titleID)
        {
            return TitelFormatDAL.GetTitelFormatIDByTitleID(titleID);
        }

        public void SaveTitel(Title titel, int[] format_ids)
        {

            ICollection<ValidationResult> validationResults;
            if (!titel.Validate(out validationResults)) // Använder "extension method" för valideringen!
            {                                              // Klassen finns under App_Infrastructure.
                // ...kastas ett undantag med ett allmänt felmeddelande samt en referens 
                // till samlingen med resultat av valideringen.
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }


            if (titel.TitelID == 0) // Ny post om TitelId är 0!
            {
                //Skickar titeln till TitleDAL där infon läggs in i databasen.
                TitelDAL.InsertTitel(titel);

                //Loopar igenom alla ikryssade format och skickar dom till AddTitelformat metoden som sedan lägger till varje format.
                for (int i = 0; format_ids.Length - 1 >= i; i++)
                {
                    TitelFormatDAL.InsertTitelformat(titel, format_ids[i]);
                }


            }
            else
            {
                TitelDAL.UpdateTitel(titel);
                TitelFormatDAL.DeleteFormat(titel.TitelID);
                for (int i = 0; format_ids.Length - 1 >= i; i++)
                {
                    TitelFormatDAL.InsertTitelformat(titel, format_ids[i]);
                }
            }
        }
        #endregion

        public Formats GetFormatByTitelFormatID(int titelformatID)
        {
            return FormatDAL.GetFormatTypesByFormatID(titelformatID);
        }

        public void DeleteFormat(int titleID)
        {
            TitelFormatDAL.DeleteFormat(titleID);
        }

        #region Filmformat
        public List<TitelFormat> GetTitelFormatByTitelID(int titleID)
        {
            return TitelFormatDAL.GetTitelFormatByTitelId(titleID);
        }

        #endregion
    }
}