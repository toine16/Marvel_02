using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Marvel_02.Tools.AccesDB
{
    /// <summary>
    /// 
    /// </summary>
    public class DbConnect : IDisposable
    {
        #region Fields
        private string _cnstr;
        private SqlConnection _oConn;
        #endregion

        /// <summary>
        /// Constructeur de la classe DbConnect
        /// </summary>
        /// <param name="cnstr">La connectionstring pour la base de données ciblée</param>
        public DbConnect(string cnstr)
        {
            _cnstr = cnstr;
        }

        /// <summary>
        /// Permet de me connecter à la base de données
        /// </summary>
        /// <returns>True si la connection est effective, False dans le cas contraire</returns>
        public bool connect()
        {
            _oConn = new SqlConnection(_cnstr);

            try
            {
                _oConn.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Permet de se déconnecter de la base de données
        /// </summary>
        /// <returns>True si la déconnection est effective, False dans le cas contraire</returns>
        public bool disconnect()
        {
            try
            {
                _oConn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private SqlCommand CreateCommand(string Query, Dictionary<string, object> parametres = null)
        {
            if (_oConn != null && _oConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand _Ocmd = _oConn.CreateCommand();
                _Ocmd.CommandText = Query;

                //Ajout des paramètres
                if (parametres != null)
                {
                    foreach (KeyValuePair<string, object> item in parametres)
                    {
                        _Ocmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                return _Ocmd;
            }
            else
            {
                throw new InvalidOperationException("The Connection was not initialized");
            }
        }

        public List<Dictionary<string, object>> Select(String Query, Dictionary<string, object> parametres = null)
        {
            List<Dictionary<string, object>> retour = new List<Dictionary<string, object>>();

            SqlCommand _Ocmd = CreateCommand(Query, parametres);
            using (SqlDataReader oDr = _Ocmd.ExecuteReader())
            {

                while (oDr.Read())
                {


                    foreach (IDataRecord item in oDr)
                    {
                        Dictionary<string, object> ligne = new Dictionary<string, object>();
                        for (int i = 0; i < item.FieldCount; i++)
                        {
                            string key = item.GetName(i).ToString();
                            object valeur = item[i];

                            ligne.Add(key, valeur);
                        }
                        retour.Add(ligne);

                    }
                }
            }
            return retour;
        }

        /// <summary>
        /// Permet d'insérer des données
        /// </summary>
        /// <param name="Query">Requête d'insertion avec paramètres ou non (!!!Utiliser output pour le retrou de l'id)</param>
        /// <param name="parametres">Paramètres nécessaires à l'insert</param>
        /// <returns>l'id auto-incrémenté</returns>
        public int insert(string Query, Dictionary<string, object> parametres = null)
        {
            SqlCommand _Ocmd = CreateCommand(Query, parametres);

            return (int)_Ocmd.ExecuteScalar();


        }

        /// <summary>
        /// Permet de mettre à jour des données
        /// </summary>
        /// <param name="Query">Requête de mise à jour avec paramètres ou non  </param>
        /// <param name="parametres">Paramètres nécessaires à l'update</param>
        /// <returns>le nombre de lignes impactées</returns>
        public int Update(string Query, Dictionary<string, object> parametres = null)
        {
            SqlCommand _Ocmd = CreateCommand(Query, parametres);

            return (int)_Ocmd.ExecuteNonQuery();


        }

        /// <summary>
        /// Permet de supprimer des données
        /// </summary>
        /// <param name="Query">Requête de suppression avec paramètres ou non  </param>
        /// <param name="parametres">Paramètres nécessaires à la suppression</param>
        /// <returns>True si la suppression est effective, False dans le cas contraire</returns>
        public bool Delete(string Query, Dictionary<string, object> parametres = null)
        {
            SqlCommand _Ocmd = CreateCommand(Query, parametres);
            try
            {
                _Ocmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        public void Dispose()
        {

            if (_oConn != null)
            {
                if (_oConn.State != ConnectionState.Closed)
                {
                    disconnect();
                }
                _oConn.Dispose();
            }

        }
    }
}