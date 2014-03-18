using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IndividuelltArbete_Emil_K.Model;

namespace IndividuelltArbete_Emil_K.Pages.TitelPages.TekniskInfoPage
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void TekniskInfoFormView_InsertItem(TekniskInfos tek)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TekniskInfoService service = new TekniskInfoService();
                    service.SaveTekniskInfos(tek);

                    // Spara (rätt)meddelande och dirigera om klienten till lista med titlar.
                    // (Meddelandet sparas i en "temporär" sessionsvariabel som kapslas 
                    // in av en "extension method" i App_Infrastructure/PageExtensions.)
                    // Del av designmönstret Post-Redirect-Get.
                    Page.SetTempData("SuccessMessage", "tekniskinfo lades till.");
                    Response.RedirectToRoute("TekniskInfo", new { id = tek.TekniskInfoID });
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då teknisk info skulle läggas till.");
                }
            }
        }
    }
}