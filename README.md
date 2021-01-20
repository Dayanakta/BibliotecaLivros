# BibliotecaLivros

Rodando o projeto via Visual Studio

1 - instale o node.js versão 14.15.4 que se encontra disponível no seguinte caminho:
https://nodejs.org/en/download/

2 - Execute npm install no prompt de comando para pegar alguma possível atualização.

2 - instale o angular cli executando o seguinte comando npm install -g @angular/cli e posteriormente instale o angular devkit (npm install @angular-devkit/build-webpack)
via cmd (prompt aberto por dentro da pasta ClientApp) C:\ProjetoLyncas\BibliotecaLivros\BibliotecaLivrosUI\ClientApp
OBS: O caminho pode variar de acordo com o local onde o projeto foi salvo.

3- Dentro do visual studio clicar em solution -> propriedades -> Startup project -> Multiple startup projescts
Realizar a troca da action dos projetos BibliotecaLivrosAPI e BibliotecaLivrosUI para start.
A ordem também deve ser alterada para que a API venha primeiro e depois a UI.

Tecnologias utilizadas:

Angular versão 8.2 - Angular é uma plataforma e framework para construção da interface de aplicações usando HTML, CSS e, principalmente, JavaScript, criada pelos desenvolvedores da Google.
Foi utilizado essa versão devido ao fato do projeto ter sido gerado pelo VS2019, porém, não indico a geração pelo mesmo, pois, obtive diversos problemas de compatibilidade de recursos, devido ao fato da versão estar desatualizada.

Projeto de teste gerado pelo Xunit - foi utilizado a ferramenta de testes gratuita Xunit para aplicar as técnicas de TDD.
O porquê de usar Xunit e não Nunit é pelo fato de que o xunit realiza a criação de uma nova instância da classe de teste para cada um dos métodos de teste, diferenmente do Nunit.

Newtonsoft json (Framework json) - foi utilizado para converter os dados recebidos da plataforma do goole api books.

Base de dados: Foi utilizado um plugin (System.data.sqlite) do sqlite para gerar a base de dados e manipular a mesma.

Utilizado o plugin Swashbuckle.AspNetCore para realizar a configuração do swagger.

Dificuldade:
Não consegui implementar o alert do angular, devido ao angular material não funcionar corretamente no projeto criado pelo visual studio.

Desafio:
Implementar o angular do zero e ter feito a escolha ruim de ter gerado o projeto pelo visual studio, visto que obtive diversos erros.


