using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SqlServerConnectApp.services
{
    public static class DB_Connection
    {
        /// <summary>
        /// データベース接続
        /// </summary>
        /// <returns></returns>
        private static SqlConnection? Connect()
        {
            string? connectionString = ConfigurationManager.AppSettings["DatabaseConnectionString"];

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                {
                    connection.Open();
                    Console.WriteLine("接続成功。");
                    
                    return connection;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("接続エラー: " + e.Message);
                return null;
            }
        }

        /// <summary>
        /// Productデータ取得（一覧データ）
        /// </summary>
        /// <param name="connection"></param>
        public static void GetProduct()
        {
            SqlConnection? connection = Connect();

            if (connection is not null)
            {
                try
                {
                    // SQLクエリを実行するためのコマンドを作成
                    string sql = "SELECT * FROM [WpfDB].[dbo].[Product]";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                Console.WriteLine($"ID: {id}, Name: {name}");
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("SQLエラー：" + e.Message);
                }
                finally
                {
                    connection?.Dispose();
                }
            }
            else
            {
                Console.WriteLine("データベース接続に失敗しました。");
            }
        }


        /// <summary>
        /// Product登録処理
        /// </summary>
        public static void InsertProduct()
        {
            SqlConnection? connection = Connect();

            if (connection is not null)
            {
                try
                {
                    string insertSql = "INSERT INTO [WpfDB].[dbo].[Product] (Name, Price) VALUES (@Value1, @Value2)";
                    using (SqlCommand command = new SqlCommand(insertSql, connection))
                    {
                        // パラメータを設定
                        command.Parameters.AddWithValue("@Value1", "test4"); // Column1の値
                        command.Parameters.AddWithValue("@Value2", 69); // Column2の値

                        // INSERT文を実行
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Insert処理: {rowsAffected}");
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("SQLエラー：" + e.Message);
                }
                finally
                {
                    connection?.Dispose();
                }
            }
            else
            {
                Console.WriteLine("データベース接続に失敗しました。");
            }
        }

        /// <summary>
        /// Product更新処理
        /// </summary>
        public static void UpdateProduct()
        {
            SqlConnection? connection = Connect();

            if (connection is not null)
            {
                try
                {
                    string updateSql = "UPDATE [WpfDB].[dbo].[Product] SET Name = @NewValue1, Price = @NewValue2  WHERE Id = @ConditionValue";
                    using (SqlCommand updateCommand = new SqlCommand(updateSql, connection))
                    {
                        // パラメータを設定
                        updateCommand.Parameters.AddWithValue("@NewValue1", "Update"); // 更新する値
                        updateCommand.Parameters.AddWithValue("@NewValue2", 50); // 更新する値
                        updateCommand.Parameters.AddWithValue("@ConditionValue", 2); // 条件の値

                        // UPDATE文を実行
                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        Console.WriteLine($"Update処理: {rowsAffected}");
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("SQLエラー: " + e.Message);
                }
                finally
                {
                    // connectionの接続切断 & リソース解放
                    connection?.Dispose();
                }

            }
            else
            {
                Console.WriteLine("データベース接続に失敗しました。");
            }

        }

        /// <summary>
        /// Productの削除処理
        /// </summary>
        public static void DeleteProduct()
        {
            SqlConnection? connection = Connect();

            if (connection is not null)
            {
                try
                {
                    string deleteSql = "DELETE FROM [WpfDB].[dbo].[Product] WHERE Id = @ConditionValue";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteSql, connection))
                    {
                        // パラメータを設定
                        deleteCommand.Parameters.AddWithValue("@ConditionValue", 2); // 削除の条件となる値

                        // DELETE文を実行
                        int rowsAffected = deleteCommand.ExecuteNonQuery();
                        Console.WriteLine($"削除処理: {rowsAffected}");
                    }
                }catch (SqlException e)
                {
                    Console.WriteLine("SQLエラー: " + e.Message);
                }
                finally
                {
                    connection?.Dispose();
                }
                
            }
            else
            {
                Console.WriteLine("データベース接続に失敗しました。");
            }
        }
    }
}
