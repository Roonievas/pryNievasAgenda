using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryNievasAgenda
{
    internal class clsConexionBD
    {

        string cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../BDAgenda.accdb";
        OleDbConnection coneccionBaseDatos;
        OleDbCommand comandoBaseDatos;
        OleDbDataReader lectorDataReader;


        public string nombreBaseDeDatos;
        public void ConectarBD(ToolStripStatusLabel label)
        {
            try
            {

                coneccionBaseDatos = new OleDbConnection(cadenaConexion);

                coneccionBaseDatos.Open();
                nombreBaseDeDatos = coneccionBaseDatos.Database;


                label.Text = "Conectado a base de datos";
                label.BackColor = System.Drawing.Color.GreenYellow;
            }
            catch (Exception error)
            {
                label.Text = "Error al conectar " + error.Message;
                label.BackColor = System.Drawing.Color.DarkRed;
            }

        }
    }
}

