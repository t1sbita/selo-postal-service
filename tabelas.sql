CREATE TABLE public.cidade (
	id int4 NOT NULL GENERATED ALWAYS AS IDENTITY,
	municipio text NULL,
	estado text NULL,
	CONSTRAINT cidade_pkey PRIMARY KEY (id)
);

CREATE TABLE public.endereco (
	id int4 NOT NULL GENERATED ALWAYS AS IDENTITY,
	nome name NOT NULL,
	"enderecoCasa" text NOT NULL,
	"numeroCasa" text NOT NULL,
	"codigoPostal" text NOT NULL,
	bairro text NULL,
	"CidadeId" int4 NULL DEFAULT 1,
	"criadoEm" date NULL,
	"modificadoEm" date NULL
);
-- public.endereco foreign keys
ALTER TABLE public.endereco ADD CONSTRAINT "CidadeId" FOREIGN KEY ("CidadeId") REFERENCES public.cidade(id);

CREATE TABLE public.usuario (
	id int4 NOT NULL GENERATED ALWAYS AS IDENTITY,
	login text NULL,
	"password" text NULL,
	"role" text NULL
);