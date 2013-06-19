﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Collections;
using HotelManager.Data;
using HotelManager.Data.Entity;

namespace HotelManager.Business
{
    class BusPhieuDatCho
    {
        /// <summary>
        /// Lấy danh sách PHIEU_DAT_CHO
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetList()
        {
            return DataPhieuDatCho.GetList();
        }

        /// <summary>
        /// Lấy hết bảng PHIEU_DAT_CHO
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTable()
        {
            return DataPhieuDatCho.GetTable();
        }

        /// <summary>
        /// UpdatePhieuDatCho giá trị mới cho bảng PHIEU_DAT_CHO
        /// </summary>
        /// <param name="dataTable"></param>
        public static void UpdateTable(DataTable dataTable)
        {
            DataPhieuDatCho.UpdateTable(dataTable);
        }

        /// <summary>
        /// Thêm phiếu đặt chỗ đặt chỗ
        /// </summary>
        /// <param name="_phieu"></param>
        /// <returns>Trả về MaPhieuDatCho nếu thành công, ngược lại -1</returns>
        public static int Add(PhieuDatCho _phieuDatCho)
        {
            return DataPhieuDatCho.Add(_phieuDatCho);
        }

        /// <summary>
        /// Xoá phiếu đặt chỗ phòng với MaPhieuDatCho
        /// </summary>
        /// <param name="_maPhieuDatCho"></param>
        public static void Delete(int _maPhieuDatCho)
        {
            DataPhieuDatCho.Delete(_maPhieuDatCho);
        }

         /// <summary>
        /// Sửa 1 phiếu đặt chỗ
        /// </summary>
        /// <param name="_phieu"></param>
        public static void UpdatePhieuDatCho(PhieuDatCho _phieuDatCho)
        {
            DataPhieuDatCho.UpdatePhieuDatCho(_phieuDatCho);
        }

        /// <summary>
        /// Tìm kiếm phiếu đặt chỗ theo Mã phiếu đặt chỗ
        /// </summary>
        /// <param name="MaPhieuDatCho"></param>
        /// <returns></returns>
        public static PhieuDatCho Find(int _maPhieuDatCho)
        {
            return DataPhieuDatCho.Find(_maPhieuDatCho);
        }




    }
}