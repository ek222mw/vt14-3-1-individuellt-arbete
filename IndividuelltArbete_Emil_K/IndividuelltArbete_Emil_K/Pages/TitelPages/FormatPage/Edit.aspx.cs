using IndividuelltArbete_Emil_K.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividuelltArbete_Emil_K.Pages.TitelPages.FormatPage
{
    public partial class Edit : System.Web.UI.Page
    {
        private FormatService _formatservice;

        private FormatService FormatService
        {
            // Ett Service-objekt skapas först då det behövs för första 
            // gången.
            get { return _formatservice ?? (_formatservice = new FormatService()); }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public IndividuelltArbete_Emil_K.Model.Formats FormatFormView_GetItem([RouteData]int id)
        {
            try
            {
                return FormatService.GetFormat(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då formatet hämtades vid redigering.");
                return null;
            }
        }

        /// <summary>
        /// Uppdaterar format uppgifter i databasen.
        /// </summary>

        public void FormatFormView_UpdateItem(int FormatID) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
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

                    Page.SetTempData("SuccessMessage", "Formatet uppdaterades.");
                    Response.RedirectToRoute("Format", new { id = format.FormatID });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då formatet skulle uppdateras.");
            }
        }
    }
}