using Marvel_02.Models.FromDB;
using Marvel_02.Models.ToView;
using Marvel_02.Tools.AccesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marvel_02.Tools.AccesDB
{
    public class InscriptionRepository : BaseRepository<InscriptionModel>
    {

        public override int Add(InscriptionModel o)
        {
            using (DbConnect db = new DbConnect(_cnsrt))
            {
                db.connect();
                // Personne 
                PersonneRepository PR = new PersonneRepository();
                int IdPersonne = PR.Add(PR.MapInscriptionModelToPersonne(o));

                // Adresse 
                AdresseRepository AR = new AdresseRepository();
                Adresse ad = AR.MapInscriptionModelToAdresse(o);
                ad.IdPersonne = IdPersonne;
                AR.Add(ad);
                
                return IdPersonne;
            }
        }

        public override InscriptionModel MapDicoToT(Dictionary<string, object> dico)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, object> MapTtoDico(InscriptionModel o)
        {
            Dictionary<string, object> dico = new Dictionary<string, object>();
            dico.Add("Nom", o.Nom);
            dico.Add("Prenom", o.Prenom);
            dico.Add("Age", o.Age);
            dico.Add("Sexe", o.Sexe);
            dico.Add("Mail", o.Mail);
            dico.Add("Pseudo", o.Pseudo);

            // Mot de passe
            dico.Add("MotDePasse", o.MotDePasse);
            dico.Add("Hash", "");

            //Adresse
            dico.Add("Ville", o.Ville);
            dico.Add("CP", o.CP);
            dico.Add("Rue", o.Rue);
            dico.Add("Numero", o.Numero);
            dico.Add("Boite", o.Boite);

            dico.Add("IdPersonne", o.Nom);

            return dico;           
        }

        public override int Update(InscriptionModel o)
        {
            throw new NotImplementedException();
        }
    }
}