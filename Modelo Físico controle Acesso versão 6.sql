

--USE master

--EXCLUIR O BANCO DE DADOS
  

CREATE DATABASE DB_CONTROLEACESSO

USE DB_CONTROLEACESSO



CREATE TABLE TB_CARGO (
COD_CARGO INTEGER,
CARGO VARCHAR(60)NOT NULL,
CONSTRAINT PK_CARGO PRIMARY KEY (COD_CARGO)
)

select * from  tb_cargo

INSERT INTO TB_CARGO (COD_CARGO,CARGO) VALUES (1, 'Professor')
INSERT INTO TB_CARGO VALUES (2, 'Secretario(a)')
INSERT INTO TB_CARGO VALUES (3, 'Diretor')
INSERT INTO TB_CARGO VALUES (4, 'Cordenador')

CREATE TABLE TB_USUARIO (
COD_USUARIO INTEGER,
NOME VARCHAR(70)NOT NULL,
SOBRENOME VARCHAR(60)NOT NULL,
EMAIL VARCHAR(60)NOT NULL,
SENHA VARCHAR(10)NOT NULL,
COD_CARGO INTEGER,
CONSTRAINT PK_USUARIO PRIMARY KEY (COD_USUARIO),
CONSTRAINT FK_CARGO FOREIGN KEY(COD_CARGO) REFERENCES TB_CARGO (COD_CARGO)
)

SELECT * FROM TB_USUARIO


INSERT INTO TB_USUARIO(COD_USUARIO,NOME,SOBRENOME, EMAIL, SENHA,COD_CARGO)
VALUES (1,'Admin','Adimin' ,'admin@admin.com', '123456','1' )
  
INSERT INTO TB_USUARIO(COD_USUARIO,NOME,SOBRENOME, EMAIL, SENHA,COD_CARGO)
VALUES (2,'User', 'User','user@user.com', '123456','2')



CREATE TABLE TB_ALUNO (
COD_ALUNO INTEGER,
NOME VARCHAR(70)NOT NULL,
RM VARCHAR(10)NOT NULL,
DATA_NASCIENTO DATE NOT NULL,
SEXO CHAR(10) NOT NULL,
CONSTRAINT PK_ALUNO PRIMARY KEY (COD_ALUNO)
)
--EXCLUIR A TABELA ALUNO
--DROP TABLE TB_ALUNO

select * from TB_ALUNO

INSERT INTO TB_ALUNO(COD_ALUNO,NOME,RM,DATA_NASCIENTO,SEXO) VALUES(1,'Fulano de Tal','2121','10-10-2008','M')
INSERT INTO TB_ALUNO VALUES(2,'BELTRANO','2323','12-02-2000', 'M')
INSERT INTO TB_ALUNO VALUES(3,'SICLANO','3333', '13-03-2010','M')

--CLAUSA WHERE PRA CONSULTAR SOMENTE POR NOME FULANO DE TAL
--SELECT * FROM TB_ALUNO
--WHERE NOME = 'FULANO DE TAL'


--EXCLUIR A CATEGORIA QUE � FULANO DE TAL
--DELETE FROM TB_ALUNO
--WHERE NOME = 'FULANO DE TAL'



CREATE TABLE TB_ACESSO (
COD_ACESSO INTEGER,
DATA VARCHAR(10)NOT NULL,
HORA_ENTRADA TIME NOT NULL,
HORA_SAIDA TIME NOT NULL,
COD_ALUNO INTEGER,
CONSTRAINT PK_ACESSO PRIMARY KEY (COD_ACESSO),
CONSTRAINT FK_ALUNO FOREIGN KEY (COD_ALUNO) REFERENCES TB_ALUNO (COD_ALUNO)
)
--EXCLUIR A TABELA ACESSO
--DROP TABLE TB_ACESSO

select * from tb_acesso

INSERT INTO TB_ACESSO (COD_ACESSO,DATA,HORA_ENTRADA,HORA_SAIDA,COD_ALUNO) VALUES(1,'26/08/2019','19:10','22:50','01' )
INSERT INTO TB_ACESSO VALUES(2,'26/08/2019','19:10','22:50','02' )
INSERT INTO TB_ACESSO VALUES(3,'26/08/2019','19:10','22:50','03' )

--EXCLUIR A CATEGORIA CUJO CODIGO FOR '1'
--DELETE FROM TB_ACESSO
--WHERE COD_ACESSO = 1

--EXCLUIR A CATEGORIA CUJO CODIGO FOR '2'
--DELETE FROM TB_ACESSO
--WHERE COD_ACESSO = 2


CREATE TABLE TB_AUTORIZACAO (
COD_AUTORIZACAO INTEGER,
NOME_RESPONSAVEL VARCHAR(70)NOT NULL,
RG CHAR(12)NOT NULL,
DATA DATE NOT NULL,
HORA TIME NOT NULL ,
TIPO_AUTORIZACAO VARCHAR(20) NULL,
VIGENCIA_INICIO VARCHAR(50)NOT NULL,
VIGENCIA_FIM VARCHAR(10)NOT NULL,
MOTIVO VARCHAR(100) NOT NULL,
COD_ALUNO INTEGER,
CONSTRAINT PK_AUTORIZACAO PRIMARY KEY (COD_AUTORIZACAO),
CONSTRAINT FK_ALUNO2 FOREIGN KEY (COD_ALUNO) REFERENCES TB_ALUNO (COD_ALUNO)
)
--EXCLUIR A TABELA AUTORIZACAO
--DROP TABLE TB_AUTORIZACAO
SELECT * FROM TB_AUTORIZACAO

INSERT INTO TB_AUTORIZACAO(COD_AUTORIZACAO,NOME_RESPONSAVEL,RG,DATA,HORA,TIPO_AUTORIZACAO,VIGENCIA_INICIO,VIGENCIA_FIM,MOTIVO,COD_ALUNO)
values (1,'Francisquinha','111000111','10-03-2020','20:30','Pessoal','10-03-2020','10-04-2020','Precisa sair mais cedo','1')
INSERT INTO TB_AUTORIZACAO values (2,'Filomena arantes','112223334','15-04-2020','17:00','Pessoal','20-03-2020','31-03-2020','Preciso Entra mais cedo','2')
--Atualizando campo cod_aluno na tabela autoriza��o de null para 2
--UPDATE TB_AUTORIZACAO SET COD_ALUNO = '2'
--WHERE COD_AUTORIZACAO =2;


CREATE TABLE TB_CURSO (
COD_CURSO INTEGER,
NOME_CURSO VARCHAR(70)NOT NULL,
CONSTRAINT PK_CURSO PRIMARY KEY (COD_CURSO)
)

select * from TB_CURSO

--INSERINDO DADOS NA TABELA CURSO USANDO O (INSERT DECLARATIVO)
INSERT INTO TB_CURSO (COD_CURSO, NOME_CURSO) VALUES (1,'Inform�tica')
INSERT INTO TB_CURSO (COD_CURSO, NOME_CURSO) VALUES (2,'Eletroeletr�nica')
--INSERINDO DADOS NA TABELA CURSO USANDO O (INSERT POSICIONAL)
INSERT INTO TB_CURSO  VALUES (3,'M�dicina')
INSERT INTO TB_CURSO  VALUES (4,'Engenharia')

--Atualizando dados de uma tabela com dados de outra tabela
--update TB_CURSO set NOME_CURSO = ( select NOME_RESPONSAVEL from TB_AUTORIZACAO where COD_AUTORIZACAO = 1)

--Atualizando os dados da tabela curso
--update TB_CURSO set NOME_CURSO = 'Psicologia' where COD_CURSO = 4;
--update TB_CURSO set NOME_CURSO = 'Inform�tica' where COD_CURSO = 1;
--update TB_CURSO set NOME_CURSO = 'M�dicina' where COD_CURSO = 3;
--update TB_CURSO set NOME_CURSO = 'Eletroeletr�nica' where COD_CURSO = 2;



CREATE TABLE TB_TURMA (
COD_TURMA INTEGER,
SERIE VARCHAR(10)NOT NULL,
PERIODO VARCHAR(10)NOT NULL,
HORA_ENTRADA TIME NOT NULL,
HORA_SAIDA TIME NOT NULL,
COD_CURSO INTEGER,
CONSTRAINT PK_TURMA PRIMARY KEY (COD_TURMA),
CONSTRAINT FK_CURSO FOREIGN KEY (COD_CURSO) REFERENCES TB_CURSO (COD_CURSO)
)

select * from TB_TURMA

--INSERINDO DADOS NA TABELA TURMA USANDO O (INSERT DECLARATIVO)
INSERT INTO TB_TURMA (COD_TURMA,SERIE,PERIODO,HORA_ENTRADA,HORA_SAIDA,COD_CURSO) VALUES (1,'1','Noite','19:00','22:45', '1')
INSERT INTO TB_TURMA (COD_TURMA,SERIE,PERIODO,HORA_ENTRADA,HORA_SAIDA,COD_CURSO) VALUES (2,'1','Noite','19:00','22:45', '2')
--INSERINDO DADOS NA TABELA TURMA USANDO O (INSERT POSICINAL)
INSERT INTO TB_TURMA VALUES (3,'1','Noite','19:00','22:45','1')
INSERT INTO TB_TURMA VALUES (4,'1','Noite','19:00','22:45','1')

--CRIANDO UMA REGRA (CONSTRAINT) OU SEJA ADICIONANDO A CHAVE PRIMARIA DA TABELA CURSO COMO CHAVE ESTRANGEIRA NA TABELA TURMA
--CONSTRAINT FK_CURSO FOREIGN KEY(COD_CURSO) REFERENCES TB_CURSO(COD_CURSO)




CREATE TABLE TB_ALUNO_TURMA (
COD_ALUNO INTEGER,
COD_TURMA INTEGER,
ANO CHAR(4),
SEMESTRE CHAR(10),
CONSTRAINT PK_ALUNO_TURMA PRIMARY KEY(COD_ALUNO,COD_TURMA,ANO,SEMESTRE),
CONSTRAINT FK_ALUNO3 FOREIGN KEY(COD_ALUNO) REFERENCES TB_ALUNO (COD_ALUNO),
CONSTRAINT FK_TURMA FOREIGN KEY(COD_TURMA) REFERENCES TB_TURMA (COD_TURMA)
)

SELECT * FROM TB_ALUNO_TURMA

INSERT INTO TB_ALUNO_TURMA (COD_ALUNO, COD_TURMA, ANO, SEMESTRE) VALUES (1, '1','2020','Segundo')
INSERT INTO TB_ALUNO_TURMA (COD_ALUNO, COD_TURMA, ANO, SEMESTRE) VALUES (2, '1','2020','Segundo')







--ADICIONANDO CHAVES ESTRANGEIRA A UMA TABELA

--ALTER TABLE TB_ACESSO ADD FOREIGN KEY(COD_ALUNO) REFERENCES TB_ALUNO (COD_ALUNO)
--ALTER TABLE TB_AUTORIZACAO ADD FOREIGN KEY(COD_ALUNO) REFERENCES TB_ALUNO (COD_ALUNO)
--ALTER TABLE TB_TURMA ADD FOREIGN KEY(COD_CURSO) REFERENCES TB_CURSO (COD_CURSO)
--Adicionando um campo (Cod_adm_usuario) na tabela aluno
--alter table TB_ALUNO
--add COD_ADM_USUARIO int;

--EXCLUINDO O CAMPO (COD_ADM_USUARIO) NA TABELA ALUNO
--ALTER TABLE TB_ALUNO
--DROP COLUMN COD_ADM_USUARIO;

--adicionando chave estrangeira (fk_Adm_usuario)na tabela aluno
--ALTER TABLE TB_ALUNO
--ADD CONSTRAINT FK_ADM_USUARIO FOREIGN KEY (COD_ADM_USUARIO)REFERENCES TB_ADM_USUARIO (COD_ADM_USUARIO)


--Removendo a chave estrangeira (FK_Aluno) da tabela tb_adm_usuario

--alter table tb_adm_usuario
--drop constraint fk_admaluno;

--CONSULTAR TODAS AS COLUNAS E REGITROS(LINHAS) DA TABELA TB_ADM_USUARIO
 select * from TB_USUARIO
 select * from TB_AUTORIZACAO
  select * from TB_ALUNO
  select*from TB_CURSO
  select * from tb_turma
  SELect * from TB_ALUNO_TURMA
  select * from TB_ACESSO

  --ADICIONAR O CAMPO PRECO NA TABELA LIVRO
--ALTER TABLE TB_LIVRO ADD PRECO DECIMAL(5,2)

-- EXCLUI O CAMPO PRECO DA TABELA LIVRO
--ALTER TABLE TB_LIVRO DROP COLUMN PRECO

--ADICIONAR OS CAMPOS PRECO E QUANTIDADE DE P�GINAS NA TABELA LIVRO
--ALTER TABLE TB_LIVRO ADD PRECO DECIMAL (5,2),QUANTIDADE_PAGINAS DECIMAL(5)


--RENOMEIA OU (ALTERA) O NOME DO CAMPO PRECO PARA VALOR DA TABELA LIVRO
--SP_RENAME 'TB_LIVRO.PRECO','VALOR','COLUMN'

--ALTERAR UMA COLUNA J� EXISTENTE
--ALTER TABLE TB_LIVRO ALTER COLUMN VALOR DECIMAL(6,2)


--ALTERAR O NOME DA TABELA 'TB_LIVRO' PARA 'TB_PRODUTO'
--SP_RENAME 'TB_LIVRO', 'TB_PRODUTO'



--ALTERAR O NOME DA TABELA 'TB_PRODUTO' PARA 'TB_LIVRO'
--SP_RENAME 'TB_PRODUTO', 'TB_LIVRO'

--RENOMEAR OU (ALTERAR) O NOME DO CAMPO 'VALOR' PARA 'PRECO'
--SP_RENAME 'TB_LIVRO.VALOR', 'PRECO', 'COLUMN'



 --Removendo o campo (COD_ALUNO) da tabela tb_adm_usuario

 --alter table tb_adm_usuario
 --drop column cod_aluno;
 --Consultar o nome do aluno e em qual semestre ele esta
 select TB_ALUNO.NOME, TB_ALUNO_TURMA.SEMESTRE 
 from TB_TURMA as TB_CURSO inner join TB_ALUNO 
 ON TB_ALUNO.COD_ALUNO = TB_CURSO.COD_CURSO
 INNER JOIN TB_ALUNO_TURMA 
 ON TB_ALUNO_TURMA.COD_ALUNO = TB_CURSO.COD_CURSO


 --CONSULTAR OS ALUNOS QUE ESTA AUTORIZADO A SAIR MAIS CEDO E O MOTIVO
 SELECT TB_ALUNO.NOME, TB_AUTORIZACAO.MOTIVO
 FROM TB_ALUNO INNER JOIN TB_AUTORIZACAO
 ON TB_ALUNO.COD_ALUNO = TB_AUTORIZACAO.COD_ALUNO

 --OU

  SELECT TB_ALUNO.NOME, TB_AUTORIZACAO.MOTIVO
 FROM TB_ALUNO ,TB_AUTORIZACAO
 WHERE TB_ALUNO.COD_ALUNO = TB_AUTORIZACAO.COD_ALUNO

 
 --Consulta o nome do aluno e qual o node do curso ele faz e de qual O periodo 
 select TB_ALUNO.NOME, TB_CURSO.NOME_CURSO,TB_TURMA.PERIODO
 FROM TB_ALUNO INNER JOIN TB_CURSO
 ON TB_ALUNO.COD_ALUNO = TB_CURSO.COD_CURSO
 INNER JOIN TB_TURMA ON TB_TURMA.COD_TURMA = TB_CURSO.COD_CURSO


 select TB_ALUNO.NOME, TB_CURSO.NOME_CURSO,TB_TURMA.PERIODO
 FROM TB_ALUNO full join TB_CURSO
 ON TB_ALUNO.COD_ALUNO = TB_CURSO.COD_CURSO
 full join TB_TURMA ON TB_TURMA.COD_TURMA = TB_CURSO.COD_CURSO