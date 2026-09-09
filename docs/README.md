# Documentação — Projeto Icosaedro 2D

Projeto do 3º bimestre da disciplina de Introdução à Computação Gráfica: uma
aplicação Windows Forms em C# que desenha a projeção 2D de um icosaedro, permite
pintar cada uma das dez faces visíveis e transformá-la por translação e escala.

| Documento | Assunto |
| --- | --- |
| [restricoes-do-material.md](restricoes-do-material.md) | **leia primeiro** — o que o professor ensinou e o que é proibido usar |
| [arquitetura.md](arquitetura.md) | tecnologia, arquivos e como `Form1.cs` está dividido |
| [geometria-icosaedro.md](geometria-icosaedro.md) | vértices, faces, numeração e a transformação |
| [interface.md](interface.md) | layout, seleção dos números, paleta e trackbars |

## Como executar

Abrir `Editor-Icosaedro.slnx` no Visual Studio e executar, ou compilar pela
linha de comando:

```bash
MSBuild.exe "Projeto Isocaedro/Editor-Icosaedro.csproj" /t:Build /p:Configuration=Debug
```

O executável fica em `Projeto Isocaedro/bin/Debug/Projeto Isocaedro.exe`.

## Requisitos atendidos

1. **Geração do icosaedro 2D** — figura desenhada a partir de vértices, arestas e
   faces definidos programaticamente, usando as primitivas da disciplina.
2. **Mosaico de cores** — paleta de dez cores e seleção das faces por índice
   numérico de 1 a 10.
3. **Controles de transformação** — dois TrackBars de translação (X e Y) e um de
   escala, todos reagindo em `ValueChanged`.
