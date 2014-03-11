using IndividuelltArbete_Emil_K.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividuelltArbete_Emil_K.Pages.TitelPages
{
    public partial class Edit2 : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            // Ett Service-objekt skapas först då det behövs för första 
            // gången (lazy initialization, http://en.wikipedia.org/wiki/Lazy_initialization).
            get { return _service ?? (_service = new Service()); }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public IndividuelltArbete_Emil_K.Model.Titel TitelFormView_GetItem([RouteData]int id)
        {
            try
            {
                return Service.GetTitel(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då titeln hämtades vid redigering.");
                return null;
            }
        }

        /// <summary>
        /// Uppdaterar en titels kunduppgifter i databasen.
        /// </summary>

        public void TitelFormView_UpdateItem(int TitelID) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {
            try
            {
                var titel = Service.GetTitel(TitelID);
                if (titel == null)
                {
                    // Hittade inte titeln.
                    ModelState.AddModelError(String.Empty,
                        String.Format("Tekniska med titelnummer {0} hittades inte.", TitelID));
                    return;
                }

                if (TryUpdateModel(titel))
                {
                    Service.SaveTitels(titel);

                    Page.SetTempData("SuccessMessage", "Tekniska infon uppdaterades.");
                    Response.RedirectToRoute("Titel", new { id = titel.TitelID });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då titeln skulle uppdateras.");
            }
        }
    }
}