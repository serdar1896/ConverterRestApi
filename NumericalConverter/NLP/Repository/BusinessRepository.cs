using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLP.Data;
using NLP.Models;
using static NLP.Data.DataList;

namespace NLP.Repository
{
    public class BusinessRepository:BaseRepository
    {
        readonly DataList datalist = new DataList();
        public string ConvertToNumeric(string metin)
        {         
            string[] bol = kelimeAyir(metin);
            bol = kelimeAyir(harfAyir(bol, datalist.liste));
            return Cevir(bol, datalist.liste); // Json formatına göre config edildi.
        }
    }
}