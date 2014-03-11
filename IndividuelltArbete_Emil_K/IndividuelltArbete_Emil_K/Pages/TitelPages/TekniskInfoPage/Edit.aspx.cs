using IndividuelltArbete_Emil_K.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividuelltArbete_Emil_K.Pages.TitelPages.TekniskInfoPage
{
    public partial class Edit : System.Web.UI.Page
    {
        private TekniskInfoService _tekniskinfoservice;

        private TekniskInfoService TekniskInfoService
        {
            // Ett Service-objekt skapas först då det behövs för första 
            // gången (lazy initialization, http://en.wikipedia.org/wiki/Lazy_initialization).
            get { return _tekniskinfoservice ?? (_tekniskinfoservice = new TekniskInfoService()); }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public IndividuelltArbete_Emil_K.Model.TekniskInfo TekniskInfoFormView_GetItem([RouteData]int id)
        {
            try
            {
                return TekniskInfoService.GetTekniskInfo(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då den tekniska infon hämtades vid redigering.");
                return null;
            }
        }

        /// <summary>
        /// Uppdaterar en teknisk info i databasen.
        /// </summary>

        public void TekniskInfoFormView_UpdateItem(int TekniskInfoID) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {
            try
            {
                var tekniskinfo = TekniskInfoService.GetTekniskInfo(TekniskInfoID);
                if (tekniskinfo == null)
                {
                    // Hittade inte titeln.
                    ModelState.AddModelError(String.Empty,
                        String.Format("Tekniska info med nummer {0} hittades inte.", TekniskInfoID));
                    return;
                }

                if (TryUpdateModel(tekniskinfo))
                {
                    TekniskInfoService.SaveTekniskInfos(tekniskinfo);

                    Page.SetTempData("SuccessMessage", "Tekniska infon uppdaterades.");
                    Response.RedirectToRoute("TekniskInfo", new { id = tekniskinfo.TekniskInfoID });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då den tekniska infon skulle uppdateras.");
            }
        }
    }
}