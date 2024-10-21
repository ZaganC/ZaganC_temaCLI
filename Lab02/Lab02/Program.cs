using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace OpenTK_console_sample01
{
    class SimpleWindow : GameWindow
    {
        private float objectPosX = 0.0f;
        private float objectPosY = 0.0f; 


        public SimpleWindow() : base(800, 600)
        {
            KeyDown += Keyboard_KeyDown;
            MouseMove += Mouse_Move;
        }


        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Exit();

            if (e.Key == Key.F11)
            {
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;
            }


            if (e.Key == Key.A)
                objectPosX -= 0.05f;


            if (e.Key == Key.D)
                objectPosX += 0.05f;
        }


        void Mouse_Move(object sender, MouseMoveEventArgs e)
        {

            objectPosY = (e.Y - Height / 2f) / (Height / 2f);
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.MidnightBlue);
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

            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(objectPosX - 1.0f, objectPosY + 1.0f); 
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(objectPosX, objectPosY - 1.0f);
            GL.Color3(Color.Ivory);
            GL.Vertex2(objectPosX + 1.0f, objectPosY + 1.0f);

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
