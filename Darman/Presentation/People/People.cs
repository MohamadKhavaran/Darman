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
    public partial class People : Form
    {
        IPersonRepository _personRepository;
        public People()
        {
            _personRepository = new PersonRepository();
            InitializeComponent();
        }

        private void People_Load(object sender, EventArgs e)
        {
            GridData();
        }
        void GridData()
        {
            dataGridViewPeople.AutoGenerateColumns = false;
            dataGridViewPeople.AllowUserToAddRows = false;
            dataGridViewPeople.DataSource = _personRepository.SearchAll();
            if (dataGridViewPeople.Rows.Count > 0)
                dataGridViewPeople.Rows[0].Selected = false;
        }

        private void AddPerson_Click(object sender, EventArgs e)
        {
            AddOrUpdate frmAddOrUpdate = new AddOrUpdate();
            if (frmAddOrUpdate.ShowDialog() == DialogResult.OK)
            {
                GridData();
            }

        }

        private void DeletePerson_Click(object sender, EventArgs e)
        {
            if (dataGridViewPeople.SelectedRows.Count > 0)
            {
                int Id = int.Parse(dataGridViewPeople.CurrentRow.Cells[0].Value.ToString());
                String Name = dataGridViewPeople.CurrentRow.Cells[1].Value.ToString();
                if (MyMessage.QuestionMessage($"آیا از حدف {Name} اطمینان دارید ؟") == DialogResult.Yes)
                {
                    _personRepository.Delete(Id);
                    MyMessage.IsSuccess("فرد مورد نظر با موفقیت حذف شد ");
                    GridData();
                }
            }

            else
            {
                MyMessage.ErrorMessage("لطفا یک فرد را جهت حذف شدن انتخاب کنید");
            }

        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (dataGridViewPeople.SelectedRows.Count > 0)
            {
                AddOrUpdate frm = new AddOrUpdate();
                int Id = int.Parse(dataGridViewPeople.CurrentRow.Cells[0].Value.ToString());
                frm.PersonId = Id;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    GridData();
                }
            }
            else
            {
                MyMessage.ErrorMessage("فردی را جهت ویرایش انتخاب کنید ");
            }
        }

        private void Search_TxtBox_TextChanged(object sender, EventArgs e)
        {
            
                DataTable dataTable = _personRepository.SearchByParam(Search_TxtBox.Text);
                dataGridViewPeople.AutoGenerateColumns = false;
                dataGridViewPeople.DataSource = dataTable;
            
        }
    }
}
