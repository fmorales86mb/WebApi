using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ResourceAccess
{
    public class ReservasResourceAccess
    {
        private const string BaseUrl = "https://api.estadisticasbcra.com";
        static readonly HttpClient client = new HttpClient();
        private const string Authorization = "Bearer";
        private const string Token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2MTE2OTI2MzcsInR5cGUiOiJleHRlcm5hbCIsInVzZXIiOiJmZWRlcmljby5tb3JhbGVzQG5lb3Jpcy5jb20ifQ._6863APnR6-h8EDHiyHoFsQayGPbWG3WXGiWw9nPetq-Mpc7-8bayUz5hbqLjHNLTjj68Wr2KJrhuBxb4Dd_XQ";

        public async Task<List<Reserva>> GetReservas()
        {
            string action = "/reservas";
            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            contentType.CharSet = "UTF-8";

            try
            {
                client.BaseAddress = new Uri(BaseUrl);                
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Authorization, Token);                
                client.DefaultRequestHeaders.Accept.Add(contentType);
                
                HttpResponseMessage response = await client.GetAsync(action);
                response.EnsureSuccessStatusCode();
                string data = await response.Content.ReadAsStringAsync();

                List<Reserva> reservas = JsonConvert.DeserializeObject<List<Reserva>>(data);

                return reservas;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
