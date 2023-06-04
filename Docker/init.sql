CREATE DATABASE fastfood;

CREATE TABLE public.categorias_produtos (
	id serial4 NOT NULL,
	nome varchar NOT NULL,
	CONSTRAINT categorias_produtos_pkey PRIMARY KEY (id)
);