using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

public class bancoDeDados : MonoBehaviour
{
       private string connectionString;

    void Start()
    {
        // Defina o caminho para o banco de dados SQLite (pode ser na pasta Assets do Unity)
        string dbName = "example.db";
        string dbPath = "URI=file:" + Application.dataPath + "/" + dbName;

        // Crie a string de conexão
        connectionString = dbPath;

       
    }

    // Função para criar a tabela de jogador
    void CreatePlayerTable()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                // Crie a tabela de jogador com alguns campos simples (ID, Nome, Pontuação)
                string sqlQuery = "CREATE TABLE IF NOT EXISTS PlayerTable (ID INTEGER PRIMARY KEY, Name TEXT, Score INTEGER)";
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
            }

            dbConnection.Close();
        }
    }

    // Exemplo de como inserir dados na tabela
    void InsertPlayerData(string playerName, int playerScore)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                // Insira dados na tabela de jogador
                string sqlQuery = "INSERT INTO PlayerTable (Name, Score) VALUES ('" + playerName + "', " + playerScore + ")";
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
            }

            dbConnection.Close();
        }
    }

    // Exemplo de como ler dados da tabela
    void ReadPlayerData()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                // Leia todos os dados da tabela de jogador
                string sqlQuery = "SELECT * FROM PlayerTable";
                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int score = reader.GetInt32(2);

                        Debug.Log("ID: " + id + ", Name: " + name + ", Score: " + score);
                    }
                }
            }

            dbConnection.Close();
        }
    }

    void Update()
    {
        // Exemplo: Chame a função InsertPlayerData ao pressionar a tecla 'I'
        if (Input.GetKeyDown(KeyCode.I))
        {
            InsertPlayerData("Jogador1", 100);
        }

        // Exemplo: Chame a função ReadPlayerData ao pressionar a tecla 'R'
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReadPlayerData();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            // Chame a função para criar a tabela (ou faça isso em outro lugar, como em um botão)
            CreatePlayerTable();
        }

         
    }



}
