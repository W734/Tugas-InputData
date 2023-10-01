using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiInputDataMahasiswa
{
    class Mahasiswa
    {
        public string NIM;
        public string Nama;
        public string Kelas;
        public int Nilai;
        public string nilaihuruf;

        public int nilai
        {
            get { return Nilai; }
            set
            {
                int val = value;
                nilai = val;
                if (val > 81)
                {
                    nilaihuruf = "A";
                }
                else if (val > 61)
                {
                    nilaihuruf = "B";
                }
                else if (val > 41)
                {
                    nilaihuruf = "C";
                }
                else if (val > 21)
                {
                    nilaihuruf = "D";
                }
                else if (val > 0)
                {
                    nilaihuruf = "E";
                }
            }
        }
    }
}
    




