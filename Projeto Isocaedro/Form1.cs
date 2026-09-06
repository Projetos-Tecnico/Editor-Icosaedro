using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Isocaedro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            montaBotoesFace();
            atualizaBotoesFace();
            atualizaRotulos();
        }

        // ------------------------------------------------------------------
        // Primitivas
        // ------------------------------------------------------------------

        public Color cores(int r, int g, int b)
        {
            Color cor = new Color();
            cor = Color.FromArgb(r, g, b);
            return cor;
        }

        public Pen caneta(int r, int g, int b)
        {
            Pen caneta = new Pen(cores(r, g, b));
            return caneta;
        }

        public Pen caneta(int r, int g, int b, int esp)
        {
            Pen caneta = new Pen(cores(r, g, b), esp);
            return caneta;
        }

        public Pen caneta(int r, int g, int b, int esp, float[] v)
        {
            Pen caneta = new Pen(cores(r, g, b), esp);
            caneta.DashPattern = v;
            return caneta;
        }

        public void pintaPonto(PaintEventArgs e, Pen caneta, int x, int y)
        {
            e.Graphics.DrawLine(caneta, x, y, x + 1, y);
        }

        public void pintaLinha(PaintEventArgs e, Pen caneta, int x, int y, int x1, int y1)
        {
            e.Graphics.DrawLine(caneta, x, y, x1, y1);
        }

        public void pintaRetangulo(PaintEventArgs e, Pen caneta, int x, int y, int x1, int y1)
        {
            e.Graphics.DrawRectangle(caneta, x, y, x1, y1);
        }

        public void desenhaPoligono(PaintEventArgs e, Pen caneta, Point[] pontos)
        {
            e.Graphics.DrawPolygon(caneta, pontos);
        }

        public void PreenchePoligono(PaintEventArgs e, SolidBrush fundo, Point[] pontos)
        {
            e.Graphics.FillPolygon(fundo, pontos);
        }

        public void PreenchePoligono(PaintEventArgs e, HatchBrush fundo, Point[] pontos)
        {
            e.Graphics.FillPolygon(fundo, pontos);
        }

        public void PreenchePoligono(PaintEventArgs e, TextureBrush fundo, Point[] pontos)
        {
            e.Graphics.FillPolygon(fundo, pontos);
        }

        public SolidBrush preen_Area(Color cor)
        {
            SolidBrush pincel = new SolidBrush(cor);
            return pincel;
        }

        public HatchBrush preen_Area(HatchStyle hachura, Color corL, Color corF)
        {
            HatchBrush pincel = new HatchBrush(hachura, corL, corF);
            return pincel;
        }

        public TextureBrush preen_Area(string imagem)
        {
            Bitmap bmp = new Bitmap(imagem);
            TextureBrush pincel = new TextureBrush(bmp);
            return pincel;
        }

        public Point[] poligono(int[] x, int[] y)
        {
            int tamanho_x_y = x.Length;
            Point[] pontos = new Point[tamanho_x_y];

            for (int i = 0; i < tamanho_x_y; i++)
            {
                Point point1 = new Point(x[i], y[i]);
                pontos[i] = point1;
            }

            return pontos;
        }

        // ------------------------------------------------------------------
        // Estrutura do icosaedro
        // ------------------------------------------------------------------

        private static readonly PointF[] BaseVertices = new PointF[]
        {
            new PointF( 0.0f,     0.57735f),
            new PointF(-0.5f,    -0.28868f),
            new PointF( 0.5f,    -0.28868f),
            new PointF( 0.0f,     1.15470f),
            new PointF( 1.0f,     0.57735f),
            new PointF( 1.0f,    -0.57735f),
            new PointF( 0.0f,    -1.15470f),
            new PointF(-1.0f,    -0.57735f),
            new PointF(-1.0f,     0.57735f),
        };

        private Face[] faces = new Face[]
        {
            new Face(0, 1, 2),
            new Face(0, 8, 1),
            new Face(0, 2, 4),
            new Face(1, 6, 2),
            new Face(0, 3, 8),
            new Face(0, 4, 3),
            new Face(2, 5, 4),
            new Face(1, 7, 6),
            new Face(2, 6, 5),
            new Face(1, 8, 7),
        };

        private const float BASE_SCALE = 280f;

        // ------------------------------------------------------------------
        // Estado da seleção e das cores
        // ------------------------------------------------------------------

        private Button[] botoesFace;
        private List<int> facesSelecionadas = new List<int>();
        private int ancoraSelecao = -1;
        private Color[] coresEscolhidas = new Color[10];
        private bool[] temCorEscolhida = new bool[10];
        private int quantidadeCoresEscolhidas = 0;

        private void montaBotoesFace()
        {
            botoesFace = new Button[]
            {
                btnFace1, btnFace2, btnFace3, btnFace4, btnFace5,
                btnFace6, btnFace7, btnFace8, btnFace9, btnFace10
            };
        }

        // ------------------------------------------------------------------
        // Transformação (translação e escala)
        // ------------------------------------------------------------------

        private Point[] TransformVertices()
        {
            float escala = BASE_SCALE * (tbScale.Value / 100f);
            int deslocaX = tbTransX.Value;
            int deslocaY = tbTransY.Value;

            float cx = drawPanel.Width / 2f + deslocaX;
            float cy = drawPanel.Height / 2f + deslocaY;

            Point[] result = new Point[BaseVertices.Length];

            for (int i = 0; i < BaseVertices.Length; i++)
            {
                float x0 = BaseVertices[i].X;
                float y0 = BaseVertices[i].Y;

                int x = (int)(cx + x0 * escala);
                int y = (int)(cy - y0 * escala);

                result[i] = new Point(x, y);
            }

            return result;
        }

        // ------------------------------------------------------------------
        // Desenho
        // ------------------------------------------------------------------

        private Point[] pontosDaFace(Point[] pts, Face f)
        {
            int[] vx = new int[] { pts[f.VertexIndices[0]].X, pts[f.VertexIndices[1]].X, pts[f.VertexIndices[2]].X };
            int[] vy = new int[] { pts[f.VertexIndices[0]].Y, pts[f.VertexIndices[1]].Y, pts[f.VertexIndices[2]].Y };
            return poligono(vx, vy);
        }

        private void desenhaFaces(PaintEventArgs e, Point[] pts)
        {
            Pen canetaBorda = caneta(0, 0, 0);

            for (int i = 0; i < faces.Length; i++)
            {
                Point[] tri = pontosDaFace(pts, faces[i]);

                Color corFace = faces[i].FillColor;
                if (facesSelecionadas.Contains(i))
                {
                    corFace = acinzentaCor(corFace);
                }

                SolidBrush pincelPreenchimento = preen_Area(corFace);

                PreenchePoligono(e, pincelPreenchimento, tri);
                desenhaPoligono(e, canetaBorda, tri);
            }
        }

        private void desenhaSelecao(PaintEventArgs e, Point[] pts)
        {
            Pen canetaSelecao = caneta(105, 105, 105, 4);

            for (int i = 0; i < faces.Length; i++)
            {
                if (facesSelecionadas.Contains(i))
                {
                    Point[] tri = pontosDaFace(pts, faces[i]);
                    desenhaPoligono(e, canetaSelecao, tri);
                }
            }
        }

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Point[] pts = TransformVertices();

            desenhaFaces(e, pts);
            desenhaSelecao(e, pts);
        }

        private void drawPanel_Resize(object sender, EventArgs e)
        {
            drawPanel.Invalidate();
        }

        // ------------------------------------------------------------------
        // Seleção dos números das faces
        // ------------------------------------------------------------------

        private void selecionaSimples(int indice)
        {
            facesSelecionadas.Clear();
            facesSelecionadas.Add(indice);
            ancoraSelecao = indice;
        }

        private void selecionaComControl(int indice)
        {
            if (facesSelecionadas.Contains(indice))
            {
                facesSelecionadas.Remove(indice);
            }
            else
            {
                facesSelecionadas.Add(indice);
                facesSelecionadas.Sort();
            }

            ancoraSelecao = indice;
        }

        private void selecionaComShift(int indice)
        {
            if (ancoraSelecao < 0)
            {
                ancoraSelecao = indice;
            }

            int inicio = ancoraSelecao;
            int fim = indice;

            if (inicio > fim)
            {
                inicio = indice;
                fim = ancoraSelecao;
            }

            facesSelecionadas.Clear();

            for (int i = inicio; i <= fim; i++)
            {
                facesSelecionadas.Add(i);
            }
        }

        private void btnFace_Click(object sender, EventArgs e)
        {
            Button botao = sender as Button;
            if (botao == null)
            {
                return;
            }

            int indice = Array.IndexOf(botoesFace, botao);
            if (indice < 0)
            {
                return;
            }

            if (Control.ModifierKeys == Keys.Control)
            {
                selecionaComControl(indice);
            }
            else if (Control.ModifierKeys == Keys.Shift)
            {
                selecionaComShift(indice);
            }
            else
            {
                selecionaSimples(indice);
            }

            limpaCoresEscolhidas();
            atualizaBotoesFace();
            drawPanel.Invalidate();
        }

        private void atualizaBotoesFace()
        {
            for (int i = 0; i < botoesFace.Length; i++)
            {
                Button botao = botoesFace[i];

                if (temCorEscolhida[i])
                {
                    botao.BackColor = clareiaCor(coresEscolhidas[i]);
                    botao.ForeColor = cores(0, 0, 0);
                    botao.FlatAppearance.BorderColor = coresEscolhidas[i];
                    botao.FlatAppearance.BorderSize = 3;
                }
                else if (facesSelecionadas.Contains(i))
                {
                    botao.BackColor = SystemColors.Highlight;
                    botao.ForeColor = SystemColors.HighlightText;
                    botao.FlatAppearance.BorderColor = cores(0, 0, 0);
                    botao.FlatAppearance.BorderSize = 3;
                }
                else
                {
                    botao.BackColor = SystemColors.Control;
                    botao.ForeColor = cores(0, 0, 0);
                    botao.FlatAppearance.BorderColor = cores(0, 0, 0);
                    botao.FlatAppearance.BorderSize = 2;
                }
            }
        }

        // ------------------------------------------------------------------
        // Paleta de cores
        // ------------------------------------------------------------------

        private Color corDaPaleta(Panel amostra)
        {
            Color cor;

            switch (amostra.Name)
            {
                case "panelRed":
                    cor = cores(255, 0, 0);
                    break;
                case "panelGreen":
                    cor = cores(0, 255, 0);
                    break;
                case "panelBlue":
                    cor = cores(0, 0, 255);
                    break;
                case "panelYellow":
                    cor = cores(255, 255, 0);
                    break;
                case "panelCyan":
                    cor = cores(0, 255, 255);
                    break;
                case "panelMagenta":
                    cor = cores(255, 0, 255);
                    break;
                case "panelOrange":
                    cor = cores(255, 165, 0);
                    break;
                case "panelPurple":
                    cor = cores(128, 0, 128);
                    break;
                case "panelBlack":
                    cor = cores(0, 0, 0);
                    break;
                case "panelGray":
                    cor = cores(128, 128, 128);
                    break;
                default:
                    cor = cores(amostra.BackColor.R, amostra.BackColor.G, amostra.BackColor.B);
                    break;
            }

            return cor;
        }

        public Color clareiaCor(Color cor)
        {
            int r = (cor.R + 255 * 4) / 5;
            int g = (cor.G + 255 * 4) / 5;
            int b = (cor.B + 255 * 4) / 5;
            return cores(r, g, b);
        }

        public Color acinzentaCor(Color cor)
        {
            int r = (cor.R * 85 + 128 * 15) / 100;
            int g = (cor.G * 85 + 128 * 15) / 100;
            int b = (cor.B * 85 + 128 * 15) / 100;
            return cores(r, g, b);
        }

        private void panelCor_Click(object sender, EventArgs e)
        {
            Panel amostra = sender as Panel;
            if (amostra == null)
            {
                return;
            }

            if (facesSelecionadas.Count == 0)
            {
                MessageBox.Show("Nenhum número selecionado.\nSelecione um número antes de selecionar uma cor!",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (quantidadeCoresEscolhidas >= facesSelecionadas.Count)
            {
                MessageBox.Show("Todos os números selecionados já receberam uma cor.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int indice = facesSelecionadas[quantidadeCoresEscolhidas];
            coresEscolhidas[indice] = corDaPaleta(amostra);
            temCorEscolhida[indice] = true;
            quantidadeCoresEscolhidas++;

            atualizaBotoesFace();
        }

        // ------------------------------------------------------------------
        // Aplicação das cores
        // ------------------------------------------------------------------

        private void limpaCoresEscolhidas()
        {
            for (int i = 0; i < temCorEscolhida.Length; i++)
            {
                temCorEscolhida[i] = false;
            }

            quantidadeCoresEscolhidas = 0;
        }

        private void limpaSelecao()
        {
            facesSelecionadas.Clear();
            ancoraSelecao = -1;
        }

        private void btnAplicarCores_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < faces.Length; i++)
            {
                if (temCorEscolhida[i])
                {
                    faces[i].FillColor = coresEscolhidas[i];
                }
            }

            limpaCoresEscolhidas();
            limpaSelecao();
            atualizaBotoesFace();
            drawPanel.Invalidate();
        }

        // ------------------------------------------------------------------
        // TrackBars
        // ------------------------------------------------------------------

        private void atualizaRotulos()
        {
            lblTransX.Text = "Translação X: " + tbTransX.Value;
            lblTransY.Text = "Translação Y: " + tbTransY.Value;
            lblScale.Text = "Escala: " + tbScale.Value + "%";
        }

        private void tbTransX_ValueChanged(object sender, EventArgs e)
        {
            lblTransX.Text = "Translação X: " + tbTransX.Value;
            drawPanel.Invalidate();
        }

        private void tbTransY_ValueChanged(object sender, EventArgs e)
        {
            lblTransY.Text = "Translação Y: " + tbTransY.Value;
            drawPanel.Invalidate();
        }

        private void tbScale_ValueChanged(object sender, EventArgs e)
        {
            lblScale.Text = "Escala: " + tbScale.Value + "%";
            drawPanel.Invalidate();
        }
    }

    public class Face
    {
        public int[] VertexIndices;
        public Color FillColor;

        public Face(int a, int b, int c)
        {
            VertexIndices = new int[] { a, b, c };
            FillColor = Color.WhiteSmoke;
        }
    }
}
