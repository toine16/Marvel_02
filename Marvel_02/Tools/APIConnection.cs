using Marvel_02.Models.FromAPI;
using Marvel_02.Models.ToView;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Marvel_02.Tools
{
    public static class APIConnection
    {
        public static CharacterList getCharacterList(int page = 1)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://gateway.marvel.com");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string lien = "/v1/public/characters?ts=1&apikey=81ca23b977c4b9d1f55715b9f4b16b50&hash=36261a4a1ba872396797b75452408068&offset=" + (page-1) * 20;
            HttpResponseMessage reponse = client.GetAsync(lien).Result;
            CharacterDataWrapper e = new CharacterDataWrapper();
            if (reponse.IsSuccessStatusCode)
            {

                string contenu = reponse.Content.ReadAsStringAsync().Result;
                e = JsonConvert.DeserializeObject<CharacterDataWrapper>(contenu);
            }

            CharacterList retour = new CharacterList();
            foreach (Character element in e.data.results)
            {
                retour.items.Add(element);
            }

            return retour;
        }

        public static Character getCharacter(string name)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://gateway.marvel.com");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string lien = "/v1/public/characters?ts=1&apikey=81ca23b977c4b9d1f55715b9f4b16b50&hash=36261a4a1ba872396797b75452408068&name=" + name;
//ttps://gateway.marvel.com/v1/public/characters?ts=1&apikey=81ca23b977c4b9d1f55715b9f4b16b50&hash=36261a4a1ba872396797b75452408068&name=Spider-Man
            HttpResponseMessage reponse = client.GetAsync(lien).Result;
            CharacterDataWrapper e = new CharacterDataWrapper();
            if (reponse.IsSuccessStatusCode)
            {

                string contenu = reponse.Content.ReadAsStringAsync().Result;
                e = JsonConvert.DeserializeObject<CharacterDataWrapper>(contenu);
            }

            Character retour = new Character();
            if(e.data.count != 0)
            {
                retour = e.data.results.FirstOrDefault();
            }
            else
            {
                retour.id = 0;
            }

            return retour;
        }
    }
}