using Microsoft.VisualBasic.Devices;
using System.CodeDom;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace GraphicsTest
{
    public partial class Form1 : Form
    {

        Scene scene;
        
        public Form1()
        {
            InitializeComponent();
            scene = new Scene(this);
            scene.addObject("cube", 0, 0, 0, false, false);
            scene.objects[0].rescale(0.01);
            this.MouseWheel += Form1_MouseWheel;
        }

        private void RenderLoop_Tick(object sender, EventArgs e)
        {
            int start = DateTime.Now.Millisecond;
            
            string shortx= scene.cam.x.ToString(), shorty= scene.cam.y.ToString(), shortz= scene.cam.z.ToString();
            if (scene.cam.x != (int)scene.cam.x)
                shortx = shortx.Substring(0, shortx.IndexOf('.') + 3);
            if (scene.cam.y != (int)scene.cam.y)
                shorty = shorty.Substring(0, shorty.IndexOf('.') + 3);
            if (scene.cam.z != Math.Round(scene.cam.z))
                shortz = shortz.Substring(0, shortz.IndexOf('.') + 3);
            label1.Text = shortx + ", " + shorty + ", " + shortz;
            
            scene.update();
            label2.Text = "Calc: " + scene.calcT + " Draw: " + scene.drawT + " Render: " + scene.renderT;
            
            int end = DateTime.Now.Millisecond;
            if (end == start)
                return;

            FPS.Text = "FPS: "+(1000/(end-start));
            

        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            scene.formResize(this);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            scene.keyDown(e);
            if (e.KeyCode == Keys.Enter)
                if (Item.SelectedItem != null)
                    scene.addObject(Item.SelectedItem.ToString(), scene.cam.x, scene.cam.y, scene.cam.z,doRotate.Checked,showFaces.Checked);
        }

        private void addModel_Click(object sender, EventArgs e)
        {
            if(Item.SelectedItem!=null)
                scene.addObject(Item.SelectedItem.ToString(), scene.cam.x, scene.cam.y, scene.cam.z, doRotate.Checked, showFaces.Checked);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            scene.mouseMove(e);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            scene.renderDistance = nud.Value;
        }
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            scene.step += e.Delta/120;
            if(scene.step < 1)
                scene.step = 1;
        }
    }
}

/*
 * 
 * Y+ is down
 * x+ is right
 * Z+ is forward
 * -------->x
 * |⟍
 * |  ⟍
 * |    ⟍
 * V      🡮
 * Y        Z
 * 
 * 
 * 
 *
 * 
 *  solved:
 *   preformance issues: when a line or a triangle is too small it wont be rendered
 *   plus: each object gets render on a different thread
 *   fliccering issue: when an object takes too long to draw, instead of not rendering it, i render the previous frame
 *      
 * 
 *  not solved:
 *   shadow problem: if you look at an object and then look down or up, you will see the object even thou its behind you
 *   object rendering order: if an object was added after another one, it will always render on top
 *   need better render time when a lot of objects in view
 * 
 * 
 * 
 * 
 * 
 * 
 */












