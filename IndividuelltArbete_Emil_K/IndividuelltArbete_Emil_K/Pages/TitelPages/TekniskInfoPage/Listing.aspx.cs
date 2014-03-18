using IndividuelltArbete_Emil_K.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividuelltArbete_Emil_K.Pages.TitelPages.TekniskInfoPage
{
    public partial class Listing : System.Web.UI.Page
    {
        private TekniskInfoService _tekniskinfoservice;

        private TekniskInfoService TekniskInfoService
        {
            // Ett Service-objekt skapas först då det behövs för första 
            // gången.
            get { return _tekniskinfoservice ?? (_tekniskinfoservice = new TekniskInfoService()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
                SuccessMessageLiteral.Text = Page.GetTempData("SuccessMessage") as string;
                SuccessMessagePanel.Visible = !String.IsNullOrWhiteSpace(SuccessMessageLiteral.Text);
            
        }

        /// <summary>
        /// Hämtar all Teknisk info som finns lagrade i databasen.
        /// </summary>
        /// <returns></returns>

        /// <summary>
        /// Lägger till en teknisk infos uppgifter i databasen.
        /// </summary>
        /// <param name="teknisk info"></param>


        /// <summary>
        /// Uppdaterar en teknisk info uppgifter i databasen.
        /// </summary>
        /// <param name="TekniskInfoID"></param>
        public void TekniskInfoListView_UpdateItem(int TekniskInfoID) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var tekniskinfo = TekniskInfoService.GetTekniskInfo(TekniskInfoID);
                    if (tekniskinfo == null)
                    {
                        // Hittade inte den tekniska infon.
                        ModelState.AddModelError(String.Empty,
                            String.Format("Tekniska infon med nummer {0} hittades inte.", TekniskInfoID));
                        return;
                    }

                    if (TryUpdateModel(tekniskinfo))
                    {
                        TekniskInfoService.SaveTekniskInfos(tekniskinfo);
                    }

                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då tekniska infon skulle uppdateras.");
                }
            }
        }
        /// <summary>
        /// Tar bort specifierat teknisk info ur databasen.
        /// </summary>
        /// <param name="TekniskInfoId"></param>
        public void TekniskInfoListView_DeleteItem(int TekniskInfoID) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TekniskInfoService.DeleteTekniskInfo(TekniskInfoID);
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då teknisk info skulle tas bort.");
                }
            }
        }

        public IEnumerable<IndividuelltArbete_Emil_K.Model.TekniskInfos> TekniskInfoListView_GetData()
        {
            return TekniskInfoService.GetTekniskInfos();
        }
    }
}