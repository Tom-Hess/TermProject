using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.ComponentModel;

namespace TermProject
{
    public partial class gvAccount : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [Category("Misc")]
        public String AccountID
        {
            get { return AccountID; }
            set { AccountID = value; }
        }

        [Category("Misc")]
        public String Name
        {
            get { return AccountID; }
            set { AccountID = value; }
        }

        [Category("Misc")]
        public String AccountType
        {
            get { return AccountType; }
            set { AccountType = value; }
        }

        [Category("Misc")]
        public String Email
        {
            get { return Email; }
            set { Email = value; }
        }

        [Category("Misc")]
        public String StorageSpace
        {
            get { return StorageSpace; }
            set { StorageSpace = value; }
        }

        [Category("Misc")]
        public String StorageUsed
        {
            get { return StorageUsed; }
            set { StorageUsed = value; }
        }

        public override void DataBind()
        {
            //DBConnect objDB = new DBConnect();
            //String strSQL = "SELECT Description, Price FROM Product WHERE ProductNumber=" + productID;
            //objDB.GetDataSet(strSQL);
            //lblDesc.Text = (String)objDB.GetField("Description", 0);
            //Decimal price = (Decimal)objDB.GetField("Price", 0);
            //lblPrice.Text = price.ToString("C2");

        }
    }
}