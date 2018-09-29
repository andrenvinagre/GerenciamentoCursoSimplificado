using AppAndre.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppAndre.Util
{
    static class Web
    {
        private static HttpClient Client = new HttpClient();

        public static async Task<ResponseLoginAPI> Login(string email, string senha)
        {
            ResponseLoginAPI result = null;
            
            //var result = await Client.PostAsync("http://localhost", new StringContent(args, Encoding.UTF8, "application/json"));
            var resultAPI = await Client.GetAsync($"http://178.128.75.221:90/api/Aluno/Logar/{email}/{senha}");

            if (resultAPI.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<ResponseLoginAPI>(await resultAPI.Content.ReadAsStringAsync());
                }
                catch (Exception)
                {
                    return null;
                }                                
            }

            return result;
        }
    }
}
