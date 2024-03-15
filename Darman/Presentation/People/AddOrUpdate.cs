using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Darman.Datalayer.Repository;
using Darman.Datalayer.Services;
using Darman.Utility;
namespace Darman.Presentation.People
{
    public partial class AddOrUpdate : Form     
    {
        public AddOrUpdate()
        {
            InitializeComponent();
        }

        private void AddPerson_Click(object sender, EventArgs e)
        {
            if (Validator.frmValidator(this))
            {
                if (Validator.CheckSSID(SSID_TxtBox.Text))
                {
                    IPersonRepository personRepository = new PersonRepository();
                    bool Create = personRepository.insert(FullName_TxtBox.Text.Trim(), SSID_TxtBox.Text.Trim(), FatherName_TextBox.Text.Trim());
                    if (Create)
                    {
                        MyMessage.IsSuccess("عملیات ثبت موفق آمیز بود ");
                        ClearTXT();
                    }
                }
            }
        }
        void ClearTXT()
        {
            FullName_TxtBox.Text = SSID_TxtBox.Text = FatherName_TextBox.Text = "";
            FullName_TxtBox.Focus();
        }
    }
}
