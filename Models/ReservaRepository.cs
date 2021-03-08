namespace Atividade_3_Projeto_Integrador.Models
{
    using System;
    using MySqlConnector;
    using System.Collections.Generic;
    public class ReservaRepository
    {
         private const string _strConexao = "DataBase=Restaurante;Data Source=localhost; User id=root;";

    public void insert(Reserva novaReserva)
    {
        MySqlConnection conexao = new MySqlConnection(_strConexao); 
        conexao.Open();
        string sql = "INSERT INTO Reserva (nomeCleinte,dataReserva,pessoasReserva) VALUES(@nomeCleinte,@dataReserva,@pessoasReserva) ";
        MySqlCommand comando = new MySqlCommand(sql,conexao);
        comando.Parameters.AddWithValue("@nomeCleinte", novaReserva.nomeCleinte);
        comando.Parameters.AddWithValue("@dataReserva", novaReserva.dataReserva);
        comando.Parameters.AddWithValue("@pessoasReserva", novaReserva.pessoasReserva);
        comando.ExecuteNonQuery();
        conexao.Close();
    }
    
      public void deleteTodos() 
    {
        MySqlConnection conexao = new MySqlConnection(_strConexao); 
        conexao.Open();
        string sql = "DELETE FROM Reserva WHERE 1=1";
        MySqlCommand comando = new MySqlCommand(sql,conexao);
        comando.ExecuteNonQueryAsync();
        conexao.Close();
    }
    public List<Reserva> Query()
    {
      MySqlConnection conexao = new MySqlConnection(_strConexao); 
        conexao.Open();
        string sql = "SELECT * FROM Reserva ORDER BY nomeCleinte";
    MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
    MySqlDataReader reader = comandoQuery.ExecuteReader();
    List<Reserva> lista = new List<Reserva>();
    while (reader.Read())
    {
        Reserva pac = new Reserva();
        pac.idReserva = reader.GetInt32("idReserva");
       
        if(!reader.IsDBNull(reader.GetOrdinal("nomeCleinte")))
            pac.nomeCleinte = reader.GetString("nomeCleinte");
    
        if(!reader.IsDBNull(reader.GetOrdinal("dataReserva")))
            pac.dataReserva = reader.GetString("dataReserva");
             
        if(!reader.IsDBNull(reader.GetOrdinal("pessoasReserva")))
            pac.pessoasReserva = reader.GetInt32("pessoasReserva");
        lista.Add(pac);
    }
    conexao.Close();
    return lista;




    }
}}