using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AureaGestao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Localização do DB
            string strcon = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\AureaDB.mdf;Integrated Security=True";
            //Conexão com o DB
            SqlConnection conexao = new SqlConnection(strcon);
            //Comunicação com o DB
            SqlCommand Sqlcom = new SqlCommand("SELECT * FROM Alunos", conexao);
            
        try  //Tenta executar o que estiver abaixo
            {                                                                                                                  
                conexao.Open(); // abre a conexão com o banco   
                MessageBox.Show("Conexão Aberta");
                Sqlcom.ExecuteNonQuery();
                /*Após o comando Sqlcom.ExecuteNonQuery(); tudo que tinha dentro do banco foi selecionado, 
                * agora os passos seguintes irão exibir as informações para que o usuário possa vê-las */

                SqlDataAdapter da = new SqlDataAdapter(); /*da, adapta o banco de dados ao projeto*/
                DataSet ds = new DataSet(); /* DataSet do banco, contém as informações do Banco no Projeto */
                da.SelectCommand = Sqlcom; // adapta SqlCom ao projeto
                da.Fill(ds); // preenche todas as informações dentro do DataSet                                          
                dataGridView1.DataSource = ds; //O form "Datagridview" recebe ds já preenchido
                dataGridView1.DataMember = ds.Tables[0].TableName;  /* Agora Datagridview exibe os dados do banco */               
            }
            catch (Exception ex)
            {                 
                MessageBox.Show("Erro "+ex.Message); /*Informa erro em um msgbox*/
                throw;      
            }
 
            finally
            {         
               conexao.Close();
               MessageBox.Show("Conexão Fechada");
            }


        }
    }
}
