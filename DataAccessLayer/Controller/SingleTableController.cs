using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DataAccessLayer.Controller
{

    public interface ISingleTableInterface
    {
        bool CreateSingleTableRecord(SingleTable adat);
        IEnumerable<SingleTable> GetAll();
        IEnumerable<SingleTable> GetById(int nid);
        IEnumerable<SingleTable> GetByAdat1(string adat);
        bool ModifySingleTableRecord(SingleTable adat);
        bool DeleteSingleTableRecord(int nid);
    }

    public class SingleTableController : ISingleTableInterface
    {
        static enMintaDb enMintaDb;

        public SingleTableController()
        {
            enMintaDb = new enMintaDb();
        }

        public bool CreateSingleTableRecord(SingleTable adat)
        {
            try
            {

                enMintaDb.SingleTable.Add(adat);
                enMintaDb.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteSingleTableRecord(int nid)
        {
            try {
                //megkeressük az érintett rekordot a táblában
                var singleTableRemovable = enMintaDb.SingleTable.Find(nid);
                enMintaDb.SingleTable.Remove(singleTableRemovable);
                enMintaDb.SaveChanges();
                return true;
            }
            catch {

                return false;
            }
        }

        public IEnumerable<SingleTable> GetAll()
        {
            return enMintaDb.SingleTable.Where(s => s.Active == true).ToList();
        }

        public IEnumerable<SingleTable> GetByAdat1(string adat)
        {
            yield return enMintaDb.SingleTable.FirstOrDefault(s => s.Adat1 == adat.ToString());
        }

        public IEnumerable<SingleTable> GetById(int nid)
        {
            //a yield biztosítja, hogy nem kell külön osztály deklaráció a visszatérő adatnál
            yield return enMintaDb.SingleTable.FirstOrDefault(s => s.nid == nid & s.Active == true);
        }

        public bool ModifySingleTableRecord( SingleTable adat)
        {
            try
            {
                //lekérdezzük az id alapján melyik rekord az érintett
                var singleTableModify = enMintaDb.SingleTable.Find(adat.nid);
                //ha nincs eredmeény hibát adunk vissza
                if (singleTableModify == null) { return CreateSingleTableRecord(adat);  }
                else {
                    //módosítjuk az adott rekord tartlmát az új értékre (mindig egész feltöltött adatot küldünk)
                    enMintaDb.Entry(singleTableModify).CurrentValues.SetValues(adat);
                    enMintaDb.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
