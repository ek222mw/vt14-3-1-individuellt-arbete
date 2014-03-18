using IndividuelltArbete_Emil_K.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividuelltArbete_Emil_K.Pages.TitelPages.FormatPage
{
    public partial class Listing : System.Web.UI.Page
    {
        
        
        private FormatService _formatservice;

        private FormatService FormatService
        {
            // Ett Service-objekt skapas först då det behövs för första 
            // gången.
            get { return _formatservice ?? (_formatservice = new FormatService()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
                SuccessMessageLiteral.Text = Page.GetTempData("SuccessMessage") as string;
                SuccessMessagePanel.Visible = !String.IsNullOrWhiteSpace(SuccessMessageLiteral.Text);
            
        }

        public IEnumerable<IndividuelltArbete_Emil_K.Model.Formats> FormatListView_GetData()
        {
            return FormatService.GetFormats();
        }
        /// <summary>
        /// Hämtar alla Format som finns lagrade i databasen.
        /// </summary>
        /// <returns></returns>

        /// <summary>
        /// Lägger till en formats uppgifter i databasen.
        /// </summary>
        /// <param name="format"></param>


        /// <summary>
        /// Uppdaterar en formats uppgifter i databasen.
        /// </summary>
        /// <param name="FormatID"></param>
        public void FormatListView_UpdateItem(int FormatID) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var format = FormatService.GetFormat(FormatID);
                    if (format == null)
                    {
                        // Hittade inte formatet.
                        ModelState.AddModelError(String.Empty,
                            String.Format("Formatet med nummer {0} hittades inte.", FormatID));
                        return;
                    }
                    
                    if (TryUpdateModel(format))
                    {
                        FormatService.SaveFormats(format);
                    }
            
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då formatet skulle uppdateras.");
                }
            }
        }
        /// <summary>
        /// Tar bort specifierat format ur databasen.
        /// </summary>
        /// <param name="Formatid"></param>
        public void FormatListView_DeleteItem(int FormatID) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {
            if (ModelState.IsValid)
            {
                try
                {
                    FormatService.DeleteFormat(FormatID);
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då Formatet skulle tas bort.");
                }
            }
        }   
    }
}