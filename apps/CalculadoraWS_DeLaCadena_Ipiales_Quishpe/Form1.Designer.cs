namespace CalculadoraWS_DeLaCadena_Ipiales_Quishpe
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSumar = new System.Windows.Forms.Button();
            this.btnRestar = new System.Windows.Forms.Button();
            this.btnMultiplicar = new System.Windows.Forms.Button();
            this.btnDividir = new System.Windows.Forms.Button();
            this.lblNum1 = new System.Windows.Forms.Label();
            this.txtBoxNum1 = new System.Windows.Forms.TextBox();
            this.txtBoxNum2 = new System.Windows.Forms.TextBox();
            this.lblNum2 = new System.Windows.Forms.Label();
            this.txtBoxResp = new System.Windows.Forms.TextBox();
            this.lvlResp = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSumar
            // 
            this.btnSumar.Location = new System.Drawing.Point(158, 155);
            this.btnSumar.Name = "btnSumar";
            this.btnSumar.Size = new System.Drawing.Size(75, 23);
            this.btnSumar.TabIndex = 0;
            this.btnSumar.Text = "Sumar";
            this.btnSumar.UseVisualStyleBackColor = true;
            this.btnSumar.Click += new System.EventHandler(this.btnSumar_Click);
            // 
            // btnRestar
            // 
            this.btnRestar.Location = new System.Drawing.Point(265, 155);
            this.btnRestar.Name = "btnRestar";
            this.btnRestar.Size = new System.Drawing.Size(75, 23);
            this.btnRestar.TabIndex = 1;
            this.btnRestar.Text = "Restar";
            this.btnRestar.UseVisualStyleBackColor = true;
            this.btnRestar.Click += new System.EventHandler(this.btnRestar_Click);
            // 
            // btnMultiplicar
            // 
            this.btnMultiplicar.Location = new System.Drawing.Point(379, 155);
            this.btnMultiplicar.Name = "btnMultiplicar";
            this.btnMultiplicar.Size = new System.Drawing.Size(75, 23);
            this.btnMultiplicar.TabIndex = 2;
            this.btnMultiplicar.Text = "Multiplicar";
            this.btnMultiplicar.UseVisualStyleBackColor = true;
            this.btnMultiplicar.Click += new System.EventHandler(this.btnMultiplicar_Click);
            // 
            // btnDividir
            // 
            this.btnDividir.Location = new System.Drawing.Point(494, 155);
            this.btnDividir.Name = "btnDividir";
            this.btnDividir.Size = new System.Drawing.Size(75, 23);
            this.btnDividir.TabIndex = 3;
            this.btnDividir.Text = "Dividir";
            this.btnDividir.UseVisualStyleBackColor = true;
            this.btnDividir.Click += new System.EventHandler(this.btnDividir_Click);
            // 
            // lblNum1
            // 
            this.lblNum1.AutoSize = true;
            this.lblNum1.Location = new System.Drawing.Point(164, 62);
            this.lblNum1.Name = "lblNum1";
            this.lblNum1.Size = new System.Drawing.Size(53, 13);
            this.lblNum1.TabIndex = 4;
            this.lblNum1.Text = "Numero 1";
            // 
            // txtBoxNum1
            // 
            this.txtBoxNum1.Location = new System.Drawing.Point(223, 59);
            this.txtBoxNum1.Name = "txtBoxNum1";
            this.txtBoxNum1.Size = new System.Drawing.Size(100, 20);
            this.txtBoxNum1.TabIndex = 5;
            // 
            // txtBoxNum2
            // 
            this.txtBoxNum2.Location = new System.Drawing.Point(223, 101);
            this.txtBoxNum2.Name = "txtBoxNum2";
            this.txtBoxNum2.Size = new System.Drawing.Size(100, 20);
            this.txtBoxNum2.TabIndex = 6;
            // 
            // lblNum2
            // 
            this.lblNum2.AutoSize = true;
            this.lblNum2.Location = new System.Drawing.Point(164, 104);
            this.lblNum2.Name = "lblNum2";
            this.lblNum2.Size = new System.Drawing.Size(50, 13);
            this.lblNum2.TabIndex = 7;
            this.lblNum2.Text = "Numero2";
            // 
            // txtBoxResp
            // 
            this.txtBoxResp.Location = new System.Drawing.Point(296, 236);
            this.txtBoxResp.Name = "txtBoxResp";
            this.txtBoxResp.Size = new System.Drawing.Size(149, 20);
            this.txtBoxResp.TabIndex = 8;
            // 
            // lvlResp
            // 
            this.lvlResp.AutoSize = true;
            this.lvlResp.Location = new System.Drawing.Point(341, 220);
            this.lvlResp.Name = "lvlResp";
            this.lvlResp.Size = new System.Drawing.Size(61, 13);
            this.lvlResp.TabIndex = 9;
            this.lvlResp.Text = "Respuesta:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(702, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "V2";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lvlResp);
            this.Controls.Add(this.txtBoxResp);
            this.Controls.Add(this.lblNum2);
            this.Controls.Add(this.txtBoxNum2);
            this.Controls.Add(this.txtBoxNum1);
            this.Controls.Add(this.lblNum1);
            this.Controls.Add(this.btnDividir);
            this.Controls.Add(this.btnMultiplicar);
            this.Controls.Add(this.btnRestar);
            this.Controls.Add(this.btnSumar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSumar;
        private System.Windows.Forms.Button btnRestar;
        private System.Windows.Forms.Button btnMultiplicar;
        private System.Windows.Forms.Button btnDividir;
        private System.Windows.Forms.Label lblNum1;
        private System.Windows.Forms.TextBox txtBoxNum1;
        private System.Windows.Forms.TextBox txtBoxNum2;
        private System.Windows.Forms.Label lblNum2;
        private System.Windows.Forms.TextBox txtBoxResp;
        private System.Windows.Forms.Label lvlResp;
        private System.Windows.Forms.Button button1;
    }
}

