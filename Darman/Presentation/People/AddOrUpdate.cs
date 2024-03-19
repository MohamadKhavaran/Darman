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
        public int PersonId = 0;
        IPersonRepository _personRepository;
        public AddOrUpdate()
        {
            _personRepository = new PersonRepository();
            InitializeComponent();
        }

        private void AddPerson_Click(object sender, EventArgs e)
        {
            if (PersonId == 0)
            {
                if (Validator.frmValidator(this))
                {
                    if (Validator.CheckSSID(SSID_TxtBox.Text))
                    {
                        bool Create = _personRepository.insert(FullName_TxtBox.Text.Trim(), SSID_TxtBox.Text.Trim(), FatherName_TextBox.Text.Trim());
                        if (Create)
                        {
                            MyMessage.IsSuccess("عملیات ثبت موفق آمیز بود ");
                            ClearTXT();
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                if (Validator.frmValidator(this))
                {
                    if (Validator.CheckSSID(SSID_TxtBox.Text))
                    {
                        bool Create = _personRepository.update(PersonId, FullName_TxtBox.Text.Trim(), SSID_TxtBox.Text.Trim(), FatherName_TextBox.Text.Trim());
                        if (Create)
                        {
                            MyMessage.IsSuccess("عملیات ویرایش با موفقیت انجام شد ");
                            ClearTXT();
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
        }
        void ClearTXT()
        {
            FullName_TxtBox.Text = SSID_TxtBox.Text = FatherName_TextBox.Text = "";
            FullName_TxtBox.Focus();
        }

        private void AddOrUpdate_Load(object sender, EventArgs e)
        {
            if (PersonId != 0)
            {
                DataTable dataTable = new DataTable();
                dataTable = _personRepository.GetById(PersonId);
                FullName_TxtBox.Text = dataTable.Rows[0]["Name"].ToString();
                SSID_TxtBox.Text = dataTable.Rows[0]["SSID"].ToString();
                FatherName_TextBox.Text = dataTable.Rows[0]["FatherName"].ToString();
                this.Text = $"ویرایش اطلاعات شخص : {FullName_TxtBox.Text}";
                Ok_Btn.Text = "بروزرسانی";
            }
        }
    }
}
