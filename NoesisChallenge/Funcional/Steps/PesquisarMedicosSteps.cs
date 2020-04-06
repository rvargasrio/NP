using TechTalk.SpecFlow;
using Unimed.Funcional.PageObjects;

namespace Unimed.Funcional.Steps
{
    [Binding]
    public class PesquisarMedicosSteps
    {
        readonly PesquisarMedicosPage page = new PesquisarMedicosPage();

        [Given(@"que acessei o Guia Medico")]
        public void DadoQueAcesseiOGuiaMedico()
        {
            page.AcessarUrl();
        }
        
        [When(@"submeter busca pela especialidade ""(.*)""")]
        public void QuandoSubmeterBuscaPelaEspecialidade(string p0)
        {
            page.InformarEspecialidadeMedica(p0);
        }
        
        [When(@"informar o estado ""(.*)"" e cidade ""(.*)""")]
        public void QuandoInformarOEstadoECidade(string p0, string p1)
        {
            page.InformarEstado(p0);
            page.InformarCidade(p1);
            page.InformarUnidadeAtendimento();
            page.ContinuarBusca();
        }
        
        [Then(@"sistema retorna lista de medicos contendo especialidade e cidade pesquisadas")]
        public void EntaoSistemaRetornaListaDeMedicosContendoEspecialidadeECidadePesquisadas()
        {
            page.ValidarTituloEspecialidade();
            page.ValidarEspecialidadeMedico();
            page.ValidarCidadeAtendimento();
        }

        [Then(@"sistema retorna lista de medicos do Rio de Janeiro sem médicos de São Paulo")]
        public void EntaoSistemaRetornaListaDeMedicosDoRioDeJaneiroSemMedicosDeSaoPaulo()
        {
            page.ValidarMedicosDeSaoPauloNaoRetornados();
        
        }
    }
}
