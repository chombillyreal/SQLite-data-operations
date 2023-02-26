//Adding Data  
            SQLiteConnection bag = new SQLiteConnection("Data Source=yourdatasource;");
            SQLiteConnection data = new SQLiteConnection(bag);
            try
            {
               data.Open();
                string isim = textBox1.Text;
                string soyisim = textBox2.Text;
                string sql = "insert into tablename(yourvalues) " +
                "VALUES('" + textBox1.Text + "','" + textBox2.Text + "','"+ textBox5.Text+ "')";
                SQLiteCommand komut = new SQLiteCommand(sql, data);
                {
                    komut.Parameters.AddWithValue("@value", isim);
                    komut.Parameters.AddWithValue("@value", soyisim);
                    komut.Parameters.AddWithValue("@value", Convert.ToInt32(textBox5.Text));
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Succesfully registered.");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox5.Clear();
                }

                data.Close();
            }
            catch (Exception bbc)
            {
               
                MessageBox.Show(bbc.Message);
            }
            
            
//Data deletion      
            try
            {      
            SQLiteConnection bag = new SQLiteConnection("Data Source=yourdatasource");
            SQLiteConnection data = new SQLiteConnection(bag);
            
             if(MessageBox.Show("Are you sure you want to delete?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
               {
                    data.Open();
                    string remove = textBox3.Text;
                    remove = sil.Replace("'", "''");
                    string deleteSql = "DELETE FROM table name WHERE no='" + remove + "'";
                    SQLiteCommand deleteCommand = new SQLiteCommand(deleteSql, veritabani);
                    deleteCommand.ExecuteNonQuery();
                    MessageBox.Show("Succesfully deleted.");
                    textBox3.Clear();
               }          
             data.Close();
            }
            catch(Exception bbc)
            {
               MessageBox.Show(bbc.Message);
            }
           
// Update Data
           try
            {
                SQLiteConnection bag = new SQLiteConnection("Data Source=yourdatasource;");
                SQLiteConnection data = new SQLiteConnection(bag);
               
                if (MessageBox.Show("Are you sure the contact will be updated?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    data.Open();
                    string update = textBox5.Text;
                    update = güncelle.Replace("'", "''");
                    string updateSql = "UPDATE tablename SET isim =@isim, soyisim=@soyisim WHERE no='" + update + "'";
                    SQLiteCommand updateCommand = new SQLiteCommand(updateSql, veritabani);
                    updateCommand.Parameters.AddWithValue("@value", textBox1.Text);
                    updateCommand.Parameters.AddWithValue("@value", textBox2.Text);
                    updateCommand.Parameters.AddWithValue("@value", Convert.ToInt32(textBox5.Text));
                    updateCommand.ExecuteNonQuery();
                    MessageBox.Show("Succesfully updated.");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox5.Clear();
                }     
             data.Close();
            }
            catch (Exception bbc)
            {
                MessageBox.Show(bbc.Message);
            }
               
               
  //Showing Data in datagridView
            try
            {
                SQLiteConnection bag = new SQLiteConnection("Data Source=yourdatasource;");
                SQLiteConnection data = new SQLiteConnection(bag);
                data.Open();
                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "Ad";
                dataGridView1.Columns[1].Name = "Soyad";
                dataGridView1.Columns[2].Name = "Numara";
                SQLiteCommand showData = new SQLiteCommand("SELECT * from tablename",data);
                SQLiteDataReader show = showData.ExecuteReader();

                while (show.Read())
                {
                    dataGridView1.Rows.Add(show[0], show[1], show[2]);
                }
               data.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
