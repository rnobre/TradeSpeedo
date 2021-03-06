﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace TradeSpeedo.Model
{
    public class Visita_Capa
    {
        private string _stringconexao;

        public int ID { get; set; }
        public string Visita { get; set; }
        public string Periodo { get; set; }
        public string Representante { get; set; }
        public string Regiao { get; set; }
        public string Objetivo { get; set; }
        public string Dia { get; set; }

        public Visita_Capa() { }
        public Visita_Capa(string stringConexao) =>
            _stringconexao = stringConexao;

        public void Salvar()
        {
            string sql;

            if (this.ID == 0)
                sql = $@"INSERT INTO VISITA (VISITA, PERIODO, REPRESENTANTE, REGIAO, OBJETIVO)
                        VALUES ('{Visita}','{Periodo}','{Representante}','{Regiao}','{Objetivo}')";
            else
                sql = $@"UPDATE VISITA SET 
                        VISITA = '{Visita}',
                        PERIODO = '{Periodo}',
                        REPRESENTANTE = '{Representante}',
                        REGIAO = '{Regiao}',
                        OBJETIVO = '{Objetivo}'
                        WHERE ID = {ID}";

            using (var conexao = new SqlConnection(_stringconexao))
                conexao.Execute(sql);
        }

        public static int GetNovoIDVisita(string stringConexao)
        {
            var sql = $"SELECT MAX(ID) AS ID from VISITA";

            using (var conexao = new SqlConnection(stringConexao))
                return conexao.QueryFirst<int>(sql);
        }

        public void Carrega(int id)
        {
            using (var conexao = new SqlConnection(_stringconexao))
            {
                conexao.Open();
                var sql = $"SELECT TOP 1 ID, VISITA, PERIODO, REPRESENTANTE,REGIAO,OBJETIVO FROM VISITA WHERE ID = '{id}'";

                using (var dr = new SqlCommand(sql, conexao).ExecuteReader())
                {
                    if (dr.Read())
                    {
                        ID = Convert.ToInt32(dr["ID"].ToString());
                        Visita = dr["VISITA"].ToString();
                        Periodo = dr["PERIODO"].ToString();
                        Representante = dr["REPRESENTANTE"].ToString();
                        Regiao = dr["REGIAO"].ToString();
                        Objetivo = dr["OBJETIVO"].ToString();
                    }

                }
            }
        }

        public void Carrega(string visita)
        {
            var sql = $"SELECT TOP 1 ID, VISITA, PERIODO, REPRESENTANTE,REGIAO,OBJETIVO FROM VISITA WHERE VISITA = '{visita}'";

            using (var conexao = new SqlConnection(_stringconexao))
            {
                conexao.Open();
                using (var dr = new SqlCommand(sql, conexao).ExecuteReader())
                {
                    if (dr.Read())
                    {
                        ID = Convert.ToInt32(dr["ID"].ToString());
                        Visita = dr["VISITA"].ToString();
                        Periodo = dr["PERIODO"].ToString();
                        Representante = dr["REPRESENTANTE"].ToString();
                        Regiao = dr["REGIAO"].ToString();
                        Objetivo = dr["OBJETIVO"].ToString();
                    }
                }
            }
        }

        public static List<Visita_Capa> Lista(int Id, string stringConexao)
        {
            var sql = $"SELECT ID_VISITA 'ID', Dia FROM VISITA_DETALHE WHERE ID_VISITA = '{Id}'";

            using (var conexao = new SqlConnection(stringConexao))
                return conexao.Query<Visita_Capa>(sql).AsList();
        }


        public void GeraTabela(int idVisita, Table tb, string stringconexao)
        {
            var i = 0;

            var sql = $"SELECT A.DATA ,A.DIA " +
                            ",B.CLIENTE " +
                            ",CONVERT (VARCHAR (10), A.DATA,103) AS DATA  " +
                        "FROM VISITA_DETALHE A " +
                        "JOIN VISITA_CLIENTE B ON A.ID_CLIFOR = B.ID " +
                        "WHERE A.ID_VISITA = '" + idVisita + "'";

            using (var conexao = new SqlConnection(stringconexao))
            {
                conexao.Open();
                using (var sda = new SqlDataAdapter(sql, stringconexao))
                {
                    using (var ds = new DataSet())
                    {
                        sda.Fill(ds, "Visitas");

                        foreach (DataRow dsRow in ds.Tables["Visitas"].Rows)
                        {
                            var j = 0;
                            var tRow = new TableRow();


                            foreach (DataColumn dsCol in ds.Tables["Visitas"].Columns)
                            {
                                var tCell = new TableCell();

                                if (j == 0)
                                {
                                    tCell.Text = string.Format("<a style='outline:none;' href='Visitas_Detalhe.aspx?id=" + idVisita + "&dia=" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "&data=" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "&cliente=" + ds.Tables[0].Rows[i].ItemArray[2].ToString() + "'><img style='outline:none;' src='/Image/bumerangue.ico'></img></a> ");
                                }

                                else
                                {
                                    tCell.Text = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                                }

                                tRow.Cells.Add(tCell);
                                j++;
                            }


                            tb.Rows.Add(tRow);
                            i++;
                        }
                    }
                }
            }
        }

        public void Valida(int IdVisita)
        {
            using (var conexao = new SqlConnection(_stringconexao))
            {
                conexao.Open();
                var sql = $@"SELECT TOP 1 ID FROM VISITA_CONCLUSAO WHERE ID_VISITA = '{IdVisita}'";

                using (var dr = new SqlCommand(sql, conexao).ExecuteReader())
                {
                    if(dr.Read())
                    {
                        ID = Convert.ToInt32(dr["ID"].ToString());
                    }
                }

            }
        }
 
    }
}
