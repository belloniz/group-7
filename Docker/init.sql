CREATE DATABASE fastfood;

-- connect to the newly created database
\c fastfood;

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
	categoriaid int4 NOT NULL,
	CONSTRAINT produtos_pkey PRIMARY KEY (id),
	CONSTRAINT produtos_fk FOREIGN KEY (categoriaid) REFERENCES public.categorias_produtos(id)
);

CREATE TABLE public.produtos_imagens (
   id SERIAL NOT NULL,
   url VARCHAR(300) NOT NULL,
   produtoid INT NOT NULL,
   CONSTRAINT produtos_imagens_pkey PRIMARY KEY (id),
   CONSTRAINT produtos_imagens_fk FOREIGN KEY (produtoid) REFERENCES public.produtos(id) ON DELETE CASCADE
);
