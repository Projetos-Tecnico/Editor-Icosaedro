# Geometria do icosaedro 2D

## Vértices

A projeção 2D do icosaedro é construída a partir de nove vértices em coordenadas
normalizadas, com origem no centro da figura e eixo Y apontando para cima. Eles
ficam em **dois vetores paralelos** (`Form1.cs`), no mesmo formato `int[] x` /
`int[] y` que o professor usa para montar polígonos, só que em `float` para não
perder as frações:

```csharp
private float[] baseX = new float[] { ... };
private float[] baseY = new float[] { ... };
```

| Índice | `baseX` | `baseY` | Posição na figura |
| --- | --- | --- | --- |
| 0 | `0.0` | `0.57735` | topo do triângulo central |
| 1 | `-0.5` | `-0.28868` | canto inferior esquerdo do triângulo central |
| 2 | `0.5` | `-0.28868` | canto inferior direito do triângulo central |
| 3 | `0.0` | `1.15470` | vértice superior do hexágono |
| 4 | `1.0` | `0.57735` | vértice direito superior do hexágono |
| 5 | `1.0` | `-0.57735` | vértice direito inferior do hexágono |
| 6 | `0.0` | `-1.15470` | vértice inferior do hexágono |
| 7 | `-1.0` | `-0.57735` | vértice esquerdo inferior do hexágono |
| 8 | `-1.0` | `0.57735` | vértice esquerdo superior do hexágono |

Os números são frações de √3 (`0.57735 ≈ 1/√3`, `0.28868 ≈ 1/(2√3)`,
`1.15470 ≈ 2/√3`), que posicionam tudo sobre uma malha de triângulos equiláteros
de lado 1. Os seis vértices externos (3 a 8) formam o hexágono regular; os três
internos (0, 1, 2) formam o triângulo central invertido. Essa combinação
reproduz as dez faces triangulares visíveis na projeção pedida no enunciado.

## Faces

Cada face é um triângulo definido por três índices de vértice. Os três índices
ficam na **mesma posição** de três vetores paralelos:

```csharp
private int[] faceA = new int[] { 0, 0, 0, 1, 0, 0, 2, 1, 2, 1 };
private int[] faceB = new int[] { 1, 8, 2, 6, 3, 4, 5, 7, 6, 8 };
private int[] faceC = new int[] { 2, 1, 4, 2, 8, 3, 4, 6, 5, 7 };
```

A cor de preenchimento atual de cada face fica em mais três vetores paralelos de
inteiros — `corFaceR`, `corFaceG` e `corFaceB` —, um por componente, todos
inicializados com 245 por `iniciaCoresDasFaces()`. O objeto `Color` só é montado
na hora de desenhar, pela primitiva `cores(r, g, b)`; nada no projeto lê as
componentes de volta a partir de um `Color`.

A posição nos vetores **é** a numeração mostrada ao usuário: a posição 0
corresponde ao número 1, a posição 9 ao número 10.

| Número | Vértices | Região |
| --- | --- | --- |
| 1 | 0, 1, 2 | triângulo central |
| 2 | 0, 8, 1 | esquerda, altura do meio |
| 3 | 0, 2, 4 | direita, altura do meio |
| 4 | 1, 6, 2 | abaixo do triângulo central |
| 5 | 0, 3, 8 | topo esquerdo |
| 6 | 0, 4, 3 | topo direito |
| 7 | 2, 5, 4 | extremidade direita |
| 8 | 1, 7, 6 | inferior esquerda |
| 9 | 2, 6, 5 | inferior direita |
| 10 | 1, 8, 7 | extremidade esquerda |

Essa numeração é interna: o programa **não** desenha os números sobre as faces.
O usuário identifica qual face é qual selecionando o número no painel lateral e
observando o contorno de destaque que aparece na figura.

Os dez triângulos usam os nove vértices, nenhuma face repete um vértice e todos
os índices ficam na faixa 0–8 — condições verificadas em teste.

## Transformação

`TransformVertices()` converte as coordenadas normalizadas em pixels do painel de
desenho, aplicando escala e translação, e devolve o resultado montando os pontos
com a primitiva `poligono(x, y)`:

```
escala = BASE_SCALE * (tbScale.Value / 100)
cx     = drawPanel.Width  / 2 + tbTransX.Value
cy     = drawPanel.Height / 2 + tbTransY.Value
x[i]   = cx + baseX[i] * escala
y[i]   = cy - baseY[i] * escala
```

`BASE_SCALE` vale 280. O sinal negativo em Y inverte o eixo, porque na tela o Y
cresce para baixo. Como a escala multiplica as coordenadas **antes** da soma do
centro, o redimensionamento é uniforme e acontece em relação ao centro da figura,
como o enunciado exige.

O centro é recalculado a cada repintura a partir do tamanho atual de `drawPanel`,
então a figura permanece centralizada quando a janela é maximizada ou
redimensionada — `drawPanel_Resize` força a repintura nesse caso.

Não há rotação: o enunciado pede apenas translação e escala. Ver
[restricoes-do-material.md](restricoes-do-material.md).
