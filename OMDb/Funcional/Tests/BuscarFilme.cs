using NUnit.Framework;

namespace OMDb.AcceptanceTest.Tests
{
    [TestFixture]
    public class BuscarFilme
    {
        readonly BuscarFilme_page page;

        public BuscarFilme()
        {
            page = new BuscarFilme_page();
        }


        [Test, Order(0), Category("Requisitar filme existente no catálogo OMDb")]
        public void BuscarFilmeValido()
        {
            page.DefinirCriteriosDeEntrada("tt1285016", "52ec71bf");
            // 
            page.BuscarFilmePorId();
            // 
            page.ValidarStatusCode();
            page.ValidarFilmeRetornado("The Social Network", "2010", "English, French");
        }

        [Test, Order(1), Category("Requisitar filme inexistente no catálogo OMDb")]
        public void BuscarFilmeInexistente()
        {
            page.DefinirCriteriosDeEntrada("1285016", "52ec71bf");
            //
            page.BuscarFilmePorId();
            page.ValidarStatusCode();
            //
            page.ValidarFilmeInexistente("False", "Incorrect IMDb ID.");
        }
    }
}