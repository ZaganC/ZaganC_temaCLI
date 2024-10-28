using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.IO;

namespace OpenTK_console_sample01
{
    class SimpleWindow : GameWindow
    {
        private Vector2[] triangleVertices = new Vector2[3];
        private Color color = Color.FromArgb(255, 0, 0, 255);


        public SimpleWindow() : base(800, 600) 
        {
            KeyDown += Keyboard_KeyDown;
            LoadTriangleCoordinates("coordonate.txt");

            triangleVertices[0] = new Vector2(-0.5f, 0.5f);
            triangleVertices[1] = new Vector2(0.0f, -0.5f);
            triangleVertices[2] = new Vector2(0.5f, 0.5f);
        }


        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Exit();

            if (e.Key == Key.R)
                color = Color.FromArgb(color.A, (color.R + 20) % 256, color.G, color.B);
            if (e.Key == Key.G)
                color = Color.FromArgb(color.A, color.R, (color.G + 20) % 256, color.B);
            if (e.Key == Key.B)
                color = Color.FromArgb(color.A, color.R, color.G, (color.B + 20) % 256);


        }

        void LoadTriangleCoordinates(string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                for (int i = 0; i < 3; i++)
                {
                    var coords = lines[i].Split(',');
                    float x = float.Parse(coords[0]);
                    float y = float.Parse(coords[1]);
                    triangleVertices[i] = new Vector2(x, y);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading triangle coordinates: " + ex.Message);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.Black);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color4(color);

            foreach (var vertex in triangleVertices)
            {
                GL.Vertex2(vertex);
            }

            GL.End();

            this.SwapBuffers();
        }

        [STAThread]
        static void Main(string[] args)
        {
            using (SimpleWindow example = new SimpleWindow())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}
