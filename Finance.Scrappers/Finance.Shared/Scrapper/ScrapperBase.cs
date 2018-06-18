using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Shared.Scrapper
{
    public abstract class ScrapperBase<T> : IScrapper<T>
    {

        public ScrapperBase(){
            this.Client = this.Client = new HttpClient();
        }        

        protected HttpClient Client { get; private set; }
        public abstract Task<T> ExecuteScrapAsync(); 
                
        protected async Task<string> GetHtmlStringAsync(string url)
        {
            var bytes = await this.Client.GetByteArrayAsync(url);
            string isocontent = Encoding.GetEncoding("ISO-8859-1").GetString(bytes, 0, bytes.Length);
            byte[] isobytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(isocontent);
            byte[] ubytes = Encoding.Convert(Encoding.GetEncoding("ISO-8859-1"), Encoding.Unicode, isobytes);
            return Encoding.Unicode.GetString(ubytes, 0, ubytes.Length);
        }

    }
}
