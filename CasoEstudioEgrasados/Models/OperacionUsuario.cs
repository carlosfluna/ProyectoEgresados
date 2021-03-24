using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CasoEstudioEgrasados.Models
{
    public class OperacionUsuarios
    {
        private SqlConnection con;
        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }
       
        public int Alta(Usuario usu)
    {
        Conectar();
        SqlCommand comando = new SqlCommand("insert into si_usuarios(usu_documento, usu_tipodoc, usu_nombre, usu_celular, usu_email, usu_genero, usu_aprendiz, usu_egresado, usu_areaformacion, usu_direccion, usu_barrio, usu_ciudad, usu_departamento) values (@usu_documento, @usu_tipodoc, @usu_nombre, @usu_celular, @usu_email, @usu_genero, @usu_aprendiz, @usu_egresado, @usu_areaformacion, @usu_direccion, @usu_barrio, @usu_ciudad, @usu_departamento)", con);

            comando.Parameters.Add("@usu_documento", SqlDbType.BigInt);
            comando.Parameters.Add("@usu_tipodoc", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@Usu_celular", SqlDbType.Int);
            comando.Parameters.Add("@usu_email", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_genero", SqlDbType.VarChar);
           // comando.Parameters.Add("@Usu_aprendiz", SqlDbType.Bit);
          //  comando.Parameters.Add("@Usu_egresado", SqlDbType.Bit);
            comando.Parameters.Add("@Usu_areaformacion", SqlDbType.VarChar);
          //  comando.Parameters.Add("@Usu_fechaegresado", SqlDbType.VarChar);
            comando.Parameters.Add("@Usu_direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_barrio", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_ciudad", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_departamento", SqlDbType.VarChar);

            comando.Parameters["@usu_documento"].Value = usu.Usu_documento;
            comando.Parameters["@usu_tipodoc"].Value = usu.Usu_tipodoc;
            comando.Parameters["@usu_nombre"].Value = usu.Usu_nombre;
            comando.Parameters["@Usu_celular"].Value = usu.Usu_celular;
            comando.Parameters["@usu_email"].Value = usu.Usu_email;
            comando.Parameters["@usu_genero"].Value = usu.Usu_genero;
          //  comando.Parameters["@Usu_aprendiz"].Value = usu.Usu_aprendiz;
          //  comando.Parameters["@Usu_egresado"].Value = usu.Usu_egresado;
            comando.Parameters["@Usu_areaformacion"].Value = usu.Usu_areaformacion;
           // comando.Parameters["@Usu_fechaegresado"].Value = usu.Usu_fechaegresado;
            comando.Parameters["@Usu_direccion"].Value = usu.Usu_direccion;
            comando.Parameters["@usu_barrio"].Value = usu.Usu_barrio;
            comando.Parameters["@usu_ciudad"].Value = usu.Usu_ciudad;
            comando.Parameters["@usu_departamento"].Value = usu.Usu_departamento;
            con.Open();
        int i = comando.ExecuteNonQuery();
        con.Close();
        return i;
    }
    
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
                    Usu_tipodoc = registros["usu_tipodoc"].ToString(),
                    Usu_nombre = registros["usu_nombre"].ToString(),
                    Usu_celular = int.Parse(registros["usu_celular"].ToString()),
                    Usu_email = registros["usu_email"].ToString(),
                    Usu_genero = registros["usu_genero"].ToString(),
                    Usu_aprendiz = bool.Parse(registros["usu_aprendiz"].ToString()),
                    Usu_egresado = bool.Parse(registros["usu_egresado"].ToString()),
                    Usu_areaformacion = registros["usu_areaformacion"].ToString(),
                    //Usu_fechaegresado = registros["usu_fechaegresado"],
                    Usu_direccion = registros["usu_direccion"].ToString(),
                    Usu_barrio = registros["usu_barrio"].ToString(),
                    Usu_ciudad = registros["usu_ciudad"].ToString(),
                    Usu_departamento = registros["usu_departamento"].ToString(),
                    Usu_fecharegistro = DateTime.Parse(registros["usu_fecharegistro"].ToString())
                };
                Usuarios.Add(usu);
            }
            con.Close();
            return Usuarios;
        }
      /*  
    public Usuario Recuperar(int usu_documento)
    {
        Conectar();
        SqlCommand comando = new SqlCommand("select * from si_usuarios where usu_documento = @usu_documento", con);


            comando.Parameters.Add("@usu_id", SqlDbType.Int);
            comando.Parameters["@usu_id"].Value = usu_id;

            comando.Parameters.Add("@usu_documento", SqlDbType.Int);
            comando.Parameters["@usu_documento"].Value = usu_documento;

            comando.Parameters.Add("@usu_tipodoc", SqlDbType.Int);
            comando.Parameters["@usu_tipodoc"].Value = usu_tipodoc;

            comando.Parameters.Add("@usu_nombre", SqlDbType.Int);
            comando.Parameters["@usu_nombre"].Value = usu_nombre;

            comando.Parameters.Add("@Usu_celular", SqlDbType.Int);
            comando.Parameters["@Usu_celular"].Value = Usu_celular;

            comando.Parameters.Add("@usu_email", SqlDbType.Int);
            comando.Parameters["@usu_email"].Value = usu_email;

            comando.Parameters.Add("@usu_genero", SqlDbType.Int);
            comando.Parameters["@usu_genero"].Value = usu_genero;

            comando.Parameters.Add("@Usu_aprendiz", SqlDbType.Int);
            comando.Parameters["@Usu_aprendiz"].Value = Usu_aprendiz;

            comando.Parameters.Add("@Usu_egresado", SqlDbType.Int);
            comando.Parameters["@Usu_egresado"].Value = Usu_egresado;

            comando.Parameters.Add("@Usu_areaformacion", SqlDbType.Int);
            comando.Parameters["@Usu_areaformacion"].Value = Usu_areaformacion;

            comando.Parameters.Add("@Usu_fechaegresado", SqlDbType.Int);
            comando.Parameters["@Usu_fechaegresado"].Value = Usu_fechaegresado;

            comando.Parameters.Add("@Usu_direccion", SqlDbType.Int);
            comando.Parameters["@Usu_direccion"].Value = Usu_direccion;

            comando.Parameters.Add("@usu_barrio", SqlDbType.Int);
            comando.Parameters["@usu_barrio"].Value = usu_barrio;

            comando.Parameters.Add("@usu_ciudad", SqlDbType.Int);
            comando.Parameters["@usu_ciudad"].Value = usu_ciudad;

            comando.Parameters.Add("@usu_departamento", SqlDbType.Int);
            comando.Parameters["@usu_departamento"].Value = usu_departamento;

            comando.Parameters.Add("@Usu_fecharegistro", SqlDbType.Int);
            comando.Parameters["@Usu_fecharegistro"].Value = Usu_fecharegistro;
            con.Open();
        SqlDataReader registros = comando.ExecuteReader();
        Usuario Usuarios = new Usuario();
        if (registros.Read())
        {
            Usuario.Usu_documento = int.Parse(registros["usu_documento"].ToString());
            Usuario.Descripcion = registros["descripcion"].ToString();
            Usuario.Precio = float.Parse(registros["precio"].ToString());
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