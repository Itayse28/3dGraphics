using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ManagedCuda;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Text.Json;
using System.Net;

namespace GraphicsTest
{
    internal class Scene
    {
        int TimeLimit = 500;
        public decimal renderDistance = 10;
        public double lightX=0,lightY=0,lightZ=0;//basicly the camera position, the further the face that being drawn from these coords, the more transparent it is
        Bitmap gPrevBitmap;//used to fix fliccering effect, save the previous frame and redraw it when fliccer
        int start;
        bool undraw = false;
        public Pen pen;
        public BufferedGraphics bufferedGraphics;
        public List<MeshObject> objects;
        public Camera cam;
        public int prevx, prevy;
        public Form form;
        public int calcT = 0, drawT = 0, renderT = 0;
        public double step = 20;
        public Scene(Form form)
        {
            this.form = form;
            bufferedGraphics = BufferedGraphicsManager.Current.Allocate(
                form.CreateGraphics(), form.ClientRectangle);
            pen = new Pen(Color.White, 2);
            objects = new List<MeshObject>();
            cam = new Camera(0,0,0);
            cam.DSx = form.Size.Width / 2;
            cam.DSy = form.Size.Height / 2;
            gPrevBitmap=new Bitmap(form.Size.Width, form.Size.Height);
        }
        public void addObject(String name, double x, double y, double z,bool rotate,bool face)
        {
            switch (name.ToLower())
            {
                case ("cube"):
                    objects.Add(new MeshObject(Models.cubeVertex, Models.cubeEdges,Models.cubeFaces, x, y, z, rotate,face));
                    break;
                case ("plane"):
                    objects.Add(new MeshObject(Models.planeVertex, Models.planeEdges, Models.planeFaces, x, y, z, rotate, face));
                    break;
                case ("pyramid"):
                    objects.Add(new MeshObject(Models.pyramidVertex, Models.pyramidEdges, Models.pyramidFaces, x, y, z, rotate, face));
                    break;
                case ("gear"):
                    objects.Add(new MeshObject(Models.gearVertex, Models.gearEdges, Models.gearFaces, 0, 0, 0, rotate, face));
                    objects[objects.Count - 1].rescale(60);
                    objects[objects.Count - 1].move('x', cam.x);
                    objects[objects.Count - 1].move('y', cam.y);
                    objects[objects.Count - 1].move('z', cam.z);
                    break;
                case ("sphere"):
                    objects.Add(new MeshObject(Models.sphereVertex, Models.sphereEdges, Models.sphereFaces, 0, 0, 0, rotate, face));
                    objects[objects.Count - 1].rotate('x', 90);
                    objects[objects.Count - 1].rescale(80);
                    objects[objects.Count - 1].move('x', cam.x);
                    objects[objects.Count - 1].move('y', cam.y);
                    objects[objects.Count - 1].move('z', cam.z);
                    break;
                case ("torus"):
                    objects.Add(new MeshObject(Models.torusVertex, Models.torusEdges, Models.torusFaces, 0, 0, 0, rotate, face));
                    objects[objects.Count - 1].rotate('x', 90);
                    objects[objects.Count - 1].rescale(30);
                    objects[objects.Count - 1].move('x', cam.x);
                    objects[objects.Count - 1].move('y', cam.y);
                    objects[objects.Count - 1].move('z', cam.z);
                    break;
                case ("candle"):
                    objects.Add(new MeshObject(Models.candleVertex, Models.candleEdges, Models.candleFaces, 0, 0, 0, rotate, face));
                    objects[objects.Count - 1].rotate('x', 180);
                    objects[objects.Count - 1].rescale(30);
                    objects[objects.Count - 1].move('x', cam.x);
                    objects[objects.Count - 1].move('y', cam.y);
                    objects[objects.Count - 1].move('z', cam.z);
                    break;
                case ("pistol"):
                    objects.Add(new MeshObject(Models.pistolVertex, Models.pistolEdges, Models.pistolFaces, 0, 0, 0, rotate, face));
                    objects[objects.Count - 1].rotate('x', 180);
                    objects[objects.Count - 1].rescale(60);
                    objects[objects.Count - 1].move('x', cam.x);
                    objects[objects.Count - 1].move('y', cam.y);
                    objects[objects.Count - 1].move('z', cam.z);
                    break;
                case ("hand"):
                    objects.Add(new MeshObject(Models.handVertex, Models.handEdges, Models.handFaces, 0, 0, 0, rotate, face));
                    objects[objects.Count - 1].rotate('x', 90);
                    objects[objects.Count - 1].rescale(60);
                    objects[objects.Count - 1].move('x', cam.x);
                    objects[objects.Count - 1].move('y', cam.y);
                    objects[objects.Count - 1].move('z', cam.z);
                    break;
                case ("damca"):
                    objects.Add(new MeshObject(Models.damcaVertex, Models.damcaEdges, Models.damcaFaces, 0, 0, 0, rotate, face));
                    objects[objects.Count - 1].rotate('x', 90);
                    objects[objects.Count - 1].rescale(80);
                    objects[objects.Count - 1].move('x', cam.x);
                    objects[objects.Count - 1].move('y', cam.y);
                    objects[objects.Count - 1].move('z', cam.z);
                    break;
                case ("itay"):
                    objects.Add(new MeshObject(Models.ITAYVertex, Models.ITAYEdges, Models.ITAYFaces, 0, 0, 0, rotate, face));
                    objects[objects.Count - 1].rotate('x', 90);
                    objects[objects.Count - 1].rescale(80);
                    objects[objects.Count - 1].move('x', cam.x);
                    objects[objects.Count - 1].move('y', cam.y);
                    objects[objects.Count - 1].move('z', cam.z);
                    break;
            }
        }
        public void addObject(String name)
        {
            addObject(name, 0, 0, 0,false,false);
        }
        public async void update()
        {
            start = DateTime.Now.Millisecond;

            lightX = cam.x;
            lightY = cam.y;
            lightZ = cam.z;

            form.DrawToBitmap(gPrevBitmap,new Rectangle(0,0,form.Width,form.Height));
            bufferedGraphics.Graphics.Clear(Color.Black);
            bufferedGraphics.Graphics.DrawLine(Pens.Red, form.Size.Width / 2 + 10, form.Size.Height / 2 + 10, form.Size.Width / 2 - 10, form.Size.Height / 2 - 10);
            bufferedGraphics.Graphics.DrawLine(Pens.Red, form.Size.Width / 2 - 10, form.Size.Height / 2 + 10, form.Size.Width / 2 + 10, form.Size.Height / 2 - 10);

            int s=DateTime.Now.Millisecond;
            List<Task> tasks=new List<Task>();
            for (int i=0;i<objects.Count;i++)
            {
                int idx = i;
                tasks.Add(drawObject(objects[idx]));
            }
            await Task.WhenAll(tasks.ToArray());
            if(undraw)
            {
                using (Graphics bitmapG = Graphics.FromImage(gPrevBitmap))
                    bitmapG.DrawImage(gPrevBitmap, new Point(0,0));
                undraw=false;
            }
            else
                bufferedGraphics.Render();

            renderT = DateTime.Now.Millisecond - s;
            
        }
        
        private Task drawObject(MeshObject obj)
        {
            if (obj == null) return Task.CompletedTask;
            if (obj.doRotate)
                obj.rotate('y', 1);
            int s = DateTime.Now.Millisecond;
            double[,] points = cam.project(obj.vertex);
            calcT=DateTime.Now.Millisecond-s;
            s = DateTime.Now.Millisecond;
            try
            {
                if (obj.face)
                    for (int i = 0; i < obj.faces.GetLongLength(0); i++)
                    {
                        int now = DateTime.Now.Millisecond;
                        if (now - start > TimeLimit || now - start < -TimeLimit)
                        {
                            undraw=true;
                            break;
                        }
                        int x1 = (int)Math.Round(points[obj.faces[i, 0], 0]);
                        int y1 = (int)Math.Round(points[obj.faces[i, 0], 1]);
                        int x2 = (int)Math.Round(points[obj.faces[i, 1], 0]);
                        int y2 = (int)Math.Round(points[obj.faces[i, 1], 1]);
                        int x3 = (int)Math.Round(points[obj.faces[i, 2], 0]);
                        int y3 = (int)Math.Round(points[obj.faces[i, 2], 1]);

                        //if(Area Of Triangle < TriangleLimit)
                        if (Math.Abs(x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2 < 300/renderDistance)
                            continue;
                        List<Point> p = new List<Point>();
                        if (x1 > 0 && y1 > 0)
                            p.Add(new Point(x1, y1));
                        if (x2 > 0 && y2 > 0)
                            p.Add(new Point(x2, y2));
                        if (x3 > 0 && y3 > 0)
                            p.Add(new Point(x3, y3));

                        Random rnd = new Random(i);
                        double alpha =Math.Sqrt(Math.Pow(obj.vertex[i, 0] - lightX, 2)+ Math.Pow(obj.vertex[i, 1] - lightY, 2)+Math.Pow(obj.vertex[i, 2] - lightZ, 2));
                        alpha = alpha / (double)renderDistance;
                        alpha = 255 - alpha;
                        if (alpha < 0)
                            alpha = 0;
                        
                        Brush b = new SolidBrush(Color.FromArgb((int)alpha,rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                        bufferedGraphics.Graphics.FillPolygon(b, p.ToArray());
                    }
                else
                {
                    for (int i = 0; i < obj.edges.GetLongLength(0); i++)
                    {
                        int now = DateTime.Now.Millisecond;
                        if (now - start > TimeLimit || now - start < -TimeLimit)
                        {
                            undraw = true;
                            break;
                        }
                        int x1 = (int)Math.Round(points[obj.edges[i, 0], 0]);
                        int y1 = (int)Math.Round(points[obj.edges[i, 0], 1]);
                        int x2 = (int)Math.Round(points[obj.edges[i, 1], 0]);
                        int y2 = (int)Math.Round(points[obj.edges[i, 1], 1]);
                        if ((x1 < 0 || x2 < 0 || y1 < 0 || y2 < 0) || (Math.Sqrt(Math.Abs(x1 - x2)*Math.Abs(x1-x2)+ Math.Abs(y1 - y2)* Math.Abs(y1 - y2))<100/(double)renderDistance))
                            continue;
                        bufferedGraphics.Graphics.DrawLine(pen, x1, y1, x2, y2);
                    }

                }
            }
            catch (Exception e)
            {
                return Task.CompletedTask;
            }
            drawT = DateTime.Now.Millisecond - s;
            return Task.CompletedTask;
        }

        public void formResize(Form form)
        {
            this.form = form;
            cam.DSx = form.Size.Width / 2;
            cam.DSy = form.Size.Height / 2;
            bufferedGraphics = BufferedGraphicsManager.Current.Allocate(
                form.CreateGraphics(), form.ClientRectangle);
        }
        public void mouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cam.rotate('y', (prevx - e.X) / 3);
                cam.rotate('x', (prevy - e.Y) / 3);
                if (cam.xrot > 90)
                    cam.rotate('x', -2);
                else if (cam.xrot < -90)
                    cam.rotate('x', 2);
            }
            
            prevx = e.X;
            prevy = e.Y;
        }
        public void keyDown(KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                cam.forward(-step);
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                cam.forward(step);
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                cam.sideways(-step);
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                cam.sideways(step);
            if (e.KeyCode == Keys.E)
                cam.y -= step;
            if (e.KeyCode == Keys.Q)
                cam.y += step;
            
        }
    }
}
