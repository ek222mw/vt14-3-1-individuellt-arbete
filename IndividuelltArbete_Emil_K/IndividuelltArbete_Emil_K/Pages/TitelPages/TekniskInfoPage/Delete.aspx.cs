using IndividuelltArbete_Emil_K.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividuelltArbete_Emil_K.Pages.TitelPages.TekniskInfoPage
{
    public partial class Delete : System.Web.UI.Page
    {
        private TekniskInfoService _tekniskInfoservice;

        private TekniskInfoService TekniskInfoService
        {
            // Ett Service-objekt skapas först då det behövs för första 
            // gången (lazy initialization, http://en.wikipedia.org/wiki/Lazy_initialization).
            get { return _tekniskInfoservice ?? (_tekniskInfoservice = new TekniskInfoService()); }
        }

        protected int Id
        {
            get { return int.Parse(RouteData.Values["id"].ToString()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CancelHyperLink.NavigateUrl = GetRouteUrl("TekniskInfo", new { id = Id });

            if (!IsPostBack)
            {
                try
                {
                    var tekniskinfo = TekniskInfoService.GetTekniskInfo(Id);
                    if (tekniskinfo != null)
                    {
                        TekniskInfo.Text = tekniskinfo.TekniskInfo;
                        return;
                    }

                    // Hittade inte titeln.
                    ModelState.AddModelError(String.Empty,
                        String.Format("Teknisk info med nummer {0} hittades inte.", Id));
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då teknisk info hämtades inför borttagning.");
                }

                ConfirmationPlaceHolder.Visible = false;
                DeleteLinkButton.Visible = false;
            }
        }

        protected void DeleteLinkButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var id = int.Parse(e.CommandArgument.ToString());
                TekniskInfoService.DeleteTekniskInfo(id);

                Page.SetTempData("SuccessMessage", "teknisk info togs bort.");
                Response.RedirectToRoute("Teknisk info", null);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då teknisk info skulle tas bort.");
            }
        }
    }
}