# projetotg
Repositório para versionamento do projeto de conclusão de curso.

Comando para subir o banco de dados mysql.

```
docker run --name prototgmysql -v /my/custom:/etc/mysql/conf.d -e MYSQL_ROOT_PASSWORD=1234 -d mysql:latest
```
Ao executar este comando você tera um container de um banco de dados mysql executando em sua maquina 

Para se fazer o restore do banco utilize esse comando
```
mysql -h 172.17.0.2 -u root -p1234 projetotgdb < projetotgdb.sql
```

Para ficarmos alinhados, sempre que houver alguma alteração no banco rode esse comando
```
mysqldump -h 172.17.0.2 -u root -p1234 --databases projetogdb > projetotgdb.sql
```
Este comando cria um backup de todos os dados da base

Lembrando que esse ip pode variar se você ja tem algum container em execução na sua maquina.
