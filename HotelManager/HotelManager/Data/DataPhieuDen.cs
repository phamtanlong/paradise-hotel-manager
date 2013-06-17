﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;
using HotelManager.Data.Entity;
using System.Data;
using System.Windows.Forms;

namespace HotelManager.Data
{
    class DataPhieuDen
    {
        public static ArrayList GetList()
        {
            ArrayList listPhieuDen = new ArrayList();
            string StrSQL = "SELECT * FROM phieu_den";
            MySqlCommand ObjCmd = DataProvider.getInstance().getCommand();
            ObjCmd.CommandText = StrSQL;
            MySqlDataReader ObjReader;
            ObjReader = ObjCmd.ExecuteReader();

            while (ObjReader.Read())
            {
                PhieuDen PhieuDen = new PhieuDen();

                PhieuDen.MaPhieuDen = (int)ObjReader["MaPhieuDen"];
                PhieuDen.TenKhachDaiDien = (string)ObjReader["TenKhachDaiDien"];
                PhieuDen.CMND = (string)ObjReader["CMND"];
                PhieuDen.ThoiDiemDen = (DateTime)ObjReader["ThoiDiemDen"];
                PhieuDen.ThoiDiemDi = (DateTime)ObjReader["ThoiDiemDi"];
                PhieuDen.TongChiPhi = (float)ObjReader["TongChiPhi"];
                PhieuDen.TinhTrangThanhToan = (bool)ObjReader["TinhTrangThanhToan"];

                listPhieuDen.Add(PhieuDen);
            }

            return listPhieuDen;
        }

        public static DataTable GetTable()
        {
            DataTable table = new DataTable();
            string StrSQL = "SELECT * FROM phieu_den";
            MySqlDataAdapter ObjAdapter = new MySqlDataAdapter(StrSQL, DataProvider.getInstance().getConnection());
            ObjAdapter.Fill(table);
            return table;
        }

        public static void UpdateTable(DataTable dataTable)
        {
            //tao chuoi ket noi.
            MySqlConnection ObjCn = DataProvider.getInstance().getConnection();
            string StrSQL = "SELECT * FROM phieu_den";

            MySqlDataAdapter ObjAdapter = new MySqlDataAdapter(StrSQL, ObjCn);
            MySqlCommandBuilder cb = new MySqlCommandBuilder(ObjAdapter);

            ObjAdapter.Update(dataTable);

            ObjCn.Close();
        }

        public static void UpdatePhieuDen(PhieuDen PhieuDen)
        {
            string StrSQL = "UPDATE phieu_den SET TenKhachDaiDien = ?, CMND = ?, ThoiDiemDen = ?, ThoiDiemDi = ?, TongChiPhi = ?, TinhTrangThanhToan = ? WHERE MaPhieuDen = ?";
            MySqlCommand ObjCmd = DataProvider.getInstance().getCommand();
            ObjCmd.CommandText = StrSQL;

            ObjCmd.Parameters.Add("@TenKhachDaiDien", MySqlDbType.String).Value = PhieuDen.TenKhachDaiDien;
            ObjCmd.Parameters.Add("@CMND", MySqlDbType.String).Value = PhieuDen.CMND;
            ObjCmd.Parameters.Add("@ThoiDiemDen", MySqlDbType.Datetime).Value = PhieuDen.ThoiDiemDen;
            ObjCmd.Parameters.Add("@ThoiDiemDi", MySqlDbType.Datetime).Value = PhieuDen.ThoiDiemDi;
            ObjCmd.Parameters.Add("@TongChiPhi", MySqlDbType.Float).Value = PhieuDen.TongChiPhi;
            ObjCmd.Parameters.Add("@TinhTrangThanhToan", MySqlDbType.Byte).Value = PhieuDen.TinhTrangThanhToan;

            ObjCmd.Parameters.Add("@MaPhieuDen", MySqlDbType.Int32).Value = PhieuDen.MaPhieuDen;

            ObjCmd.ExecuteNonQuery();
        }

        public static bool Add(PhieuDen PhieuDen)
        {
            try
            {
                MySqlConnection ObjCn = DataProvider.getInstance().getConnection();

                string StrSQL = "INSERT INTO phieu_den(TenKhachDaiDien, CMND, ThoiDiemDen, ThoiDiemDi, TongChiPhi, TinhTrangThanhToan) VALUES( ?, ?, ?, ?, ?, ?);";
                MySqlCommand ObjCmd = new MySqlCommand(StrSQL, ObjCn);

                ObjCmd.Parameters.Add("@TenKhachDaiDien", MySqlDbType.String).Value = PhieuDen.TenKhachDaiDien;
                ObjCmd.Parameters.Add("@CMND", MySqlDbType.String).Value = PhieuDen.CMND;
                ObjCmd.Parameters.Add("@ThoiDiemDen", MySqlDbType.Datetime).Value = PhieuDen.ThoiDiemDen;
                ObjCmd.Parameters.Add("@ThoiDiemDi", MySqlDbType.Datetime).Value = PhieuDen.ThoiDiemDi;
                ObjCmd.Parameters.Add("@TongChiPhi", MySqlDbType.Float).Value = PhieuDen.TongChiPhi;
                ObjCmd.Parameters.Add("@TinhTrangThanhToan", MySqlDbType.Byte).Value = PhieuDen.TinhTrangThanhToan;

                ObjCmd.ExecuteNonQuery();

                //Theo bạn Hiệp nghĩ là để update MaPhong theo TenPhong, ~ tăng cái primary key
                StrSQL = "Select @@IDENTITY";

                ObjCmd = new MySqlCommand(StrSQL, ObjCn);
                PhieuDen.MaPhieuDen = (int)ObjCmd.ExecuteScalar();

                return true;
            }
            catch (Exception ee)
            {
                if (ee.Message.Contains("duplicate"))
                {
                    MessageBox.Show("Dữ liệu trùng lặp: PhieuDen " + PhieuDen.TenKhachDaiDien);
                }
                return false;
            }
        }

        public static void Delete(int maPhieuDen)
        {
            string StrSQL = "DELETE FROM phieu_den WHERE MaPhieuDen = ?";

            MySqlCommand ObjCmd = DataProvider.getInstance().getCommand();
            ObjCmd.CommandText = StrSQL;

            ObjCmd.Parameters.Add("@MaPhieuDen", MySqlDbType.Int32).Value = maPhieuDen;

            ObjCmd.ExecuteNonQuery();
        }

        public static DataTable Find(int maPhieuDen)
        {
            DataTable dt = new DataTable();

            string StrSQL = "SELECT * FROM phieu_den WHERE MaPhieuDen = ?";
            MySqlCommand ObjCmd = DataProvider.getInstance().getCommand();
            ObjCmd.CommandText = StrSQL;

            ObjCmd.Parameters.Add("@MaPhieuDen", MySqlDbType.Int32).Value = maPhieuDen;

            MySqlDataAdapter adapter = new MySqlDataAdapter(ObjCmd);
            adapter.Fill(dt);

            return dt;
        }

        public static DataTable Find(string tenKhachDaiDien)
        {
            DataTable dt = new DataTable();

            string StrSQL = "SELECT * FROM phieu_den WHERE TenKhachDaiDien = ?";

            MySqlCommand ObjCmd = DataProvider.getInstance().getCommand();
            ObjCmd.CommandText = StrSQL;

            ObjCmd.Parameters.Add("@TenKhachDaiDien", MySqlDbType.String).Value = tenKhachDaiDien;

            MySqlDataAdapter adapter = new MySqlDataAdapter(ObjCmd);
            adapter.Fill(dt);

            return dt;
        }

    }
}