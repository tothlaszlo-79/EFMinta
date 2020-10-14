using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.AdditionalModels;

namespace DataAccessLayer.Controller
{
    public interface ITableWithForigenKeyInterface
    {
        bool CreateTableWithForigenKeyRecord(TableWithForigenKey adat, int ForeignKey);
        IEnumerable<TableWithForigenKey> GetAll();
        IEnumerable<TableWithLinkedData> GetAll_linked();
        IEnumerable<TableWithForigenKey> GetById(int nid);
        IEnumerable<TableWithLinkedData> GetAll_linked_ID(int nid);
        bool ModifyTableWithForigenKeyRecord(TableWithForigenKey adat);
        bool DeleteTableWithForigenKeyRecord(int nid);
    }
    public class TableWithForigenKeyController : ITableWithForigenKeyInterface
    {
        static enMintaDb enMintaDb;

        public TableWithForigenKeyController()
        {
            enMintaDb = new enMintaDb();
          
        }

        public bool CreateTableWithForigenKeyRecord(TableWithForigenKey adat, int ForeignKey)
        {
            try
            {
                //ide kell betölteni a külső kulcsot
                ForigenKeyTable key = enMintaDb.ForigenKeyTable.First(f => f.nid == ForeignKey);

                enMintaDb.TableWithForigenKey.Add(new TableWithForigenKey { 
                SajatAdat1 = adat.SajatAdat1,
                SajatAdat2 = adat.SajatAdat2,
                SajatAdat3 = adat.SajatAdat3,
                ForigenKeyTable_id = key.nid,
                Active = true
                });
                
                enMintaDb.SaveChanges();
                return true;
            }
            catch (InvalidOperationException e)
            {
                ShowInfo info = new ShowInfo();
                info.ShowMessage(e.InnerException.ToString());
                return false;
            }
            catch (ArgumentNullException e)
            {
                ShowInfo info = new ShowInfo();
                info.ShowMessage(e.InnerException.ToString());
                return false;
            }
            catch (Exception ex)
            {
                ShowInfo info = new ShowInfo();
                info.ShowMessage(ex.InnerException.ToString());
                return false;
            }

        }

        public bool DeleteTableWithForigenKeyRecord(int nid)
        {
            try
            {
                //megkeressük az érintett rekordot a táblában
                var TableWithForeignKeyRemove = enMintaDb.TableWithForigenKey.Find(nid);
                enMintaDb.TableWithForigenKey.Remove(TableWithForeignKeyRemove);
                enMintaDb.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<TableWithForigenKey> GetAll()
        {
            return enMintaDb.TableWithForigenKey.ToList();
        }

        public IEnumerable<TableWithLinkedData> GetAll_linked()
        {
            //Linq összetett adatokra
            var mindenadat =
                (from Main1 in enMintaDb.TableWithForigenKey
                 from keyt in enMintaDb.ForigenKeyTable
                 where Main1.ForigenKeyTable_id == keyt.nid && Main1.Active == true
                 select new TableWithLinkedData
                 {
                     Adat1 = Main1.SajatAdat1,
                     Adat2 = Main1.SajatAdat2,
                     Adat3 = Main1.SajatAdat3,
                     Adat4 = keyt.KulsoAdat1
                 }).ToList();
            return mindenadat;
        }

        public IEnumerable<TableWithLinkedData> GetAll_linked_ID(int nid)
        {
            var mindenadat =
         (from main in enMintaDb.TableWithForigenKey
          from keyt in enMintaDb.ForigenKeyTable
          where main.ForigenKeyTable_id == keyt.nid && main.Active == true && main.nid == nid
          select new TableWithLinkedData
          {
              Adat1 = main.SajatAdat1,
              Adat2 = main.SajatAdat2,
              Adat3 = main.SajatAdat3,
              Adat4 = keyt.KulsoAdat1
          }).ToList();
            return mindenadat;
        }

        public IEnumerable<TableWithForigenKey> GetById(int nid)
        {
           yield return enMintaDb.TableWithForigenKey.FirstOrDefault( t => t.nid == nid);
        }

        public bool ModifyTableWithForigenKeyRecord(TableWithForigenKey adat)
        {
            try
            {
                //megkeressük az adott rekordot a Find metódus segítségével és az elsődleges kulcs értékkel
                var tableWithForeignKeyModify = enMintaDb.TableWithForigenKey.Find(adat.nid);
                if(tableWithForeignKeyModify == null) { return false; }
                else {
                    enMintaDb.Entry(tableWithForeignKeyModify).CurrentValues.SetValues(adat);
                    enMintaDb.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
