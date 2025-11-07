using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryNievasAgenda
{
    public partial class frmActividades : Form
    {
        private string cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../BDAgenda.accdb";
        public frmActividades()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // 1) Validaciones
            string asunto = txtActividad.Text.Trim();
            string observacion = txtObservacion.Text.Trim();

            if (string.IsNullOrEmpty(asunto))
            {
                MessageBox.Show("El campo 'Actividad' no puede quedar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtActividad.Focus();
                return;
            }

            // Fecha seleccionada -> tomar la fecha y forzar hora 12:00:00
            DateTime fechaConHora = dtpFecha.Value.Date.Add(new TimeSpan(12, 0, 0));

            if (fechaConHora <= DateTime.Now)
            {
                MessageBox.Show("La fecha debe ser futura (la hora guardada será 12:00:00).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFecha.Focus();
                return;
            }
            string sql = "INSERT INTO Actividad (Asuntos, Fecha, Observacion) VALUES (?,?,?)";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(cadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    // Parámetros en el orden correcto
                    cmd.Parameters.AddWithValue("?", asunto);
                    cmd.Parameters.AddWithValue("?", fechaConHora);
                    // Si observación viene vacía, podemos insertar DBNull
                    if (string.IsNullOrEmpty(observacion))
                        cmd.Parameters.AddWithValue("?", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("?", observacion);

                    conn.Open();
                    int filas = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (filas > 0)
                    {
                        MessageBox.Show("Actividad agregada correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; // útil para que el form principal recargue la grilla si usa ShowDialog()
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo insertar la actividad. Revise la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar en la base: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmActividades_Load(object sender, EventArgs e)
        {

        }
    }
}
