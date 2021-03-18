using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CasoEstudioEgrasados.Models
{
    public class OperacionUsuario
    {
        private SqlConnection con;
        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }
        /*
    public int Alta(Usuarios usu)
    {
        Conectar();
        SqlCommand comando = new SqlCommand("insert into si_usuarios(codigo, descripcion, precio) values (@codigo, @descripcion, @precio)", con);

        comando.Parameters.Add("@codigo", SqlDbType.Int);
        comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
        comando.Parameters.Add("@precio", SqlDbType.Float);
        comando.Parameters["@codigo"].Value = usu.Codigo;
        comando.Parameters["@descripcion"].Value = usu.Descripcion;
        comando.Parameters["@precio"].Value = usu.Precio;
        con.Open();
        int i = comando.ExecuteNonQuery();
        con.Close();
        return i;
    }
    */
        public List<Usuario> RecuperarTodos()
        {
            Conectar();
            List<Usuario> Usuarios = new List<Usuario>();
            SqlCommand com = new SqlCommand("select * from si_usuarios", con);

            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Usuario usu = new Usuario
                {
                    Usu_id = int.Parse(registros["usu_id"].ToString()),
                    Usu_documento = int.Parse(registros["usu_documento"].ToString()),
                   /* Usu_tipodoc = registros["usu_tipodoc"].ToString(),
                    Usu_nombre = registros["usu_nombre"].ToString(),
                    Usu_celular = int.Parse(registros["usu_celular"].ToString()),
                    Usu_email = registros["usu_email"].ToString(),
                    Usu_genero = registros["usu_genero"].ToString(),
                    Usu_aprendiz = bool.Parse(registros["usu_aprendiz"].ToString()),
                    Usu_egresado = bool.Parse(registros["usu_egresado"].ToString()),
                    Usu_areaformacion = registros["usu_areaformacion"].ToString(),
                    Usu_fechaegresado = DateTime.Parse(registros["usu_fechaegresado"].ToString()),
                    Usu_direccion = registros["usu_direccion"].ToString(),
                    Usu_barrio = registros["usu_barrio"].ToString(),
                    Usu_ciudad = registros["usu_ciudad"].ToString(),
                    Usu_departamento = registros["usu_departamento"].ToString(),*/
                    Usu_fecharegistro = DateTime.Parse(registros["usu_fecharegistro"].ToString())
                };
                Usuarios.Add(usu);
            }
            con.Close();
            return Usuarios;
        }
        /*
    public Usuarios Recuperar(int usu_documento)
    {
        Conectar();
        SqlCommand comando = new SqlCommand("select * from si_usuarios where usu_documento = @usu_documento", con);


        comando.Parameters.Add("@usu_documento", SqlDbType.Int);
        comando.Parameters["@usu_documento"].Value = usu_documento;
        con.Open();
        SqlDataReader registros = comando.ExecuteReader();
        Usuarios Usuarios = new Usuarios();
        if (registros.Read())
        {
            Usuarios.Usu_documento = int.Parse(registros["usu_documento"].ToString());
            Usuarios.Descripcion = registros["descripcion"].ToString();
            Usuarios.Precio = float.Parse(registros["precio"].ToString());
        }
        con.Close();
        return Usuarios;
    }
    public int Modificar(Usuarios usu)
    {
        Conectar();
        SqlCommand comando = new SqlCommand("update si_usuarios set descripcion = @descripcion, precio = @precio where usu_documento = @usu_documento", con);

        comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
        comando.Parameters["@descripcion"].Value = usu.Descripcion;
        comando.Parameters.Add("@precio", SqlDbType.Float);
        comando.Parameters["@precio"].Value = usu.Precio;
        comando.Parameters.Add("@codigo", SqlDbType.Int);
        comando.Parameters["@codigo"].Value = usu.Codigo;
        con.Open();
        int i = comando.ExecuteNonQuery();
        con.Close();
        return i;
    }
    public int Borrar(int usu_documento)
    {
        Conectar();
        SqlCommand comando = new SqlCommand("delete from si_usuarios where usu_documento = @usu_documento", con);

        comando.Parameters.Add("@usu_documento", SqlDbType.BigInt);

        comando.Parameters["@usu_documento"].Value = usu_documento;
        con.Open();
        int i = comando.ExecuteNonQuery();
        con.Close();
        return i;
    }*/
    }
}