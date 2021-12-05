# Aula: Acessando banco de dados com Entity Frameworl Core
Nessa aula, demostrei um desafio que tive quando trabalhei em um banco, os problemas e como usei o EF Core para me ajudar a entregar valor ao meu cliente.

## Preparando o Ambiente

### MySQL
Criando a imagem Docker: `docker run --name ExpertsClub-EFCore-MySQL -e MYSQL_ROOT_PASSWORD=Senh@1234 -p 3306:3306 mysql`

### Oracle
Criando a imagem Docker: `docker run --name ExpertsClub-EFCore-Oracle -d -p 1521:1521 pvargacl/oracle-xe-18.4.0`

Criando um usuário para utilizar o banco:
`alter session set "_ORACLE_SCRIPT"=true; -- Habilitar criação de usuário  

	CREATE USER variosbancos IDENTIFIED BY 1234; -- Criar usuário

	GRANT CREATE TABLE TO variosbancos; -- Permissão para o usuário criar tabelas
	GRANT CREATE SEQUENCE TO variosbancos;

	grant create session to variosbancos; 

	GRANT UNLIMITED TABLESPACE TO variosbancos;`
  
### SQL Server
Criando a imagem Docker: `docker run --name ExpertsClub-EFCore-SqlServer -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Senh@1234" -e "MSSQL_PID=Express" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest `


