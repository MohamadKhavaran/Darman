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
namespace Darman.Presentation.People
{
    public partial class People : Form
    {
        public People()
        {
            InitializeComponent();
        }

        private void People_Load(object sender, EventArgs e)
        {
            IPersonRepository personRepository = new PersonRepository(); 
            dataGridViewPeople.DataSource = personRepository.SearchAll();
        }
    }
}
