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


namespace Baza
{
    public partial class Form1 : Form
    {
        public string conString = "Data Source=LAPTOPSZAFIRKA;Initial Catalog=projekt;Integrated Security=True";
        public SqlConnection connection;


        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(conString);
                dataGridView1.ReadOnly = true;
           
             


            }
            catch (Exception ex)
            {
                MessageBox.Show("Bład1 " + ex.Message);
            }
         


           
            try
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    testConnect.BackColor = Color.Lime;
                    testConnect.Text = "OK";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bład " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }


        //test polaczenia
        private void button3_Click(object sender, EventArgs e)
        {
         
            try
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    MessageBox.Show("Połączenie poprawne!");
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bład " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        
        }

        //dodawanie
        private void button3_Click_1(object sender, EventArgs e)
        {
           
            try
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {


                    SqlCommand cmd = new SqlCommand("select COUNT(*) from users ", connection);
                   
                    
                    SqlDataReader rd = cmd.ExecuteReader();
                    if ( String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text))
                    {
                        MessageBox.Show("Nie uzupełniono wszystkich pól!");
                    }
                    else if (rd.Read())
                    {
                        if (MessageBox.Show("Czy na pewno chcesz wykonać tę czynność?", "Pytanie", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            connection.Close();
                            connection.Open();
                            SqlCommand cmd1 =
                            new SqlCommand("INSERT INTO users (login, name, surname) VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", connection);
                            cmd1.ExecuteNonQuery();
                            MessageBox.Show("Dodano!");
                        }
                        
                    }

 
                    connection.Close();

                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bład " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            
            
          
        }

        //wyswietlanie
        private void button4_Click(object sender, EventArgs e)
        {


            
            try
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand("select COUNT(*) from users ", connection);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        connection.Close();
                        connection.Open();
                        SqlCommand cmd1 =
                            new SqlCommand("select * from users", connection);

                        SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd1);

                        DataTable data = new DataTable();
                        sqlDataAdap.Fill(data);
                        dataGridView1.DataSource = data;


                        cmd1.ExecuteNonQuery();

                        button4.Text = "Odśwież";
                        button4.BackColor = Color.Silver;
                        button5.Visible = true;
                        button6.Visible = true;

                       // MessageBox.Show("Wyświetlono dane!");


                    }
                    else
                    {
                        MessageBox.Show("Pusta tabela!");
                    }

                    connection.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bład " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        //update
        private void button5_Click(object sender, EventArgs e)
        {
           
            try
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand("select COUNT(*) from users", connection);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        

                        if (MessageBox.Show("Czy na pewno chcesz wykonać tę czynność?", "Pytanie", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            connection.Close();
                        connection.Open();
                            SqlCommand cmd1 =
                                new SqlCommand("UPDATE users SET login = '" + textBox2.Text + "' , name ='" + textBox3.Text + "', surname = '" + textBox4.Text + "' WHERE id='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "' ", connection);

                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd1);

                           cmd1.ExecuteNonQuery();
                          
                            MessageBox.Show("Edytowano dane!");
                           
                        }
                        
                       
                    }
                    else
                    {
                        MessageBox.Show("Pusta tabela!");
                    }

                    connection.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bład " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }



     

        //usuwanie
        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand("select COUNT(*) from users", connection);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {


                        if (MessageBox.Show("Czy na pewno chcesz wykonać tę czynność?", "Pytanie", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            connection.Close();
                            connection.Open();
                            SqlCommand cmd1 =
                                new SqlCommand("DELETE FROM users WHERE id='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "' ", connection);

                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd1);

                            cmd1.ExecuteNonQuery();


                            MessageBox.Show("Usunieto dane!");
                        }


                    }
                    else
                    {
                        MessageBox.Show("Pusta tabela!");
                    }

                    connection.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bład " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            try
            {
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bład " + ex.Message);
            }
           
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bład " + ex.Message);
            }
        }

        

       

       
    }
}
