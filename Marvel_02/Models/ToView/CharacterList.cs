using Marvel_02.Models.FromAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marvel_02.Models.ToView
{
    public class CharacterList
    {
        public CharacterList()
        {
            items = new List<Character>();
            page = 0;
        }

        public CharacterList(int page)
        {
            items = new List<Character>();
            this.page = page;
        }

        public CharacterList(List<Character> items)
        {
            this.items = items;
            page = 0;
        }

        public List<Character> items { get; set; }

        public int page;

    }
}