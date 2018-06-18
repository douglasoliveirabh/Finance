using Finance.Scrappers.Domain.Entities;
using Finance.Scrappers.Tasks.Scrappers.Interfaces;
using Finance.Scrappers.Tasks.Scrappers.Providers;
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
    public class EmpresaScrapper : ScrapperBase<IEnumerable<Empresa>>, IEmpresaScrapper
    {
        private const string GET_EMPRESAS_URl = "http://bvmf.bmfbovespa.com.br/cias-listadas/empresas-listadas/ResumoEmpresaPrincipal.aspx?codigoCvm={0}&idioma=pt-br";
        private List<Empresa> empresas;

        private readonly ICvmCodesScrapper cvmCodesScrapper;
        private HtmlDocument documentToScrap;

        public EmpresaScrapper(ICvmCodesScrapper cvmCodesScrapper) : base()
        {            
            this.cvmCodesScrapper = cvmCodesScrapper;
            this.documentToScrap = new HtmlDocument();
        }

        public override async Task<IEnumerable<Empresa>> ExecuteScrapAsync()
        {
            var cvmCodes = await this.cvmCodesScrapper.ExecuteScrapAsync();

            var empresas = new List<Empresa>();

            foreach (var cvmCode in cvmCodes)
            {
                var html = await this.GetHtmlStringAsync(string.Format(GET_EMPRESAS_URl, cvmCode));
                this.documentToScrap.LoadHtml(html);

                //var empresa = new Empresa()


                documentToScrap
                    .DocumentNode
                    .SelectNodes("//div[@id='accordionDados']/table/tbody/tr")
                    ?.ToList()
                     .ForEach(x =>
                     {

                     });
            }

            return empresas;


            /*var documentToScrap = new HtmlDocument();

            foreach (var word in "ABCDEFGHIJKLMNOPQRSTWXYZ0123456789".ToCharArray())
            {
                var html = await this.GetHtmlStringAsync(string.Format(GET_EMPRESAS_URl, word));
                documentToScrap.LoadHtml(html);

                var documentNode = documentToScrap.DocumentNode;

                documentNode
                    .SelectNodes("//table[@class='MasterTable_SiteBmfBovespa']/tbody/tr")
                    ?.ToList()
                    .ForEach(x =>
                    {
                        var tds = x.ChildNodes.Where(n => n.Name == "td").ToArray();

                        var hrefText = tds[0].ChildNodes[0].ChildAttributes("href").Single().Value;

                        var codigoCVM = new Regex("\\d+").Match(hrefText).Value;

                        var empresa = new Empresa(tds[0].InnerText, tds[1].InnerText, Convert.ToInt32(codigoCVM));
                        empresas.Add(empresa);
                    });
            }

            return empresas;*/
        }
    }
}
