using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt.Pages.TitelPages
{
    public partial class Edit : System.Web.UI.Page
    {
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

        #region Page load
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowMessage.Text = Message;
            ShowMessage.Visible = true;
        }
        #endregion

        #region Navigation
        protected void AddRedirectButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Titel");
            Context.ApplicationInstance.CompleteRequest();
        }
        #endregion

        #region Update

        public Title TitelFormView_GetData([QueryString]int TitelID)
        {
            //iD = titleID;
            //titleID = Convert.ToInt32(Request.QueryString["id"]);
            return Service.GetTitel(TitelID);
        }

        public void TitelFormView_UpdateItem([QueryString]int TitelID) // Parameterns namn är samma som värdet DataKeyNames har.
        {
            if (ModelState.IsValid)
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

                    var checkBoxList = (CheckBoxList)TitelFormView.FindControl("FormatCheckBoxList");
                    int[] format_ids = checkBoxList.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => int.Parse(li.Value)).ToArray();
                    if (TryUpdateModel(titel))
                    {

                        titel.TitelID = TitelID;
                        Service.SaveTitel(titel, format_ids);

                    }
                    Message = "Uppdateringen lyckades";
                    Response.Redirect("Titel", false);
                    Page.SetTempData("SuccessMessage", "Titeln uppdaterades.");
                    Response.RedirectToRoute("Titel", new { id = titel.TitelID });
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    Message = "Uppdateringen misslyckades";
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då titeluppgiften skulle uppdateras.");
                }
            }
        }

        #region Checkbox
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

        #endregion

        //Metod som kryssar i de format filmen har när man ska redigera
        protected void FormatCheckBoxList_DataBound(object sender, EventArgs e)
        {
            int titelID = Convert.ToInt32(Request.QueryString["titelID"]);
            var checkBoxes = sender as CheckBoxList;
            var format = Service.GetTitelFormatByTitelID(titelID).ToList();

            foreach (var checkBox in checkBoxes.Items.Cast<ListItem>())
            {
                for (int i = 0; i < format.Count; i++)
                {
                    if (format[i].FormatID.ToString() == checkBox.Value)
                    {
                        checkBox.Selected = true;
                    }
                }
            }
        }

        protected void CheckCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {

            var checkBoxList = (CheckBoxList)TitelFormView.FindControl("FormatCheckBoxList");
            var checkBoxChecked = checkBoxList.SelectedItem;

            if (checkBoxChecked != null)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}