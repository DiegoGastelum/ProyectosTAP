namespace Práctica_3
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
            this.btnValidar = new System.Windows.Forms.Button();
            this.txtBox1 = new System.Windows.Forms.TextBox();
            this.txtBoxRFC = new System.Windows.Forms.TextBox();
            this.btnRFC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.customTxtBox1 = new LibreríaCustom.CustomTxtBox();
            this.customBtn1 = new LibreríaCustom.CustomBtn();
            this.SuspendLayout();
            // 
            // btnValidar
            // 
            this.btnValidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidar.Location = new System.Drawing.Point(476, 49);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(151, 70);
            this.btnValidar.TabIndex = 2;
            this.btnValidar.Text = "Validar";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // txtBox1
            // 
            this.txtBox1.Location = new System.Drawing.Point(476, 23);
            this.txtBox1.Name = "txtBox1";
            this.txtBox1.Size = new System.Drawing.Size(312, 20);
            this.txtBox1.TabIndex = 3;
            this.txtBox1.TextChanged += new System.EventHandler(this.txtBox1_TextChanged);
            // 
            // txtBoxRFC
            // 
            this.txtBoxRFC.Location = new System.Drawing.Point(476, 234);
            this.txtBoxRFC.Name = "txtBoxRFC";
            this.txtBoxRFC.Size = new System.Drawing.Size(312, 20);
            this.txtBoxRFC.TabIndex = 6;
            // 
            // btnRFC
            // 
            this.btnRFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRFC.Location = new System.Drawing.Point(476, 260);
            this.btnRFC.Name = "btnRFC";
            this.btnRFC.Size = new System.Drawing.Size(151, 70);
            this.btnRFC.TabIndex = 7;
            this.btnRFC.Text = "Validar RFC";
            this.btnRFC.UseVisualStyleBackColor = true;
            this.btnRFC.Click += new System.EventHandler(this.btnRFC_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(471, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(317, 109);
            this.label3.TabIndex = 11;
            this.label3.Text = "En la TextBox superior deberás introducir números, letras y te dirá si solo son n" +
    "úmeros, letras o combinados.";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(471, 333);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(317, 109);
            this.label4.TabIndex = 12;
            this.label4.Text = "En esta TextBox debes introducir un RFC con el formato correcto para persona físi" +
    "ca o moral.";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(317, 109);
            this.label5.TabIndex = 13;
            this.label5.Text = "En este botón tienes que presionar doble click.";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(316, 120);
            this.label6.TabIndex = 15;
            this.label6.Text = "En este apartado deberás seleccionar el modo en las propiedades de la TextBox a s" +
    "ólo letras o sólo números.";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(18, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(419, 96);
            this.label7.TabIndex = 16;
            this.label7.Text = "Seleccionar TextBox -> Propiedades -> Comportamiento -> Mode";
            // 
            // customTxtBox1
            // 
            this.customTxtBox1.ErrorColor = System.Drawing.Color.Red;
            this.customTxtBox1.Location = new System.Drawing.Point(25, 20);
            this.customTxtBox1.Mode = LibreríaCustom.CustomTxtBox.InputMode.NumbersOnly;
            this.customTxtBox1.Name = "customTxtBox1";
            this.customTxtBox1.Size = new System.Drawing.Size(282, 23);
            this.customTxtBox1.TabIndex = 17;
            // 
            // customBtn1
            // 
            this.customBtn1.HoverBackColor = System.Drawing.Color.LightGray;
            this.customBtn1.Location = new System.Drawing.Point(21, 260);
            this.customBtn1.Name = "customBtn1";
            this.customBtn1.Size = new System.Drawing.Size(151, 70);
            this.customBtn1.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.customBtn1);
            this.Controls.Add(this.customTxtBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRFC);
            this.Controls.Add(this.txtBoxRFC);
            this.Controls.Add(this.txtBox1);
            this.Controls.Add(this.btnValidar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.TextBox txtBox1;
        private System.Windows.Forms.TextBox txtBoxRFC;
        private System.Windows.Forms.Button btnRFC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private LibreríaCustom.CustomTxtBox customTxtBox1;
        private LibreríaCustom.CustomBtn customBtn1;
    }
}

