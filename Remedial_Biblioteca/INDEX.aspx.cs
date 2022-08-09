using CapaDLL;
using CapaENTIDAES;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Remedial_Biblioteca
{
    public partial class INDEX : System.Web.UI.Page
    {
        Logica_Negocio LN = null;
        List<Usuarios> Lista_Usuarios = new List<Usuarios>();
        string mensaje = "", mensajeC = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LN = new Logica_Negocio(ConfigurationManager.ConnectionStrings["BDBiblioteca"].ConnectionString);
                Session["negocioServer"] = LN;
            }
            else
            {
                LN = (Logica_Negocio)Session["negocioServer"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Lista Usuarios --->INICIO
            Lista_Usuarios = LN.L_Usuarios(ref mensaje, ref mensajeC);
            for (int i = 0; i < Lista_Usuarios.Count(); i++)
            {
                ListBox1.Items.Add(Lista_Usuarios[i].IdUsuario.ToString());
                ListBox1.Items.Add(Lista_Usuarios[i].Nombre.ToString());
                ListBox1.Items.Add(Lista_Usuarios[i].Colonia.ToString());
                ListBox1.Items.Add(Lista_Usuarios[i].Numero.ToString());
                ListBox1.Items.Add(Lista_Usuarios[i].CP.ToString());
                ListBox1.Items.Add(Lista_Usuarios[i].Nom_Centro_Trabajo.ToString());
                ListBox1.Items.Add(Lista_Usuarios[i].Telefono.ToString());
            }
            //Lista Usuarios --->FINAL

        }
    }
}