using Base;
using FluentAssertions;
using System.Collections.Generic;
using System.Net;
using RestSharp.Serialization.Json;
using System;

namespace OMDb.AcceptanceTest
{
    public class BuscarFilme_page : BaseApi
    {

        public void DefinirCriteriosDeEntrada(string filme, string key)
        {
            endPoint = "?i=" + filme + "&apikey=" + key;
        }
        public void BuscarFilmePorId()
        {
            GetClient();
            GetRequest(endPoint);
            GetResponse();
        }

        public Dictionary<string, string> DeserializeResponse()
        {
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            return output;
        }

        public void ValidarStatusCode()
        {
            (response.StatusCode).Should().Be(HttpStatusCode.OK);
        }

        public void ValidarFilmeRetornado(string title, string year, string language)
        {
            var content = DeserializeResponse();
            string Title = content["Title"];
            string Year = content["Year"];
            string Language = content["Language"];

            Title.Should().Be(title);
            Year.Should().Be(year);
            Language.Should().Be(language);
        }

        public void ValidarFilmeInexistente(string response, string error)
        {
            var content = DeserializeResponse();
            string Response = content["Response"];
            string Error = content["Error"];

            Response.Should().Be(response);
            Error.Should().Be(error);
        }
    }
}
