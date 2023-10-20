# Desenvolvedor ASP NET

[github.com/edsonlcandido/desenvolvedornet](https://github.com/edsonlcandido/desenvolvedornet)

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
- ASP.NET MVC		
- Bulma CSS
- Entity Framework Core
- LINQ

## Roadmap

- renderizar em html esse README.md usando o Markdig ao acessar "/"
- criar um enpoint [/api/usuario](/api/usuario) que retorne todos os usuários cadastrados
	- usando o Evolve DB para controlar as versões do banco de dados
	- usando Dapper e SQLite
- pagina [/usuario](/usuario) mostra todos os usuários cadastrados
- criar um endpoint [/api/usuario/{id}](/api/usuario/5b61f8d0-63ae-433a-a880-c83a127f7808) que retorne um usuário específico
- pagina [/usuario/details/{id}](/usuario/details/5b61f8d0-63ae-433a-a880-c83a127f7808) mostra os detalhes de um usuário específico
- criar operação de adicionar usuario
- criar operação de editar um usuario
- deletar um usuario
- estilizar a pagina de listagem de usuarios
- utilizar Entity Framework Core para o novo modelo Empregado
	- executar migrations do entity framework ao iniciar a aplicação
- pagina [/empregado](/empregado) mostra todos os empregados cadastrados
	- listar departamentos buscando do banco de dados
- criar um endpoint /api/empregado/{id} que retorne um empregado específico
- pagina de detalhes do empregado
- criar operação de adicionar empregado
	- corrigir buscar departamento do empregado
- criar operação de editar um empregado
- deletar um empregado
- [ ] manipular erros de forma centralizada
- [	] manipular erros de forma global
- [ ] criar um contexto com login e senha usando o Identity
- [ ] criar niveis de acesso para usuarios do sistema
- [ ] criar ambiente de acesso restrito as seguintes funçoes de um programa de estoque
- [	] administrar usuarios
- [ ] cadastrar produtos
- [ ] listar produtos
- [ ] editar produtos
- [ ] adcionar entrada de produtos
- [ ] retirar produtos
- [ ] criar um historico de movimentações 
- [ ] transformar os endpoint numa API RESTfull