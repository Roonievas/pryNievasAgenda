namespace pryNievasAgenda
{
    partial class frmActividades
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActividades));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblActividad = new System.Windows.Forms.Label();
            this.txtActividad = new System.Windows.Forms.TextBox();
            this.gbActividades = new System.Windows.Forms.GroupBox();
            this.gbActividades.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(610, 218);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(177, 51);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(610, 76);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(177, 51);
            this.btnAceptar.TabIndex = 13;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtObservacion
            // 
            this.txtObservacion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtObservacion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacion.Location = new System.Drawing.Point(214, 218);
            this.txtObservacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(310, 122);
            this.txtObservacion.TabIndex = 50;
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservacion.Location = new System.Drawing.Point(57, 209);
            this.lblObservacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(141, 23);
            this.lblObservacion.TabIndex = 12;
            this.lblObservacion.Text = "Observación:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CalendarFont = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Location = new System.Drawing.Point(214, 122);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(310, 29);
            this.dtpFecha.TabIndex = 8;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(57, 128);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(76, 23);
            this.lblFecha.TabIndex = 11;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblActividad
            // 
            this.lblActividad.AutoSize = true;
            this.lblActividad.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActividad.Location = new System.Drawing.Point(57, 50);
            this.lblActividad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActividad.Name = "lblActividad";
            this.lblActividad.Size = new System.Drawing.Size(108, 23);
            this.lblActividad.TabIndex = 9;
            this.lblActividad.Text = "Actividad:";
            // 
            // txtActividad
            // 
            this.txtActividad.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActividad.Location = new System.Drawing.Point(214, 46);
            this.txtActividad.Margin = new System.Windows.Forms.Padding(4);
            this.txtActividad.Multiline = true;
            this.txtActividad.Name = "txtActividad";
            this.txtActividad.Size = new System.Drawing.Size(310, 27);
            this.txtActividad.TabIndex = 7;
            // 
            // gbActividades
            // 
            this.gbActividades.BackColor = System.Drawing.Color.LightGreen;
            this.gbActividades.Controls.Add(this.btnCancelar);
            this.gbActividades.Controls.Add(this.btnAceptar);
            this.gbActividades.Controls.Add(this.txtObservacion);
            this.gbActividades.Controls.Add(this.lblObservacion);
            this.gbActividades.Controls.Add(this.dtpFecha);
            this.gbActividades.Controls.Add(this.lblFecha);
            this.gbActividades.Controls.Add(this.lblActividad);
            this.gbActividades.Controls.Add(this.txtActividad);
            this.gbActividades.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbActividades.Location = new System.Drawing.Point(45, 79);
            this.gbActividades.Name = "gbActividades";
            this.gbActividades.Size = new System.Drawing.Size(889, 421);
            this.gbActividades.TabIndex = 51;
            this.gbActividades.TabStop = false;
            this.gbActividades.Text = "Actividades";
            // 
            // frmActividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(985, 632);
            this.Controls.Add(this.gbActividades);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmActividades";
            this.Text = "frmInicio";
            this.Load += new System.EventHandler(this.frmActividades_Load);
            this.gbActividades.ResumeLayout(false);
            this.gbActividades.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblActividad;
        private System.Windows.Forms.TextBox txtActividad;
        private System.Windows.Forms.GroupBox gbActividades;
    }
}