<h1 align="center">:file_cabinet:README.md</h1>

## :memo: Descrição
Desenvolver e testar uma API com CRUD para Cursos, Estudantes e
Avaliações, permitindo que os estudantes avaliem os cursos com estrelas de 1
a 5 e, opcionalmente, deixem um comentário. Além disso, deve ser criado um
endpoint que retorne os cursos com suas respectivas avaliações, incluindo a
quantidade de estrelas, comentário (se existir) e a data/hora da avaliação.

## :books: Funcionalidades
* <b>Funcionalidades</b>: API com endpoints para realizar operações CRUD
(Create, Read, Update, Delete) para os recursos de Curso, Estudante e
Avaliação.

## :wrench: Tecnologias utilizadas
* Tecnologia; Csharp + Postgresql (API RESTful)

## :rocket: Rodando o projeto
Para rodar o projeto é necessário executar os seguintes passos:
```

git clone https://github.com/GabrielFSouza/vylexAPI.git

Configure o banco de dados no appsettings.json
"DefaultConnection": "Host=localhost;Database=yourdatabase;Username=youruser;Password=yourpassword"

Verifique a pasta Migrations e exclua o arquivo ..._InitialCreate.cs e o AppDbContextModelSnapshot.cs

Abra o Console do Gerenciador de Pacotes e execute os seguintes comandos:
> dotnet ef migrations add InitialCreate
> dotnet ef database update

Sugestão: Deixei um pasta com nome de ArquivoJSON com um arquivo **estudande.json**, para assim que
executar o projeto no swagger ir no estudante e executar o POST.

```

## :handshake: Colaboradores
<table>
  <tr>
    <td align="center">
      <a href="https://gabirudev.com/">
        <img src="https://avatars.githubusercontent.com/u/58001372?s=400&u=1915bb67b262dd94bb5354425e8f2deba07098e5&v=4" width="100px;" alt="Foto de Gabriel no GitHub"/><br>
        <sub>
          <b>gabirudev</b>
        </sub>
      </a>
    </td>
  </tr>
</table>
