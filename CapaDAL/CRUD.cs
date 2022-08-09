using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaENTIDAES;

namespace CapaDAL
{
    public class CRUD
    {
        private Acceso_Datos AC = null;
        public CRUD(string connection)
        {
            AC = new Acceso_Datos(connection);
        }

        //<-----------------------------------------------------------------------Creacion de Listas----------------------------------------------------------------------->

        public List<Usuarios> ListaUsuarios(ref string mensaje, ref string mensajeC)//Metodo de la Lista Actualización
        {
            string comandoSql = "select * from usuarios;", etiqueta = "Biblioteca3";//Variables y Utilidades
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<Usuarios> actualizacion = new List<Usuarios>();//Creacion de una lista del tipo Actualizacion para trabajar

            dataSet = AC.LecturaSet(comandoSql, AC.ConnectionEstablecida(ref mensajeC), ref mensaje, etiqueta);//Se llena el DataSet con los datos de la BD
            if (dataSet != null)//Si e DataSet tiene datos entonces
            {
                dataTable = dataSet.Tables[0];//Se crea un DataTable y se llena con la informacion del DataSet
                actualizacion = dataTable.AsEnumerable().Select(row => new Usuarios//El datatable es como un numerable y se hace una seleccion, cada row será igual a un nuevo objeto de a clase seleccionada
                {//Por cada iterancia vamos a pasar los parámetros de mi objeto
                    IdUsuario = row.Field<int>("id_act"),
                    Nombre = row.Field<string>("nombre"),
                    Colonia = row.Field<string>("colonia"),
                    Numero = row.Field<int>("numero"),
                    CP = row.Field<int>("cp"),
                    Nom_Centro_Trabajo = row.Field<string>("nom_tentro_trabajo"),
                    Telefono = row.Field<int>("telefono"),

                }).ToList();//Se añade la información a la Lista
            }
            return actualizacion;//Se retorna la Lista 
        }



        //<-----------------------------------------------------------------------Metodo de Insertar----------------------------------------------------------------------->

        public bool InsertarUsuarios(string[] nuevoDatos, ref string mensaje, ref string mensajeC)
        {
            bool respuesta = false;

            string instrccion = "INSERT INTO usuarios (nombre, colonia, numero, cp, nom_centro Trabajo, telefono)" +
                "values ( @nombre, @colonia, @numero, @cp, @nom_centro Trabajo, @telefono )";
            SqlParameter[] info = new SqlParameter[]
            {
                new SqlParameter("@nombre",SqlDbType.VarChar, 20),
                new SqlParameter("@colonia",SqlDbType.VarChar, 50),
                new SqlParameter("@numero",SqlDbType.Int),
                new SqlParameter("@cp",SqlDbType.Int),
                new SqlParameter("@nom_centro Trabajo",SqlDbType.VarChar, 50),
                new SqlParameter("@telefono",SqlDbType.Int),
            };
            info[0].Value = nuevoDatos[0];
            info[1].Value = nuevoDatos[1];
            info[2].Value = Convert.ToInt32(nuevoDatos[2]);
            info[3].Value = Convert.ToInt32(nuevoDatos[3]);
            info[4].Value = nuevoDatos[4];
            info[5].Value = Convert.ToInt32(nuevoDatos[5]);


            respuesta = AC.BaseSegura(instrccion, AC.ConnectionEstablecida(ref mensajeC), ref mensaje, info);
            return respuesta;
        }

        ////<-----------------------------------------------------------------------Metodo de Modificar----------------------------------------------------------------------->

        // editar actualizacion---------
        public bool ActualizarUsuario(string[] nuevoDatos, ref string mensaje, ref string mensajeC, int id)
        {
            bool respuesta = false;

            string instruccion = "UPDATE usuarios " +
                " set id_usuario = @nombre, @colonia, @numero, @cp, @nom_centro Trabajo, @telefono + where id_usuario = @id_usuario;";
            SqlParameter[] evalucion = new SqlParameter[]
            {
                new SqlParameter("@nombre",SqlDbType.VarChar, 20),
                new SqlParameter("@colonia",SqlDbType.VarChar, 50),
                new SqlParameter("@numero",SqlDbType.Int),
                new SqlParameter("@cp",SqlDbType.Int),
                new SqlParameter("@nom_centro Trabajo",SqlDbType.VarChar, 50),
                new SqlParameter("@telefono",SqlDbType.Int),
            };
            info[0].Value = nuevoDatos[0];
            info[1].Value = nuevoDatos[1];
            info[2].Value = Convert.ToInt32(nuevoDatos[2]);
            info[3].Value = Convert.ToInt32(nuevoDatos[3]);
            info[4].Value = nuevoDatos[4];
            info[5].Value = Convert.ToInt32(nuevoDatos[5]);

            respuesta = AC.BaseSegura(instruccion, AC.ConnectionEstablecida(ref mensajeC), ref mensaje, evalucion);
            return respuesta;

        }
        ////<-----------------------------------------------------------------------Metodo de Eliminar----------------------------------------------------------------------->

        public bool Eliminaractualizacion(ref string Mensaje, ref string MensajeC, int ID)
        {
            bool respuesta = false;

            string instruccion = "DELETE from usuarios where id_usuario = @id_usuario";

            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@id_act",SqlDbType.Int)
            };

            evaluacion[0].Value = ID;

            respuesta = AC.BaseSegura(instruccion, AC.ConnectionEstablecida(ref MensajeC), ref Mensaje, evaluacion);

            return respuesta;
        }

    }
}
