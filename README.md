# DesenvolvedorNET

Projeto criado para aplicar os meus conhecimentos em .NET utilizando o C#.

Aplicando as principais tecnologias desse ecossistema.

## Tecnologias utilizadas

- NET 7.0
- C#
- Evolve DB
- ASP.NET Core
- Markdig
- SQLite
- Dapper

## Roadmap

- renderizar em html esse README.md usando o Markdig ao acessar "/"
- criar um enpoint [/api/usuario](/api/usuario) que retorne todos os usuários cadastrados
	- usando o Evolve DB para controlar as versões do banco de dados
	- usando Dapper e SQLite
- pagina [/usuario](/usuario) mostra todos os usuários cadastrados
- criar um endpoint "/api/usuario/{id}" que retorne um usuário específico
- pagina /usuario/details/{id} mostra os detalhes de um usuário específico
- [ ] criar um endpoint "/api/usuario" que permita cadastrar um novo usuário
- [ ] criar um endpoint "/api/usuario/{id}" que permita atualizar um usuário
- [ ] criar um endpoint "/api/usuario/{id}" que permita excluir um usuário