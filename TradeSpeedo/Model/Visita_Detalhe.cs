using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TradeSpeedo.Model
{
    public class Visita_Detalhe
    {
        private SqlConnection _conexao;

        public int? ID { get; set; }

        public int? ID_VISITA { get; set; }

        public string Visita { get; set; }

        public string Descricao { get; set; }

        private string _stringconexao { get; set; }

        public int idClifor { get; set; }

        public string Clifor { get; set; }

        public string Cliente { get; set; }        

        public Int64 Cnpj { get; set; }

        public string Matriz { get; set; }

        public string ClienteCompleto { get; set; }    
        
        public string Dia { get; set; }

        public string Data { get; set; }

        public string Local { get; set; }

        public string Comprador { get; set; }

        public int Id_Perfil { get; set; }

        public string Perfil { get; set; }

        public int Id_Sortimento { get; set; }

        public string Sortimento { get; set; }

        public int Id_Exposicao { get; set; }

        public string Exposicao { get; set; }

        public string Concorrente { get; set; }

        public string Comentarios { get; set; }

        public string H1 { get; set; }

        public string H2 { get; set; }

        public string H3 { get; set; }

        public string H4 { get; set; }

        public string Ht1 { get; set; }

        public string Ht2 { get; set; }

        public string Ht3 { get; set; }

        public string Ht4 { get; set; }

        public Visita_Detalhe(string stringConexao)
        {
            _conexao = new SqlConnection(stringConexao);
            _stringconexao = stringConexao;
        }

        public List<Visita_Detalhe> Lista()
        {
            var visitas = new List<Visita_Detalhe>();

            _conexao.Open();

            var sql = $"SELECT ID,rtrim(ltrim(CLIFOR)) AS CLIFOR,rtrim(ltrim(CLIENTE))AS CLIENTE,isnull(rtrim(ltrim(CNPJ)),'0') as CNPJ,MATRIZ FROM VISITA_CLIENTE";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();

            while (dr.Read())
            {
                var visita = new Visita_Detalhe(_stringconexao);

                visita.idClifor = Convert.ToInt32(dr["ID"].ToString());
                visita.Clifor = dr["CLIFOR"].ToString();
                visita.Cliente = dr["CLIENTE"].ToString();
                visita.Cnpj = Convert.ToInt64(dr["CNPJ"].ToString());
                visita.Matriz = dr["MATRIZ"].ToString();
                visita.ClienteCompleto = dr["CLIFOR"].ToString() + ' ' + '-' + ' ' + Convert.ToInt64(dr["CNPJ"].ToString()) + ' ' + '-' + ' ' + dr["MATRIZ"].ToString();

                visitas.Add(visita);
            }

            _conexao.Close();

            return visitas;
        }

        public List<Visita_Detalhe> ListaPerfil()
        {
            var visitas = new List<Visita_Detalhe>();

            _conexao.Open();

            var sql = $"SELECT ID,DESCRICAO FROM VISITA_PERFIL";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();

            while (dr.Read())
            {
                var visita = new Visita_Detalhe(_stringconexao);

                visita.ID = Convert.ToInt32(dr["ID"].ToString());
                visita.Descricao = dr["DESCRICAO"].ToString();

                visitas.Add(visita);
            }

            _conexao.Close();

            return visitas;
        }

        public List<Visita_Detalhe> ListaSortimento()
        {
            var visitas = new List<Visita_Detalhe>();

            _conexao.Open();

            var sql = $"SELECT ID,DESCRICAO FROM VISITA_SORTIMENTO";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();

            while (dr.Read())
            {
                var visita = new Visita_Detalhe(_stringconexao);

                visita.ID = Convert.ToInt32(dr["ID"].ToString());
                visita.Descricao = dr["DESCRICAO"].ToString();

                visitas.Add(visita);
            }

            _conexao.Close();

            return visitas;
        }

        public List<Visita_Detalhe> ListaExpo()
        {
            var visitas = new List<Visita_Detalhe>();

            _conexao.Open();

            var sql = $"SELECT ID,DESCRICAO FROM VISITA_EXPOSICAO";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();

            while (dr.Read())
            {
                var visita = new Visita_Detalhe(_stringconexao);

                visita.ID = Convert.ToInt32(dr["ID"].ToString());
                visita.Descricao = dr["DESCRICAO"].ToString();

                visitas.Add(visita);
            }

            _conexao.Close();

            return visitas;
        }

        public void Salva()
        {
            
            _conexao.Open();

            
            var sql = $"INSERT INTO VISITA_DETALHE(ID_VISITA,DIA,DATA,ID_CLIFOR,LOCAL,COMPRADOR,ID_PERFIL,ID_SORTIMENTO,ID_EXPOSICAO,CONCORRENTE,COMENTARIOS,H1,H2,H3,H4,HT1,HT2,HT3,HT4) VALUES('{ID_VISITA}','{Dia}','{Data}','{idClifor}','{Local}','{Comprador}','{Id_Perfil}','{Id_Sortimento}','{Id_Exposicao}','{Concorrente}',{Comentarios},'{H1}','{H2}','{H3}','{H4}','{Ht1}','{Ht2}','{Ht3}','{Ht4}')";
            new SqlCommand(sql, _conexao).ExecuteNonQuery();

            _conexao.Close();   
        }

        public void Altera()
        {
            _conexao.Open();

            var sql = $"UPDATE VISITA_DETALHE SET DIA = '{Dia}', DATA = '{Data}', ID_CLIFOR = '{idClifor}',LOCAL= '{Local}',COMPRADOR= '{Comprador}',ID_PERFIL= '{Id_Perfil}',ID_SORTIMENTO = '{Id_Sortimento}', ID_EXPOSICAO = '{Id_Exposicao}', CONCORRENTE = '{Concorrente}',COMENTARIOS = '{Comentarios}', H1 = '{H1}', H2 = '{H2}', H3 = '{H3}', H4 = '{H4}', HT1 = '{Ht1}', HT2 = '{Ht2}', HT3 = '{Ht3}', HT4 = '{Ht3}' WHERE ID = '{ID}' AND ID_VISITA = '{ID_VISITA}' AND DIA = '{Dia}'";
            new SqlCommand(sql, _conexao).ExecuteNonQuery();

            _conexao.Close();
        }

        public void Carrega(int idVisita, string dia)
        {
            _conexao.Open();

            var sql = $"SELECT " +
                       "A.ID " +
                       ",A.ID_VISITA " +
                       ",A.DIA " +
                       ",A.DATA " +
                       ",E.CLIENTE " +
                       ",A.LOCAL " +
                       ",A.COMPRADOR  " +
                       ",B.DESCRICAO AS PERFIL " +
                       ",C.DESCRICAO AS SORTIMENTO " +
                       ",D.DESCRICAO AS EXPOSICAO " +
                       ",A.CONCORRENTE " +
                       ",A.COMENTARIOS " +
                       ",A.H1 " +
                       ",A.H2 " +
                       ",A.H3 " +
                       ",A.H4 " +
                       ",A.HT1 " +
                       ",A.HT2 " +
                       ",A.HT3 " +
                       ",A.HT4 " +
                            "FROM VISITA_DETALHE A " +
                            "JOIN VISITA_PERFIL B ON A.ID_PERFIL = B.ID " +
                            "JOIN VISITA_SORTIMENTO C ON A.ID_SORTIMENTO = C.ID " +
                            "JOIN VISITA_EXPOSICAO D ON A.ID_EXPOSICAO = D.ID " +
                            "JOIN VISITA_CLIENTE E ON A.ID_CLIFOR = E.ID " +
                        "WHERE A.ID_VISITA = '" + idVisita + "' " +
                          "AND A.DIA = '" + dia + "' ";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();

            while (dr.Read())
            {
                ID = Convert.ToInt32(dr["ID"].ToString());
                ID_VISITA = Convert.ToInt32(dr["ID_VISITA"].ToString());
                Dia = dr["DIA"].ToString();
                Data = dr["DATA"].ToString();
                Cliente = dr["CLIENTE"].ToString();
                Local = dr["LOCAL"].ToString();
                Comprador = dr["COMPRADOR"].ToString();
                Perfil = dr["PERFIL"].ToString();
                Sortimento = dr["SORTIMENTO"].ToString();
                Exposicao = dr["EXPOSICAO"].ToString();
                Concorrente = dr["CONCORRENTE"].ToString();
                Comentarios = dr["COMENTARIOS"].ToString();
                H1 = dr["H1"].ToString();
                H2 = dr["H2"].ToString();
                H3 = dr["H3"].ToString();
                H4 = dr["H4"].ToString();                
                Ht1 = dr["HT1"].ToString();
                Ht2 = dr["HT2"].ToString();
                Ht3 = dr["HT3"].ToString();
                Ht4 = dr["HT4"].ToString();

            }

            _conexao.Close();

        }

        public void IdDetalheRec()
        {
            _conexao.Open();

            var sql = $"SELECT TOP 1 MAX(ID) AS ID,ID_VISITA,DIA FROM VISITA_DETALHE GROUP BY ID,ID_VISITA,DIA order by ID desc";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();

            while (dr.Read())
            {
                ID = Convert.ToInt32(dr["ID"].ToString());
                ID_VISITA = Convert.ToInt32(dr["ID_VISITA"].ToString());
                Dia = dr["DIA"].ToString();
            }

            _conexao.Close();
        }


    }
}