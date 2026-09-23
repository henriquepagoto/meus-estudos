-- Os comentários começam com dois hífens. Cada comando é encerrado com um
-- ponto e vírgula.

-- SQL não diferencia maiúsculas de minúsculas em palavras-chave. Os
-- comandos de exemplo mostrados aqui seguem a convenção de serem escritos
-- em maiúsculas porque torna mais fácil distingui-los dos nomes dos bancos
-- de dados, tabelas e colunas.

-- Em seguida, um banco de dados é criado e excluído. Os nomes do banco de
-- dados e da tabela são sensíveis a maiúsculas de minúsculas.

-- Tentei criar as DATABASE no PostgreSQL e deu certo:
CREATE DATABASE someDatabase;
DROP DATABASE someDatabase;

-- Mostra numa lista todos os bancos de dados disponíveis.
-- Tentei usar esse comando abaixo no PostgreSQL porem ele não reconhece esse comando:
SHOW DATABASES;

-- Para lista todos os bancos de dados ativos no PostgreSQL usei o comando abaixo:
SELECT datname FROM pg_database WHERE datistemplate = false;

-- pg_database: É uma tabela interna do PostgreSQL que guarda as informações de todos os bancos criados.
-- WHERE datistemplate = false: Esse filtro serve para esconder os bancos de modelo (como template0 e template1) que o PostgreSQL cria e gerencia sozinho.

-- Segue para criar o DataBase, depois tem que criar uma nova consulta:
CREATE DATABASE employees;

-- Usa um determinado banco de dados existente.
-- Esse comando abaixo não funciona no PostgreSQL, tem que criar uma nova consulta:
USE employees;

-- Seleciona todas as filas e colunas da tabela de departamentos no banco
-- de dados atual. A atividade padrão é o intérprete rolar os resultados
-- na tela.
SELECT * FROM departments;

-- Recupera todas as filas da tabela de departamentos, mas apenas as colunas
-- dept_no e dept_name.
-- A separação de comandos em várias linhas é permitida.
SELECT dept_no,
       dept_name FROM departments;

-- Obtém todas as colunas de departments, mas é limitado a 5 filas.
SELECT * FROM departments LIMIT 5;

-- Obtém os valores da coluna dept_name da tabela de departments quando
-- dept_name tem como valor a substring 'en'.
SELECT dept_name FROM departments WHERE dept_name LIKE '%en%';

-- Recupera todas as colunas da tabela de departments onde a coluna
-- dept_name começa com um 'S' e tem exatamente 4 caracteres depois dele.
SELECT * FROM departments WHERE dept_name LIKE 'S____';

-- Seleciona os valores dos títulos da tabela de titles, mas não mostra
-- duplicatas.
SELECT DISTINCT title FROM titles;

-- Igual ao anterior, mas ordenado por valores de da coluna title (diferencia
-- maiúsculas de minúsculas).
SELECT DISTINCT title FROM titles ORDER BY title;

-- Mostra o número de filas da tabela departments.
SELECT COUNT(*) FROM departments;

-- Mostra o número de filas da tabela departments que contém 'en' como
-- substring na coluna dept_name.
SELECT COUNT(*) FROM departments WHERE dept_name LIKE '%en%';

-- Uma união (JOIN) de informações de várias tabelas: a tabela titles mostra
-- quem tem quais cargos laborais, de acordo com seu número de funcionários,
-- e desde que data até que data. Esta informação é obtida, mas em vez do
-- número do funcionário é usada como referência cruzada a tabela employee
-- para obter o nome e sobrenome de cada funcionário (e limita os resultados
--  a 10 filas).
SELECT employees.first_name, employees.last_name,
       titles.title, titles.from_date, titles.to_date
FROM titles INNER JOIN employees ON
       employees.emp_no = titles.emp_no LIMIT 10;

-- São listadas todas as tabelas de todas os bancos de dados. As implementações
-- normalmente fornecem seus próprios comandos para fazer isso com o banco de
-- dados atualmente em uso.
SELECT * FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE='BASE TABLE';

-- As tabelas abaixo criei seguindo a documentação do PostgreSQl:
-- VARCHAR(80) limita o campo a no máximo 80 caracteres.
CREATE TABLE weather (
    city            varchar(80),
    temp_lo         int,           -- low temperature
    temp_hi         int,           -- high temperature
    prcp            real,          -- precipitation
    date            date
);

-- Tabela criada conforme documentação:
CREATE TABLE cities (
    name            varchar(80),
    location        point
);

-- Cria uma tabela chamada tablename1, com as duas colunas mostradas, a partir
-- do banco de dados em uso. Há muitas outras opções disponíveis para a forma
-- em que se especificam as colunas, por ex. seus tipos de dados.
CREATE TABLE tablename1 (fname VARCHAR(20), lname VARCHAR(20));

-- Insere uma fila de dados na tabela tablename1. É assumido que a tabela foi
-- definida para aceitar esses valores como adequados.
INSERT INTO tablename1 VALUES('Richard','Mutt');

-- Em tablename1, se altera o valor de fname para 'John' em todas as filas que
-- contenham um valor em lname igual a 'Mutt'.
UPDATE tablename1 SET fname='John' WHERE lname='Mutt';

-- Se excluem as filas da tabela tablename1 em que o valor de lname começa
-- com 'M'.
DELETE FROM tablename1 WHERE lname like 'M%';

-- Se excluem as filas da tabela tablename1, deixando a tabla vazia.
DELETE FROM tablename1;

-- A tabela tablename1, é excluída completamente.
DROP TABLE tablename1;

-- Caso precise podemos forçar a excluir o database com o comando abaixo:
DROP DATABASE somedatabase WITH (FORCE);

-- 1. Garanta que está no banco principal (nunca tente apagar o banco em que está logado)
-- Se estiver no psql use \c postgres, se estiver em interface gráfica garanta que a aba atual aponta para o banco 'postgres'

-- 2. Bloqueia novas conexões para que ninguém reconecte no meio do processo
ALTER DATABASE somedatabase WITH ALLOW_CONNECTIONS false;

-- 3. Derruba todas as sessões ativas que estão presas nesse banco agora
SELECT pg_terminate_backend(pid) 
FROM pg_stat_activity 
WHERE datname = 'somedatabase' AND pid <> pg_backend_pid();

-- 4. Exclui o banco de dados de forma limpa e rápida
DROP DATABASE somedatabase;

-- A alternativa conceitual: Schemas (Esquemas)
-- Muitas vezes, quem vem do MySQL usa múltiplos "bancos de dados" quando na verdade deveria usar Schemas dentro de um mesmo banco.
-- Se o seu employees for um esquema (uma pasta organizacional dentro do banco), você pode definir o caminho de busca padrão com o comando: 
SET search_path TO employees;

