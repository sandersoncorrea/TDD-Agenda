using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DAL
{
    public class Contatos
    {
        string _strCon;
        SqlConnection _con;

        public Contatos()
        {
            _strCon = @"Data Source=localhost;User ID=sa;Password=ACESSO;Initial Catalog=Agenda";
            _con = new SqlConnection(_strCon);
        }

        public void Adicionar(string id, string nome)
        {
            _con.Open();

            string query = $"insert into Contato (Id, Nome) values ('{id}', '{nome}')";
            SqlCommand cmd = new SqlCommand(query, _con);
            cmd.ExecuteNonQuery();

            _con.Close();
        }

        public string Obter(string id)
        {
            _con.Open();
            var query = $"select Nome from Contato where Id = '{id}'";
            var cmd = new SqlCommand(query, _con);
            var r = cmd.ExecuteScalar();
            return r.ToString();
        }
    }
}
