using Marvel_02.Tools.AccesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Marvel_02.Models.FromDB;
using Marvel_02.Models.ToView;
using System.Text;
using System.Data.SqlClient;

namespace Marvel_02.Tools.AccesDB
{
    public class PersonneRepository : BaseRepository<Personne>
    {
        private string oneCommand = "Insert into Personne(Nom,Prenom, Age, Sexe,Mail,MotDePasse,Pseudo,Hash) output Inserted.IdPersonne "
            + "Values (@Nom,@Prenom, @Age, @Sexe,@Mail,@MotDePasse,@Pseudo,@Hash)";
        private string personnePseudoCommand = "Select * from Personne where Pseudo = ";
        public override int Add(Personne o)
        {
            using (DbConnect db = new DbConnect(_cnsrt))
            {
                db.connect();

                return db.insert(oneCommand,MapTtoDico(o));
            }
        }

        public override Personne MapDicoToT(Dictionary<string, object> dico)
        {
            Personne p = new Personne
            {
                Nom = dico["Nom"].ToString(),
                Prenom = dico["Prenom"].ToString(),
                Age = (int)dico["Age"],
                Sexe = (bool)dico["Sexe"],
                Mail = dico["Mail"].ToString(),
                Pseudo = dico["Pseudo"].ToString(),
                Hash = dico["Hash"].ToString(),
                MotDePasse = dico["MotDePasse"].ToString(),
                IdPersonne = (int)dico["IdPersonne"]

            };

            return p;
        }

        public override Dictionary<string, object> MapTtoDico(Personne o)
        {
            Dictionary<string, object> dico = new Dictionary<string, object>();
            dico.Add("Nom", o.Nom);
            dico.Add("Prenom", o.Prenom);
            dico.Add("Age", o.Age);
            dico.Add("Sexe", o.Sexe);
            dico.Add("Mail", o.Mail);
            dico.Add("Pseudo", o.Pseudo);

            dico.Add("Hash", o.Hash);
            dico.Add("MotDePasse",o.MotDePasse);
            dico.Add("IdPersonne", o.IdPersonne);
           
            return dico;
        }

        public Personne MapInscriptionModelToPersonne(InscriptionModel o)
        {
            Personne p = new Personne
            {
                Nom = o.Nom,
                Prenom = o.Prenom,
                Age = o.Age,
                Sexe = o.Sexe,
                Mail = o.Mail,
                Pseudo = o.Pseudo,
                IdPersonne = 0              
            };

            p.Hash = HashGenerator();
            p.MotDePasse = MD5Password(o.MotDePasse, p.Hash);
            return p;            
        }

        public override int Update(Personne o)
        {
            throw new NotImplementedException();
        }

        public string HashGenerator()
        {
            return Guid.NewGuid().ToString();
        }

        public string MD5Password(string mdp, string hash)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(mdp+hash);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public Personne GetPersonneByPseudo(string pseudo)
        {
            using (SqlConnection db = new SqlConnection(_cnsrt))
            {
                db.Open();
                SqlCommand command = new SqlCommand(personnePseudoCommand + "'" + pseudo + "'",db);
                Dictionary<string, object> dico = new Dictionary<string, object>();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                for (int i = 0; i< reader.FieldCount; i++)
                {
                    
                    dico.Add(reader.GetName(i).ToString(), reader[i]);
                }

                return MapDicoToT(dico);

            }
        }

        public bool CheckPassword(string mdp, string pseudo)
        {
            Personne p = GetPersonneByPseudo(pseudo);

            return p.MotDePasse.Equals(MD5Password(mdp, p.Hash));
        }
    }
}