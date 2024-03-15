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
using Darman.Presentation.People;
namespace Darman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            IPersonRepository personRepository = new PersonRepository();
            personRepository.insert("حسین", "131", "علی");
        }

        private void AddPerson_Click(object sender, EventArgs e)
        {
           AddOrUpdate addOrUpdate = new AddOrUpdate();
            addOrUpdate.Show();
        }

        private void Click_ShowPeople(object sender, EventArgs e)
        {
            People people = new People();   
            people.Show();  

        }
    }
}
