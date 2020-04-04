using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace NLP.Repository
{
    public class BaseRepository : IBaseRepository
    {
 

        public string Cevir(string[] bol, Hashtable liste)
        {
            StringBuilder cumle = new StringBuilder();
            int toplam = 0, sayac = 0, sayi = 0;
           
            for (int i = 0; i < bol.Length; i++)
            {
                //Yazılan Kelime listede var mı veya sayı mı? 
                if (liste.Contains(bol[i]) || liste.ContainsValue(bol[i]) || SayiMi(bol[i]))
                    {
                    sayac = 1;                    
                    //işlem yapılan kelimeden sonra bir kelime daha var iken
                    if (i + 1 < bol.Length)
                    {
                        //Ayrılan Kelime Rakam Mı?
                        int a = !liste.Contains(bol[i]) ? int.Parse(bol[i]) : int.Parse(liste[bol[i]].ToString());
                        //Sonraki Kelime listede var mı veya sayı mı? 
                        if (liste.Contains(bol[i + 1]) || liste.ContainsValue(bol[i + 1]) || SayiMi(bol[i+1]))
                        {
                            //Sonraki kelime Rakam Mı? 
                            int b = !liste.Contains(bol[i + 1]) ? int.Parse(bol[i + 1]) : int.Parse(liste[bol[i + 1]].ToString());
                            if (a < b)
                            {
                                if (toplam > 0 && toplam != 1000)
                                {
                                    sayi = (toplam + a) * b + sayi;
                                    toplam = 0;

                                }
                                else if (a < 10 && b > 99 && b < 1000 && toplam < 1000)
                                {
                                    toplam = a * b - b;
                                    i--;
                                }
                                else
                                {
                                    sayi = a * b + sayi + toplam;
                                    toplam = 0;
                                }
                                i++;
                            }
                            else   toplam = a + toplam;   
                        }
                        else sayi = a + toplam + sayi;
                    }
                }
                //Anlamsız bir kelimeyse
                else
                {
                    if (sayac > 0)
                    {
                        cumle.Append(sayi + " " + bol[i] + " ");
                        sayac = 0;
                        sayi = 0;
                        toplam = 0;
                    }
                    else cumle.Append(bol[i]+" ");
                }
            }
            return cumle.ToString();
        }
        public string harfAyir(string[] bol, Hashtable liste)
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < bol.Length; i++)
            {
                for (int j = 0; j < bol[i].Length - 1; j++)
                {
                    for (int k = 1; k <= bol[i].Length - j; k++)
                    {
                        if (liste.Contains(bol[i].Substring(j, k)))
                        {
                            if (bol[i].Substring(0, j) != "")
                            {
                                str.Append(" "+bol[i].Substring(0,j));
                                str.Append(" "+bol[i].Substring(j,k));
                                bol[i] = bol[i].Remove(j, k);
                                bol[i] = bol[i].Remove(0, j);
                            }
                            else
                            {
                                str.Append(" " + bol[i].Substring(j, k));                                                      
                                bol[i] = bol[i].Remove(j, k);
                            }
                            j = 0;
                            k = 1;
                        }
                    }
                }
                if (bol[i] == "")                
                    str.Append(bol[i]);                
                else                
                    str.Append(" " + bol[i]);                  
            }               
            return str.ToString();
        }
        public string[] kelimeAyir(string cumle)
        {
            string[] bol = cumle.Split(' ');
            return bol;
        }
        public static bool SayiMi(string strVeri)
        {
            if (String.IsNullOrEmpty(strVeri) == true)
            {
                return false;
            }
            else
            {
                Regex desen = new Regex("^[0-9]*$");
                return desen.IsMatch(strVeri);
            }
        }

    }
}