
using System;
using System.Collections.Generic;
using System.Text;

// Lớp cha: Chuyến xe
public abstract class ChuyenXe
{
    protected string maSoChuyen;
    protected string hoTenTaiXe;
    protected string soXe;
    protected double doanhThu;

    // Constructor
    public ChuyenXe(
        string maSoChuyen,
        string hoTenTaiXe,
        string soXe,
        double doanhThu)
    {
        this.maSoChuyen = maSoChuyen;
        this.hoTenTaiXe = hoTenTaiXe;
        this.soXe = soXe;
        this.doanhThu = doanhThu;
    }

    // Lấy doanh thu
    public double GetDoanhThu()
    {
        return doanhThu;
    }

    // Xuất thông tin
    public virtual void XuatThongTin()
    {
        Console.WriteLine("Mã số chuyến: " + maSoChuyen);
        Console.WriteLine("Họ tên tài xế: " + hoTenTaiXe);
        Console.WriteLine("Số xe: " + soXe);
        Console.WriteLine("Doanh thu: " + doanhThu.ToString("N0") + " VNĐ");
    }
}

// Chuyến xe nội thành
public class ChuyenXeNoiThanh : ChuyenXe
{
    private int soTuyen;
    private double soKmDiDuoc;

    // Constructor
    public ChuyenXeNoiThanh(
        string maSoChuyen,
        string hoTenTaiXe,
        string soXe,
        int soTuyen,
        double soKmDiDuoc,
        double doanhThu)
        : base(maSoChuyen, hoTenTaiXe, soXe, doanhThu)
    {
        this.soTuyen = soTuyen;
        this.soKmDiDuoc = soKmDiDuoc;
    }

    // Xuất thông tin
    public override void XuatThongTin()
    {
        Console.WriteLine("=== CHUYẾN XE NỘI THÀNH ===");

        base.XuatThongTin();

        Console.WriteLine("Số tuyến: " + soTuyen);
        Console.WriteLine("Số km đi được: " + soKmDiDuoc);
    }
}

// Chuyến xe ngoại thành
public class ChuyenXeNgoaiThanh : ChuyenXe
{
    private string noiDen;
    private int soNgayDiDuoc;

    // Constructor
    public ChuyenXeNgoaiThanh(
        string maSoChuyen,
        string hoTenTaiXe,
        string soXe,
        string noiDen,
        int soNgayDiDuoc,
        double doanhThu)
        : base(maSoChuyen, hoTenTaiXe, soXe, doanhThu)
    {
        this.noiDen = noiDen;
        this.soNgayDiDuoc = soNgayDiDuoc;
    }

    // Xuất thông tin
    public override void XuatThongTin()
    {
        Console.WriteLine("=== CHUYẾN XE NGOẠI THÀNH ===");

        base.XuatThongTin();

        Console.WriteLine("Nơi đến: " + noiDen);
        Console.WriteLine("Số ngày đi được: " + soNgayDiDuoc);
    }
}

// Chương trình chính
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        // Tạo danh sách chuyến xe
        List<ChuyenXe> danhSach = new List<ChuyenXe>();

        // Tạo 2 chuyến xe nội thành
        ChuyenXeNoiThanh xeNoiThanh1 = new ChuyenXeNoiThanh(
            "NT01",
            "Nguyen Van An",
            "51A-12345",
            10,
            150.5,
            5000000
        );

        ChuyenXeNoiThanh xeNoiThanh2 = new ChuyenXeNoiThanh(
            "NT02",
            "Tran Van Binh",
            "51A-67890",
            15,
            200.5,
            6000000
        );

        // Tạo 2 chuyến xe ngoại thành
        ChuyenXeNgoaiThanh xeNgoaiThanh1 = new ChuyenXeNgoaiThanh(
            "NG01",
            "Le Van Cuong",
            "51B-11111",
            "Vung Tau",
            2,
            8000000
        );

        ChuyenXeNgoaiThanh xeNgoaiThanh2 = new ChuyenXeNgoaiThanh(
            "NG02",
            "Pham Van Dung",
            "51B-22222",
            "Da Lat",
            3,
            10000000
        );

        // Thêm vào danh sách
        danhSach.Add(xeNoiThanh1);
        danhSach.Add(xeNoiThanh2);
        danhSach.Add(xeNgoaiThanh1);
        danhSach.Add(xeNgoaiThanh2);

        // Xuất danh sách
        Console.WriteLine("===== DANH SÁCH CHUYẾN XE =====");
        Console.WriteLine();

        foreach (ChuyenXe xe in danhSach)
        {
            xe.XuatThongTin();
            Console.WriteLine();
        }

        // Tính tổng doanh thu
        double tongDoanhThu = 0;
        double tongDoanhThuNoiThanh = 0;
        double tongDoanhThuNgoaiThanh = 0;

        foreach (ChuyenXe xe in danhSach)
        {
            tongDoanhThu += xe.GetDoanhThu();

            if (xe is ChuyenXeNoiThanh)
            {
                tongDoanhThuNoiThanh += xe.GetDoanhThu();
            }
            else if (xe is ChuyenXeNgoaiThanh)
            {
                tongDoanhThuNgoaiThanh += xe.GetDoanhThu();
            }
        }

        // Xuất tổng doanh thu
        Console.WriteLine("===== TỔNG DOANH THU =====");

        Console.WriteLine(
            "Tổng doanh thu tất cả chuyến xe: "
            + tongDoanhThu.ToString("N0")
            + " VNĐ"
        );

        Console.WriteLine(
            "Tổng doanh thu xe nội thành: "
            + tongDoanhThuNoiThanh.ToString("N0")
            + " VNĐ"
        );

        Console.WriteLine(
            "Tổng doanh thu xe ngoại thành: "
            + tongDoanhThuNgoaiThanh.ToString("N0")
            + " VNĐ"
        );

        Console.ReadLine();
    }
}

