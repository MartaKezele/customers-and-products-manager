using RWAProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RWAProject.Forms
{
    public partial class Customers : System.Web.UI.Page
    {
        // Properties

        private bool Update
        {
            get
            {
                if (Session["updateCustomer"] != null)
                {
                    return (bool)Session["updateCustomer"];
                }

                return false;
            }
            set
            {
                Session["updateCustomer"] = value;
            }
        }



        // Events

        protected void Page_Load(object sender, EventArgs e)
        {
            gvCustomers.PageSize = int.Parse(ddlNumberOfCustomersShown.SelectedValue);
        }

        protected void PhoneNumberLengthValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length >= 10 && args.Value.Length <= 20)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void DdlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnselectCustomerHideUpdateTableAndMessage();
        }

        protected void DdlCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnselectCustomerHideUpdateTableAndMessage();
        }

        protected void GvCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            messageContainer.Visible = false;

            var IDCustomer = int.Parse(gvCustomers.SelectedDataKey.Value.ToString());

            Customer customer = Repo.RetrieveCustomerByID(IDCustomer);
            txtFirstName.Text = customer.FirstName;
            txtLastName.Text = customer.LastName;
            txtEmail.Text = customer.Email;
            txtPhone.Text = customer.Phone;

            HandleDdlUpdateCountriesAndCities();

            title.InnerText = "Update customer";
            btnDelete.Visible = true;
            Update = true;
            createOrUpdateTable.Visible = true;
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (Update)
                {
                    UpdateCustomer();
                    message.InnerText = "Customer updated!";
                }
                else
                {
                    CreateCustomer();
                    message.InnerText = "Customer created!";
                }

                UnselectCustomerHideUpdateTableAndMessage();
                messageContainer.Visible = true;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            UnselectCustomerHideUpdateTableAndMessage();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            var IDCustomer = int.Parse(gvCustomers.SelectedDataKey.Value.ToString());
            Repo.DeleteCustomerByID(IDCustomer);
            UnselectCustomerHideUpdateTableAndMessage();
            message.InnerText = "Customer deleted!";
            messageContainer.Visible = true;
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            gvCustomers.SelectedIndex = -1;
            messageContainer.Visible = false;

            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;

            HandleDdlUpdateCountriesAndCities();

            title.InnerText = "Create customer";
            btnDelete.Visible = false;
            Update = false;
            createOrUpdateTable.Visible = true;
        }

        protected void BtnGenerateError_Click(object sender, EventArgs e)
        {
            throw new HttpUnhandledException();
        }

        protected void Page_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError().GetBaseException().Message;
            Response.Redirect($"Error?error={error}");
        }



        // Methods

        private void UnselectCustomerHideUpdateTableAndMessage()
        {
            gvCustomers.SelectedIndex = -1;
            createOrUpdateTable.Visible = false;
            messageContainer.Visible = false;
        }

        private void CreateCustomer()
        {
            Customer customer = new Customer
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                City = Repo.RetrieveCityByID(int.Parse(ddlUpdateCities.SelectedValue))
            };

            Repo.CreateCustomer(customer);
        }

        private void UpdateCustomer()
        {
            var IDCustomer = int.Parse(gvCustomers.SelectedDataKey.Value.ToString());

            Customer customer = new Customer
            {
                ID = IDCustomer,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                City = Repo.RetrieveCityByID(int.Parse(ddlUpdateCities.SelectedValue))
            };

            Repo.UpdateCustomerByID(customer);
        }

        private void HandleDdlUpdateCountriesAndCities()
        {
            ddlUpdateCountries.SelectedValue = ddlCountries.SelectedValue;
            if (ddlUpdateCities.Items.Contains(ddlCities.SelectedItem))
            {
                ddlUpdateCities.SelectedValue = ddlCities.SelectedValue;
            }
            else
            {
                ddlUpdateCities.Items.Clear();
                ddlUpdateCities.SelectedValue = ddlCities.SelectedValue;
            }
        }
    }
}