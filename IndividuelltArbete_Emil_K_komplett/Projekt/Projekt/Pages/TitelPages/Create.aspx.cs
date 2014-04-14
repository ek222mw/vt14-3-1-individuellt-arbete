using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt.Pages.TitelPages
{
    public partial class Create : System.Web.UI.Page
    {
        #region Properties
        private Service _service;

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
            if (HasMessage)
            {
                ShowMessage.Text = Message;
                ShowMessage.Visible = true;
            }
        }


        #region Insert
        public void TitelFormView_InsertItem(Title TitelID)
        {
            if (ModelState.IsValid)
            {
                var checkBoxList = (CheckBoxList)TitelFormView.FindControl("FormatCheckBoxList");
                //Lägger till de formaten som användaren kryssat i checkboxen.
                int[] format_ids = checkBoxList.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => int.Parse(li.Value)).ToArray();
                try
                {
                    //Arrayen skickas vidare till Service klassen tillsammans med filmen.
                    Service.SaveTitel(TitelID, format_ids);
                    Message = "Titeln lades till";
                    Response.Redirect("TitelCreate", false);
                    Page.SetTempData("SuccessMessage", "format lades till.");
                    Response.RedirectToRoute("Titel", new { id = TitelID.TitelID });
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då titeluppgiften skulle läggas till.");
                    Message = "titeln lades inte till";
                    Response.Redirect("TitelCreate");
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }
        #endregion

        #region Navigation
        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Titel");
            Context.ApplicationInstance.CompleteRequest();
        }
        #endregion

        #region Checkbox

        public IEnumerable<Formats> FormatCheckBoxList_GetData()
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

        protected void CheckCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {

            var checkBoxList = (CheckBoxList)TitelFormView.FindControl("FormatCheckBoxList");
            var checkBoxChecked = checkBoxList.SelectedItem;

            /* ContentPlaceHolder mycont = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
    CheckBoxList CheckBoxList1 = (CheckBoxList)mycont.FindControl("CheckBoxList1");
    CheckBoxList1.DataSource = Dcon.Tables[0];
    CheckBoxList1.DataBind(); */

            if (checkBoxChecked != null)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

       /* public void TitelListView_InsertItem()
        {
            var item = new IndividuelltArbete_Emil_K.Model.Title();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here

            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression*/
    }
}