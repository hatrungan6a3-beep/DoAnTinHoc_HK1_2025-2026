using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleanData
{
    public partial class Form1 : Form
    {
        CTDL.AVLTree root =new CTDL.AVLTree();
        List<CTDL.Patient> DSach= new List<CTDL.Patient>(); 
        private void HienBenhNhan(List<CTDL.Patient> data)
        {
            dgvDanhsach.DataSource = null;
            dgvDanhsach.AutoGenerateColumns = true;
            dgvDanhsach.DataSource = data.Select(p => new { p.Ten, p.Tuoi, p.Gioitinh, p.Nhommau, p.Tinhtrang, p.Ngayvao, p.Ngayra, p.Loainhapvien }).ToList();
            dgvDanhsach.Refresh();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDocFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog(); //tao hop thoai mo File
            openFile.Filter = "CSV File(*.csv)|*.csv"; // liet ke cach file co dang .csv
            if (openFile.ShowDialog() == DialogResult.OK) //cho nguoi dung con open hoac can not open se == ok chay
            {
                string[] lines = File.ReadAllLines(openFile.FileName);
                DSach.Clear();

                for (int i = 1; i < lines.Length; i++)
                {
                    if (i == 10)
                        break;
                    string[] p = lines[i].Split(',');
                    if (p.Length >= 14)
                    {
                        DSach.Add(new CTDL.Patient(p[0], int.Parse(p[1]), p[2], p[3], p[4], p[5], p[6], p[7], p[8], p[9], p[10], p[11], p[12], p[13], p[14]));

                    }

                }
                HienBenhNhan(DSach);
            }
            if (DSach.Count >0)
            {
                MessageBox.Show("Doc File Thanh Cong.");
            }
            else
                MessageBox.Show("Doc File That Bai.");
        }

        private void btnAVLTree_Click(object sender, EventArgs e)
        {
            root=new CTDL.AVLTree();
            foreach (CTDL.Patient BenhNhan in DSach)
            {
                root.add(BenhNhan);
            }
            List<CTDL.Patient> AVLTREE = root.ToList();
            HienBenhNhan(AVLTREE);
            int chieucao = root.Height(root.tree);
            if(root!=null)
                MessageBox.Show($"Đã xây dựng cây avl với chiều cao là{chieucao} ");
        }

        private void btnGhiFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFile = new SaveFileDialog();//tao hop thoai luu FIle
            SaveFile.Filter = "CSV File(*.csv)|*.csv";///"Mo ta|*.csv dinh dang|
            if(SaveFile.ShowDialog() == DialogResult.OK)
            {
                List<CTDL.Patient> AVLTree=root.ToList();
                using (StreamWriter write=new StreamWriter(SaveFile.FileName))//luu du lieu dang text vao file
                {
                    write.WriteLine("Ten,Tuoi,GioiTinh,Nhommau,TinhTrang,NgayVao,BacSi,BenhVien,BaoHiem,VienPhi,Phong,LoaiNhapVien,NgayRa,Thuoc,GhiChu");
                    foreach(CTDL.Patient bn in AVLTree)
                    {
                        write.WriteLine($"{bn.Ten},{bn.Tuoi},{bn.Gioitinh},{bn.Nhommau},{bn.Tinhtrang},{bn.Ngayvao},{bn.Bacsi},{bn.Benhvien},{bn.Baohiem},{bn.Vienphi},{bn.Phong},{bn.Loainhapvien}," +
                            $" {bn.Ngayra},{bn.Thuoc},{bn.Ghichu}");
                    }    
                }
                MessageBox.Show("Đã Ghi Thanh Cong.");
            }    
        }

        
    }
}
