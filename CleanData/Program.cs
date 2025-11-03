using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CleanData;

internal static class Progarm
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
}










    //static void Main()
    //{

    //    string ReadData = "DataSet.csv";
    //    string WriteData = "CTDLData.csv";
    //    CTDL.AVLTree tree = new CTDL.AVLTree();

    //    try
    //    {
    //        string[] lines = File.ReadAllLines(ReadData);
    //        foreach (string line in lines)
    //        {
    //            if (line.StartsWith("Name")) // .startwith kiem cho chuoi bat bat neu bang name bo qua
    //                continue;
    //            string[] v = line.Split(',');// tach ["sdad,asdas,asd,asd,asd] -> [["sad"],..]
    //            string Ten = v[0];
    //            int tuoi = int.Parse(v[1]);
    //            string gioitinh = v[2];
    //            string nhommau = v[3];
    //            string tinhtrang = v[4];
    //            string ngayvao = v[5];
    //            string bacsi = v[6];
    //            string benhvien = v[7];
    //            string baohiem = v[8];
    //            string vienphi = v[9];
    //            string phong = v[10];
    //            string loainhapvien = v[11];
    //            string ngayra = v[12];
    //            string thuoc = v[13];
    //            string ghichu = v[14];
    //            CTDL.Patient p = new CTDL.Patient(Ten, tuoi, gioitinh, nhommau, tinhtrang, ngayvao, bacsi, benhvien, baohiem, vienphi, phong, loainhapvien, ngayra, thuoc, ghichu);
    //            tree.add(p);
    //        }
    //        List<CTDL.Patient> DsBenhNhan = tree.ToList(); // khoi tao danh sach co kieu thuoc tinh benh nhan de ghi file
    //        using (StreamWriter GhiFile = new StreamWriter(WriteData))
    //        {
    //            foreach (CTDL.Patient p in DsBenhNhan)
    //            {
    //                GhiFile.WriteLine($"{p.Ten},{p.Tuoi},{p.Gioitinh},{p.Nhommau},{p.Tinhtrang},{p.Ngayvao},{p.Bacsi},{p.Benhvien},{p.Baohiem},{p.Vienphi},{p.Phong},{p.Loainhapvien},{p.Ngayra},{p.Thuoc},{p.Ghichu}");
    //            }
    //        }
    //        Console.WriteLine("Da ghi file thanh cong");
    //        Console.ReadLine();
    //    }
    //    catch (Exception ex)
    //    {

    //        Console.WriteLine($"Lỗi :{ex.Message}");
    //    } 
    //    }


