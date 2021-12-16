using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DBStructureCompare
{
    //[ENGLISH]
    //Unlicensed Software (Fully developed by Matheus Hoske @ 2021)
    //This means that NO ONE can legally use, copy, distribute, or modify that software without explicit permission from the creator/author (Matheus Hoske)
    //If you want to use, copy, distribute, or modify that software, contact the creator and ask for a explicit permission to use the code.

    //Contact info:
    //email: matheushoske@gmail.com
    //linkedin: https://www.linkedin.com/in/matheus-hoske/
    //github: https://github.com/matheushoske

    //[PORTUGUES]
    // Software não licenciado (totalmente desenvolvido por Matheus Hoske @ 2021)
    // Isso significa que NINGUÉM pode usar, copiar, distribuir ou modificar legalmente este software sem a permissão explícita do criador / autor (Matheus Hoske)
    // Se você deseja usar, copiar, distribuir ou modificar este software, entre em contato com o criador e peça permissão explícita para usar o código.

    // Informações de Contato:
    // email: matheushoske@gmail.com
    // linkedin: https://www.linkedin.com/in/matheus-hoske/
    // github: https://github.com/matheushoske

    public static class RotinasGerais
    {
      public  static void ExecutaSQLTarg(string sql) 
        {
            MySqlConnection tempcnTarg = new MySqlConnection(Variables.cnStringTarg);
            MySqlCommand cmdtarg2 = new MySqlCommand(sql, tempcnTarg);
            tempcnTarg.Open();
            cmdtarg2.ExecuteScalar();
            tempcnTarg.Close();
        }

        public static string RetornaSQLRef(string query, int index = 0) 
        {
            MySqlConnection tempcnRef = new MySqlConnection(Variables.cnStringRef);
            MySqlCommand cmdRef2 = new MySqlCommand(query, tempcnRef);
            MySqlDataReader readerRef2;
            tempcnRef.Open();
            readerRef2 = cmdRef2.ExecuteReader();
            readerRef2.Read();
            string result = readerRef2.GetValue(index).ToString();
            readerRef2.Dispose();
            tempcnRef.Close();
            return result;
        }
        public static string RetornaSQLTarg(string query, int index = 0)
        {
            MySqlConnection tempcn = new MySqlConnection(Variables.cnStringTarg);
            MySqlCommand cmd = new MySqlCommand(query, tempcn);
            MySqlDataReader reader;
            tempcn.Open();
            reader = cmd.ExecuteReader();
            reader.Read();
            string result = reader.GetValue(index).ToString();
            reader.Dispose();
            tempcn.Close();
            return result;
        }

        public static void WriteLog(string text)
        {
  
            string path = "DBStructureCompare.log";

            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(text);

                }
            }
            else if (File.Exists(path))
            {
                using (var sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(text);
                }
            }


        }
    }
}
