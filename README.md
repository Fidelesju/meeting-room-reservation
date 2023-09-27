# Meeting Room Reservation

Bem-vindo ao Meeting Room Reservation, um sistema de reservas de salas de reunião desenvolvido utilizando ASP.NET Core, Entity Framework e My SQL. Este projeto permite que os usuários agendem e gerenciem reservas de salas de reunião, facilitando a organização de encontros eficientes e produtivos.

### Status: Finalizado

## Tecnologias Utilizadas

- **ASP.NET Core:** Framework para criação de aplicativos web de alta performance e escalabilidade.
- **Entity Framework:** Mapeamento objeto-relacional para gerenciar o acesso a dados.
- **My SQL:** Banco de dados relacional para armazenar informações de reservas e salas.

## Pré-requisitos

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [My SQL](https://dev.mysql.com/downloads/connector/net/)


## Configuração e Instalação

1. Clone o repositório:

   ```bash
   git clone https://github.com/fidelesju/meeting-room-reservation.git
   ```

2. Navegue até o diretório do projeto:

   ```bash
   cd meeting-room-reservation
   ```

3. Atualize a string de conexão do banco de dados em `appsettings.json`.

4. Execute as migrações para criar as tabelas do banco de dados:

   ```bash
   dotnet ef database update
   ```

5. Execute a aplicação:

   ```bash
   dotnet run
   ```

6. Acesse a aplicação em seu navegador: `http://localhost:5000/swagger`

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir problemas e enviar solicitações pull.

## Licença

Este projeto está licenciado sob a [Licença MIT](LICENSE).
