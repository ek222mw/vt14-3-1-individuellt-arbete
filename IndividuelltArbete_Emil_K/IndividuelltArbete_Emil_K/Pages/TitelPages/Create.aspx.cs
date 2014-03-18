using IndividuelltArbete_Emil_K.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividuelltArbete_Emil_K.Pages.TitelPages
{
    public partial class Create1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void TitelFormView_InsertItem(Title t)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service service = new Service();
                    service.SaveTitels(t);

                    // Spara (rätt)meddelande och dirigera om klienten till lista med titlar.
                    // (Meddelandet sparas i en "temporär" sessionsvariabel som kapslas 
                    // in av en "extension method" i App_Infrastructure/PageExtensions.)
                    // Del av designmönstret Post-Redirect-Get.
                    Page.SetTempData("SuccessMessage", "titeln lades till.");
                    Response.RedirectToRoute("Titel", new { id = t.TitelID });
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då titeln skulle läggas till.");
                }
            }
        }
    }
}