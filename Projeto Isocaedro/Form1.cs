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
        }
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

        private const float BASE_SCALE = 120f;
        private Color selectedColor = Color.Red;
        
        private Point[] TransformVertices()
        {
            float scale = BASE_SCALE * (tbScale.Value / 100f);
            double angleX = tbX.Value * Math.PI / 180.0;
            double angleY = tbY.Value * Math.PI / 180.0;

            float cx = drawPanel.Width / 2f;
            float cy = drawPanel.Height / 2f;

            Point[] result = new Point[BaseVertices.Length];

            for (int i = 0; i < BaseVertices.Length; i++)
            {
                float x0 = BaseVertices[i].X;
                float y0 = BaseVertices[i].Y;

                double rx = x0 * Math.Cos(angleX) - y0 * Math.Sin(angleX);
                double ry = x0 * Math.Sin(angleX) + y0 * Math.Cos(angleX);

                double projectedX = rx * Math.Cos(angleY);
                double projectedY = ry * Math.Cos(angleY) + rx * Math.Sin(angleY) * 0.3;

                int x = (int)(cx + (float)projectedX * scale);
                int y = (int)(cy - (float)projectedY * scale);

                result[i] = new Point(x, y);
            }

            return result;
        }
        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Point[] pts = TransformVertices();

            // Usa a sua primitiva 'caneta' de borda
            Pen canetaBorda = caneta(0, 0, 0);

            for (int i = 0; i < faces.Length; i++)
            {
                Face f = faces[i];

                int[] vx = new int[] { pts[f.VertexIndices[0]].X, pts[f.VertexIndices[1]].X, pts[f.VertexIndices[2]].X };
                int[] vy = new int[] { pts[f.VertexIndices[0]].Y, pts[f.VertexIndices[1]].Y, pts[f.VertexIndices[2]].Y };
                Point[] tri = poligono(vx, vy);

                SolidBrush pincelPreenchimento = preen_Area(f.FillColor);

                PreenchePoligono(e, pincelPreenchimento, tri);
                desenhaPoligono(e, canetaBorda, tri);

                int centroideX = (tri[0].X + tri[1].X + tri[2].X) / 3;
                int centroideY = (tri[0].Y + tri[1].Y + tri[2].Y) / 3;

                e.Graphics.DrawString((i + 1).ToString(), this.Font, Brushes.Black, centroideX, centroideY);
            }
        }

        private void drawPanel_MouseClick(object sender, MouseEventArgs e)
        {
            Point[] pts = TransformVertices();

            for (int i = 0; i < faces.Length; i++)
            {
                Face f = faces[i];
                Point a = pts[f.VertexIndices[0]];
                Point b = pts[f.VertexIndices[1]];
                Point c = pts[f.VertexIndices[2]];

                if (PointInTriangle(e.Location, a, b, c))
                {
                    f.FillColor = selectedColor;
                    drawPanel.Invalidate();
                    return;
                }
            }
        }

        private void tbX_ValueChanged(object sender, EventArgs e)
        {
            lblX.Text = "Girar Eixo X: " + tbX.Value + "°";
            drawPanel.Invalidate();
        }

        private void tbY_ValueChanged(object sender, EventArgs e)
        {
            lblY.Text = "Girar Eixo Y: " + tbY.Value + "°";
            drawPanel.Invalidate();
        }

        private void tbScale_ValueChanged(object sender, EventArgs e)
        {
            lblScale.Text = "Escala: " + tbScale.Value + "%";
            drawPanel.Invalidate();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Panel swatch = sender as Panel;
            if (swatch != null)
            {
                // Identifica a caixa selecionada pelo Name e define a cor usando a primitiva 'cores'
                switch (swatch.Name)
                {
                    case "panelRed":
                        selectedColor = cores(255, 0, 0);
                        break;
                    case "panelGreen":
                        selectedColor = cores(0, 255, 0);
                        break;
                    case "panelBlue":
                        selectedColor = cores(0, 0, 255);
                        break;
                    case "panelYellow":
                        selectedColor = cores(255, 255, 0);
                        break;
                    case "panelCyan":
                        selectedColor = cores(0, 255, 255);
                        break;
                    case "panelMagenta":
                        selectedColor = cores(255, 0, 255);
                        break;
                    case "panelOrange":
                        selectedColor = cores(255, 165, 0);
                        break;
                    case "panelPurple":
                        selectedColor = cores(128, 0, 128);
                        break;
                    case "panelBlack":
                        selectedColor = cores(0, 0, 0);
                        break;
                    case "panelGray":
                        selectedColor = cores(128, 128, 128);
                        break;
                    default:
                        selectedColor = cores(swatch.BackColor.R, swatch.BackColor.G, swatch.BackColor.B);
                        break;
                }
            }
        }
        private static bool PointInTriangle(PointF p, PointF a, PointF b, PointF c)
        {
            float d1 = Sign(p, a, b);
            float d2 = Sign(p, b, c);
            float d3 = Sign(p, c, a);

            bool temNegativo = (d1 < 0) || (d2 < 0) || (d3 < 0);
            bool temPositivo = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(temNegativo && temPositivo);
        }

        private static float Sign(PointF p1, PointF p2, PointF p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
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
