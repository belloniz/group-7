
CREATE TABLE public.categorias_produtos (
   id SERIAL NOT NULL,
   nome VARCHAR(50) NOT NULL,
   CONSTRAINT categorias_produtos_pkey PRIMARY KEY (id)
);

CREATE TABLE public.produtos (
	id serial4 NOT NULL,
	nome varchar(100) NOT NULL,
	descricao varchar(1000) NOT NULL,
	preco money NOT NULL,
	categoria_id int4 NOT NULL,
	CONSTRAINT produtos_pkey PRIMARY KEY (id),
	CONSTRAINT produtos_fk FOREIGN KEY (categoria_id) REFERENCES public.categorias_produtos(id)
);

CREATE TABLE public.produtos_imagens (
   id SERIAL NOT NULL,
   url VARCHAR(300) NOT NULL,
   produto_id INT NOT NULL,
   CONSTRAINT produtos_imagens_pkey PRIMARY KEY (id),
   CONSTRAINT produtos_imagens_fk FOREIGN KEY (produto_id) REFERENCES public.produtos(id) ON DELETE CASCADE
);

CREATE TABLE public.combos ( 
   id serial4 NOT NULL, 
   nome varchar(100) NOT NULL, 
   descricao varchar(1000) NOT NULL, 
   CONSTRAINT combos_pkey PRIMARY KEY (id) 
);

CREATE TABLE public.combos_imagens ( 
   id serial4 NOT NULL, 
   url varchar(300) NOT NULL, 
   combo_id INT NOT NULL, 
   CONSTRAINT combos_imagens_pkey PRIMARY KEY (id), 
   CONSTRAINT combos_imagens_fk FOREIGN KEY (combo_id) REFERENCES public.combos(id) ON DELETE CASCADE 
);

CREATE TABLE public.combos_produtos ( 
   combo_id INT NOT NULL, 
   produto_id INT NOT NULL, 
   quantidade INT NOT NULL, 
   CONSTRAINT combos_produtos_pkey PRIMARY KEY (combo_id, produto_id),
   CONSTRAINT combos_fk FOREIGN KEY (combo_id) REFERENCES public.combos(id),
   CONSTRAINT combos_produtos_fk FOREIGN KEY (produto_id) REFERENCES public.produtos(id)
);

CREATE TABLE public.ocupacoes ( 
   id serial4 NOT NULL, 
   nome varchar(80) NOT NULL, 
   CONSTRAINT ocupacoes_pkey PRIMARY KEY (id) 
);

CREATE TABLE public.funcionarios ( 
   id serial4 NOT NULL, 
   nome varchar(100) NOT NULL, 
   matricula varchar(15) NOT NULL, 
   ocupacao_id INT NOT NULL, 
   CONSTRAINT funcionarios_pkey PRIMARY KEY (id), 
   CONSTRAINT funcionarios_ocupacoes_fk FOREIGN KEY (ocupacao_id) REFERENCES public.ocupacoes(id) 
);

CREATE TABLE public.clientes ( 
   id serial4 NOT NULL, 
   nome varchar(100) NULL, 
   cpf varchar(11) NULL, 
   email varchar(80) NULL, 
   CONSTRAINT clientes_pkey PRIMARY KEY (id)
);

CREATE TABLE public.situacoes_pedidos ( 
   id INT NOT NULL, 
   nome varchar(50) NOT NULL, 
   CONSTRAINT situacoes_pedidos_pkey PRIMARY KEY (id) 
);

CREATE TABLE public.pedidos ( 
   id serial4 NOT NULL, 
   cliente_id INT NOT NULL, 
   CONSTRAINT pedidos_pkey PRIMARY KEY (id), 
   CONSTRAINT pedidos_clientes_fk FOREIGN KEY (cliente_id) REFERENCES public.clientes(id) 
);

CREATE TABLE public.pedidos_combos ( 
   id serial4 NOT NULL, 
   pedido_id INT NOT NULL, 
   quantidade INT NOT NULL,   
   CONSTRAINT pedidos_combos_pkey PRIMARY KEY (id), 
   CONSTRAINT pedidos_combos_fk FOREIGN KEY (pedido_id) REFERENCES public.pedidos(id)
);

CREATE TABLE public.pedidos_combos_produtos ( 
   combo_id INT NOT NULL, 
   produto_id INT NOT NULL,
   valor_unitario  money NOT NULL,
   quantidade INT NOT NULL,
   CONSTRAINT pedidos_combos_produtos_pkey PRIMARY KEY (combo_id, produto_id), 
   CONSTRAINT pedidos_combos_fk FOREIGN KEY (combo_id) REFERENCES public.pedidos_combos(id),
   CONSTRAINT pedidos_produtos_fk FOREIGN KEY (produto_id) REFERENCES public.produtos(id)
);

CREATE TABLE public.pedidos_andamentos ( 
   id serial4 NOT NULL, 
   data_hora_inicio timestamp NOT NULL, 
   data_hora_fim timestamp NOT NULL, 
   situacao_id INT NOT NULL, 
   funcionario_id INT NOT NULL, 
   CONSTRAINT pedidos_andamentos_pkey PRIMARY KEY (id), 
   CONSTRAINT andamentos_situacoes_fk FOREIGN KEY (situacao_id) REFERENCES public.situacoes_pedidos(id), 
   CONSTRAINT andamentos_funcionarios_fk FOREIGN KEY (funcionario_id) REFERENCES public.funcionarios(id) 
);

CREATE TABLE public.pagamentos ( 
   id serial4 NOT NULL, 
   identificador varchar(40) NOT NULL, 
   pedido_id int NOT NULL, 
   data_transacao timestamp NOT NULL, 
   valor_transacao money NOT NULL, 
   data_pagamento timestamp NOT NULL, 
   valor_pagamento money NOT NULL, 
   qr_code varchar(300) NOT NULL, 
   CONSTRAINT pagamentos_pkey PRIMARY KEY (id), 
   CONSTRAINT pagamentos_pedidos_fk FOREIGN KEY (pedido_id) REFERENCES public.pedidos(id) 
);


insert into public.categorias_produtos (nome) values ('Sanduíche');
insert into public.categorias_produtos (nome) values ('Acompanhamento');
insert into public.categorias_produtos (nome) values ('Bebida');
insert into public.categorias_produtos (nome) values ('Sobremesa');

insert into public.ocupacoes (nome) values ('Administrador');
insert into public.ocupacoes (nome) values ('Atendente');
insert into public.ocupacoes (nome) values ('Preparador');

insert into public.situacoes_pedidos (id, nome) values (1, 'Recebido');
insert into public.situacoes_pedidos (id, nome) values (2, 'Em preparação');
insert into public.situacoes_pedidos (id, nome) values (3, 'Pronto');
insert into public.situacoes_pedidos (id, nome) values (4, 'Retirado');
insert into public.situacoes_pedidos (id, nome) values (5, 'Finalizado');
insert into public.situacoes_pedidos (id, nome) values (6, 'Cancelado');

insert into public.clientes (id, nome, cpf, email) values (1, 'Ana Maria', null, null);
insert into public.clientes (id, nome, cpf, email) values (2, 'Bruno Miranda', null, null);
insert into public.clientes (id, nome, cpf, email) values (3, null, '11111111111', 'cliente1@teste.com');
insert into public.clientes (id, nome, cpf, email) values (4, null, '22222222222', 'cliente2@teste.com');
