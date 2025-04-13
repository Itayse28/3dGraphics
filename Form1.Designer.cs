namespace GraphicsTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.RenderLoop = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FPS = new System.Windows.Forms.Label();
            this.Item = new System.Windows.Forms.ComboBox();
            this.addModel = new System.Windows.Forms.Button();
            this.doRotate = new System.Windows.Forms.CheckBox();
            this.showFaces = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // RenderLoop
            // 
            this.RenderLoop.Enabled = true;
            this.RenderLoop.Interval = 1;
            this.RenderLoop.Tick += new System.EventHandler(this.RenderLoop_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1196, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1196, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 1;
            // 
            // FPS
            // 
            this.FPS.AutoSize = true;
            this.FPS.ForeColor = System.Drawing.Color.White;
            this.FPS.Location = new System.Drawing.Point(33, 14);
            this.FPS.Name = "FPS";
            this.FPS.Size = new System.Drawing.Size(38, 15);
            this.FPS.TabIndex = 2;
            this.FPS.Text = "FPS: 0";
            // 
            // Item
            // 
            this.Item.CausesValidation = false;
            this.Item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Item.FormattingEnabled = true;
            this.Item.Items.AddRange(new object[] {
            "Cube",
            "Plane",
            "Pyramid",
            "Sphere",
            "Gear",
            "Torus",
            "Candle",
            "Pistol",
            "Hand",
            "Damca",
            "ITAY"});
            this.Item.Location = new System.Drawing.Point(1289, 85);
            this.Item.Name = "Item";
            this.Item.Size = new System.Drawing.Size(121, 23);
            this.Item.TabIndex = 3;
            // 
            // addModel
            // 
            this.addModel.Location = new System.Drawing.Point(1310, 176);
            this.addModel.Name = "addModel";
            this.addModel.Size = new System.Drawing.Size(75, 23);
            this.addModel.TabIndex = 4;
            this.addModel.Text = "Add Model";
            this.addModel.UseVisualStyleBackColor = true;
            this.addModel.Click += new System.EventHandler(this.addModel_Click);
            // 
            // doRotate
            // 
            this.doRotate.AutoSize = true;
            this.doRotate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.doRotate.ForeColor = System.Drawing.Color.White;
            this.doRotate.Location = new System.Drawing.Point(1310, 118);
            this.doRotate.Name = "doRotate";
            this.doRotate.Size = new System.Drawing.Size(66, 19);
            this.doRotate.TabIndex = 5;
            this.doRotate.Text = "Spining";
            this.doRotate.UseVisualStyleBackColor = true;
            // 
            // showFaces
            // 
            this.showFaces.AutoSize = true;
            this.showFaces.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showFaces.ForeColor = System.Drawing.Color.White;
            this.showFaces.Location = new System.Drawing.Point(1310, 143);
            this.showFaces.Name = "showFaces";
            this.showFaces.Size = new System.Drawing.Size(87, 19);
            this.showFaces.TabIndex = 6;
            this.showFaces.Text = "Show Faces";
            this.showFaces.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 51);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(91, 23);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1196, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1454, 871);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.showFaces);
            this.Controls.Add(this.doRotate);
            this.Controls.Add(this.addModel);
            this.Controls.Add(this.Item);
            this.Controls.Add(this.FPS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Graphics is cool (;";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer RenderLoop;
        private Label label1;
        private Label label2;
        private Label FPS;
        private ComboBox Item;
        private Button addModel;
        private CheckBox doRotate;
        private CheckBox showFaces;
        private NumericUpDown numericUpDown1;
        private Label label3;
    }
}