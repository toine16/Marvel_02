using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Marvel_02.Tools.AccesDB
{
  
        public abstract class BaseRepository<T>

        {
            protected string _cnsrt = @"Data Source=FORMA-VDI210\TFTIC;Initial Catalog=Marvel;Persist Security Info=True;User ID=sa;Password=tftic@2012";
            protected string OneCommand;
            protected string UpdateCommand;
            protected string DeleteCommand;
            protected string InsertCommand;
             protected string AllCommand;

            public abstract int Add(T o);
            public abstract int Update(T o);

            public bool Remove(T o, int id)
            {
                using (DbConnect db = new DbConnect(_cnsrt))
                {
                    db.connect();
                    Dictionary<string, object> dico = new Dictionary<string, object>();

                    foreach (PropertyInfo i in o.GetType().GetProperties())
                    {
                        dico.Add(i.Name, i.GetValue(i));
                    }

                    string query = "Delete " + o.GetType().Name + " where @Id =" + id;
                    bool ttt = db.Delete(query, dico);
                    return ttt;
                }
            }

            public Dictionary<string, object> GetOne(T o, int id)
            {
                Dictionary<string, object> retour = new Dictionary<string, object>();

                using (DbConnect db = new DbConnect(_cnsrt))
                {
                    db.connect();
                    Dictionary<string, object> dico = new Dictionary<string, object>();

                    foreach (PropertyInfo i in o.GetType().GetProperties())
                    {
                        dico.Add(i.Name, i.GetValue(i));
                    }

                    string query = "Select * from " + o.GetType().Name + " where @Id = " + id;
                    retour = db.Select(query, dico).FirstOrDefault();

                }

                return retour;
            }

            public IEnumerable<Dictionary<string, object>> GetAll(T o)
            {
                List<Dictionary<string, object>> retour = new List<Dictionary<string, object>>();

                using (DbConnect db = new DbConnect(_cnsrt))
                {
                    db.connect();
                    string query = "Select * from " + o.GetType().Name;
                    retour = db.Select(query, null);

                }

                return retour;
            }

            public abstract Dictionary<string, object> MapTtoDico(T o);
            public abstract T MapDicoToT(Dictionary<string, object> dico);
        }
    }
