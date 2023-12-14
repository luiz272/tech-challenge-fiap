# Tech Challenge FIAP

## Projeto
Sistema de pedidos de uma lanchonete de bairro

## Grupo
  - Marlon - RM X
  - Zanaro - RM X
  - Jônatas - RM 353060
  - Matheus - RM 352813
  - Luiz - RM 353114

## Desenvolvimento
  - Acompanhamento (Click Up): https://app.clickup.com/9017094286/v/b/8cqbw4e-57
  - Arquitetura (Miro): https://miro.com/app/board/uXjVNQfujpo=/
  - Linguagem: C#
  - Banco de Dados: TBD
  - Infraestrutura: Containers em Docker

## Detalhes do Projeto

### Pedido
Os clientes são apresentados a uma interface de seleção na qual podem optar por se identificarem via CPF, se cadastrarem com nome, e-mail ou não se identificar, podendo montar o combo na seguinte sequência, sendo todas elas opcionais: 
  - Lanche
  - Acompanhamento
  - Bebida 

Em cada etapa é exibido o nome, descrição e preço de cada produto.

### Pagamento
O sistema deverá possuir uma opção de pagamento integrada para MVP. A forma de pagamento oferecida será via QRCode do Mercado Pago.

### Acompanhamento
Uma vez que o pedido é confirmado e pago, ele é enviado para a cozinha para ser preparado. Simultaneamente deve aparecer em um monitor para o cliente acompanhar o progresso do seu pedido com as seguintes etapas: Recebido Em preparação Pronto Finalizado

### Entrega
Quando o pedido estiver pronto, o sistema deverá notificar o cliente que ele está pronto para retirada. Ao ser retirado, o pedido deve ser atualizado para o status finalizado. Além das etapas do cliente, o estabelecimento precisa de um acesso administrativo.

### Gerenciar clientes
Com a identificação dos clientes o estabelecimento pode trabalhar em campanhas promocionais.

### Gerenciar produtos e categorias
Os produtos dispostos para escolha do cliente serão gerenciados pelo estabelecimento, definindo nome, categoria, preço, descrição e imagens. Para esse sistema teremos categorias fixas
  - Lanche
  - Acompanhamento
  - Bebida
  - Sobremesa

### Acompanhamento de pedidos
Deve ser possível acompanhar os pedidos em andamento e tempo de espera de cada pedido. As informações dispostas no sistema de pedidos precisarão ser gerenciadas pelo estabelecimento através de um painel administrativo.
