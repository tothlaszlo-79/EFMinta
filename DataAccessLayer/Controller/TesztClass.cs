using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Controller
{
    

    public class TesztClass : IMainCRUD<SingleTable>
    {
        private static enMintaDb enMintaDb;

        public TesztClass()
        {
            enMintaDb = new enMintaDb();
        }

        public bool Create(SingleTable adat)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SingleTable> GetAll()
        {
            return enMintaDb.SingleTable.Where(s => s.Active == true);
        }

        public IEnumerable<SingleTable> GetByID(int id)
        {
            return enMintaDb.SingleTable.Where(s => s.Active == true && s.nid == id);
        }

        public bool Modify(SingleTable adat)
        {
            throw new NotImplementedException();
        }

        public bool Teszt()
        {
            throw new NotImplementedException();
        }
    }
}
