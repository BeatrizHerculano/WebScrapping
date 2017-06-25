using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WebScrapping.Models;
using System.Text;

namespace WebScrapping
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> verbosInfinitivos = new List<string>();
                verbosInfinitivos.Add("olho");
                verbosInfinitivos.Add("caio");
                verbosInfinitivos.Add("sei");
                verbosInfinitivos.Add("corre");
                verbosInfinitivos.Add("vimos");
                verbosInfinitivos.Add("gosto");
                verbosInfinitivos.Add("Deus");  
                var baseUrl = "https://www.conjugacao.com.br";
                var client = new HtmlWeb();
                client.OverrideEncoding = Encoding.UTF8;
                foreach (string verbo in verbosInfinitivos)
                {
                    var conjugations = client.Load(baseUrl + "/busca.php?q=" + verbo);
                    if (conjugations.DocumentNode.SelectNodes("//span[@class=\"f\"]") != null)
                    {
                        var conjugationLength = conjugations.DocumentNode.SelectNodes("//span[@class=\"f\"]").Count;
                        var conjugationList = conjugations.DocumentNode.SelectNodes("//span[@class=\"f\"]");
                        //
                        Console.WriteLine(conjugationLength);
                        if (conjugationLength > 0)
                        {
                            Console.WriteLine(conjugationList[0].InnerText);
                            //foreach (var item in conjugationList)
                            //{
                            //    Console.WriteLine(item.InnerHtml);
                            //}
                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        Console.WriteLine("O verbo " + verbo + " nao se encontra na base utilizada ou nao tem um infinitivo.");
                    }                    
                }
                Console.Read();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
