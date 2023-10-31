# Taste Ease S/A

## Miro DDD

- [Taste Ease Análise DDD](https://miro.com/app/board/uXjVMm2nBP0=/)

## Para construir a image

No diretório raiz do projeto, execute o comando:

```bash
 docker build -t tasteease/tasteease .
```

## Para subir infra do projeto

No diretório raiz do projeto, execute o comando:

```bash
 docker compose up -d
```

## Acesso PGAdmin

- <http://localhost:82>
- User: <taste@tasteease.com>
- Password: @123456
- Adicionar o servidor utilizando o host com o nome do container:
  - tasteease-postgresql
  - usuario: postgres
  - senha: postgres

## Para utilização da collection no insomnia

- Faça a importação do arquivo:
  `taste-ease_Insomnia_2023-10-29.json` ou `taste-ease_Insomnia_2023-10-29.yaml`
  no insomnia

## SEED

Após acessar o PgAdmin, execute o script `seed.sql` para popular o banco de dados.
No local de execução de scripts do PgAdmin, copie e cole o conteudo do arquivo `seed.sql` e execute.

## Contribuição

Authored by:

RM352294 - [Carlos Roberto Nascimento Junior](https://github.com/carona-jr)

RM351359 - [André Ribeiro](https://github.com/AndreRibeir0)

RM352094 - [José Ivan Ribeiro de Oliveira](https://github.com/estrng)
