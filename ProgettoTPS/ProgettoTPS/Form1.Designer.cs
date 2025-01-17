namespace ProgettoTPS
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
            IniziaGioco = new Button();
            ManoG1 = new ListBox();
            ManoG2 = new ListBox();
            GiocaG1 = new Button();
            PescaG1 = new Button();
            GiocaG2 = new Button();
            PescaG2 = new Button();
            label1 = new Label();
            label2 = new Label();
            FineG1 = new Button();
            FineG2 = new Button();
            CartaTav = new Button();
            SuspendLayout();
            // 
            // IniziaGioco
            // 
            IniziaGioco.Location = new Point(369, 87);
            IniziaGioco.Name = "IniziaGioco";
            IniziaGioco.Size = new Size(75, 54);
            IniziaGioco.TabIndex = 0;
            IniziaGioco.Text = "INIZIA GIOCO";
            IniziaGioco.UseVisualStyleBackColor = true;
            IniziaGioco.Click += IniziaGioco_Click_1;
            // 
            // ManoG1
            // 
            ManoG1.FormattingEnabled = true;
            ManoG1.ItemHeight = 15;
            ManoG1.Location = new Point(62, 110);
            ManoG1.Name = "ManoG1";
            ManoG1.Size = new Size(165, 229);
            ManoG1.TabIndex = 1;
            ManoG1.Visible = false;
            // 
            // ManoG2
            // 
            ManoG2.FormattingEnabled = true;
            ManoG2.ItemHeight = 15;
            ManoG2.Location = new Point(596, 110);
            ManoG2.Name = "ManoG2";
            ManoG2.Size = new Size(165, 229);
            ManoG2.TabIndex = 2;
            ManoG2.Visible = false;
            // 
            // GiocaG1
            // 
            GiocaG1.Location = new Point(62, 348);
            GiocaG1.Name = "GiocaG1";
            GiocaG1.Size = new Size(75, 42);
            GiocaG1.TabIndex = 3;
            GiocaG1.Text = "GIOCA";
            GiocaG1.UseVisualStyleBackColor = true;
            GiocaG1.Visible = false;
            GiocaG1.Click += GiocaG1_Click;
            // 
            // PescaG1
            // 
            PescaG1.Location = new Point(152, 348);
            PescaG1.Name = "PescaG1";
            PescaG1.Size = new Size(75, 42);
            PescaG1.TabIndex = 4;
            PescaG1.Text = "PESCA";
            PescaG1.UseVisualStyleBackColor = true;
            PescaG1.Visible = false;
            PescaG1.Click += PescaG1_Click;
            // 
            // GiocaG2
            // 
            GiocaG2.Location = new Point(596, 348);
            GiocaG2.Name = "GiocaG2";
            GiocaG2.Size = new Size(75, 42);
            GiocaG2.TabIndex = 5;
            GiocaG2.Text = "GIOCA";
            GiocaG2.UseVisualStyleBackColor = true;
            GiocaG2.Visible = false;
            GiocaG2.Click += GiocaG2_Click;
            // 
            // PescaG2
            // 
            PescaG2.Location = new Point(686, 348);
            PescaG2.Name = "PescaG2";
            PescaG2.Size = new Size(75, 42);
            PescaG2.TabIndex = 6;
            PescaG2.Text = "PESCA";
            PescaG2.UseVisualStyleBackColor = true;
            PescaG2.Visible = false;
            PescaG2.Click += PescaG2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(316, 63);
            label1.Name = "label1";
            label1.Size = new Size(70, 21);
            label1.TabIndex = 7;
            label1.Text = "TURNO:";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(392, 63);
            label2.Name = "label2";
            label2.Size = new Size(114, 21);
            label2.TabIndex = 8;
            label2.Text = "GIOCATORE  1";
            label2.Visible = false;
            // 
            // FineG1
            // 
            FineG1.Location = new Point(103, 396);
            FineG1.Name = "FineG1";
            FineG1.Size = new Size(75, 42);
            FineG1.TabIndex = 9;
            FineG1.Text = "FINE TURNO";
            FineG1.UseVisualStyleBackColor = true;
            FineG1.Visible = false;
            // 
            // FineG2
            // 
            FineG2.Location = new Point(639, 396);
            FineG2.Name = "FineG2";
            FineG2.Size = new Size(75, 42);
            FineG2.TabIndex = 10;
            FineG2.Text = "FINE TURNO";
            FineG2.UseVisualStyleBackColor = true;
            FineG2.Visible = false;
            // 
            // CartaTav
            // 
            CartaTav.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            CartaTav.Location = new Point(369, 176);
            CartaTav.Name = "CartaTav";
            CartaTav.Size = new Size(75, 87);
            CartaTav.TabIndex = 11;
            CartaTav.Text = "0";
            CartaTav.UseVisualStyleBackColor = true;
            CartaTav.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CartaTav);
            Controls.Add(FineG2);
            Controls.Add(FineG1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PescaG2);
            Controls.Add(GiocaG2);
            Controls.Add(PescaG1);
            Controls.Add(GiocaG1);
            Controls.Add(ManoG2);
            Controls.Add(ManoG1);
            Controls.Add(IniziaGioco);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button IniziaGioco;
        private ListBox ManoG1;
        private ListBox ManoG2;
        private Button GiocaG1;
        private Button PescaG1;
        private Button GiocaG2;
        private Button PescaG2;
        private Label label1;
        private Label label2;
        private Button FineG1;
        private Button FineG2;
        private Button CartaTav;
    }
}
