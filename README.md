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
Onion architecture e event driven.<br>
**2.** Descreve como a modelagem de domínio foi implementada de uma maneira que deixa a aplicação flexível:<br>
Apenas duas classes. Uma para cada microserviço. A classe de integração poderia ter sido quebrada em pequenas classes.<br>
**3.** Como você resolveu/resolveria problemas de resiliência na aplicação.<br>
Utilizando a lib Polly, controlando o número e o tempo entre cada retry e caso definindo circuit break. <br>
**4.** Como você resolveu/resolveria problemas de escalabilidade na aplicação?<br>


Now that you have the backend running, let's setup the frontend.

Enter into the frontend directory and run the following commands in your CLI(terminal):
```
$ yarn
$ yarn start
```

- Runs the app in the development mode.

- Open [http://localhost:3000](http://localhost:3000) to view it in the browser.

- The page will reload if you make edits.


## Instructions

**1.** One click to place the clouds.<br>
**2.** Two clicks to place the airports.<br>
**3.** Three clicks to reset the terrain in case of misplacement.<br>
**4.** Press simulate.<br>


## Technologies
- Node.js 11.10.1
- JavaScript
- Krakenjs
- React.js
- React Hooks
- Typescript

## About Me

This App was developed by:

- [**Wesley Canosa**](https://github.com/asonac)
