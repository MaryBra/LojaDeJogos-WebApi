# LojaDeJogos-WebApi

Documentação WebApi Loja de Jogos
Integrantes da equipe:
•	Mariana Marques Braguim.
•	Hiran Pereira Leite.
•	Chat GPT.

Tema do projeto: Gerenciamento de uma loja de jogos.

Introdução
	O sistema de comercio de Jogos é uma aplicação destinada a simplificar e otimizar a compra e venda de jogos online. Este projeto tem como objetivo fornecer uma plataforma abrangente para gerenciar produtos, clientes, pedidos e todas as operações relacionadas a uma loja virtual de jogos.

Estrutura do projeto
Models:
1.	Produto(Hiran): Representa os jogos disponíveis para compra. 
•	Atributos: IdProduto, NomeProduto, Descrição, Preço, Desenvolvedor e Plataforma.
2.	Cliente(Mariana): Representa os clientes que visitam a loja.
•	Atributos: IdCliente, NomeCliente, Endereço e Telefone.
3.	Pedido(Hiran): Registra os pedidos feitos pelos clientes.
•	Atributos: IdPedido, Data do Pedido, Cliente, Jogos(lista de jogos) e Status.
4.	Carrinho(Mariana): Representa o carrinho de compras de um cliente.
•	Atributos: Cliente, Itens do Carrinho(lista de jogos).
5.	Pagamento(Hiran): Lida com informações de pagamento. 
•	Atributos: IdPagamento, Método de pagamento, Total, Endereço de Entrega.
6.	Desenvolvedor(Mariana): Informações sobre os desenvolvedores do jogo. 
•	Atributos: IdDesenvolvedor, NomeDesenvolvedor, Histórico e Jogos produzidos.
7.	Plataforma(Chat GPT): Representa as diferentes plataformas nas quais os jogos estão disponíveis. 
•	Atributos: IdPlataforma, Nome e Lista de Jogos.
8.	Estoque(Chat GPT): Rastreia o estoque disponível de cada jogo. 
•	Atributos: Lista de Jogos.

Controllers:
Um controlador é uma parte crucial de qualquer aplicação web, incluindo a nossa.Ele desempenha o papel de supervisionar e orquestrar operações relacionadas a um domínio específico. Por exemplo, o nosso controlador 'DesenvolvedorController' é encarregado de lidar com todas as ações relacionadas aos desenvolvedores de jogos em uma loja de jogos online. Esse controlador oferece pontos de acesso (endpoints) que permitem criar, listar, buscar, atualizar e excluir informações sobre desenvolvedores no banco de dados. Dessa forma, os controladores servem como intermediários entre a interface do usuário e o sistema de armazenamento de dados, garantindo que as operações sejam executadas de maneira eficaz e segura. Usando a classe “Desenvolvedor” como exemplo, temos:
#POST / Desenvolvedor / Cadastrar
Este endpoint permite cadastrar um novo desenvolvedor de jogos.
#GET / Desenvolvedor / Listar
Este endpoint permite listar todos os desenvolvedores registrados no sistema.
#GET / Desenvolvedor / Buscar /{Id}
Este endpoint permite buscar um desenvolvedor especifico com base no seu id.
#PUT / Desenvolvedor / Alterar
Permite atualizar as informações de um desenvolvedor existente no sistema.
#DELETE / Desenvolvedor / Excluir {Id}
Permite excluir um desenvolvedor com base no seu id.

Nota:
Os controladores fazem uso do Entity Framework Core e do banco de dados para realização de operações de criação, leitura, atualização e exclusão da entidade.

Relacionamentos:
1.	Produto:
•	Um produto pertence a um Desenvolvedor(1:1).
•	Um produto pode ter varias classificações(1:N).
•	Um produto pode estar disponível em varias plataformas(1:N)
•	Um produto pode fazer parte de vários Pedidos(N:N)
2.	Cliente:
•	Um cliente pode fazer vários pedidos(1:N).
•	Um cliente pode ter um carrinho de compras(1:1).
3.	Pedido:
•	Um pedido pertence a um cliente(1:1).
•	Um pedido contem vários Jogos(Produtos)(N:N)
•	Um pedido esta relacionado a um pagamento(1:1).
4.	Carrinho de Compras:
•	Um carrinho de compras pertence a um cliente(1:1).
•	Um carrinho de compras contem vários itens do Carrinho(N:N).
5.	Pagamento:
•	Um pagamento esta associado a um pedido(1:1)
6.	Desenvolvedor: 
•	Um desenvolvedor pode ter produzido vários Produtos(N:1).
7.	Plataforma:
•	Um produto pode estar disponível em varias plataformas(1:N).
8.	Estoque:
•	O estoque pertence a um único produto(1:1).

Modelagem de Dados em tabelas (Gerado pelo ChatGPT):
1.	Tabela Produto:
•	IDProduto(Chave Primaria)
•	Nome
•	Descrição
•	Preço
•	IdDesenvolvedor(Chave Estrangeira)
•	IdPlataforma(Chave Estrangeira) 
•	Estoque(Pode ser uma referencia ao Estoque)
2.	Tabela Cliente:
•	IdCliente(Chave Primaria)
•	NomeCliente
•	Endereço
•	E-mail
•	Telefone
3.	Tabela Pedido:
•	IdPedido(Chave Primaria)
•	Data do Pedido
•	IdCliente(Chave Estrangeira)
•	Status do Pedido
4.	Tabela Carrinho de Compras
•	IdCarrinho(Chave Primaria)
•	IdCliente(Chave Estrangeira)
•	IdProduto(Chave Estrangeira)
•	Quantidade
•	Preço Total
5.	Tabela Pagamento
•	IdPagamento(Chave Primaria)
•	IdCliente(Chave Estrangeira)
•	Endereço de Entrega
6.	Tabela Desenvolvedor:
•	IdDesenvolvedor(Chave Primaria)
•	Nome
•	Histórico 
•	Jogos Produzidos
7.	Tabela Plataforma:
•	IdPlataforma(Chave Primaria)
•	Nome
8.	Tabela Estoque:
•	IdProduto(Chave Estrangeira)
•	Quantidade Disponível.

Regras de Negócios
1.	Validação de Estoque: 
•	Regra: Um pedido não pode ser processado se um produto estiver fora de estoque.
•	Implementação: Antes de confirmar um pedido, verificar se a quantidade de produtos no carrinho não excede o estoque disponível na tabela de Estoque.
2.	Cálculo Total do Pedido:
•	Regra: O preço total do pedido deve ser calculado com base nos preços individuais dos produtos no carrinho.
•	Implementação: Ao criar um novo pedido, iterar pelos itens do carrinho e somar os preços individuais para obter o preço total do pedido.
3.	Desenvolvedor Relacionado a um jogo:
•	Regra: Vincular um desenvolvedor a um jogo.
•	Implementação: Usar a chave estrangeira “Id do desenvolvedor” na tabela Produto para vincular um desenvolvedor a um jogo.

