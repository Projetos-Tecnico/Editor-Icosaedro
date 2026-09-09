# Restrição: só o que o professor ensinou

Esta é a regra mais importante do projeto e vale acima de qualquer preferência
técnica.

O trabalho é da disciplina **Introdução à Computação Gráfica (ICG)**, Colégio
Técnico Antônio Teixeira Fernandes / UNIVAP, com o **Prof. Wagner Santos C. de
Jesus**. O professor cobra que o código use **exclusivamente** os recursos
apresentados nas apostilas dele. Recurso de C# ou do .NET que não aparece no
material custa nota, mesmo estando correto e mesmo sendo mais simples.

Antes de introduzir qualquer construção nova no projeto, confirme que ela está
na lista abaixo. Se não estiver, **pergunte ao autor do trabalho** em vez de
decidir sozinho.

## O que o material cobre

### Desenho (`System.Drawing`, GDI+)

| Recurso | Forma ensinada |
| --- | --- |
| Cor | `Color cor = new Color(); cor = Color.FromArgb(r, g, b);` |
| Caneta | `Pen caneta = new Pen(cor, espessura);` |
| Tracejado | `float[] flinha = {5,2,15,4}; caneta.DashPattern = flinha;` |
| Ponto | `e.Graphics.DrawLine(pen, x, y, x+1, y);` |
| Reta | `e.Graphics.DrawLine(pen, x0, y0, x1, y1);` |
| Retângulo | `e.Graphics.DrawRectangle(pen, x, y, largura, altura);` |
| Elipse | `e.Graphics.DrawEllipse(pen, Xc, Yc, Lx, Ay);` |
| Polígono | `e.Graphics.DrawPolygon(caneta, pontos);` / `FillPolygon(fundo, pontos)` |
| Preenchimento sólido | `SolidBrush fundo = new SolidBrush(cor);` |
| Hachura | `HatchBrush p = new HatchBrush(HatchStyle.X, corL, corF);` |
| Textura | `Bitmap bmp = new Bitmap(caminho); TextureBrush t = new TextureBrush(bmp);` |
| Texto | `DrawString(texto, font, brush, x, y)` com `new Font("Arial", 16, FontStyle.Bold)` |
| Repintura | `Invalidate()` |
| Pacote extra | `using System.Drawing.Drawing2D;` (exigido pelo `HatchBrush`) |

### Eventos

- `private void Form1_Paint(object sender, PaintEventArgs e)`
- `private void Form1_MouseClick(object sender, MouseEventArgs e)` com `e.X` e `e.Y`
- `MessageBox.Show(...)`

### Estruturas de dados

Apenas **vetores** (arrays): `int[]`, `float[]`, `Point[]`. O padrão de polígono
do professor é a base de tudo:

```csharp
int[] x = { 100, 200, 200, 100 };
int[] y = { 100, 100, 300, 300 };
Point[] pontos = new Point[4];
for (int i = 0; i <= 3; i++)
{
    Point point1 = new Point(x[i], y[i]);
    pontos[i] = point1;
}
```

### Matemática

- Retas: `y = mx + b`, algoritmos DDA e Bresenham (em C# usa-se `DrawLine`).
- Círculos e elipses por coordenadas polares: `x = Xc + r·cos(θ)`, `y = Yc + r·sen(θ)`,
  com `Math.Sin` e `Math.Cos` e a conversão de graus para radianos.
- Transformações 2D:
  - translação `x' = x + tx`, `y' = y + ty`
  - rotação `x' = x·cos(θ) − y·sen(θ)`, `y' = x·sen(θ) + y·cos(θ)`
  - escala `x' = x·Sx`, `y' = y·Sy`

## O que NÃO usar

Cada item abaixo já apareceu neste projeto e foi removido justamente por não
estar no material:

| Proibido | Usar no lugar |
| --- | --- |
| `List<T>` e `.Add()`, `.Remove()`, `.Contains()`, `.Sort()`, `.Count` | vetor (`bool[]`, `int[]`) percorrido com `for` |
| `using System.Collections.Generic` | — |
| LINQ, `using System.Linq`, expressões lambda | `for` |
| `foreach` | `for` com índice |
| `PointF` | `Point`, ou `float[] x` e `float[] y` separados |
| `Array.IndexOf` e afins | `for` que compara os elementos |
| `SystemColors.*` | `Color.FromArgb`, pela primitiva `cores(r, g, b)` |
| Cores nomeadas (`Color.WhiteSmoke`) | `cores(245, 245, 245)` |
| `SmoothingMode` / antisserrilhamento | nada — desenho direto |
| Classe própria (`class Face { ... }`) | vetores paralelos |
| Ler `cor.R`, `cor.G`, `cor.B` de um `Color` | guardar as componentes em `int[]` e montar a cor com `cores(r, g, b)` |
| Guardar cor em `Color[]` | três `int[]` paralelos, um por componente |
| `sender as Button` / `as Panel` | um manipulador por controle, cada um informando o próprio número |
| `switch` sobre string | um manipulador por controle |
| `const`, `static readonly` | campo simples |

## Itens fora do material mantidos por decisão do autor

Estes quatro pontos também não aparecem em slide nenhum, foram levantados e o
autor do trabalho decidiu mantê-los. Estão listados aqui para que ninguém os
"corrija" por engano numa próxima passagem, e para que o risco fique registrado.

| Item | Onde | Por que foi mantido |
| --- | --- | --- |
| `Control.ModifierKeys`, `Keys.Control`, `Keys.Shift` | `selecionaFace` | é o que permite o Ctrl+clique e o Shift+clique. Sem isso a seleção múltipla exigiria um clique por número |
| `Paint` de um `Panel` (`drawPanel_Paint`) em vez de `Form1_Paint` | desenho | é o mesmo evento `Paint` com o mesmo `PaintEventArgs e`; usar o painel é o que separa a área de desenho da coluna de controles |
| `MessageBox.Show` com quatro argumentos | `escolheCor` | o material mostra só `MessageBox.Show("ok")`; a versão com título e ícone é a mesma chamada com mais parâmetros |
| `vetor.Length` | todos os `for` | o professor escreve o limite literal (`i <= 3`); `.Length` é a mesma contagem sem repetir o número em dois lugares |

Os controles de tela (`Button`, `Panel`, `Label`, `TrackBar`) e suas propriedades
(`BackColor`, `ForeColor`, `FlatAppearance`) também não aparecem no material,
que só desenha. Eles são a interface exigida pelo enunciado e ficam como estão.

## Exceção conhecida

`Form1.Designer.cs` é gerado pelo Visual Studio. Ele contém `Controls.Add(...)`
e cores nomeadas (`System.Drawing.Color.Red` no fundo das amostras da paleta)
porque foram definidas na janela de propriedades do designer. Esse arquivo não é
código escrito à mão e editá-lo manualmente quebra o designer visual — fica como
está.

## Rotação

O material ensina as três transformações, mas o enunciado deste trabalho pede
apenas **translação e escala**. A rotação foi deliberadamente deixada de fora.
Se o enunciado mudar, a fórmula está na tabela acima.
