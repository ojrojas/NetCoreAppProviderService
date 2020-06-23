using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Cinte.Core.Entities;
using Cinte.Core.Infraestructure;
using Cinte.Infraestructure.Exceptions;
using Cinte.Infraestructure.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Cinte.Infraestructure.RequestProvider
{
    public class PeticionesService : IPeticionesService
    {
        /// <summary>
        /// Configuracion serializacion objetos
        /// </summary>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>20/06/2020.</date>
        private readonly JsonSerializerSettings _serializerSettings;

        /// <summary>
        /// Uri base de peticiones dirección web de peticiones
        /// </summary>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>20/06/2020.</date>
        private readonly Uri _uri;

        /// <summary>
        /// Uri base de peticiones dirección web de peticiones
        /// </summary>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>20/06/2020.</date>
        private readonly Uri _uriToken;

        private readonly ICacheProvider _cache;

        public PeticionesService(Uri uriToken,ICacheProvider cache,Uri uri = null)
        {
            _cache = cache;
            _uri = uri;
            _uriToken = uriToken;
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };
            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public async Task<T> GetAsync<T>()
        {
           try
            {
                var token = await ObtenerToken();
                HttpClient httpClient = CrearHttpCliente(token);
                HttpResponseMessage response = await httpClient.GetAsync(_uri.ToString());
                await HandleResponse(response);
                string serialized = await response.Content.ReadAsStringAsync();

                T result = await Task.Run(() =>
                    JsonConvert.DeserializeObject<T>(serialized, _serializerSettings));

                return result;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetAsync<T>(Dictionary<string, string> parametros)
        {
            var token = await ObtenerToken();
            HttpClient httpClient = CrearHttpCliente(token);
            var uriConParametros = FomarUriConParametros(parametros);
            HttpResponseMessage response = await httpClient.GetAsync(uriConParametros);
            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();

            T result = await Task.Run(() =>
                JsonConvert.DeserializeObject<T>(serialized, _serializerSettings));

            return result;
        }

        public async Task<T> GetAsync<T>(Dictionary<string, string> parametros, Dictionary<string, string> headers)
        {
            var token = await ObtenerToken();
            HttpClient httpClient = CrearHttpCliente(token);

            if (headers != null)
            {
                AddHeaderParameter(httpClient, headers);
            }

            var uriConParametros = FomarUriConParametros(parametros);
            HttpResponseMessage response = await httpClient.GetAsync(_uri.ToString());
            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();

            T result = await Task.Run(() =>
                JsonConvert.DeserializeObject<T>(serialized, _serializerSettings));

            return result;
        }

        public async Task<T> PostAsync<T>(T objeto, Dictionary<string, string> headers= null)
        {
           var token = await ObtenerToken();
            HttpClient httpClient = CrearHttpCliente(token);

            if (headers != null)
            {
                AddHeaderParameter(httpClient, headers);
            }

            var content = new StringContent(JsonConvert.SerializeObject(objeto));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync(_uri, content);

            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();

            T result = await Task.Run(() =>
                JsonConvert.DeserializeObject<T>(serialized, _serializerSettings));

            return result;
        }

        #region Metodos Privados

        /// <summary>
        /// Obtiene el token de _cache.
        /// </summary>
        /// <returns>Token de aplicacion</returns>
        private async Task<Token> ObtenerToken(object login = null)
        {
            Token token = null;
            var cache = this._cache.ObtenerTokenCache();
            if (cache != null)
                token = cache as Token;
            else
                token = await ConsultarToken(login);
            return token;
        }

        /// <summary>
        /// Obtiene el token del webapi.
        /// </summary>
        /// <returns>Token</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>20/06/2020.</date>
        private async Task<Token> ConsultarToken(object login)
        {
            try
            {
                HttpClient client = CrearHttpClientToken();
                var content = new StringContent(JsonConvert.SerializeObject(login));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await client.PostAsync(_uriToken,content);
                await HandleResponse(response);
                var resultado = await response.Content.ReadAsStringAsync();
                Token token = JsonConvert.DeserializeObject<Token>(resultado);
                if (token.Token_Auth != null)
                    _cache.SetearTokenCache(token);
                return token;
            }
            catch (HttpRequestExceptionEx ex)
            {
                throw ex;
            }
        }

        public async Task<Token> PostConsultarTokenAsync(object objeto) => 
        await this.ConsultarToken(objeto);


        /// <summary>
        /// Añade los headers a la peticion
        /// </summary>
        /// <param name="httpClient">Cliente de peticiones http</param>
        /// <param name="parameter">parametros headers</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>20/06/2020.</date>
        private void AddHeaderParameter(HttpClient httpClient, Dictionary<string, string> parameters)
        {
            if (httpClient == null)
                return;

            if (parameters == null)
                return;

            foreach (var i in parameters)
                httpClient.DefaultRequestHeaders.Add(i.Key, i.Value);
        }

        /// <summary>
        /// Manejador de respuestas http.
        /// </summary>
        /// <param name="response">Respuesta del web api</param>
        /// <returns>Void</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>20/06/2020.</date>
        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Forbidden ||
                    response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new ServiceAuthenticationException(content);
                }

                throw new HttpRequestExceptionEx(response.StatusCode, content);
            }
        }

        /// <summary>
        /// Crear el cliente de peticiones http para todas las consultas.
        /// </summary>
        /// <param name="token">Token de autorizacion webapi</param>
        /// <returns>Cliente de peticiones http.</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>20/06/2020.</date>
        private HttpClient CrearHttpCliente(Token token = null)
        {
            HttpClient client = null;
            if (!string.IsNullOrEmpty(token?.Token_Auth))
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token?.Token_Auth);
            }

            return client;
        }

        /// <summary>
        /// Crea el cliente http de peticion token
        /// </summary>
        /// <returns>HttpClient de peticiones</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>20/06/2020.</date>
        private HttpClient CrearHttpClientToken()
        {
            var client = new HttpClient();
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", ConstantesAplicacion.ClaveSecreta);
            return client;
        }

        /// <summary>
        /// Formaliza un direccion uri de peticion get
        /// </summary>
        /// <param name="parametros">Parametros de peticion</param>
        /// <returns>Ruta de webapi con parametros.</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>20/06/2020.</date>
        private string FomarUriConParametros(Dictionary<string, string> parametros)
        {
            var cadena = string.Empty;
            if (parametros.Count > default(int))
                cadena = "?";
            foreach (var i in parametros)
                cadena += string.Join("&", $"{i.Key}={i.Value}");
            return _uri.ToString() + cadena;
        }

        public async Task<T> PutAsync<T>(T objeto, Dictionary<string, string> headers=null)
        {
            var token = await ObtenerToken();
            HttpClient httpClient = CrearHttpCliente(token);

            if (headers != null)
            {
                AddHeaderParameter(httpClient, headers);
            }

            var content = new StringContent(JsonConvert.SerializeObject(objeto));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PutAsync(_uri, content);

            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();

            T result = await Task.Run(() =>
                JsonConvert.DeserializeObject<T>(serialized, _serializerSettings));

            return result;
        }

        public async Task<T> DeleteAsync<T>(T objeto, Dictionary<string, string> headers = null)
        {
             var token = await ObtenerToken();
            HttpClient httpClient = CrearHttpCliente(token);

            if (headers != null)
            {
                AddHeaderParameter(httpClient, headers);
            }

            var content = new StringContent(JsonConvert.SerializeObject(objeto));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.DeleteAsync(_uri);

            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();

            T result = await Task.Run(() =>
                JsonConvert.DeserializeObject<T>(serialized, _serializerSettings));

            return result;
        }


        #endregion

    }
}