using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus
{
    public class Articles
    {
        //private string refArticle;
        public string refArticle{set;get;}

        //private string description;
        public string description { set; get; }

        //private string sousFamile;
        public string sousFamile { set; get; }

        public string famile { set; get; }

        public string marque { set; get; }

        public string prixHT { set; get; }

        //private string quantite;

        public Articles()
        {

        }

        public Articles(string d, string r, string m, string f, string sf, string p)
        {
            this.description = d;
            this.refArticle = r;
            this.marque = m;
            this.famile = f;
            this.sousFamile = sf;
            this.prixHT = p;
        }


    }
}
