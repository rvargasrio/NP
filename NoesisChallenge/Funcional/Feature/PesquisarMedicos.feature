#language: pt
Funcionalidade: Busca Rapida por Medicos
  		Realizar busca rapida por médico na rede Unimed
  		informado especialidade e Cidade de atendimento.

@scopeBinding
Cenário: Buscar medicos da cidade Rio de Janeiro
	Dado que acessei o Guia Medico
	Quando submeter busca pela especialidade "Anestesiologia"
	E informar o estado "Rio de Janeiro" e cidade "Rio de Janeiro"
	Então sistema retorna lista de medicos contendo especialidade e cidade pesquisadas

@scopeBinding
Cenário: Buscar medicos da cidade Rio de Janeiro sem que exiba médicos de São Paulo
	Dado que acessei o Guia Medico
	Quando submeter busca pela especialidade "Anestesiologia"
	E informar o estado "Rio de Janeiro" e cidade "Rio de Janeiro"
	Então sistema retorna lista de medicos do Rio de Janeiro sem médicos de São Paulo