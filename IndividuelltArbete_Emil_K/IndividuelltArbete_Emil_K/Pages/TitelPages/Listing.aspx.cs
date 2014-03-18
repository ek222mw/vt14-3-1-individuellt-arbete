using IndividuelltArbete_Emil_K.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividuelltArbete_Emil_K.Pages.TitelPages
{
    public partial class Listing1 : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            // Ett Service-objekt skapas först då det behövs för första 
            // gången.
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
                SuccessMessageLiteral.Text = Page.GetTempData("SuccessMessage") as string;
                SuccessMessagePanel.Visible = !String.IsNullOrWhiteSpace(SuccessMessageLiteral.Text);
          
        }

        /// <summary>
        /// Hämtar alla titlar som finns lagrade i databasen.
        /// </summary>
        /// <returns></returns>

        /// <summary>
        /// Lägger till en titels uppgifter i databasen.
        /// </summary>
        /// <param name="titel"></param>


        /// <summary>
        /// Uppdaterar en titels uppgifter i databasen.
        /// </summary>
        /// <param name="TitelId"></param>
        public void TitelListView_UpdateItem(int TitelID) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var titel = Service.GetTitel(TitelID);
                    if (titel == null)
                    {
                        // Hittade inte titeln.
                        ModelState.AddModelError(String.Empty,
                            String.Format("Titeln med nummer {0} hittades inte.", TitelID));
                        return;
                    }

                    if (TryUpdateModel(titel))
                    {
                        Service.SaveTitels(titel);
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då titeln skulle uppdateras.");
                }
            }
        }
        /// <summary>
        /// Tar bort specifierad titel ur databasen.
        /// </summary>
        /// <param name="TitelId"></param>
        public void TitelListView_DeleteItem(int TitelID) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    Service.DeleteTitel(TitelID);
                  

                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då Titeln skulle tas bort.");
                }
            }
        }

        public IEnumerable<IndividuelltArbete_Emil_K.Model.Title> TitelListView_GetData()
        {
            return Service.GetTitels();
        }
        
    }
}