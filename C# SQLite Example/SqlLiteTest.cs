using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

public class SqlLiteTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IDataReader reader;

        //Create Database
        string path = "Data Source= " + Application.dataPath + "/TestDB.db";
        Debug.Log(path);
        IDbConnection dbcon = new SqliteConnection(path);


        dbcon.Close();

        //Write in database
        IDbCommand cmnd_write = dbcon.CreateCommand();
        dbcon.Open();
        string writestr = "INSERT INTO tableHeroes (Hero, Level, Damage) VALUES ('Uthred', 1, 20)";
        cmnd_write.CommandText = writestr;
        cmnd_write.ExecuteNonQuery();
        dbcon.Close();


        //Read from Database
        IDbCommand cmnd_read = dbcon.CreateCommand();
        dbcon.Open();
        string query = "SELECT hero, level, damage FROM tableHeroes";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        while (reader.Read())
        {
            Debug.Log("Hero: " + reader[0].ToString());
            Debug.Log("Level: " + reader[1].ToString());
            Debug.Log("Damage: " + reader[2].ToString());
        }

        dbcon.Close();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
