# Taste Ease S/A

## Para construir a image

```bash
 docker build -t tasteease/tasteease .
```

## Para subir infra do projeto

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

[] todo

## Contribuição

Authored by:

[Carlos Roberto Nascimento Junior](https://github.com/carona-jr)

[André Ribeiro](https://github.com/AndreRibeir0)

Apoio

[José Ivan Ribeiro de Oliveira](https://github.com/estrng)