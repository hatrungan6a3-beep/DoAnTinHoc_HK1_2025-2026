using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanData
{
    internal class CTDL
    {
        public class Patient // khai bao lop benh nhan
        {


            public string Ten;
            public int Tuoi;
            public string Gioitinh;
            public string Nhommau;
            public string Tinhtrang;
            public string Ngayvao;
            public string Bacsi;
            public string Benhvien;
            public string Baohiem;
            public string Vienphi;
            public string Phong;
            public string Loainhapvien;
            public string Ngayra;
            public string Thuoc;
            public string Ghichu;

            public Patient(string ten, int tuoi, string gioitinh, string nhommau, string tinhtrang, string ngayvao, string bacsi, string benhvien,
                string baohiem, string vienphi, string phong, string loainhapvien, string ngayra, string thuoc, string ghichu)
            {
                Ten = ten;
                Tuoi = tuoi;
                Gioitinh = gioitinh;
                Nhommau = nhommau;
                Tinhtrang = tinhtrang;
                Ngayvao = ngayvao;
                Bacsi = bacsi;
                Benhvien = benhvien;
                Baohiem = baohiem;
                Vienphi = vienphi;
                Phong = phong;
                Loainhapvien = loainhapvien;
                Ngayra = ngayra;
                Thuoc = thuoc;
                Ghichu = ghichu;
            }
        }

        public class AVLNode // lop nut
        {
            public Patient data; // du lieu benh nhan
            public AVLNode left;
            public AVLNode right;
            public int height;//chieu cao de cay can bang
            public AVLNode(Patient benhnhan1)
            {
                data = benhnhan1;
            }
            // khoi tao 1 nut them du lieu ( HAM DUNG CO DOI SO LA CLASS)
        }

        public class AVLTree  // lop cua cay AVL
        {
            public AVLNode tree;

            public int Height(AVLNode n)//chieu cao cua cay neu co thi tra ve chieu cao k thi tra ve 0
            {
                return n != null ? n.height:0; //khac null thi .height = nul thi 0
            }   
            private int Balance(AVLNode n) // tinh he so can bang
            {
                return n != null ? Height(n.right) - Height(n.left):0;
            }
            private AVLNode XoayPhai(AVLNode y)
            {
                AVLNode x = y.left;
                AVLNode T2 = x.right;
                x.right = y;
                y.left = T2;
                y.height = Math.Max(Height(y.left), Height(y.right)) + 1;
                x.height = Math.Max(Height(x.left), Height(x.right)) + 1;
                return x;
            }
            private AVLNode XoayTrai(AVLNode x)
            {
                AVLNode y = x.right;
                AVLNode T2 = y.left;
                y.left = x;
                y.left = T2;
                x.height = Math.Max(Height(x.left), Height(x.right)) + 1;
                y.height = Math.Max(Height(y.left), Height(y.right)) + 1;
                return y;
            }
            private int SoSanhGT(Patient a, Patient b)
            {
                string[] hotenA= a.Ten.Trim().Split(' ');
                string[] hotenB = b.Ten.Trim().Split(' ');

                string HoA = hotenA[0];
                string HoB = hotenB[0];
                
                string TenA= hotenA[hotenA.Length-1];
                string TenB=hotenB[hotenB.Length-1];

                // so sanh ten truoc 
                int ssten=string.Compare(TenA, TenB, StringComparison.OrdinalIgnoreCase);
                if(ssten != 0 )
                    return ssten;
                //trung tên thi ss ho
                int ssho=string.Compare(HoA, HoB, StringComparison.OrdinalIgnoreCase);
                if(ssho != 0 )
                    return ssho;
                // neu trung ho ttrung ten ss het
                return string.Compare(a.Ten,b.Ten, StringComparison.OrdinalIgnoreCase);

                

                
                // lop cua thu vien có sẵn dùng để so sánh chuỗi theo chữ cái, a trước b thì -1 , sau thi 1 ,= thì 0
            }
            private AVLNode Insert(AVLNode Node, Patient data)
            {
              
                if (Node == null)
                    Node = new AVLNode(data);//khoi tao nut cho cay con
                int kt = SoSanhGT(data, Node.data);
                if (kt < 0)
                    Node.left = Insert(Node.left, data);
                else if (kt > 0)
                    Node.right = Insert(Node.right, data);
                else
                    return Node;
                Node.height = Math.Max(Height(Node.left), Height(Node.right)); // tinh toan lay nhanh cao nhat
                int CanBang = Balance(Node);//kt can bang

                if (CanBang > 1 && SoSanhGT(data, Node.left.data) < 0)// trai trai
                    return XoayPhai(Node);
                if (CanBang < -1 && SoSanhGT(data, Node.right.data) > 0)// phai phai
                    return XoayTrai(Node);
                if (CanBang > 1 && SoSanhGT(data, Node.left.data) > 0)// trai phai
                {
                    Node.left = XoayTrai(Node.left);
                    return XoayPhai(Node);
                }
                if (CanBang < -1 && SoSanhGT(data, Node.right.data) < 0)// phai trai
                {
                    Node.right = XoayPhai(Node.right);
                    return XoayTrai(Node);
                }
                return Node;

            }
            public void add(Patient data)
            {
                tree = Insert(tree, data);
            }
            private void LNR(AVLNode node, List<Patient> list) // chuyên data từ cay AVL benh nhan sang ds benh nhan theo chu cai tang dan den ghi file
            {
                if (node != null)
                {
                    LNR(node.left, list);
                    list.Add(node.data);
                    LNR(node.right, list);
                }
            }
            public List<Patient> ToList() // ham dung de su dung ben ngoai
            {
                List<Patient> list = new List<Patient>();
                LNR(tree, list);
                return list; ;
            }
        }

    }  
      
}

