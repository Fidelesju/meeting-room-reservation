# Meeting Room Reservation

Bem-vindo ao Meeting Room Reservation, um sistema de reservas de salas de reunião desenvolvido utilizando ASP.NET Core, Entity Framework e SQL Server. Este projeto permite que os usuários agendem e gerenciem reservas de salas de reunião, facilitando a organização de encontros eficientes e produtivos.
### Status: Em desenvolvimento

## Recursos Principais

- Reservas de Salas: Os usuários podem visualizar a disponibilidade das salas e criar reservas para datas e horários específicos.
- Calendário de Reservas: Um calendário interativo exibe as reservas existentes, proporcionando uma visão clara das atividades planejadas.
- Notificações por Email: Os usuários recebem confirmações e lembretes de reservas por email.
- Autenticação de Usuário: Os usuários podem criar contas, fazer login e gerenciar seus perfis pessoais.
- Gerenciamento de Salas: Administradores podem adicionar, editar e remover salas disponíveis.

## Tecnologias Utilizadas

- **ASP.NET Core:** Framework para criação de aplicativos web de alta performance e escalabilidade.
- **Entity Framework:** Mapeamento objeto-relacional para gerenciar o acesso a dados.
- **SQL Server:** Banco de dados relacional para armazenar informações de reservas e salas.
- **React:** Tecnologia de modelagem de página para criar uma interface interativa.

## Pré-requisitos

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)


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

6. Acesse a aplicação em seu navegador: `http://localhost:5000`

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir problemas e enviar solicitações pull.

## Licença

Este projeto está licenciado sob a [Licença MIT](LICENSE).
