using IndividuelltArbete_Emil_K.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividuelltArbete_Emil_K.Pages.TitelPages
{
    public partial class Delete1 : System.Web.UI.Page
    {
       
             private Service _service;

            private Service Service
            {
                // Ett Service-objekt skapas först då det behövs för första 
                // gången (lazy initialization, http://en.wikipedia.org/wiki/Lazy_initialization).
                get { return _service ?? (_service = new Service()); }
            }

            protected int Id
            {
                get { return int.Parse(RouteData.Values["id"].ToString()); }
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                CancelHyperLink.NavigateUrl = GetRouteUrl("Titel", new { id = Id });

                if (!IsPostBack)
                {
                    try
                    {
                        var titel = Service.GetTitel(Id);
                        if (titel != null)
                        {
                            TitelName.Text = titel.Titel;
                            return;
                        }

                        // Hittade inte titeln.
                        ModelState.AddModelError(String.Empty,
                            String.Format("Titeln med titelnummer {0} hittades inte.", Id));
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError(String.Empty, "Fel inträffade då titeln hämtades inför borttagning.");
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
                    Service.DeleteTitel(id);

                    Page.SetTempData("SuccessMessage", "titeln togs bort.");
                    Response.RedirectToRoute("Titel", null);
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då titeln skulle tas bort.");
                }
            }

        
    }
}