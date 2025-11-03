using System;
using System.Collections.Generic;// dung de tao danh sach kieu list<kieu data>
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net; // thu vien chua cac ham doc ghi file

//khoi lenh try{}catch{} loi va hien thi loi
namespace CleanData
{
    public class ReadCsv
    {
       public static List<string[]> ReadCsvFile(string nameFile)
        {
            List<string[]> Dsach = new List<string[]>(); //khai bao va cap phat vung nho cho Dsach
            int count = 0;
            try
            {
                string[] lines = File.ReadAllLines(nameFile); // doc toan bo file moi lines(dong) la 1 phan tu trong mang
                foreach (string line in lines) // duyet toan bo dong trong mang(lines)
                {
                    //if (line.StartsWith("Name"))
                    //    continue
                    string[] values = line.Split(',');// tach chuoi chuyen dong thanh tung cot ra chuoi moi
                    Dsach.Add(values);//them chuoi moi vao danh sach mang kieu 
                }//cat thanh nhieu phan tu roi gan vao danh sach
                Console.WriteLine("Doc Csv thanh cong!");
            }
            catch(Exception ex) //thong bao loi 
            {
                Console.WriteLine($"da xay ra loi:{ex.Message}"); //$ cho phep chen bien vao trong chuoi ,
                //{ex.Message} mo ta loi 
            }
            return Dsach;
            
        }
      public static void WriteCsvFile(List<string[]> data,string nameFile)
        {
            try
            {
                using (StreamWriter GhiFile = new StreamWriter(nameFile))// StreamWriter lop ghi du lieu text ->file ,khai bao và cấp phát vung để ghi
                ///using () { } giup dong file k can writer.close()
                {
                    foreach (string[] line in data)
                    {
                        GhiFile.WriteLine(string.Join(",", line));//noi chuoi lại rồi ghi chuoi đó vao file hoan thanh 1 phan tu trong mang chuoi

                    }
                    Console.WriteLine("Ghi File Thanh Cong!");
                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine($"loi ghi File :{ex.Message}");
            }
        }
        public static void WriteTreeFile(List<string[]> data, string nameFile)
        {
            try
            {
                using (StreamWriter GhiFile = new StreamWriter(nameFile))// StreamWriter lop ghi du lieu text ->file ,khai bao và cấp phát vung để ghi
                ///using () { } giup dong file k can writer.close()
                {
                    foreach (string[] line in data)
                    {
                        GhiFile.WriteLine(line.ToString());//noi chuoi lại rồi ghi chuoi đó vao file hoan thanh 1 phan tu trong mang chuoi

                    }
                    Console.WriteLine("Ghi File Thanh Cong!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"loi ghi File :{ex.Message}");
            }
        }
        public static List<string[]> CleanData(List<string[]> data)
        {
            List<string[]> cleandata =new List<string[]>();
            foreach (string[] line in data)
            {
                bool flag = true;//dung co de nhan dang du lieu chuan
                // dung de bo khoang trang 2 dau
                for (int i = 0; i < line.Length; i++) //.Length la so phan tu trong mang 
                {
                    line[i]= line[i].Trim(); //.trim() la cat bo vi tri trong 2 dau chuoi
                    if(string.IsNullOrEmpty(line[i]))//kiem tra xem co cot nao trong trong dong k 
                    {
                        flag = false;//co trong thih bo qua
                        break;
                    }
                }
                if (flag)
                    cleandata.Add(line);
            }    
            Console.WriteLine($"du lieu da duoc lam sach :{data.Count/cleandata.Count}");// co bao nhieu du lieu sach tren tong so 
            return cleandata;
        }
        //static void Main()
        //{
        //    string ReadData = "healthcare_dataset.csv";
        //    string WriteData = "DataSet22.csv";
        //    List<string[]> csvData = ReadCsvFile(ReadData);
        //    foreach (string[] row in csvData)
        //    {
        //        Console.WriteLine(string.Join(",", row));
        //    }
        //    List<string[]> cleandata = CleanData(csvData);

        //    WriteCsvFile(cleandata, WriteData);
        //    Console.WriteLine();
        //}
    }
}
