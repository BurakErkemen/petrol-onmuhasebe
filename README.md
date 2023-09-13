private void GridYükle()
        {
            using (var context = new Context())
            {

                var musterı_Bılgıs = context.Musterı_Bılgıs.ToList();
                BindingList<Musterı_bılgı> musterı_s = new BindingList<Musterı_bılgı>(musterı_Bılgıs);
                MüsteriTablosu.DataSource = musterı_s;
                musterı_Bılgıs = context.Musterı_Bılgıs.Include("Plaka_Kayıts").ToList();
                musterı_Bılgıs = context.Musterı_Bılgıs.Include("Musterı_Odemes").ToList();

                if (MüsteriTablosu.Columns.Contains("TankDolumlar") || MüsteriTablosu.Columns.Contains("Musterı_Odemes") || MüsteriTablosu.Columns.Contains("MusteriBorc"))
                {
                    MüsteriTablosu.Columns["MusterıID"].Visible = false;

                    foreach (DataGridViewRow row in MüsteriTablosu.Rows)
                    {
                        if (row.Cells["Musterı_Odemes"].Value == null || row.Cells["Plaka_Kayıts"].Value == null || !MüsteriTablosu.Columns.Contains("MusteriBorc"))
                        {
                            row.Cells["Musterı_Odemes"].Value = ""; // Null değeri bir boş string ile değiştir
                            row.Cells["Plaka_Kayıts"].Value = ""; // Null değeri bir boş string ile değiştir
                            if (!MüsteriTablosu.Columns.Contains("MusteriBorc"))
                            {
                                MüsteriTablosu.Columns.Add("MusteriBorc", "Müşteri Borcu"); // Sütun eksikse, sütunu ekleyin
                            }
                            row.Cells["MusteriBorc"].Value = 0; // Null değeri default ile değiştir
                        }
                    }
                }
                
                MüsteriTablosu.Columns["Plaka_Kayıts"].HeaderText = "Plaka";
                MüsteriTablosu.Columns["Musterı_Odemes"].HeaderText = "Ödeme";
                
                Txt_Ad.Clear();
                Txt_Soyad.Clear();
            }
        }