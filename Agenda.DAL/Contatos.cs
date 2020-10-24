using Agenda.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DAL
{
    public class Contatos
    {
        string _strCon;
        //SqlConnection _con;

        public Contatos()
        {
            _strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString ;
            //_con = new SqlConnection(_strCon);
        }

        public void Adicionar(Contato contato)
        { 
            using(var con = new SqlConnection(_strCon))
            {
                con.Execute("insert into Contato (Id, Nome) values (@Id, @Nome)", contato);
                //con.Open();

                //string query = $"insert into Contato (Id, Nome) values ('{contato.Id}', '{contato.Nome}')";
                //SqlCommand cmd = new SqlCommand(query, con);
                //cmd.ExecuteNonQuery();
            }            
        }

        public Contato Obter(Guid id)
        {
            Contato contato;
            using (var con = new SqlConnection(_strCon))
            {
                contato = con.QueryFirst<Contato>("select * from Contato where Id = @Id", new { Id = id.ToString() });
                //con.Open();
                //var query = $"select * from Contato where Id = '{id}'";
                //var cmd = new SqlCommand(query, con);

                //var sqlDataReader = cmd.ExecuteReader();
                //sqlDataReader.Read();

                //contato = new Contato()
                //{
                //    Id = Guid.Parse(sqlDataReader["Id"].ToString()),
                //    Nome = sqlDataReader["Nome"].ToString()
                //};
            }

            return contato;
        }

        public List<Contato> ObterTodos()
        {
            var contatos = new List<Contato>();
            using (var con = new SqlConnection(_strCon))
            {
                var query = $"select * from Contato";
                contatos = con.Query<Contato>(query).ToList();
                //con.Open();
                //var cmd = new SqlCommand(query, con);

                //var sqlDataReader = cmd.ExecuteReader();

                //while (sqlDataReader.Read())
                //{
                //    contatos.Add(new Contato()
                //    {
                //        Id = Guid.Parse(sqlDataReader["Id"].ToString()),
                //        Nome = sqlDataReader["Nome"].ToString()
                //    });
                //}
            }

            return contatos;
        }
    }
}
