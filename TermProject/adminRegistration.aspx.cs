using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TermProjectLibrary;
using System.Data;
using Utilities;
namespace TermProject
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        Validation myValidation = new Validation();
        DBConnect myDB = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (myValidation.IsEmpty(txtName.Text))
            {
                lblMsg.Text = "Name cannot be blank. ";
            }
            else if (myValidation.IsEmpty(txtEmail.Text))
            {
                lblMsg.Text = "Email cannot be blank. ";
            }
            else if (myValidation.IsEmpty(txtPassword.Text))
            {
                lblMsg.Text = "Password cannot be blank. ";
            }
            else if (myValidation.IsEmpty(txtConfirm.Text))
            {
                lblMsg.Text = "Confirmation Password cannot be blank. ";
            }
            else if (txtPassword.Text != txtConfirm.Text)
            {
                lblMsg.Text = "Password and Confirmation Password must be the same. ";
            }
            else
            {
                //create the Admin in the Database, display message
                SqlCommand myCommand = new SqlCommand();
                myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                myCommand.CommandText = "AddAdmin";

                SqlParameter myParameter = new SqlParameter("Name", txtName.Text);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("Password", txtPassword.Text);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("Email", txtEmail.Text);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                int returnValue = myDB.DoUpdateUsingCmdObj(myCommand);


                //account is added
                if(returnValue > 0)
                {

                } else
                {
                    //SP failed
                    
                }


            }
        }
    }
}