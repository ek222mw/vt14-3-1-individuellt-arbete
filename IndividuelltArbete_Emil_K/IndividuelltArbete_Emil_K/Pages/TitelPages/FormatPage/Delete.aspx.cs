using IndividuelltArbete_Emil_K.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividuelltArbete_Emil_K.Pages.TitelPages.FormatPage
{
    public partial class Delete : System.Web.UI.Page
    {
        private FormatService _formatservice;

        private FormatService FormatService
        {
            get { return _formatservice ?? (_formatservice = new FormatService()); }
        }

        protected int Id
        {
            get { return int.Parse(RouteData.Values["id"].ToString()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CancelHyperLink.NavigateUrl = GetRouteUrl("Format", new { id = Id });

            if (!IsPostBack)
            {
                try
                {
                    var format = FormatService.GetFormat(Id);
                    if (format != null)
                    {
                        FormatName.Text = format.Format;
                        return;
                    }

                    // Hittade inte formatet.
                    ModelState.AddModelError(String.Empty,
                        String.Format("Formatet med nummer {0} hittades inte.", Id));
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då formatet hämtades inför borttagning.");
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
                FormatService.DeleteFormat(id);

                Page.SetTempData("SuccessMessage", "formatet togs bort.");
                Response.RedirectToRoute("Format", null);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då formatet skulle tas bort.");
            }
        }

    }
}