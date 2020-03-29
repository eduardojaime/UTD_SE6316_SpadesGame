using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AM_Spades
{
    public static class OnlineGameAdapter
    {
        static String cnnString = "Data Source=[SERVER];Initial Catalog=[CATALOG];User Id=[USER];Password=[PASSWORD];";

        public static bool isMyTurn(string token)
        {
            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    SqlDataReader drd = cmd.ExecuteReader();
                    if (drd.Read()) return true;
                    else return false;
                }
            }
        }

        public static void turnMade(string token)
        {
            using (SqlConnection cnn = new SqlConnection("tsts"))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void joinGame(string token)
        {
            using (SqlConnection cnn = new SqlConnection("tsts"))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static int getToken()
        {
           
            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                String cmdText = "Select * from dbo._am_game;";
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(cmdText, cnn))
                {
                    SqlDataReader drd = cmd.ExecuteReader();
                    if (drd.Read())
                    {
                        if (drd[0].ToString() == "0")
                        {
                            drd.Close();
                            cmdText = "UPDATE _AM_GAME SET PLAYER1 = 1;";
                            cmd.CommandText = cmdText;
                            cmd.ExecuteNonQuery();
                            return 1;
                        }
                        if (drd[1].ToString() == "0")
                        {
                            drd.Close();
                            cmdText = "UPDATE _AM_GAME SET PLAYER2 = 2;";
                            cmd.CommandText = cmdText;
                            cmd.ExecuteNonQuery();
                            return 2;
                        }
                        if (drd[2].ToString() == "0")
                        {
                            drd.Close();
                            cmdText = "UPDATE _AM_GAME SET PLAYER3 = 3;";
                            cmd.CommandText = cmdText;
                            cmd.ExecuteNonQuery();
                            return 3;
                        }
                        if (drd[3].ToString() == "0")
                        {
                            drd.Close();
                            cmdText = "UPDATE _AM_GAME SET PLAYER4 = 4;";
                            cmd.CommandText = cmdText;
                            cmd.ExecuteNonQuery();
                            return 4;
                        } 
                        drd.Close();
                        cmdText = "UPDATE _AM_GAME SET PLAYER1 = 1; UPDATE _AM_GAME SET PLAYER2 = 0; UPDATE _AM_GAME SET PLAYER3 = 0; UPDATE _AM_GAME SET PLAYER4 = 0;";
                        cmd.CommandText = cmdText;
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                    else
                    {
                        drd.Close();
                        cmdText = "UPDATE _AM_GAME SET PLAYER1 = 1;";
                        cmd.CommandText = cmdText;
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                }
            }
        }
    }
}
