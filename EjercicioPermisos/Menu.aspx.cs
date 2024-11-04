using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EjercicioPermisos
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UsuarioId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    GenerateMenu();
                }
            }
        }
        private void GenerateMenu()
        {
            int usuarioId = Convert.ToInt32(Session["UsuarioId"]);

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT opcion, url FROM usuario WHERE id = @UsuarioId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UsuarioId", usuarioId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    StringBuilder menuBuilder = new StringBuilder();
                    menuBuilder.Append("<ul class='horizontal-menu'>");

                    while (reader.Read())
                    {
                        string opcion = reader["opcion"].ToString();
                        string url = reader["url"].ToString();

                        menuBuilder.AppendFormat("<li><a href='{0}'>{1}</a></li>", url, opcion);
                    }

                    menuBuilder.Append("</ul>");
                    MenuPlaceHolder.Controls.Add(new Literal { Text = menuBuilder.ToString() });
                }
                catch (Exception ex)
                {
                    MenuPlaceHolder.Controls.Add(new Literal { Text = $"Error al generar el menú: {ex.Message}" });
                }
            }
        }
    }
}