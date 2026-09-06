# Arquitetura do código

## Tecnologia

Aplicação Windows Forms em C#, .NET Framework 4.7.2, desenhada inteiramente com
`System.Drawing` (GDI+) no evento `Paint` de um `Panel`. Não há bibliotecas
externas.

## Arquivos

| Arquivo | Conteúdo |
| --- | --- |
| `Program.cs` | ponto de entrada padrão do Windows Forms |
| `Form1.Designer.cs` | declaração e posicionamento de todos os controles |
| `Form1.cs` | primitivas de desenho, geometria, estado e eventos |

A classe `Face`, no fim de `Form1.cs`, guarda os três índices de vértice de uma
face e a cor de preenchimento atual.

## Organização de `Form1.cs`

O arquivo é dividido em blocos, cada um com uma responsabilidade, e nenhuma
função acumula mais de um assunto:

**Primitivas** — as funções de desenho usadas nos exercícios da disciplina, que o
enunciado exige que sejam reaproveitadas: `cores`, `caneta` (três sobrecargas),
`pintaPonto`, `pintaLinha`, `pintaRetangulo`, `desenhaPoligono`,
`PreenchePoligono` (três sobrecargas), `preen_Area` (três sobrecargas) e
`poligono`. Todo desenho da figura passa por elas — nenhuma chamada direta a
`Graphics` acontece fora desse bloco, com exceção de `SmoothingMode`.

**Estrutura do icosaedro** — `BaseVertices`, `faces` e `BASE_SCALE`. Descrito em
[geometria-icosaedro.md](geometria-icosaedro.md).

**Estado da seleção e das cores** — `botoesFace`, `facesSelecionadas`,
`ancoraSelecao`, `coresEscolhidas`, `temCorEscolhida` e
`quantidadeCoresEscolhidas`, mais `montaBotoesFace`, que junta os dez botões num
array para que o índice da face seja obtido por `Array.IndexOf`.

**Transformação** — `TransformVertices`, único ponto que converte coordenadas
normalizadas em pixels.

**Desenho** — `pontosDaFace` monta o triângulo de uma face, `desenhaFaces` pinta
e contorna todas, `desenhaSelecao` redesenha por cima o contorno das
selecionadas, `drawPanel_Paint` orquestra os três e `drawPanel_Resize` força a
repintura ao redimensionar.

**Seleção** — `selecionaSimples`, `selecionaComControl` e `selecionaComShift`
tratam um modo de seleção cada; `btnFace_Click` apenas identifica o botão e o
modificador e delega; `atualizaBotoesFace` cuida só da aparência dos botões.

**Paleta** — `corDaPaleta` traduz o nome do painel clicado em uma cor,
`clareiaCor` e `acinzentaCor` derivam as variações usadas no fundo dos botões e
no destaque das faces, e `panelCor_Click` faz as validações e a atribuição.

**Aplicação** — `limpaCoresEscolhidas`, `limpaSelecao` e `btnAplicarCores_Click`.

**TrackBars** — `atualizaRotulos` para o estado inicial e um `ValueChanged` para
cada controle.

## Convenções

- Métodos próprios em português; nomes de controles em inglês, seguindo o padrão
  já existente no projeto.
- Cores nunca são construídas com `Color.FromArgb` direto no código de negócio:
  passam sempre pela primitiva `cores(r, g, b)`.
- Cada evento faz o mínimo e chama funções nomeadas — a lógica não mora dentro
  dos manipuladores.
