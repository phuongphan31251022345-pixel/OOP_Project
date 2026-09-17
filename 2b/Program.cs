using System;
using System.Collections.Generic;
using System.Text;

// Lớp cha: Sách
public abstract class Sach
{
    protected string maSach;
    protected DateTime ngayNhap;
    protected double donGia;
    protected int soLuong;
    protected string nhaXuatBan;

    // Constructor
    public Sach(
        string maSach,
        DateTime ngayNhap,
        double donGia,
        int soLuong,
        string nhaXuatBan)
    {
        this.maSach = maSach;
        this.ngayNhap = ngayNhap;
        this.donGia = donGia;
        this.soLuong = soLuong;
        this.nhaXuatBan = nhaXuatBan;
    }

    // Tính thành tiền
    public abstract double ThanhTien();

    // Lấy nhà xuất bản
    public string GetNhaXuatBan()
    {
        return nhaXuatBan;
    }

    // Xuất thông tin
    public virtual void XuatThongTin()
    {
        Console.WriteLine("Ma sach: " + maSach);
        Console.WriteLine("Ngay nhap: " + ngayNhap.ToString("dd/MM/yyyy"));
        Console.WriteLine("Don gia: " + donGia);
        Console.WriteLine("So luong: " + soLuong);
        Console.WriteLine("Nha xuat ban: " + nhaXuatBan);
        Console.WriteLine("Thanh tien: " + ThanhTien());
    }
}

// Sách giáo khoa
public class SachGiaoKhoa : Sach
{
    private string tinhTrang;

    // Constructor
    public SachGiaoKhoa(
        string maSach,
        DateTime ngayNhap,
        double donGia,
        int soLuong,
        string nhaXuatBan,
        string tinhTrang)
        : base(maSach, ngayNhap, donGia, soLuong, nhaXuatBan)
    {
        this.tinhTrang = tinhTrang;
    }

    // Tính thành tiền
    public override double ThanhTien()
    {
        if (tinhTrang.ToLower() == "mới")
        {
            return soLuong * donGia;
        }
        else
        {
            return soLuong * donGia * 0.5;
        }
    }

    // Xuất thông tin
    public override void XuatThongTin()
    {
        Console.WriteLine("=== SACH GIAO KHOA ===");

        base.XuatThongTin();

        Console.WriteLine("Tinh trang: " + tinhTrang);
    }
}

// Sách tham khảo
public class SachThamKhao : Sach
{
    private double thue;

    // Constructor
    public SachThamKhao(
        string maSach,
        DateTime ngayNhap,
        double donGia,
        int soLuong,
        string nhaXuatBan,
        double thue)
        : base(maSach, ngayNhap, donGia, soLuong, nhaXuatBan)
    {
        this.thue = thue;
    }

    // Tính thành tiền
    public override double ThanhTien()
    {
        return soLuong * donGia + thue;
    }

    // Xuất thông tin
    public override void XuatThongTin()
    {
        Console.WriteLine("=== SACH THAM KHAO ===");

        base.XuatThongTin();

        Console.WriteLine("Thue: " + thue);
    }
}

// Chương trình chính
class Program
{
    static void Main(string[] args)
    {   
        Console.OutputEncoding = Encoding.UTF8;

        // Tạo danh sách sách
        List<Sach> danhSach = new List<Sach>();

        // TẠO 3 SÁCH GIÁO KHOA

        SachGiaoKhoa sgk1 = new SachGiaoKhoa(
            "SGK01",
            new DateTime(2026, 1, 10),
            50000,
            10,
            "K",
            "mới"
        );

        SachGiaoKhoa sgk2 = new SachGiaoKhoa(
            "SGK02",
            new DateTime(2026, 2, 15),
            60000,
            8,
            "NXB Giáo Dục",
            "cũ"
        );

        SachGiaoKhoa sgk3 = new SachGiaoKhoa(
            "SGK03",
            new DateTime(2026, 3, 20),
            70000,
            12,
            "K",
            "mới"
        );

        // TẠO 3 SÁCH THAM KHẢO

        SachThamKhao stk1 = new SachThamKhao(
            "STK01",
            new DateTime(2026, 1, 12),
            80000,
            5,
            "NXB Kim Đồng",
            20000
        );

        SachThamKhao stk2 = new SachThamKhao(
            "STK02",
            new DateTime(2026, 2, 18),
            90000,
            6,
            "NXB Khoa Học",
            30000
        );

        SachThamKhao stk3 = new SachThamKhao(
            "STK03",
            new DateTime(2026, 3, 25),
            100000,
            10,
            "NXB Kim Đồng",
            50000
        );

        // Thêm tất cả sách vào danh sách
        danhSach.Add(sgk1);
        danhSach.Add(sgk2);
        danhSach.Add(sgk3);

        danhSach.Add(stk1);
        danhSach.Add(stk2);
        danhSach.Add(stk3);

        // XUẤT DANH SÁCH SÁCH
     

        Console.WriteLine("===== DANH SACH CAC LOAI SACH =====");
        Console.WriteLine();

        foreach (Sach sach in danhSach)
        {
            sach.XuatThongTin();
            Console.WriteLine();
        }

        // 1. TÍNH TỔNG THÀNH TIỀN TỪNG LOẠI

        double tongSachGiaoKhoa = 0;
        double tongSachThamKhao = 0;

        foreach (Sach sach in danhSach)
        {
            if (sach is SachGiaoKhoa)
            {
                tongSachGiaoKhoa += sach.ThanhTien();
            }
            else if (sach is SachThamKhao)
            {
                tongSachThamKhao += sach.ThanhTien();
            }
        }

        Console.WriteLine("===== TONG THANH TIEN =====");

        Console.WriteLine(
            "Tong thanh tien sach giao khoa: "
            + tongSachGiaoKhoa
        );

        Console.WriteLine(
            "Tong thanh tien sach tham khao: "
            + tongSachThamKhao
        );

        Console.WriteLine();

        // 2. TÌM SÁCH GIÁO KHOA CỦA NXB K

        Console.Write("Nhap nha xuat ban K: ");
        string K = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("===== SACH GIAO KHOA CUA NXB " + K + " =====");

        bool timThay = false;

        foreach (Sach sach in danhSach)
        {
            if (sach is SachGiaoKhoa &&
                sach.GetNhaXuatBan().ToLower() == K.ToLower())
            {
                sach.XuatThongTin();
                Console.WriteLine();

                timThay = true;
            }
        }

        if (!timThay)
        {
            Console.WriteLine("Khong tim thay sach giao khoa cua NXB " + K);
        }

        // 3. TÌM THÀNH TIỀN CAO NHẤT

        double maxThanhTien = 0;

        foreach (Sach sach in danhSach)
        {
            if (sach.ThanhTien() > maxThanhTien)
            {
                maxThanhTien = sach.ThanhTien();
            }
        }

        Console.WriteLine();
        Console.WriteLine("===== THANH TIEN CAO NHAT =====");
        Console.WriteLine(
            "Thanh tien cao nhat: "
            + maxThanhTien
        );

        Console.ReadLine();
    }
}
