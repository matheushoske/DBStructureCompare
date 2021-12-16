using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
    



namespace DBStructureCompare
{
    public partial class frmStructureCorrector : Form
    {
        
        MySqlConnection cnRef; // Conexão de referência para a correção
        MySqlConnection cnTarget; // Conexão do BD que terá a estrutura corrigida
        string bdREF;
        string bdTARG;
        int countErros;
        public frmStructureCorrector()
        {
            InitializeComponent();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            string texto;
            StartConnections();
            CompareStructure();
            texto = "Processamento Finalizado com " + countErros + " erros. \n Verifique o Log \"DBStructureCompare.log\" para mais informações. ";
            MessageBox.Show(texto, "Sucesso",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CompareStructure() 
        {
            CorrectDifferentTables();
            CorrectDifferentColumns();

        }

        
        private void CorrectDifferentTables( bool CorrigeEngine =false) // Encontra e corrige tabelas diferentes
        {
            string csql = "";
            int TabCriadas = 0;
            lblComparando.Text = "Comparando Tabelas...";
            //SQLS não parametrizadas devido ao baixo risco de SQL Injection nas situações de utilização deste específico software
            //Porém é recomendado, sempre que possível, a parametrização de suas queries.
            //Documentação Working with Parameters : https://dev.mysql.com/doc/connector-net/en/connector-net-tutorials-parameters.html
            //Você também pode encontrar exemplos de parametrização em outros projetos publicados no meu github
            //https://github.com/matheushoske
            pgbProgress.Maximum = int.Parse(RotinasGerais.RetornaSQLRef("SELECT count(*) FROM information_schema.TABLES WHERE table_schema = \"" + bdREF + "\""));
            pgbProgress.Value = 0;
            string queryref = "SELECT TABLE_NAME, table_type, ENGINE, table_collation FROM information_schema.TABLES WHERE table_schema = \"" + bdREF + "\" order by table_type, table_name";
            MySqlCommand cmdRef = new MySqlCommand(queryref, cnRef);
            MySqlDataReader readerRef;
            cnRef.Open();
            readerRef = cmdRef.ExecuteReader();
            while (readerRef.Read()) 
            {
                try
                {
                    string reftabela = readerRef.GetString("table_name");
                    if (reftabela == "switches_funcionalidades") 
                    { 
                        Console.WriteLine(); 
                    }
                    string reftype = readerRef.GetString("table_type");
                    string refengine = readerRef["ENGINE"] as string;
                    string refcollation = readerRef["table_collation"] as string;


                    string querytarg = "SELECT TABLE_NAME, table_type, ENGINE, table_collation FROM information_schema.TABLES WHERE table_schema = \"" + bdTARG + "\" and table_name = \"" + reftabela + "\"";
                    MySqlCommand cmdtarg = new MySqlCommand(querytarg, cnTarget);
                    MySqlDataReader readerTarg;
                    cnTarget.Open();
                    readerTarg = cmdtarg.ExecuteReader();
                    if (readerTarg.Read())
                    {
                        //EXISTE A TABELA
                        //RECUPERA OS DADOS DA TABELA TARGET
                        string targtype = readerTarg.GetString("table_type");
                        string targengine = readerTarg["ENGINE"] as string;
                        string targcollation = readerTarg["table_collation"] as string;
                        try
                        {
                            if (reftype != targtype)
                            {
                                csql = "REPAIR TABLE " + reftabela;
                                RotinasGerais.ExecutaSQLTarg(csql);
                            }

                            if (refengine != targengine && CorrigeEngine)
                            {
                                csql = "ALTER TABLE " + reftabela + " ENGINE = " + refengine;
                                RotinasGerais.ExecutaSQLTarg(csql);
                            }


                        }
                        catch (Exception ex)
                        {
                            RotinasGerais.WriteLog("Não foi possível executar o SQL: " + csql + "\n\n Erro: " + ex);
                            countErros++;
                        }
                    }
                    else
                    {
                        //TABELA NÃO EXISTE / CRIAR
                        //ENCONTRANDO E EXECUTANDO CREATE DA TABELA NO BANCO DE REFERENCIA
                        CriarTabela(reftabela);
                        TabCriadas++;
                      
                        lblTabelasCorrigidas.Text = "Tabelas criadas: " + TabCriadas;
                    }
                }
                catch (Exception ex)
                {
                    RotinasGerais.WriteLog("Erro ao comparar Tabelas: " + ex);
                    countErros++;
                }
                cnTarget.Close();
                lblQuantidadeErros.Text = "Erros: "+ countErros.ToString();
                pgbProgress.Value++;
                lblProgress.Text = pgbProgress.Value.ToString() + "/" + pgbProgress.Maximum.ToString();
                Application.DoEvents();
            }
            cnRef.Close();
        }



        private void CorrectDifferentColumns() // Encontra e corrige COLUNAS diferentes
        {
            int ColCriadas = 0;
            lblComparando.Text = "Comparando Colunas...";
            //SQLS não parametrizadas devido ao baixo risco de SQL Injection nas situações de utilização deste específico software
            //Porém é recomendado, sempre que possível, a parametrização de suas queries.
            //Documentação Working with Parameters : https://dev.mysql.com/doc/connector-net/en/connector-net-tutorials-parameters.html
            //Você também pode encontrar exemplos de parametrização em outros projetos publicados no meu github
            //https://github.com/matheushoske
            pgbProgress.Maximum = int.Parse(RotinasGerais.RetornaSQLRef("SELECT count(*) FROM information_schema.columns WHERE table_schema = \"" + bdREF + "\""));
            pgbProgress.Value = 0;
            string queryref = "SELECT table_schema, TABLE_NAME, column_name, column_default, is_nullable, column_type, column_key, extra FROM information_schema.columns WHERE table_schema = \"" + bdREF + "\" order by table_name";
            MySqlCommand cmdRef = new MySqlCommand(queryref, cnRef);
            MySqlDataReader readerRef;
            cnRef.Open();
            readerRef = cmdRef.ExecuteReader();

            List<string> PrimaryAdded = new List<string>();
            while (readerRef.Read())
            {
                try
                {


                    string tempsql;

                    string reftabela = readerRef.GetString("table_name");
                    string refcoluna = readerRef.GetString("column_name");
                    string refcoldefault = readerRef["column_default"] as string;
                    string refcolisnull = readerRef["is_nullable"] as string;
                    string refcoltype = readerRef["column_type"] as string;
                    string refcolkey = readerRef["column_key"] as string;
                    string refcolextra = readerRef["extra"] as string;


                    string querytarg = "SELECT table_schema, TABLE_NAME, column_name, column_default, is_nullable, column_type, column_key, extra FROM information_schema.columns WHERE table_schema = \"" + bdTARG + "\" and table_name = \"" + reftabela + "\" and column_name = \"" + refcoluna + "\"";
                    MySqlCommand cmdtarg = new MySqlCommand(querytarg, cnTarget);
                    MySqlDataReader readerTarg;
                    cnTarget.Open();
                    readerTarg = cmdtarg.ExecuteReader();
                    if (readerTarg.Read())
                    {
                        //EXISTE A COLUNA
                        //RECUPERA OS DADOS DA COLUNA TARGET
                        string targcoldefault = readerRef["column_default"] as string;
                        string targcolisnull = readerRef["is_nullable"] as string;
                        string targcoltype = readerRef["column_type"] as string;
                        string targcolkey = readerRef["column_key"] as string;
                        string targcolextra = readerRef["extra"] as string;

                        //CORRIGE AS DIVERGENCIAS ENTRE AS COLUNAS


                    }
                    else
                    {
                        tempsql = "select table_type from information_schema.TABLES " +
                            " where table_schema = \"" + bdREF + "\" and table_name = \"" + reftabela + "\"";
                        if (RotinasGerais.RetornaSQLRef(tempsql) != "VIEW") //VERIFICA SE É UMA TABELA
                        {


                            //COLUNA NÃO EXISTE / CRIAR

                            //MONTANDO O ALTER TABLE
                            tempsql = "ALTER TABLE " + reftabela + " ADD " + refcoluna + " " + refcoltype + " ";



                            if (refcolextra != "")
                            {
                                tempsql += refcolextra;
                            }

                            tempsql += " ";

                            if (refcolisnull.ToUpper() == "NO") { tempsql += "NOT NULL"; }

                            tempsql += " ";


                            if (readerRef.IsDBNull(3))
                            {
                                if (refcolisnull.ToUpper() != "NO")
                                {
                                    tempsql += "DEFAULT NULL";
                                }

                            }
                            else if (refcoldefault != "")
                            {
                                tempsql += "DEFAULT \"" + refcoldefault + "\"";
                            }

                            tempsql += " ";

                            if (refcolkey != "")
                            {
                                switch (refcolkey.ToUpper())
                                {
                                    case "PRI":
                                        if (!PrimaryAdded.Contains(reftabela)) //VERIFICANDO LIST PARA A ADIÇÃO DE MULTIPLAS PRIMARIAS
                                        {
                                            tempsql += "primary key";
                                            PrimaryAdded.Add(reftabela);
                                        }
                                        else
                                        {
                                            string primarycolumns = RotinasGerais.RetornaSQLTarg("SELECT column_key, GROUP_CONCAT(COLUMN_NAME SEPARATOR ', ') FROM information_schema.columns WHERE table_schema = \"" + bdTARG + "\" and table_name = \"" + reftabela + "\" AND column_key = \"PRI\" GROUP BY column_key;", 1);
                                            primarycolumns += "," + refcoluna;

                                            tempsql += ",DROP PRIMARY KEY, ADD PRIMARY KEY(" + primarycolumns + ")";
                                        }

                                        break;
                                    case "UNI":
                                        tempsql += "unique key";
                                        break;
                                    case "MUL":
                                        tempsql += ", add key(" + refcoluna + ")";
                                        break;

                                }
                            }



                            //EXECUTANDO O ADD COLUMN NO TARGET
                            try
                            {
                                RotinasGerais.ExecutaSQLTarg(tempsql);
                                ColCriadas++;
                                lblColunasCorrigidas.Text = "Colunas criadas: " + ColCriadas;
                            }
                            catch (Exception ex)
                            {
                                RotinasGerais.WriteLog("Erro: " + ex + "\n\n Não foi possível executar o SQL: " + tempsql);
                                countErros++;
                            }

                        }
                        else //SE FOR VIEW - REFAZER O SELECT DA VIEW
                        {
                            RotinasGerais.ExecutaSQLTarg("DROP VIEW IF EXISTS " + reftabela);
                            CriarTabela(reftabela);

                        }

                    }


                }
                catch (Exception ex)
                {
                    RotinasGerais.WriteLog("Erro ao comparar colunas: " + ex);
                    countErros++;
                }
                cnTarget.Close();
                pgbProgress.Value++;
                lblProgress.Text = pgbProgress.Value.ToString() + "/" + pgbProgress.Maximum.ToString();
                Application.DoEvents();
            }
            cnRef.Close();
        }

        private void StartConnections() 
        
        
        {
            int errorcount = 0;
            //REFERENCE
             bdREF = txtRefDatabase.Text;

            string serverREF = txtRefProvider.Text;
             string userREF = txtRefUser.Text;
            string passREF = txtRefPass.Text;

           Variables.cnStringRef = "Server="+ serverREF + ";Database=" + bdREF + ";Uid="+userREF+";Pwd="+passREF+";" +
                                        "Integrated Security=SSPI; Pooling=false;";
            
            while (errorcount <= 2) 
            {
                try
                {
                    if (errorcount > 0)
                    {
                        Variables.cnStringRef = "Server=" + serverREF + ";Database=" + bdREF + ";Uid=" + userREF + ";Pwd=" + passREF + ";" +
                                            "Pooling=false;";
                    }
                    cnRef = new MySqlConnection(Variables.cnStringRef);
                    cnRef.Open();
                    cnRef.Close();
                    errorcount = 3;
                }
                catch 
                {
                    errorcount++;
                    if (errorcount == 2) 
                    {
                        throw;
                    }
                }
                
                
            }

            //TARGET
            bdTARG = txtTargDatabase.Text;
            string serverTARG = txtTargProvider.Text;
            string userTARG = txtTargUser.Text;
            string passTARG = txtTargPass.Text;
            errorcount = 0;
            Variables.cnStringTarg = "Server=" + serverTARG + ";Database=" + bdTARG + ";Uid=" + userTARG + ";Pwd=" + passTARG + ";" +
                                        "Integrated Security=SSPI; Pooling=false;";
            

            while (errorcount <= 2)
            {
                try
                {
                    if (errorcount > 0)// desativa o Integrated Security
                    {
                        Variables.cnStringTarg = "Server=" + serverTARG + ";Database=" + bdTARG + ";Uid=" + userTARG + ";Pwd=" + passTARG + ";" +
                                         "Pooling=false;";
                    }
                    cnTarget = new MySqlConnection(Variables.cnStringTarg);
                    cnTarget.Open();
                    cnTarget.Close();
                    errorcount = 3;
                }
                catch
                {
                    errorcount++;
                    if (errorcount == 2)
                    {
                        throw;
                    }
                }


            }

        }

        private void CriarTabela(string nomeTabela) 
        {
            string tempquery = "show create table " + nomeTabela;

            string createREF = RotinasGerais.RetornaSQLRef(tempquery, 1);

            //EXECUTANDO O CREATE NO TARGET
            try
            {
                RotinasGerais.ExecutaSQLTarg(createREF);
            }
            catch (Exception ex)
            {
                RotinasGerais.WriteLog("Erro ao executar SQL: " + createREF + "\n Erro: " + ex);
                countErros++;
            }

        }

        private void frmStructureCorrector_Load(object sender, EventArgs e)
        {
            cbxTipoBanco.SelectedIndex = 0;
        }
    }
}
