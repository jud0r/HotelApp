# HotelApp

Hotel Management App

	• Portal Web
		○ Permitir reserva de quartos
		○ Saber se tem quartos disponíveis
	• Desktop App
		○ Check in de usuário
		○ Pode pesquisar reserva por nome
  	• É um MVP


================================================================

Premissas confirmadas

	• Apenas um hotel
	• Usuário reserva um tipo de quarto, não quarto específico
	• O funcionário do hotel faz o check in do usuário
	• Busca de reserva é feita pelo sobrenome
	• Check in significa que só sinalizamos que usuário está no hotel
	• Dados serão armazenados no SQL Server
	• Sem API 
 	• Usar últimas versões de tecnologias .NET
 


================================================================

Coisas do MVP

	• ASP.NET Core Blazor Pages
	• Web Page - Buscar um quarto
		○ Data de entrada
		○ Data de saída
		○ Listar tipos de quartos disponíveis
		○ Usuário pode escolher um
	• Web Page - Reservar quarto
		○ Escolher quarto da página de busca
		○ Perguntar informações do usuário (nome)
		
	• WPF Core Desktop App
	• WPF Page - Buscar usuário
		○ Buscar reserva por sobrenome e usar data de hoje
		○ Mostrar lista de reservas compatíveis com a busca
		○ Botão para check-in do usuário
	• Banco de dados SQL Server

================================================================

Coisas para versões futuras

	• Autenticação de usuários
	• Histórico de usuários
	• Multiplos hotéis
	• Permitir usuário realizar check-out
	• Permitir busca por código de reserva ou outro tipo de informação
	• Permitir outro banco de dados


================================================================



