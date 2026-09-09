/*Colegio Técnico Antônio Teixeira Fernandes (Univap)
 * Curso Técnico em Informática - Data de Entrega: 09/09/2026
 * Autores do Projeto: Mateus Todeschini & Heitor Pinheiro de Souza
 *
 * Turma: 3I
 * Atividade Proposta em aula
 * Observação: <colocar se houver>
 * 
 * 
 * ******************************************************************/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Projeto_Isocaedro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            montaBotoesFace();
            iniciaCoresDasFaces();
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

        private float[] baseX = new float[]
        {
             0.0f, -0.5f,  0.5f,  0.0f,  1.0f,  1.0f,  0.0f, -1.0f, -1.0f
        };

        private float[] baseY = new float[]
        {
             0.57735f, -0.28868f, -0.28868f,  1.15470f,  0.57735f,
            -0.57735f, -1.15470f, -0.57735f,  0.57735f
        };

        private int[] faceA = new int[] { 0, 0, 0, 1, 0, 0, 2, 1, 2, 1 };
        private int[] faceB = new int[] { 1, 8, 2, 6, 3, 4, 5, 7, 6, 8 };
        private int[] faceC = new int[] { 2, 1, 4, 2, 8, 3, 4, 6, 5, 7 };

        private int[] corFaceR = new int[10];
        private int[] corFaceG = new int[10];
        private int[] corFaceB = new int[10];

        private float BASE_SCALE = 280f;

        private void iniciaCoresDasFaces()
        {
            for (int i = 0; i < corFaceR.Length; i++)
            {
                corFaceR[i] = 245;
                corFaceG[i] = 245;
                corFaceB[i] = 245;
            }
        }

        // ------------------------------------------------------------------
        // Estado da selecao e das cores
        // ------------------------------------------------------------------

        private Button[] botoesFace;
        private bool[] faceSelecionada = new bool[10];
        private int ancoraSelecao = -1;
        private int[] corEscolhidaR = new int[10];
        private int[] corEscolhidaG = new int[10];
        private int[] corEscolhidaB = new int[10];
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

        private int quantidadeSelecionada()
        {
            int quantidade = 0;

            for (int i = 0; i < faceSelecionada.Length; i++)
            {
                if (faceSelecionada[i])
                {
                    quantidade++;
                }
            }

            return quantidade;
        }

        private int faceDaPosicao(int posicao)
        {
            int contador = 0;

            for (int i = 0; i < faceSelecionada.Length; i++)
            {
                if (faceSelecionada[i])
                {
                    if (contador == posicao)
                    {
                        return i;
                    }

                    contador++;
                }
            }

            return -1;
        }

        // ------------------------------------------------------------------
        // Transformacao (translacao e escala)
        // ------------------------------------------------------------------

        private Point[] TransformVertices()
        {
            float escala = BASE_SCALE * (tbScale.Value / 100f);
            int deslocaX = tbTransX.Value;
            int deslocaY = tbTransY.Value;

            float cx = drawPanel.Width / 2f + deslocaX;
            float cy = drawPanel.Height / 2f + deslocaY;

            int[] x = new int[baseX.Length];
            int[] y = new int[baseY.Length];

            for (int i = 0; i < baseX.Length; i++)
            {
                x[i] = (int)(cx + baseX[i] * escala);
                y[i] = (int)(cy - baseY[i] * escala);
            }

            return poligono(x, y);
        }

        // ------------------------------------------------------------------
        // Desenho
        // ------------------------------------------------------------------

        private Point[] pontosDaFace(Point[] pts, int face)
        {
            int[] vx = new int[] { pts[faceA[face]].X, pts[faceB[face]].X, pts[faceC[face]].X };
            int[] vy = new int[] { pts[faceA[face]].Y, pts[faceB[face]].Y, pts[faceC[face]].Y };
            return poligono(vx, vy);
        }

        private void desenhaFaces(PaintEventArgs e, Point[] pts)
        {
            Pen canetaBorda = caneta(0, 0, 0);

            for (int i = 0; i < faceA.Length; i++)
            {
                Point[] tri = pontosDaFace(pts, i);

                Color corFace = cores(corFaceR[i], corFaceG[i], corFaceB[i]);
                if (faceSelecionada[i])
                {
                    corFace = acinzentaCor(corFaceR[i], corFaceG[i], corFaceB[i]);
                }

                SolidBrush pincelPreenchimento = preen_Area(corFace);

                PreenchePoligono(e, pincelPreenchimento, tri);
                desenhaPoligono(e, canetaBorda, tri);
            }
        }

        private void desenhaSelecao(PaintEventArgs e, Point[] pts)
        {
            Pen canetaSelecao = caneta(105, 105, 105, 4);

            for (int i = 0; i < faceA.Length; i++)
            {
                if (faceSelecionada[i])
                {
                    Point[] tri = pontosDaFace(pts, i);
                    desenhaPoligono(e, canetaSelecao, tri);
                }
            }
        }

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            Point[] pts = TransformVertices();

            desenhaFaces(e, pts);
            desenhaSelecao(e, pts);
        }

        private void drawPanel_Resize(object sender, EventArgs e)
        {
            drawPanel.Invalidate();
        }

        // ------------------------------------------------------------------
        // Selecao dos numeros das faces
        // ------------------------------------------------------------------

        private void desmarcaTodas()
        {
            for (int i = 0; i < faceSelecionada.Length; i++)
            {
                faceSelecionada[i] = false;
            }
        }

        private void selecionaSimples(int indice)
        {
            desmarcaTodas();
            faceSelecionada[indice] = true;
            ancoraSelecao = indice;
        }

        private void selecionaComControl(int indice)
        {
            if (faceSelecionada[indice])
            {
                faceSelecionada[indice] = false;
            }
            else
            {
                faceSelecionada[indice] = true;
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

            desmarcaTodas();

            for (int i = inicio; i <= fim; i++)
            {
                faceSelecionada[i] = true;
            }
        }

        private void selecionaFace(int indice)
        {
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

        private void btnFace1_Click(object sender, EventArgs e)
        {
            selecionaFace(0);
        }

        private void btnFace2_Click(object sender, EventArgs e)
        {
            selecionaFace(1);
        }

        private void btnFace3_Click(object sender, EventArgs e)
        {
            selecionaFace(2);
        }

        private void btnFace4_Click(object sender, EventArgs e)
        {
            selecionaFace(3);
        }

        private void btnFace5_Click(object sender, EventArgs e)
        {
            selecionaFace(4);
        }

        private void btnFace6_Click(object sender, EventArgs e)
        {
            selecionaFace(5);
        }

        private void btnFace7_Click(object sender, EventArgs e)
        {
            selecionaFace(6);
        }

        private void btnFace8_Click(object sender, EventArgs e)
        {
            selecionaFace(7);
        }

        private void btnFace9_Click(object sender, EventArgs e)
        {
            selecionaFace(8);
        }

        private void btnFace10_Click(object sender, EventArgs e)
        {
            selecionaFace(9);
        }

        private void atualizaBotoesFace()
        {
            for (int i = 0; i < botoesFace.Length; i++)
            {
                Button botao = botoesFace[i];

                if (temCorEscolhida[i])
                {
                    botao.BackColor = clareiaCor(corEscolhidaR[i], corEscolhidaG[i], corEscolhidaB[i]);
                    botao.ForeColor = cores(0, 0, 0);
                    botao.FlatAppearance.BorderColor = cores(corEscolhidaR[i], corEscolhidaG[i], corEscolhidaB[i]);
                    botao.FlatAppearance.BorderSize = 3;
                }
                else if (faceSelecionada[i])
                {
                    botao.BackColor = cores(0, 120, 215);
                    botao.ForeColor = cores(255, 255, 255);
                    botao.FlatAppearance.BorderColor = cores(0, 0, 0);
                    botao.FlatAppearance.BorderSize = 3;
                }
                else
                {
                    botao.BackColor = cores(240, 240, 240);
                    botao.ForeColor = cores(0, 0, 0);
                    botao.FlatAppearance.BorderColor = cores(0, 0, 0);
                    botao.FlatAppearance.BorderSize = 2;
                }
            }
        }

        // ------------------------------------------------------------------
        // Paleta de cores
        // ------------------------------------------------------------------

        public Color clareiaCor(int r, int g, int b)
        {
            int rc = (r + 255 * 4) / 5;
            int gc = (g + 255 * 4) / 5;
            int bc = (b + 255 * 4) / 5;
            return cores(rc, gc, bc);
        }

        public Color acinzentaCor(int r, int g, int b)
        {
            int rc = (r * 85 + 128 * 15) / 100;
            int gc = (g * 85 + 128 * 15) / 100;
            int bc = (b * 85 + 128 * 15) / 100;
            return cores(rc, gc, bc);
        }

        private void escolheCor(int r, int g, int b)
        {
            if (quantidadeSelecionada() == 0)
            {
                MessageBox.Show("Nenhum número selecionado.\nSelecione um número antes de selecionar uma cor!",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (quantidadeCoresEscolhidas >= quantidadeSelecionada())
            {
                MessageBox.Show("Todos os números selecionados já receberam uma cor.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int indice = faceDaPosicao(quantidadeCoresEscolhidas);
            if (indice < 0)
            {
                return;
            }

            corEscolhidaR[indice] = r;
            corEscolhidaG[indice] = g;
            corEscolhidaB[indice] = b;
            temCorEscolhida[indice] = true;
            quantidadeCoresEscolhidas++;

            atualizaBotoesFace();
        }

        private void panelRed_Click(object sender, EventArgs e)
        {
            escolheCor(255, 0, 0);
        }

        private void panelGreen_Click(object sender, EventArgs e)
        {
            escolheCor(0, 255, 0);
        }

        private void panelBlue_Click(object sender, EventArgs e)
        {
            escolheCor(0, 0, 255);
        }

        private void panelYellow_Click(object sender, EventArgs e)
        {
            escolheCor(255, 255, 0);
        }

        private void panelCyan_Click(object sender, EventArgs e)
        {
            escolheCor(0, 255, 255);
        }

        private void panelMagenta_Click(object sender, EventArgs e)
        {
            escolheCor(255, 0, 255);
        }

        private void panelOrange_Click(object sender, EventArgs e)
        {
            escolheCor(255, 165, 0);
        }

        private void panelPurple_Click(object sender, EventArgs e)
        {
            escolheCor(128, 0, 128);
        }

        private void panelBlack_Click(object sender, EventArgs e)
        {
            escolheCor(0, 0, 0);
        }

        private void panelGray_Click(object sender, EventArgs e)
        {
            escolheCor(128, 128, 128);
        }

        // ------------------------------------------------------------------
        // Aplicacao das cores
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
            desmarcaTodas();
            ancoraSelecao = -1;
        }

        private void btnAplicarCores_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < corFaceR.Length; i++)
            {
                if (temCorEscolhida[i])
                {
                    corFaceR[i] = corEscolhidaR[i];
                    corFaceG[i] = corEscolhidaG[i];
                    corFaceB[i] = corEscolhidaB[i];
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
}
