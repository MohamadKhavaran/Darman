using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Darman.Datalayer.Repository
{
    public interface IPersonRepository
    {
        //CRUD  : Create Read Update Delete 
        bool insert(string Name, string SSID, string FatherName);
        bool update(int Id, string Name, string SSID, string FatherName);
        bool Delete(int Id);
        DataTable SearchAll();
    }
}
