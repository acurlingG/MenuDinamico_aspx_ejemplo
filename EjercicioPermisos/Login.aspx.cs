using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EjercicioPermisos
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text.Trim();

            // Obtén la cadena de conexión desde el archivo Web.config
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Consulta para verificar las credenciales del usuario
                string query = "SELECT UsuarioId FROM Login WHERE Usuario = @Usuario AND Clave = @Clave";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Usuario", usuario);
                command.Parameters.AddWithValue("@Clave", clave);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        // Guardar el UsuarioId en la sesión y redirigir a la página del menú
                        int usuarioId = Convert.ToInt32(result);
                        Session["UsuarioId"] = usuarioId;
                        Response.Redirect("Menu.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Usuario o clave incorrecta.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = $"Error al iniciar sesión: {ex.Message}";
                }
            }
        }
    }
}