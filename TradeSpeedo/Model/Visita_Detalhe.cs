using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Globalization;

namespace TradeSpeedo.Model
{
    public class Visita_Detalhe
    {
        private SqlConnection _conexao;

        public int ID { get; set; }

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

        public DateTime Data { get; set; }

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
        public Visita_Detalhe()
        {

        }

        public List<Visita_Detalhe> Lista() =>
                _conexao
                .Query<Visita_Detalhe>("SELECT ID,Clifor,Cliente,ISNULL(Cnpj,'0') AS Cnpj,Matriz, (RTRIM(Clifor) + ' - ' + RTRIM(LTRIM(Cnpj))  + ' - ' + RTRIM(LTRIM(Matriz))) AS ClienteCompleto FROM VISITA_CLIENTE")
                .ToList();

        public List<Visita_Detalhe> ListaPerfil() =>
            _conexao
            .Query<Visita_Detalhe>("SELECT ID,Descricao FROM VISITA_PERFIL")
            .ToList();

        public List<Visita_Detalhe> ListaSortimento() =>
            _conexao
            .Query<Visita_Detalhe>("SELECT ID, Descricao FROM VISITA_SORTIMENTO")
            .ToList();

        public List<Visita_Detalhe> ListaExpo() =>
            _conexao
            .Query<Visita_Detalhe>("SELECT ID,Descricao FROM VISITA_EXPOSICAO")
            .ToList();

        public List<Visita_Detalhe> ListaIdCliente(int IdVisita, string dia) =>
            _conexao
            .Query<Visita_Detalhe>("SELECT ID_Cliente from VISITA_DETALHE where ID_VISITA = '" + IdVisita + "' AND DIA = '" + dia + "'")
            .ToList();


        public void Salva()
        {
            _conexao.Open();

            var sql = $"INSERT INTO VISITA_DETALHE(ID_VISITA,DIA,DATA,ID_CLIFOR,LOCAL,COMPRADOR,ID_PERFIL,ID_SORTIMENTO,ID_EXPOSICAO,CONCORRENTE,COMENTARIOS,H1,H2,H3,H4,HT1,HT2,HT3,HT4) VALUES('{ID_VISITA}','{Dia}','{Data.ToString("yyyyMMdd")}','{idClifor}','{Local}','{Comprador}','{Id_Perfil}','{Id_Sortimento}','{Id_Exposicao}','{Concorrente}','{Comentarios}','{H1}','{H2}','{H3}','{H4}','{Ht1}','{Ht2}','{Ht3}','{Ht4}')";
            new SqlCommand(sql, _conexao).ExecuteNonQuery();

            _conexao.Close();
        }

        public void Altera()
        {
            _conexao.Open();

            var sql = $"UPDATE VISITA_DETALHE SET DIA = '{Dia}', DATA = '{Data.ToString("yyyyMMdd")}', ID_CLIFOR = '{idClifor}',LOCAL= '{Local}',COMPRADOR= '{Comprador}',ID_PERFIL= '{Id_Perfil}',ID_SORTIMENTO = '{Id_Sortimento}', ID_EXPOSICAO = '{Id_Exposicao}', CONCORRENTE = '{Concorrente}',COMENTARIOS = '{Comentarios}', H1 = '{H1}', H2 = '{H2}', H3 = '{H3}', H4 = '{H4}', HT1 = '{Ht1}', HT2 = '{Ht2}', HT3 = '{Ht3}', HT4 = '{Ht3}' WHERE ID = '{ID}' AND ID_VISITA = '{ID_VISITA}' AND DIA = '{Dia}'";
            new SqlCommand(sql, _conexao).ExecuteNonQuery();

            _conexao.Close();
        }

        public void Carrega(int idVisita, string dia, DateTime data, string cliente)
        {
            _conexao.Open();


            var sql = $"SELECT " +
                       "A.ID " +
                       ",A.ID_VISITA " +
                       ",A.DIA " +
                       ",A.DATA " +
                       ",A.ID_CLIFOR " +
                       ",A.LOCAL " +
                       ",A.COMPRADOR  " +
                       ",B.ID AS PERFIL " +
                       ",C.ID AS SORTIMENTO " +
                       ",D.ID AS EXPOSICAO " +
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
                          "AND A.DIA = '" + dia + "' " +
                          "AND A. DATA ='" + data.ToString("yyyy/MM/dd") + "'" +
                          "AND E.CLIENTE='" + cliente + "'";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();

            while (dr.Read())
            {
                ID = Convert.ToInt32(dr["ID"].ToString());
                ID_VISITA = Convert.ToInt32(dr["ID_VISITA"].ToString());
                Dia = dr["DIA"].ToString();
                Data = Convert.ToDateTime(dr["DATA"].ToString());
                idClifor = Convert.ToInt32(dr["ID_CLIFOR"].ToString());
                Local = dr["LOCAL"].ToString();
                Comprador = dr["COMPRADOR"].ToString();
                Id_Perfil = Convert.ToInt32(dr["PERFIL"].ToString());
                Id_Sortimento = Convert.ToInt32(dr["SORTIMENTO"].ToString());
                Id_Exposicao = Convert.ToInt32(dr["EXPOSICAO"].ToString());
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