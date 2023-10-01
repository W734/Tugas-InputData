using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiInputDataMahasiswa
{
    public partial class Form1 : Form
    {
        private List<Mahasiswa> list = new List<Mahasiswa>();
        public Form1()
        {
            InitializeComponent();
            InisialisasiListView();
            ResetForm();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {

        }

        private void lvwMahasiswa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // atur kolom listview
        private void InisialisasiListView()
        {
            lvwMahasiswa.View = View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;
            lvwMahasiswa.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nim", 91, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nama", 200, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Kelas", 70, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilai", 50, HorizontalAlignment.Center);
        }

        private void ResetForm()
        {
            txtNIM.Clear();
            txtNama.Clear();
            txtKelas.Clear();
            txtNilai.Text = "0";
            txtNIM.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // cek apakah data mahasiswa sudah dipilih
            if (lvwMahasiswa.SelectedItems.Count > 0)
            {
                // tampilkan konfirmasi
                var konfirmasi = MessageBox.Show("Apakah data mahasiswa ingin dihapus ? ", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil index list yang di pilih
                    var index = lvwMahasiswa.SelectedIndices[0];
                    // hapus objek mahasiswa dari list
                    list.RemoveAt(index);
                    // refresh tampilan listview
                    
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data mahasiswa belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TampilkanData()
        {
            // kosongkan data listview
            lvwMahasiswa.Items.Clear();
            // lakukan perulangan untuk menampilkan data mahasiswa ke listview
            foreach (var mhs in list)
            {
                var noUrut = lvwMahasiswa.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.NIM);
                item.SubItems.Add(mhs.Nama);
                item.SubItems.Add(mhs.Kelas);
                item.SubItems.Add(mhs.Nilai.ToString());
                item.SubItems.Add(mhs.nilaihuruf);
                lvwMahasiswa.Items.Add(item);
            }
        }

        private void btnHapus_Click_1(object sender, EventArgs e)
        {
            // cek apakah data mahasiswa sudah dipilih
            if (lvwMahasiswa.SelectedItems.Count > 0)
            {
                // tampilkan konfirmasi
                var konfirmasi = MessageBox.Show("Apakah data mahasiswa ingin dihapus ? ", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil index list yang di pilih
                    var index = lvwMahasiswa.SelectedIndices[0];

                    // hapus objek mahasiswa dari list
                    list.RemoveAt(index);
                    // refresh tampilan listivew
                    TampilkanData();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data mahasiswa belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnTampilkanData_Click(object sender, EventArgs e)
        {
            TampilkanData();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // Validasi untuk memastikan txtNilai adalah angka
            if (!int.TryParse(txtNilai.Text, out int nilai))
            {
                MessageBox.Show("Nilai harus berupa angka!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNilai.Text = "0"; // Set nilai kembali ke 0
                return;
            }

            // Validasi untuk memastikan NIM tidak kosong
            if (string.IsNullOrWhiteSpace(txtNIM.Text))
            {
                MessageBox.Show("NIM tidak boleh kosong!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // membuat objek mahasiswa 
            Mahasiswa mhs = new Mahasiswa();
            // set nilai masing-masing propertynya
            // berdasarkan inputan yang ada di form
            mhs.NIM = txtNIM.Text;
            mhs.Nama = txtNama.Text;
            mhs.Kelas = txtKelas.Text;
            mhs.Nilai = nilai;
            // tambahkan objek mahasiswa ke dalam collection
            list.Add(mhs);
            var msg = "Data mahasiswa berhasil disimpan.";
            // tampilkan dialog informasi
            MessageBox.Show(msg, "Informasi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            // reset form input
            ResetForm();

        }
    }
}
