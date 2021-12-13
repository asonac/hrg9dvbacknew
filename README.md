# hrg9dvbacknew
hrg9dvbacknew

## Como Rodar

É necessário ter o docker para rodar o projeto.
Na raiz do projeto, na linha de comandos, rodar o comando:

```
$ docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

```

Após finalizar, já é possível acessar as duas api's através do:
http://localhost:8000/swagger e http://localhost:8001/swagger

Depois de rodado o comando no docker, já é possível rodar o projeto através
do visual studio ou ide da sua preferência.

###  De maneira textual, responda as questões abaixo

**1.** Descreva/Desenhe a arquitetura utilizada na solução:<br>
![](https://res.cloudinary.com/practicaldev/image/fetch/s--5A11Acxs--/c_limit%2Cf_auto%2Cfl_progressive%2Cq_auto%2Cw_880/https://img.barrymcauley.co.uk/onion_architecture.jpg)
<br><br>Onion architecture e event driven.<br>
**2.** Descreve como a modelagem de domínio foi implementada de uma maneira que deixa a aplicação flexível:<br>
Apenas duas classes. Uma para cada microserviço. A classe de integração poderia ter sido quebrada em pequenas classes.<br>
**3.** Como você resolveu/resolveria problemas de resiliência na aplicação.<br>
Utilizando a lib Polly, controlando o número e o tempo entre cada retry e caso definindo circuit break. <br>
**4.** Como você resolveu/resolveria problemas de escalabilidade na aplicação?<br>
Ter em atenção a performance de todos os microserviços e garantir a escabilidades de todas as dependências. <br>
**5.** Como você resolveu/resolveria problemas de rastreabilidade na aplicação?<br>
Arquitetura por eventos permiti você ter controle e registro de todos os eventos executados. Mantendo um histórico de ações por um determinado período<br>
**6.**  Como você garantiu a qualidade da sua aplicação?<br>
Respeitando a arquitetura, separando a regra de negócio, utilizando patterns para reutilização de código. Acrescentar testes unitários.

## About Me

This App was developed by:

- [**Wesley Canosa**](https://github.com/asonac)
