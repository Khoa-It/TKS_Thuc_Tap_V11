using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKS_Thuc_Tap_V11_Data_Access.DataLayer;
using TKS_Thuc_Tap_V11_Data_Access.Entity.XNK;
using TKS_Thuc_Tap_V11_Data_Access.Utility;

namespace TKS_Thuc_Tap_V11_Data_Access.Controller.XNK
{
    public class CXNK_Xuat_Nhap_Ton_Controller
    {
        public List<CXNK_Xuat_Nhap_Ton> FQ_4005_XNT_sp_sel_Bao_Cao_Xuat_Nhap_Ton(DateTime? p_dtmFrom, DateTime? p_dtmTo)
        {
            List<CXNK_Xuat_Nhap_Ton> v_arrRes = new List<CXNK_Xuat_Nhap_Ton>();
            DataTable v_dt = new DataTable();

            try
            {
                p_dtmFrom = CUtility_Date.Convert_To_Dau_Ngay(p_dtmFrom);
                p_dtmTo = CUtility_Date.Convert_To_Cuoi_Ngay(p_dtmTo);

                CSqlHelper.FillDataTable(CConfig.TKS_Thuc_Tap_V11_Conn_String, v_dt, "FQ_4005_XNT_sp_sel_Bao_Cao_Xuat_Nhap_Ton", p_dtmFrom, p_dtmTo);

                foreach (DataRow v_row in v_dt.Rows)
                {
                    CXNK_Xuat_Nhap_Ton v_objRes = CUtility.Map_Row_To_Entity<CXNK_Xuat_Nhap_Ton>(v_row);
                    v_arrRes.Add(v_objRes);
                }
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                v_dt.Dispose();
            }

            return v_arrRes;
        }
    }
}
