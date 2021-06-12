using System;
using System.Windows.Forms;

namespace FoodMataDemo
{
    public partial class FoodMata : Form
    {
        Database databaseObject = new Database();
        public FoodMata()
        {
            InitializeComponent();
            
        }
        string User_Name, User_Location, Phone_Number, Account_Name, Bank_Name, Website;
        long Account_Number;

        public void ClearAll()
        {
            txtName.Clear();
            txtLocation.Clear();
            txtPhoneNumber.Clear();
            txtAccountName.Clear();
            txtAccountNumber.Clear();
            txtBankName.Clear();
            txtWebsite.Clear();
        }
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            User_Name = txtName.Text;
            User_Location = txtLocation.Text;
            Phone_Number = txtPhoneNumber.Text;
            Account_Name = txtAccountName.Text;
            Bank_Name = txtBankName.Text;
            Website = txtWebsite.Text;
            try 
            { 
                Account_Number = long.Parse(txtAccountNumber.Text); 
            }
            catch(Exception ex)
            {
                txtAccountNumber.Clear();
                MessageBox.Show("Account Number must be integer\n" + ex.Message);
            }
            if (User_Name == "" || User_Location == "" || Phone_Number == "" || Account_Name == "" || Bank_Name == "" || Website == "" || txtAccountNumber.Text == "")
            {
                MessageBox.Show("Field(s) cannot be empty.\n Please fill all fields");
            }
            else
            {
                //databaseObject.CreateTable();
                databaseObject.InsertData(User_Name, User_Location, Phone_Number, Account_Name, Account_Number, Bank_Name, Website);
                MessageBox.Show("Your Data has been saved.\nThank you");
                ClearAll();
            }
        }
    }
}
