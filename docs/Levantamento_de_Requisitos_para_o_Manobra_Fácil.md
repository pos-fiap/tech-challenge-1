# Levantamento de Requisitos para o Manobra Fácil
1. Introdução
        1.1 Objetivo
        O objetivo do sistema é gerenciar o uso de vagas de estacionamento, trazendo um maior controle e rapidez para o processo, possibilitando rastreabilidade do uso das vagas.

        1.2 Escopo
        O sistema deve incluir funções básicas para o controle de vagas em pequenos estacionamentos, dentre as funções o mesmo deve possibilitar o gerenciamento de atores e atividades no processo, possibilitando ao usuário administrador uma visão geral da ocupação sem defasagem.

2. Requisitos Funcionais

        2.1 Gestão de Vagas
        Descrição: Função destinada aos usuários atendentes e administradores para gestão das vagas do estacionamento.
        Requisitos Específicos:
                a. Os usuários(atendente/manobrista) deverão realizar reserva e baixa de utilização da vaga através dessa função.
                b. A tela de reserva de vagas deverá exibir a ocupação das vagas com defasagem de no máximo 10 segundos, sendo possível efetuar reserva somente para vagas disponíveis.
                c. O sistema deve pegar a hora automaticamente, não possibilitando ao usuário informar datas retroativas ou futuras.
                d. O informe do pagamento, quantidade de horas e valor deverá ser realizado no momento da baixa.
 
        2.2. Vagas
        Descrição: Função destinada ao administrador do sistema para cadastro de novas vagas de estacionamento.
        Requisitos Específicos:
                a. O sistema deve permitir adicionar, editar, excluir e listar vagas.
                b. Somente usuários com permissão de administrador poderão usar a função.
                c. O sistema não deve permitir que um carro seja alocado numa vaga já preenchida.

             d. O mesmo carro não deve poder ser cadastro em mais que uma vaga ao mesmo tempo.
             e. Não deve ser possível alocar mais carros do que o total de vagas.

        
        2.3. Veículos
        Descrição: Função destinada ao cadastro de veículos para utilização do estacionamento.
        Requisitos Específicos:
                a. O sistema deve permitir adicionar, editar, excluir e listar carros.
                b. Essa função deve estar disponível aos usuários atendentes e administradores.
                
        2.4. Manobristas
        Descrição: Função destinada ao cadastro dos manobristas do estacionamento.
        Requisitos Específicos:
                a. O sistema deve permitir adicionar, editar, excluir e listar manobristas.
                b. O sistema não deve permitir dois cadastros para o mesmo manobrista devendo validar documento(s) do mesmo.
                
        2.5. Usuários
        Descrição: Função destinada ao cadastro de novos usuários no sistema, existindo somente duas possibilidade de permissões: Administrador e Atendente.
        Requisitos Específicos:
                a. O sistema deve permitir adicionar, editar, excluir e listar usuários.
                b. A permissão de atendente deve conseguir executar somente as funções de cadastrar carros que utilizam o estacionamento, reservar vagas e dar baixa nas vagas/pagamento.
                c. Usuários administradores acumulam as funções de atendente, entretanto devem possuir acesso também à funções administrativas: 
                        - Cadastrar novos usuários no sistema.
                        - Cadastrar novos manobristas.
                        - Cadastrar novas vagas.
                        
        2.6 Geração de Relatórios
        Descrição: Função para geração de relatórios.
        Requisitos Específicos:
                a. Deve ser possível gerar relatório em tela do status atual das vagas (livres e em uso).

        2.7 Autenticação e Autorização
        Descrição: Função para controle da autenticação e autorização do usuário.
        Requisitos Específicos:
          a. O sistema deve conter controle de sessão, podendo se autenticar e se manter autenticado por até 10 horas.
          b. O mesmo deverá também verificar qual perfil o usuário pertence e garantir o acesso somente às funções pertinentes. Os perfis e acessos estão elucidados no tópico "2.5 Usuários item c".

3. Requisitos Não Funcionais

        3.1 Usabilidade
        A interface do usuário deve ser intuitiva e fácil de usar para usuários de todos os níveis de habilidade.

        3.2 Segurança
        O sistema deve garantir a segurança das informações dos usuários e veículos.

        3.4 Compatibilidade
        O sistema deve rodar nos navegadores de internet padrões de mercado.

5. Tecnologia
      
      5.1 Linguagem e Frameworks
        O sistema deve ser desenvolvido utilizando .Net e banco SQL Server, respectivamente nas versões LTS dos mesmos no momento de início do desenvolvimento. O sistema obrigatoriamente deve deve utilizar o framework ORM (*Object Relational Mapping*) Entity Framework trabalhando em modo *Code First*. 
      
      5.2 Arquitetura
        O sistema deverá possuir uma API construída utilizando DDD (*Domain-Driven Design*) & *Clean Archtecture* e um frontend que consumirá API em questão.

      5.3 Documentações
        A API deverá fornecer uma página de documentação swagger detalhando todos os endpoints. No repositório da aplicação deverá constar README.md com todas as instruções necessárias ao desenvolvedor para executar a aplicação. 

7. Anexos

        7.1 Domínio puro (*Story Telling*)
               1. Cenário de vaga disponível
                  

![](https://paper-attachments.dropboxusercontent.com/s_8C8A6195AB63C5B54441FE2FA9AF7242A73AEA158D32C9EEB19DB3B097A05576_1696990058820_image.png)


               2. Cenário de vaga indisponível
                  

![](https://paper-attachments.dropboxusercontent.com/s_8C8A6195AB63C5B54441FE2FA9AF7242A73AEA158D32C9EEB19DB3B097A05576_1696990126535_image.png)








