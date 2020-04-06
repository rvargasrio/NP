using Base;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace Unimed.Funcional.PageObjects
{
    public class PesquisarMedicosPage : WebDriver
    {
        readonly BaseClass baseClass = new BaseClass();

        readonly string CampoPesquisa = "campo_pesquisa";
        readonly string Pesquisar = "btn_pesquisar";
        readonly string Estado = "//*[@id='react-select-2-input']";
        readonly string Cidade = "//*[@id='react-select-3-input']";
        readonly string Unidade = "//*[@id='app']/div/div/div/div/div[2]/form/label/div[1]/input";
        readonly string Continuar = "//*[@id='app']/div/div/div/div/div[3]/button[2]";
        readonly string PesquisandoPor = "//*[@id='app']/div/div/div[5]/p";
        readonly string EspecialidadeMedico = "(//span[.='Anestesiologia'])";
        readonly string CidadeAtuacao = "(//p[text()='Barra Da Tijuca'])[1]";
        readonly string Pagina2 = "//div[contains(@class,'pagination')]//a[text()='2']";
        readonly string Pagina3 = "//div[contains(@class,'pagination')]//a[text()='3']";

        public void EncerrarWebDriver()
        {
            baseClass.Dispose();
        }


        internal void AcessarUrl()
        {
            baseClass.OpenUrl("https://www.unimed.coop.br/guia-medico");
        }

        internal void InformarEspecialidadeMedica(string p0)
        {
            baseClass.WaitElement(By.Id(CampoPesquisa), 5);
            baseClass.Click(By.Id(CampoPesquisa));
            baseClass.SetText(By.Id(CampoPesquisa), p0);

            baseClass.Click(By.Id(Pesquisar));
        }

        internal void ValidarMedicosDeSaoPauloNaoRetornados()
        {
            // Varrer página 1
            baseClass.ValidarCidadeResultadoBuscaMedicos("São Paulo");

            try
            {
                baseClass.Click(By.XPath(Pagina2));
                baseClass.ValidarCidadeResultadoBuscaMedicos("São Paulo");
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {
                Console.WriteLine("Página 2 não disponível em tela.");
                return;
            }

            try
            {
                baseClass.Click(By.XPath(Pagina3));
                baseClass.ValidarCidadeResultadoBuscaMedicos("São Paulo");
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {
                Console.WriteLine("Página 3 não disponível em tela.");
                return;
            }

            baseClass.Dispose();
        }

        internal void ValidarCidadeAtendimento()
        {
            baseClass.AssertTextContains(By.XPath(CidadeAtuacao), "Rio de Janeiro");
            baseClass.Dispose();
        }

        internal void ValidarEspecialidadeMedico()
        {
            baseClass.AssertTextContains(By.XPath(EspecialidadeMedico), "Anestesiologia");
        }

        internal void ValidarTituloEspecialidade()
        {
            Thread.Sleep(2000);
            baseClass.AssertTextEquals(By.XPath(PesquisandoPor), "Você está pesquisando por: Anestesiologia");
        }

        internal void InformarCidade(string p1)
        {
            baseClass.WaitElement(By.XPath(Cidade), 5);
            baseClass.SetText(By.XPath(Cidade), p1);
            baseClass.SendTabKey(By.XPath(Cidade));
        }

        internal void InformarEstado(string p0)
        {
            baseClass.WaitElement(By.XPath(Estado), 5);
            baseClass.SetText(By.XPath(Estado), p0);
            baseClass.SendTabKey(By.XPath(Estado));
        }

        internal void ContinuarBusca()
        {
            baseClass.WaitElement(By.XPath(Continuar), 5);
            baseClass.Click(By.XPath(Continuar));
        }

        internal void InformarUnidadeAtendimento()
        {
            baseClass.WaitElement(By.XPath(Unidade), 5);
            baseClass.Click(By.XPath(Unidade));
        }
    }
}
