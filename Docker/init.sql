
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
   id uuid NOT NULL, 
   cliente_id uuid NULL, 
   CONSTRAINT pedidos_pkey PRIMARY KEY (id), 
   CONSTRAINT pedidos_clientes_fk FOREIGN KEY (cliente_id) REFERENCES public.clientes(id) 
);

CREATE TABLE public.pedidos_combos ( 
   id serial4 NOT NULL, 
   pedido_id INT NOT NULL, 
   quantidade INT NOT NULL,   
   CONSTRAINT pedidos_combos_pkey PRIMARY KEY (id), 
   CONSTRAINT pedidos_combos_fk FOREIGN KEY (pedido_id) REFERENCES public.pedidos(id) ON DELETE CASCADE
);

CREATE TABLE public.pedidos_combos_produtos ( 
   combo_id INT NOT NULL, 
   produto_id INT NOT NULL,
   valor_unitario  money NOT NULL,
   quantidade INT NOT NULL,
   CONSTRAINT pedidos_combos_produtos_pkey PRIMARY KEY (combo_id, produto_id), 
   CONSTRAINT pedidos_combos_fk FOREIGN KEY (combo_id) REFERENCES public.pedidos_combos(id) ON DELETE CASCADE,
   CONSTRAINT pedidos_produtos_fk FOREIGN KEY (produto_id) REFERENCES public.produtos(id)
);

CREATE TABLE public.pedidos_andamentos ( 
   id serial4 NOT NULL, 
   pedido_id INT NOT NULL,
   data_hora_inicio timestamp NOT NULL, 
   data_hora_fim timestamp NULL, 
   situacao_id INT NOT NULL, 
   funcionario_id INT NULL, 
   atual bool NOT NULL DEFAULT false, 
   CONSTRAINT pedidos_andamentos_pkey PRIMARY KEY (id), 
   CONSTRAINT andamentos_pedidos_fk FOREIGN KEY (pedido_id) REFERENCES public.pedidos(id) ON DELETE CASCADE, 
   CONSTRAINT andamentos_situacoes_fk FOREIGN KEY (situacao_id) REFERENCES public.situacoes_pedidos(id), 
   CONSTRAINT andamentos_funcionarios_fk FOREIGN KEY (funcionario_id) REFERENCES public.funcionarios(id) 
);

CREATE TABLE public.pagamentos ( 
   id serial4 NOT NULL, 
   pedido_id int NOT NULL, 
   valor money NOT NULL, 
   qr_code varchar(300) NOT NULL, 
   CONSTRAINT pagamentos_pkey PRIMARY KEY (id), 
   CONSTRAINT pagamentos_pedidos_fk FOREIGN KEY (pedido_id) REFERENCES public.pedidos(id) ON DELETE CASCADE
);


INSERT INTO public.categorias_produtos (id,nome) VALUES
	('d7589235-397f-4690-b71f-79cfe3d166e1','Sanduíche'),
	('d7589235-397f-4690-b71f-79cfe3d166e3','Bebida'),
	('d7589235-397f-4690-b71f-79cfe3d166e6','Sobremesa'),
	('d7589235-397f-4690-b71f-79cfe3d166e7','Complemento');

INSERT INTO public.ocupacoes (id,nome) VALUES
	('09f6a1c6-2fe3-4276-8014-b9595437e331','Administrador'),
	('09f6a1c6-2fe3-4276-8014-b9595437e332','Atendente'),
	('09f6a1c6-2fe3-4276-8014-b9595437e333','Preparador');

INSERT INTO public.situacoes_pedidos (id, nome) VALUES 
   (0, 'Realizado'),
   (1, 'Recebido'),
   (2, 'Em preparação'),
   (3, 'Pronto'),
   (4, 'Retirado'),
   (5, 'Finalizado'),
   (6, 'Cancelado');

INSERT INTO public.clientes (id, nome, cpf, email) VALUES 
   ('a817156e-4ccc-4229-bfd1-a524f54dd5d1', 'Ana Maria', null, null),
   ('a817156e-4ccc-4229-bfd1-a524f54dd5d2', 'Bruno Miranda', null, null),
   ('a817156e-4ccc-4229-bfd1-a524f54dd5d3', null, '27000631040', 'cliente1@teste.com'),
   ('a817156e-4ccc-4229-bfd1-a524f54dd5d4', null, '97491193048', 'cliente2@teste.com');

INSERT INTO public.produtos (id, nome, descricao, preco, categoria_id) VALUES 
   ('140b22ca-b64f-4c9e-b756-f2a24eb823d1', 'X-Burger Bacon', 'Tradicional', 18.00, 'd7589235-397f-4690-b71f-79cfe3d166e1'),
   ('140b22ca-b64f-4c9e-b756-f2a24eb823d2', 'X-Moda Frango', 'Acebolado', 17.00, 'd7589235-397f-4690-b71f-79cfe3d166e1'),
   ('140b22ca-b64f-4c9e-b756-f2a24eb823d3', 'X-Tudo Filé', 'Completo', 25.00, 'd7589235-397f-4690-b71f-79cfe3d166e1'),
   ('140b22ca-b64f-4c9e-b756-f2a24eb823d4', 'Coca-Cola Lata', '350ml', 7.00, 'd7589235-397f-4690-b71f-79cfe3d166e3'),
   ('140b22ca-b64f-4c9e-b756-f2a24eb823d5', 'Guaraná Lata', '350ml', 7.00, 'd7589235-397f-4690-b71f-79cfe3d166e3'),
   ('140b22ca-b64f-4c9e-b756-f2a24eb823d6', 'Água Mineral', '500ml', 6.00, 'd7589235-397f-4690-b71f-79cfe3d166e3'),
   ('140b22ca-b64f-4c9e-b756-f2a24eb823d7', 'Batata Pequena', 'Com sal', 12.00, 'd7589235-397f-4690-b71f-79cfe3d166e7'),
   ('140b22ca-b64f-4c9e-b756-f2a24eb823d8', 'Batata Média', 'Com sal', 13.00, 'd7589235-397f-4690-b71f-79cfe3d166e7'),
   ('140b22ca-b64f-4c9e-b756-f2a24eb823d9', 'Batata Grande', 'Com sal', 15.00, 'd7589235-397f-4690-b71f-79cfe3d166e7'),
   ('140b22ca-b64f-4c9e-b756-f2a24eb823da', 'Sunday Creme', 'Especial', 12.00, 'd7589235-397f-4690-b71f-79cfe3d166e6'),
   ('140b22ca-b64f-4c9e-b756-f2a24eb823db', 'Sunday Chocolate', 'Especial', 12.00, 'd7589235-397f-4690-b71f-79cfe3d166e6'),
   ('140b22ca-b64f-4c9e-b756-f2a24eb823dc', 'Sunday Morango', 'Especial', 12.00, 'd7589235-397f-4690-b71f-79cfe3d166e6');

INSERT INTO public.produtos_imagens (url, produto_id) VALUES 
   ('http://www.google.com/imagem1.jpg', '140b22ca-b64f-4c9e-b756-f2a24eb823d1'),
   ('http://www.google.com/imagem2.jpg', '140b22ca-b64f-4c9e-b756-f2a24eb823d2'),
   ('http://www.google.com/imagem3.jpg', '140b22ca-b64f-4c9e-b756-f2a24eb823d3'),
   ('http://www.google.com/imagem4.jpg', '140b22ca-b64f-4c9e-b756-f2a24eb823d4'),
   ('http://www.google.com/imagem5.jpg', '140b22ca-b64f-4c9e-b756-f2a24eb823d5'),
   ('http://www.google.com/imagem6.jpg', '140b22ca-b64f-4c9e-b756-f2a24eb823d6'),
   ('http://www.google.com/imagem7.jpg', '140b22ca-b64f-4c9e-b756-f2a24eb823d7'),
   ('http://www.google.com/imagem8.jpg', '140b22ca-b64f-4c9e-b756-f2a24eb823d8'),
   ('http://www.google.com/imagem9.jpg', '140b22ca-b64f-4c9e-b756-f2a24eb823d9'),
   ('http://www.google.com/imagem10.jpg', '140b22ca-b64f-4c9e-b756-f2a24eb823da'),
   ('http://www.google.com/imagem11.jpg', '140b22ca-b64f-4c9e-b756-f2a24eb823db'),
   ('http://www.google.com/imagem12.jpg', '140b22ca-b64f-4c9e-b756-f2a24eb823dc');

INSERT INTO public.funcionarios (id, nome, matricula, ocupacao_id) VALUES 
   ('6b4f3188-4536-4029-8033-3835c7437f31', 'Ana Maria', 'A000001', '09f6a1c6-2fe3-4276-8014-b9595437e332'),
   ('6b4f3188-4536-4029-8033-3835c7437f32', 'Bruno Pereira', 'A000002', '09f6a1c6-2fe3-4276-8014-b9595437e332'),
   ('6b4f3188-4536-4029-8033-3835c7437f33', 'João Almeida', 'A000003', '09f6a1c6-2fe3-4276-8014-b9595437e332');

