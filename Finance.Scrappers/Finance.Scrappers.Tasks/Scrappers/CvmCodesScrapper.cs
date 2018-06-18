using Finance.Scrappers.Tasks.Scrappers.Interfaces;
using Finance.Shared.Scrapper;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Finance.Scrappers.Tasks.Scrappers
{
    public class CvmCodesScrapper : ScrapperBase<int[]>,  ICvmCodesScrapper
    {

        private const string CVM_CODES_URL = "http://bvmf.bmfbovespa.com.br/cias-listadas/empresas-listadas/BuscaEmpresaListada.aspx?Letra={0}&idioma=pt-br";

        public override async Task<int[]> ExecuteScrapAsync()
        {
            var documentToScrap = new HtmlDocument();
            var cvmCodes = new List<int>();

            foreach (var word in "ABCDEFGHIJKLMNOPQRSTWXYZ0123456789".ToCharArray())
            {
                var html = await this.GetHtmlStringAsync(string.Format(CVM_CODES_URL, word));
                documentToScrap.LoadHtml(html);

                var documentNode = documentToScrap.DocumentNode;

                documentNode
                    .SelectNodes("//table[@class='MasterTable_SiteBmfBovespa']/tbody/tr")
                    ?.ToList()
                    .ForEach(x =>
                    {
                        var tds = x.ChildNodes.Where(n => n.Name == "td").ToArray();
                        var hrefText = tds[0].ChildNodes[0].ChildAttributes("href").Single().Value;
                        var codigoCVM = Convert.ToInt32(new Regex("\\d+").Match(hrefText).Value);
                        cvmCodes.Add(codigoCVM);
                    });
            }

            return cvmCodes.ToArray();
        }
    }
}
