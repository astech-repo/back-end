using Newtonsoft.Json.Linq;

namespace astech_DTO.Validations
{
    public class CepValidation
    {
        private const string CorreiosApiBaseUrl = "https://viacep.com.br/ws/";

        public async Task<bool> ValidateCep(string cep, string endereco)
        {
            using (var httpClient = new HttpClient())
            {
                var apiUrl = $"{CorreiosApiBaseUrl}/{cep}/json";
                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var enderecoJson = JObject.Parse(jsonResponse);

                    string enderecoCompleto = enderecoJson["logradouro"].ToString();
                    return enderecoCompleto.ToLower() == endereco.ToLower();
                }
                else
                {
                    Console.WriteLine("Erro ao consultar API dos Correios");
                    return false;
                }
            }
        }
    }
}
