using Marvel_02.Models.FromDB;
using Marvel_02.Models.ToView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marvel_02.Tools.AccesDB
{
    public class AdresseRepository : BaseRepository<Adresse>
    {
        private string oneCommand = "Insert into Adresse(Ville,CP, Rue, Numero,Boite,IdPersonne) output Inserted.IdAdresse "
           + "Values (@Ville,@CP, @Rue, @Numero,@Boite,@IdPersonne)";
        public override int Add(Adresse o)
        {
            using (DbConnect db = new DbConnect(_cnsrt))
            {
                db.connect();

                return db.insert(oneCommand, MapTtoDico(o));
            }
        }

        public override Adresse MapDicoToT(Dictionary<string, object> dico)
        {
            Adresse a = new Adresse
            {
                Boite = (char)dico["Boite"],
                CP = (int)dico["CP"],
                Numero = (int)dico["Numero"],
                Rue = dico["Rue"].ToString(),
                Ville = dico["Ville"].ToString(),
                IdPersonne = (int)dico["IdPersonne"],
                IdAdresse = (int)dico["IdAdresse"]
            };

            return a;
        }

        public override Dictionary<string, object> MapTtoDico(Adresse o)
        {
            Dictionary<string, object> dico = new Dictionary<string, object>();
            dico.Add("Boite", o.Boite);
            dico.Add("CP", o.CP);
            dico.Add("Numero", o.Numero);
            dico.Add("Rue", o.Rue);
            dico.Add("Ville", o.Ville);
            dico.Add("IdPersonne", o.IdPersonne);
            dico.Add("IdAdresse", o.IdAdresse);

            return dico;
        }

        public Adresse MapInscriptionModelToAdresse(InscriptionModel o)
        {
            Adresse a = new Adresse
            {
                Boite= o.Boite,
                CP = o.CP,
                Numero = o.Numero,
                Rue = o.Rue,
                Ville = o.Ville,
                IdPersonne = 0,
                IdAdresse = 0
               
        };
            return a;
        }
        public override int Update(Adresse o)
        {
            throw new NotImplementedException();
        }
    }
}