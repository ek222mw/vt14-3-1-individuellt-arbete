using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt.Pages.TitelPages
{
    public partial class Listing : System.Web.UI.Page
    {
        #region Fields
        private Service _service;
        #endregion

        #region Properties
        private Service Service
        {
            get
            {
                return _service ?? (_service = new Service());
            }
        }

        public CheckBoxList CheckBoxes { get; set; }
        #endregion

        #region Session
        private bool HasMessage
        {
            get
            {
                return Session["message"] != null;
            }
        }

        private string Message
        {
            get
            {
                var message = Session["message"] as string;
                Session.Remove("message");
                return message;
            }

            set
            {
                Session["message"] = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            SuccessMessageLiteral.Text = Page.GetTempData("SuccessMessage") as string;
            SuccessMessagePanel.Visible = !String.IsNullOrWhiteSpace(SuccessMessageLiteral.Text);
        }


        public IEnumerable<Title> TitelListView_GetData()
        {

            return Service.GetTitels();
        }


        #region Delete
        public void TitelListView_DeleteItem(int TitelID) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {

            try
            {
                Service.DeleteTitel(TitelID);
                Page.SetTempData("SuccessMessage", "Titeln togs bort.");
                Response.Redirect("~/Pages/TitelPages/Listing.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                Message = "Titeln togs inte bort";
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då titeluppgiften skulle tas bort.");
            }


        }
        #endregion

        #region Navigation buttons

        protected void AddRedirectButton2_Click(object sender, EventArgs e)
        {
            Title title = new Title();

            Response.Redirect("Update.aspx?id=" + title.TitelID);
            Context.ApplicationInstance.CompleteRequest();
        }
        #endregion


        protected void TitelListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Title title = e.Item.DataItem as Title;

            if (title != null)
            {

                TitelFormat titelformat = new TitelFormat();
                List<string> formatArray = new List<string>(10);

                var format = Service.GetTitelFormatByTitelID(title.TitelID);
                var literal = e.Item.FindControl("literal") as Literal;

                for (int i = 0; i < format.Count; i++)
                {
                    var formatTyp = Service.GetFormatByTitelFormatID(format[i].FormatID);
                    formatArray.Add(formatTyp.Format);
                    literal.Text = string.Join(", ", formatArray);
                }


            }
        }




        #region Update


        public void TitelListView_UpdateItem(int TitelID) // Parameterns namn är samma som värdet DataKeyNames har.
        {
            try
            {
                var titel = Service.GetTitel(TitelID);
                if (titel == null)
                {
                    ModelState.AddModelError(String.Empty,
                        String.Format("Titeln med ID {0} hittades inte.", TitelID));
                    return;
                }


                if (TryUpdateModel(titel))
                {
                    int[] format_ids = CheckBoxes.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => int.Parse(li.Value)).ToArray();
                    Service.SaveTitel(titel, format_ids);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då titeluppgiften skulle uppdateras.");
            }

        }

        public IEnumerable<Formats> FormatCheckboxList_GetData()
        {
            return Service.GetFormats();
        }

        protected void FormatCheckBoxList_DataBinding(object sender, EventArgs e)
        {
            var checkBoxes = sender as CheckBoxList;
            if (checkBoxes != null)
            {
                CheckBoxes = checkBoxes;
            }
        }

       

        #endregion
    }
}