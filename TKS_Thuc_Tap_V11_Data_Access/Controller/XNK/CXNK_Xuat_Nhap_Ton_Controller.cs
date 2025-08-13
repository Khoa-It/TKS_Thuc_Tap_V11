using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKS_Thuc_Tap_V11_Data_Access.Controller.Cache;
using TKS_Thuc_Tap_V11_Data_Access.Controller.DM;
using TKS_Thuc_Tap_V11_Data_Access.DataLayer;
using TKS_Thuc_Tap_V11_Data_Access.Entity.DM;
using TKS_Thuc_Tap_V11_Data_Access.Entity.XNK;
using TKS_Thuc_Tap_V11_Data_Access.Utility;

namespace TKS_Thuc_Tap_V11_Data_Access.Controller.XNK
{
    public class CXNK_Xuat_Nhap_Ton_Controller
    {
        public List<CDM_San_Pham> FQ_4005_XNT_sp_sel_Bao_Cao_Xuat_Nhap_Ton(DateTime? p_dtmFrom, DateTime? p_dtmTo)
        {
            List<CDM_San_Pham> v_arrSan_Pham = new List<CDM_San_Pham>();
            List<CXNK_Nhap_Kho_Raw_Data> v_arrNhap_Kho_Raw_Data = new List<CXNK_Nhap_Kho_Raw_Data>();
            List<CXNK_Xuat_Kho_Raw_Data> v_arrXuat_Kho_Raw_Data = new List<CXNK_Xuat_Kho_Raw_Data>();

            CCache_San_Pham.Load_Cache_DM_San_Pham();
            CXNK_Nhap_Kho_Controller v_objCtrNhap_Kho = new CXNK_Nhap_Kho_Controller();
            CXNK_Xuat_Kho_Controller v_objCtrXuat_Kho = new CXNK_Xuat_Kho_Controller();
            CXNK_Nhap_Kho_Raw_Data_Controller v_objCtrNhap_Kho_Raw_Data = new CXNK_Nhap_Kho_Raw_Data_Controller();
            CXNK_Xuat_Kho_Raw_Data_Controller v_objCtrXuat_Kho_Raw_Data = new CXNK_Xuat_Kho_Raw_Data_Controller();

            v_arrSan_Pham = CCache_San_Pham.List_Data();
            v_arrNhap_Kho_Raw_Data = v_objCtrNhap_Kho_Raw_Data.F4005_sp_sel_List_NKRD_By_Created();
            v_arrXuat_Kho_Raw_Data = v_objCtrXuat_Kho_Raw_Data.F4005_sp_sel_List_XKRD_By_Created();

            foreach (var item in v_arrSan_Pham)
            {
                var v_objRes = Calculate_SL_Dau_Ky_And_SL_Nhap(v_arrNhap_Kho_Raw_Data, item.Auto_ID, p_dtmFrom, p_dtmTo);
                item.SL_Dau_Ky = v_objRes.SL_Dau_Ky;
                item.SL_Nhap = v_objRes.SL_Nhap;
                item.SL_Xuat = Calculate_SL_Xuat(v_arrXuat_Kho_Raw_Data, item.Auto_ID, p_dtmFrom, p_dtmTo);
                item.SL_Cuoi_Ky = item.SL_Dau_Ky + item.SL_Nhap - item.SL_Xuat;
            }

            return v_arrSan_Pham;
        }

        public (double SL_Dau_Ky, double SL_Nhap) Calculate_SL_Dau_Ky_And_SL_Nhap(List<CXNK_Nhap_Kho_Raw_Data> p_arrNhap_Kho_Raw_Data, long p_lngSan_Pham_ID, DateTime? p_dtmFrom, DateTime? p_dtmTo)
        {
            double v_dblSLNhap = 0;
            double v_dblSL_Dau_Ky = 0;
            foreach (var item in p_arrNhap_Kho_Raw_Data)
            {
                if (item.San_Pham_ID == p_lngSan_Pham_ID)
                {
                    if (p_dtmFrom <= item.Ngay_Nhap && item.Ngay_Nhap <= p_dtmTo)
                        v_dblSLNhap += item.SL_Nhap;
                    if (item.Ngay_Nhap < p_dtmFrom)
                        v_dblSL_Dau_Ky += item.SL_Nhap;
                }
            }
            return (v_dblSL_Dau_Ky, v_dblSLNhap);
        }

        public double Calculate_SL_Xuat(List<CXNK_Xuat_Kho_Raw_Data> p_arrXuat_Kho_Raw_Data, long p_lngSan_Pham_ID, DateTime? p_dtmFrom, DateTime? p_dtmTo)
        {
            double v_dblSLXuat = 0;
            foreach (var item in p_arrXuat_Kho_Raw_Data)
            {
                if (item.San_Pham_ID == p_lngSan_Pham_ID)
                {
                    if (p_dtmFrom <= item.Ngay_Xuat && item.Ngay_Xuat <= p_dtmTo)
                        v_dblSLXuat += item.SL_Xuat;
                }
            }
            return v_dblSLXuat;
        }
    }
}
