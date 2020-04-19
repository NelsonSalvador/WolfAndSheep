# Projeto 1 de Linguagens de Programação I 2019/2020

### Nelson Salvador n21904295| Pedro Coutinho n21905323| Miguel Martinho n21901530

# Autoria :
Nelson Salvador:
- Print da board
- Print das ovelhas
- Sistema de cores
- Sistema inicial do movimento de ovelhas
- Sistema inicial de movimento do lobo
- Sistema de verificação de movimento (se as peças podem mexer para a posição pedida)

Pedro Coutinho:
- Melhoramento do sistema de prints
- Método para sair do programa
- Sistema final de movimento das ovelhas
- Sistema final de movimento do lobo
- Correção de bugs

Miguel Martinho:
- Fluxograma
- Sistema de turnos
- Sistema inicial de print de instruções
- Documentação e comentários
- Separação do código em ficheiros
- Relatório
  
# Arquitetura de solução:

Começamos por criar o tabuleiro e conseguir fazer mexer as ovelhas quando ainda
não tinhamos criado métodos nenhuns. Depois começamos a expandir o movimento das
ovelhas e a colocar os diferentes sistemas em métodos. 

Utilizámos um array bidimensional de strings para o board para as conseguirmos
desenhar o board e as peças. E criámos dois array para guardar a posição de cada 
uma das peças, um para o lobo outro para as ovelhas.

Fomos expandindo cada um dos métodos e criando o movimento do lobo muito baseado
no das ovelhas. Criámos o método CanMove para fazer a verificação se a peça
selecionada se podia mexer para o a posição pedida. []