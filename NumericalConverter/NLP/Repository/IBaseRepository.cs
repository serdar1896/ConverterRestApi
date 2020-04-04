using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Repository
{
    interface IBaseRepository
    {
        string[] kelimeAyir(string cumle);
        string harfAyir(string[] bol, Hashtable liste);
        string Cevir(string[] bol, Hashtable liste);
    }
}