# Arquitetura do código

## Restrição que rege todo o projeto

O código só pode usar recursos apresentados nas apostilas do professor. Leia
[restricoes-do-material.md](restricoes-do-material.md) **antes** de escrever
qualquer linha aqui — ela lista o que é permitido e o que já foi removido do
projeto por não estar no material.

## Tecnologia

Aplicação Windows Forms em C#, .NET Framework 4.7.2, desenhada inteiramente com
`System.Drawing` (GDI+) no evento `Paint` de um `Panel`. Não há bibliotecas
externas. Todo o estado mora em **vetores** — não existe nenhuma coleção
genérica nem classe própria no projeto.

## Arquivos

| Arquivo | Conteúdo |
| --- | --- |
| `Program.cs` | ponto de entrada padrão do Windows Forms |
| `Form1.Designer.cs` | declaração e posicionamento de todos os controles |
| `Form1.cs` | primitivas de desenho, geometria, estado e eventos |

## Organização de `Form1.cs`

O arquivo é dividido em blocos, cada um com uma responsabilidade, e nenhuma
função acumula mais de um assunto:

**Primitivas** — as funções de desenho usadas nos exercícios da disciplina, que o
enunciado exige que sejam reaproveitadas: `cores`, `caneta` (três sobrecargas),
`pintaPonto`, `pintaLinha`, `pintaRetangulo`, `desenhaPoligono`,
`PreenchePoligono` (três sobrecargas), `preen_Area` (três sobrecargas) e
`poligono`. Todo desenho da figura passa por elas — nenhuma chamada direta a
`Graphics` acontece fora desse bloco. Várias primitivas não são chamadas por
nenhuma tela; são mantidas de propósito, como biblioteca da disciplina.

**Estrutura do icosaedro** — `baseX`, `baseY`, `faceA`, `faceB`, `faceC`,
`corFaceR`, `corFaceG`, `corFaceB`, `BASE_SCALE` e `iniciaCoresDasFaces`.
Descrito em [geometria-icosaedro.md](geometria-icosaedro.md).

**Estado da seleção e das cores** — `botoesFace`, `faceSelecionada`,
`ancoraSelecao`, `corEscolhidaR`, `corEscolhidaG`, `corEscolhidaB`,
`temCorEscolhida` e `quantidadeCoresEscolhidas`, mais `montaBotoesFace`, que
junta os dez botões num vetor para que `atualizaBotoesFace` os percorra com um
`for`. Duas funções auxiliares substituem o que uma lista daria de graça:

- `quantidadeSelecionada()` — conta quantas posições de `faceSelecionada` estão
  em `true`.
- `faceDaPosicao(posicao)` — devolve o índice da n-ésima face selecionada,
  contando em ordem crescente; devolve `-1` se não existir. É o que garante que
  as cores sejam distribuídas do menor número para o maior.

**Transformação** — `TransformVertices`, único ponto que converte coordenadas
normalizadas em pixels. Monta um `int[] x` e um `int[] y` e devolve o resultado
por meio da primitiva `poligono`.

**Desenho** — `pontosDaFace` monta o triângulo de uma face, `desenhaFaces` pinta
e contorna todas, `desenhaSelecao` redesenha por cima o contorno das
selecionadas, `drawPanel_Paint` orquestra os dois e `drawPanel_Resize` força a
repintura ao redimensionar.

**Seleção** — `desmarcaTodas` zera o vetor; `selecionaSimples`,
`selecionaComControl` e `selecionaComShift` tratam um modo de seleção cada;
`selecionaFace` lê o modificador e delega; `atualizaBotoesFace` cuida só da
aparência dos botões. Cada botão tem seu próprio manipulador
(`btnFace1_Click` a `btnFace10_Click`), e cada um informa o próprio número —
por isso não é preciso converter o `sender` nem procurar o botão num vetor.

**Paleta** — `clareiaCor(r, g, b)` e `acinzentaCor(r, g, b)` derivam as variações
usadas no fundo dos botões e no destaque das faces; `escolheCor(r, g, b)` valida
a seleção e guarda as três componentes. Cada amostra tem seu próprio manipulador
(`panelRed_Click` a `panelGray_Click`) que chama `escolheCor` com os seus três
números.

**Aplicação** — `limpaCoresEscolhidas`, `limpaSelecao` e `btnAplicarCores_Click`.

**TrackBars** — `atualizaRotulos` para o estado inicial e um `ValueChanged` para
cada controle.

## Convenções

- Métodos próprios em português; nomes de controles em inglês, seguindo o padrão
  já existente no projeto.
- Cores nunca são construídas com `Color.FromArgb` direto no código de negócio:
  passam sempre pela primitiva `cores(r, g, b)`. `cores` é o único lugar do
  projeto que chama `FromArgb`.
- Cor guardada é sempre três `int` soltos, nunca um objeto `Color`. Nenhum ponto
  do projeto lê `cor.R`, `cor.G` ou `cor.B` de volta: o `Color` só é montado no
  instante de desenhar ou de pintar um botão, e é descartado em seguida.
- Cada evento faz o mínimo e chama funções nomeadas — a lógica não mora dentro
  dos manipuladores.
- Um controle, um manipulador. Nenhum manipulador descobre quem o chamou.
- Toda travessia de vetor é um `for` com índice.

## Como compilar e testar

O `MSBuild` desta máquina trava sem produzir saída (problema de ambiente, não do
projeto). A compilação pode ser verificada chamando o compilador direto, de
dentro da pasta `Projeto Isocaedro`:

```bash
C:/Windows/Microsoft.NET/Framework64/v4.0.30319/csc.exe -target:winexe -out:check.exe Form1.cs Form1.Designer.cs Program.cs Properties/AssemblyInfo.cs Properties/Resources.Designer.cs Properties/Settings.Designer.cs
```

Esse `csc` já referencia `System`, `System.Drawing` e `System.Windows.Forms`
sozinho. O compilador do Visual Studio serve igual, mas exige os `-r:` na mão.
O projeto compila com zero erros e zero avisos em `-warn:4`.

Não há projeto de testes no repositório. A lógica de seleção, distribuição de
cores, transformação e geometria é verificada por um arranjo temporário que
carrega o executável compilado e chama os métodos por reflexão — 67 verificações
na última passagem, todas passando. Esse caminho é o certo aqui porque evita
depender de cliques automatizados na tela: a janela perde o foco com facilidade
e os cliques acabam caindo em outros programas.

O desenho é conferido do mesmo jeito, sem abrir janela: cria-se um `Bitmap`, um
`Graphics` sobre ele e um `PaintEventArgs`, chama-se `drawPanel_Paint` por
reflexão e salva-se o resultado em PNG.
