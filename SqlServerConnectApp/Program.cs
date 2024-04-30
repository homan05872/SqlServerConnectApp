using System;
using System.Data.SqlClient;
using SqlServerConnectApp.services;

class Program
{
    static void Main()
    {
        // Select処理
        DB_Connection.GetProduct();

        // INSERT処理
        //DB_Connection.InsertProduct();

        // Update処理
        //DB_Connection.UpdateProduct();

        // 削除処理
        //DB_Connection.DeleteProduct();
    }    
}