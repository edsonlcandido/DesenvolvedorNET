# DesenvolvedorNET

Projeto criado para aplicar os meus conhecimentos em .NET utilizando o C#.

Aplicando as principais tecnologias desse ecossistema.

## Tecnologias utilizadas

- NET 7.0
- C#
- Markdig
- Razor pages
- Evolve DB 
- SQLite
- Dapper

## Roadmap

- endpoint "/usuario" retornar uma lista estatica de usuarios do metodo Get() do controller
- criar um enpoint "/api/usuario" que retorne todos os usuários cadastrados
	- usando o Evolve DB para controlar as versões do banco de dados
	- usando Dapper e SQLite
- pagina /usuario mostra todos os usuários cadastrados
- criar um endpoint "/api/usuario/{id}" que retorne um usuário específico
- pagina /usuario/{id} mostra os detalhes de um usuário específico
- [] criar um endpoint "/api/usuario" que permita cadastrar um novo usuário
- [] criar um endpoint "/api/usuario/{id}" que permita atualizar um usuário
- [] criar um endpoint "/api/usuario/{id}" que permita excluir um usuário