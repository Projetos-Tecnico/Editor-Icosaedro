# Interface e interação

## Layout

A janela abre maximizada e se divide em duas áreas, ambas ancoradas para
acompanhar o redimensionamento:

- `drawPanel` — ocupa a esquerda e todo o restante da largura. É onde o
  icosaedro é desenhado. Fundo branco e borda simples.
- `pnlControles` — coluna fixa de 364 px na direita, com todos os controles.

A ordem vertical dentro de `pnlControles` é:

```
Faces do icosaedro
[1] [2] [3] [4] [5]
[6] [7] [8] [9] [10]

Paleta de cores
[vermelho] [verde] [azul] [amarelo] [ciano]
[magenta] [laranja] [roxo] [preto] [cinza]

[         Aplicar cores         ]

Translação X: 0
<TrackBar>
Translação Y: 0
<TrackBar>
Escala: 100%
<TrackBar>
```

## Seleção dos números

Os dez botões numerados usam o mesmo comportamento do Windows Explorer. Cada
botão tem seu próprio manipulador (`btnFace1_Click` a `btnFace10_Click`) e cada
um chama `selecionaFace` passando o próprio número — nenhum código precisa
descobrir qual botão foi clicado. `selecionaFace` lê o modificador de
`Control.ModifierKeys` e delega para uma das três funções de seleção:

- **Clique simples** (`selecionaSimples`) — descarta a seleção anterior, deixa
  apenas o item clicado e fixa nele a âncora.
- **Ctrl+clique** (`selecionaComControl`) — liga o item se ele estiver
  desligado, desliga se já estiver ligado.
- **Shift+clique** (`selecionaComShift`) — seleciona todo o intervalo entre a
  âncora e o item clicado. A âncora **não** muda, então cliques sucessivos com
  Shift sempre partem do primeiro item, crescendo ou encolhendo o intervalo. Se
  ainda não houver âncora, o próprio item clicado vira a âncora.

A seleção é guardada em `bool[] faceSelecionada`, um vetor de dez posições em que
`true` significa selecionado. Como a ordem crescente vem da própria posição no
vetor, não existe nada a ordenar: `faceDaPosicao` percorre de 0 a 9 e sempre
encontra os selecionados do menor número para o maior.

Qualquer mudança de seleção descarta as cores ainda não aplicadas
(`limpaCoresEscolhidas`), porque a correspondência entre números e cores depende
da seleção vigente.

### Destaque visual

Um botão selecionado fica com fundo azul `cores(0, 120, 215)`, texto branco e
borda preta de 3 px; os não selecionados usam `cores(240, 240, 240)`. Na figura,
as faces correspondentes recebem dois sinais
combinados, desenhados em `desenhaFaces` e `desenhaSelecao`:

- o preenchimento é escurecido levemente por `acinzentaCor(r, g, b)` (85% da cor
  original misturada com 15% de cinza), o que produz o cinza fraco nas faces
  ainda não pintadas;
- o contorno é redesenhado com 4 px em cinza `(105,105,105)`, contrastando com a
  borda preta fina de 1 px das faces não selecionadas.

Os contornos de seleção são desenhados num segundo laço, depois de todas as
faces, para que nenhuma face vizinha recorte o destaque.

## Paleta de cores

A paleta tem dez amostras (`Panel` com `BorderStyle` simples). Cada amostra tem
seu próprio manipulador (`panelRed_Click` a `panelGray_Click`), que chama
`escolheCor(r, g, b)` com os três números da sua própria cor — não existe tabela
nem busca por nome de controle. As componentes ficam guardadas em `corEscolhidaR`,
`corEscolhidaG` e `corEscolhidaB` até o clique em **Aplicar cores**. O fluxo é
sempre número primeiro, cor depois, e `escolheCor` valida isso:

1. Sem nenhum número selecionado, exibe
   `"Nenhum número selecionado.\nSelecione um número antes de selecionar uma cor!"`
   e não faz nada.
2. Com números selecionados, cada clique numa cor atribui essa cor ao próximo
   número da seleção, em ordem crescente. Selecionar 1 a 4 e clicar amarelo,
   vermelho, amarelo e azul pinta os botões 1, 2, 3 e 4 nessa ordem.
3. Quando todos os números selecionados já receberam cor, um clique adicional
   avisa `"Todos os números selecionados já receberam uma cor."` e é ignorado.

O botão que recebeu uma cor passa a exibir a cor forte no contorno e uma versão
clara dela no fundo, produzida por `clareiaCor` (uma parte da cor para quatro
partes de branco).

## Aplicar cores

`btnAplicarCores_Click` percorre as dez faces e pinta apenas as que têm cor
escolhida, deixando as demais como estavam. Depois limpa as cores pendentes e a
seleção, e os botões voltam ao contorno preto padrão.

Duas consequências previstas no enunciado do trabalho:

- selecionar números e não escolher cor nenhuma não altera a figura;
- selecionar seis números e escolher só quatro cores pinta quatro faces e
  preserva as outras duas.

## TrackBars

Os três controles reagem no evento `ValueChanged`, atualizam o próprio rótulo e
chamam `drawPanel.Invalidate()` para redesenhar:

| Controle | Faixa | Valor inicial | Efeito |
| --- | --- | --- | --- |
| `tbTransX` | -400 a 400 | 0 | desloca a figura no eixo X |
| `tbTransY` | -400 a 400 | 0 | desloca a figura no eixo Y |
| `tbScale` | 30 a 250 | 100 | escala uniforme, em porcentagem |

Como a escala pode passar de 100%, a figura pode ultrapassar os limites do painel
nos valores altos — é o comportamento esperado de um controle de ampliação.
