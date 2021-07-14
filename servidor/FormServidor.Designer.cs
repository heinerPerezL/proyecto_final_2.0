namespace servidor
{
    partial class FormServidor
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
            this.label1 = new System.Windows.Forms.Label();
            this.cantClientes = new System.Windows.Forms.TextBox();
            this.dgwMostrarViajes = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnLCond = new System.Windows.Forms.Button();
            this.cbxEstado = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwMostrarViajes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(603, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clientes conectados";
            // 
            // cantClientes
            // 
            this.cantClientes.Location = new System.Drawing.Point(712, 18);
            this.cantClientes.Name = "cantClientes";
            this.cantClientes.Size = new System.Drawing.Size(67, 20);
            this.cantClientes.TabIndex = 2;
            // 
            // dgwMostrarViajes
            // 
            this.dgwMostrarViajes.AllowUserToOrderColumns = true;
            this.dgwMostrarViajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwMostrarViajes.Location = new System.Drawing.Point(31, 80);
            this.dgwMostrarViajes.Name = "dgwMostrarViajes";
            this.dgwMostrarViajes.Size = new System.Drawing.Size(634, 150);
            this.dgwMostrarViajes.TabIndex = 3;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(50, 248);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(118, 32);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar Viajes";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnLCond
            // 
            this.btnLCond.Location = new System.Drawing.Point(174, 248);
            this.btnLCond.Name = "btnLCond";
            this.btnLCond.Size = new System.Drawing.Size(142, 32);
            this.btnLCond.TabIndex = 5;
            this.btnLCond.Text = "Lista Conductores";
            this.btnLCond.UseVisualStyleBackColor = true;
            this.btnLCond.Click += new System.EventHandler(this.btnLCond_Click);
            // 
            // cbxEstado
            // 
            this.cbxEstado.FormattingEnabled = true;
            this.cbxEstado.Items.AddRange(new object[] {
            "activo",
            "inactivo"});
            this.cbxEstado.Location = new System.Drawing.Point(30, 32);
            this.cbxEstado.Name = "cbxEstado";
            this.cbxEstado.Size = new System.Drawing.Size(125, 21);
            this.cbxEstado.TabIndex = 6;
            this.cbxEstado.Text = "Seleccionar Estado";
            this.cbxEstado.SelectedIndexChanged += new System.EventHandler(this.cbxEstado_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(181, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 21);
            this.button1.TabIndex = 7;
            this.button1.Text = "Cambiar Estado";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(348, 248);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 32);
            this.button2.TabIndex = 8;
            this.button2.Text = "Choferes Inactivos";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbxEstado);
            this.Controls.Add(this.btnLCond);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dgwMostrarViajes);
            this.Controls.Add(this.cantClientes);
            this.Controls.Add(this.label1);
            this.Name = "FormServidor";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormServidor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwMostrarViajes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cantClientes;
        private System.Windows.Forms.DataGridView dgwMostrarViajes;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnLCond;
        private System.Windows.Forms.ComboBox cbxEstado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

