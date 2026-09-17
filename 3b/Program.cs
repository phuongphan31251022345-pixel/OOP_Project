using System;
using System.Collections.Generic;
using System.Text;

// Lớp cha
public abstract class GiaoDich
{
    protected string maGiaoDich;
    protected DateTime ngayGiaoDich;
    protected double donGia;
    protected int soLuong;

    public GiaoDich(string maGiaoDich, DateTime ngayGiaoDich,
                    double donGia, int soLuong)
    {
        this.maGiaoDich = maGiaoDich;
        this.ngayGiaoDich = ngayGiaoDich;
        this.donGia = donGia;
        this.soLuong = soLuong;
    }

    public int GetSoLuong()
    {
        return soLuong;
    }

    public double GetDonGia()
    {
        return donGia;
    }

    public abstract double ThanhTien();

    public virtual void XuatThongTin()
    {
        Console.WriteLine("Mã giao dịch: " + maGiaoDich);
        Console.WriteLine("Ngày giao dịch: " +
                          ngayGiaoDich.ToString("dd/MM/yyyy"));
        Console.WriteLine("Đơn giá: " + donGia);
        Console.WriteLine("Số lượng: " + soLuong);
        Console.WriteLine("Thành tiền: " + ThanhTien());
    }
}

// Giao dịch vàng
public class GiaoDichVang : GiaoDich
{
    private string loaiVang;

    public GiaoDichVang(string maGiaoDich, DateTime ngayGiaoDich,
                        double donGia, int soLuong, string loaiVang)
        : base(maGiaoDich, ngayGiaoDich, donGia, soLuong)
    {
        this.loaiVang = loaiVang;
    }

    // Thành tiền = số lượng * đơn giá
    public override double ThanhTien()
    {
        return soLuong * donGia;
    }

    public override void XuatThongTin()
    {
        base.XuatThongTin();
        Console.WriteLine("Loại vàng: " + loaiVang);
    }
}

// Giao dịch tiền tệ
public class GiaoDichTienTe : GiaoDich
{
    private double tiGia;
    private string loaiTienTe;

    public GiaoDichTienTe(string maGiaoDich, DateTime ngayGiaoDich,
                          double donGia, int soLuong,
                          double tiGia, string loaiTienTe)
        : base(maGiaoDich, ngayGiaoDich, donGia, soLuong)
    {
        this.tiGia = tiGia;
        this.loaiTienTe = loaiTienTe;
    }

    // USD hoặc Euro:
    // Thành tiền = số lượng * đơn giá * tỉ giá
   
    // Việt Nam:
    // Thành tiền = số lượng * đơn giá
    public override double ThanhTien()
    {
        if (loaiTienTe == "USD" || loaiTienTe == "Euro")
        {
            return soLuong * donGia * tiGia;
        }
        else
        {
            return soLuong * donGia;
        }
    }

    public override void XuatThongTin()
    {
        base.XuatThongTin();
        Console.WriteLine("Tỉ giá: " + tiGia);
        Console.WriteLine("Loại tiền tệ: " + loaiTienTe);
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Tạo danh sách giao dịch
        List<GiaoDich> danhSach = new List<GiaoDich>();

        // 3 giao dịch vàng

        danhSach.Add(new GiaoDichVang(
            "V01",
            new DateTime(2026, 1, 10),
            800000000,
            2,
            "Vàng 24K"
        ));

        danhSach.Add(new GiaoDichVang(
            "V02",
            new DateTime(2026, 2, 15),
            1200000000,
            3,
            "Vàng 18K"
        ));

        danhSach.Add(new GiaoDichVang(
            "V03",
            new DateTime(2026, 3, 20),
            1500000000,
            1,
            "Vàng 24K"
        ));

        // 3 giao dịch tiền tệ

        danhSach.Add(new GiaoDichTienTe(
            "TT01",
            new DateTime(2026, 1, 12),
            25000,
            100,
            1,
            "Việt Nam"
        ));

        danhSach.Add(new GiaoDichTienTe(
            "TT02",
            new DateTime(2026, 2, 18),
            1,
            1000,
            25000,
            "USD"
        ));

        danhSach.Add(new GiaoDichTienTe(
            "TT03",
            new DateTime(2026, 3, 25),
            1,
            500,
            29000,
            "Euro"
        ));

        // 1. Tính tổng số lượng

        int tongSoLuongVang = 0;
        int tongSoLuongTienTe = 0;

        foreach (GiaoDich giaoDich in danhSach)
        {
            if (giaoDich is GiaoDichVang)
            {
                tongSoLuongVang += giaoDich.GetSoLuong();
            }
            else if (giaoDich is GiaoDichTienTe)
            {
                tongSoLuongTienTe += giaoDich.GetSoLuong();
            }
        }

        Console.WriteLine("===== TỔNG SỐ LƯỢNG =====");
        Console.WriteLine("Tổng số lượng giao dịch vàng: "
                          + tongSoLuongVang);
        Console.WriteLine("Tổng số lượng giao dịch tiền tệ: "
                          + tongSoLuongTienTe);

        // 2. Tính trung bình thành tiền của giao dịch tiền tệ

        double tongThanhTienTienTe = 0;
        int soGiaoDichTienTe = 0;

        foreach (GiaoDich giaoDich in danhSach)
        {
            if (giaoDich is GiaoDichTienTe)
            {
                tongThanhTienTienTe += giaoDich.ThanhTien();
                soGiaoDichTienTe++;
            }
        }

        double trungBinh = tongThanhTienTienTe / soGiaoDichTienTe;

        Console.WriteLine();
        Console.WriteLine("===== TRUNG BÌNH THÀNH TIỀN =====");
        Console.WriteLine("Trung bình thành tiền giao dịch tiền tệ: "
                          + trungBinh);

        // 3. Xuất giao dịch có đơn giá > 1 tỷ

        Console.WriteLine();
        Console.WriteLine("===== GIAO DỊCH CÓ ĐƠN GIÁ > 1 TỶ =====");

        foreach (GiaoDich giaoDich in danhSach)
        {
            if (giaoDich.GetDonGia() > 1000000000)
            {
                giaoDich.XuatThongTin();
                Console.WriteLine();
            }
        }

        Console.ReadKey();
    }
}

