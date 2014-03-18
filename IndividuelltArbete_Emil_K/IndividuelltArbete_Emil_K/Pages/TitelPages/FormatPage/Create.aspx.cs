using IndividuelltArbete_Emil_K.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividuelltArbete_Emil_K.Pages.TitelPages.FormatPage
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void FormatFormView_InsertItem(Formats f)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    FormatService service = new FormatService();
                    service.SaveFormats(f);

                    // Spara (rätt)meddelande och dirigera om klienten till lista med format.
                    // (Meddelandet sparas i en "temporär" sessionsvariabel som kapslas in.
                    Page.SetTempData("SuccessMessage", "format lades till.");
                    Response.RedirectToRoute("Format", new { id = f.FormatID });
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då ett format skulle läggas till.");
                }
            }
        }
    }
}