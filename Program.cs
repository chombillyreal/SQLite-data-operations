//Adding Data
            
            SQLiteConnection bag = new SQLiteConnection("Data Source=yourdatasource;");
            SQLiteConnection veritabani = new SQLiteConnection(bag);
            try
            {
                veritabani.Open();
                string isim = textBox1.Text;
                string soyisim = textBox2.Text;
                string sql = "insert into kullanicilar(isim,soyisim,no) " +
                "VALUES('" + textBox1.Text + "','" + textBox2.Text + "','"+ textBox5.Text+ "')";
                SQLiteCommand komut = new SQLiteCommand(sql, veritabani);
                {
                    komut.Parameters.AddWithValue("@isim", isim);
                    komut.Parameters.AddWithValue("@soyisim", soyisim);
                    komut.Parameters.AddWithValue("@no", Convert.ToInt32(textBox5.Text));
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarıyla Eklendi");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox5.Clear();
                }

                veritabani.Close();
            }
            catch (Exception bbc)
            {
               
                MessageBox.Show(bbc.Message);
            }
            
            
//Data deletion      
            try
            {      
            SQLiteConnection bag = new SQLiteConnection("Data Source=yourdatasource");
            SQLiteConnection veritabani = new SQLiteConnection(bag);
            
             if(MessageBox.Show("Seçili kayıt silinecek emin misiniz?","UYARI",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
               {
                    veritabani.Open();
                    string sil = textBox3.Text;
                    sil = sil.Replace("'", "''");
                    string deleteSql = "DELETE FROM kullanicilar WHERE no='" + sil + "'";
                    SQLiteCommand deleteCommand = new SQLiteCommand(deleteSql, veritabani);
                    deleteCommand.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarıyla Silindi");
                    textBox3.Clear();
               }
              
             
             veritabani.Close();
            }
            catch(Exception bbc)
            {
                MessageBox.Show(bbc.Message);

            }
           
// Update Data
                          try
            {
                SQLiteConnection bag = new SQLiteConnection("Data Source=yourdatasource;");
                SQLiteConnection veritabani = new SQLiteConnection(bag);
               
                if (MessageBox.Show("Kişi güncellenecek emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    veritabani.Open();
                    string güncelle = textBox5.Text;
                    güncelle = güncelle.Replace("'", "''");
                    string updateSql = "UPDATE kullanicilar SET isim =@isim, soyisim=@soyisim WHERE no='" + güncelle + "'";
                    SQLiteCommand updateCommand = new SQLiteCommand(updateSql, veritabani);
                    updateCommand.Parameters.AddWithValue("@isim", textBox1.Text);
                    updateCommand.Parameters.AddWithValue("@soyisim", textBox2.Text);
                    updateCommand.Parameters.AddWithValue("@no", Convert.ToInt32(textBox5.Text));
                    updateCommand.ExecuteNonQuery();
                    veritabani.Close();
                    MessageBox.Show("Kayıt Başarıyla Güncellendi");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox5.Clear();
                }
               
            }
            catch (Exception bbc)
            {
                MessageBox.Show(bbc.Message);
            }
               
               
  //Showing Data in datagridView
            try
            {
                SQLiteConnection bag = new SQLiteConnection("Data Source=yourdatasource;");
                SQLiteConnection veritabani = new SQLiteConnection(bag);
                veritabani.Open();
                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "Ad";
                dataGridView1.Columns[1].Name = "Soyad";
                dataGridView1.Columns[2].Name = "Numara";
                SQLiteCommand showData = new SQLiteCommand("SELECT isim,soyisim,no from kullanicilar", veritabani);
                SQLiteDataReader show = showData.ExecuteReader();

                while (show.Read())
                {
                    dataGridView1.Rows.Add(show[0], show[1], show[2]);
                }
                veritabani.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
           
           
           //Developed by Chombilly.
