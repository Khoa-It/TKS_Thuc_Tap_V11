using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKS_Thuc_Tap_V11_Data_Access.Utility;

namespace TKS_Thuc_Tap_V11_Data_Access.Entity.XNK
{
    public class CXNK_Xuat_Kho
    {
        private long m_lngAuto_ID;
        private string m_strSo_Phieu_Xuat_Kho;
        private long m_lngKho_ID;
        private DateTime? m_dtmNgay_Xuat_Kho;
        private string m_strGhi_Chu;
        private int m_intdeleted;
        private DateTime? m_dtmCreated;
        private string m_strCreated_By;
        private string m_strCreated_By_Function;
        private DateTime? m_dtmLast_Updated;
        private string m_strLast_Updated_By;
        private string m_strLast_Updated_By_Function;

        private string m_strTen_Kho;

        public CXNK_Xuat_Kho()
        {
            ResetData();
        }

        public void ResetData()
        {
            m_lngAuto_ID = CConst.INT_VALUE_NULL;
            m_strSo_Phieu_Xuat_Kho = CConst.STR_VALUE_NULL;
            m_lngKho_ID = CConst.INT_VALUE_NULL;
            m_dtmNgay_Xuat_Kho = CConst.DTM_VALUE_NULL;
            m_strGhi_Chu = CConst.STR_VALUE_NULL;
            m_intdeleted = CConst.INT_VALUE_NULL;
            m_dtmCreated = CConst.DTM_VALUE_NULL;
            m_strCreated_By = CConst.STR_VALUE_NULL;
            m_strCreated_By_Function = CConst.STR_VALUE_NULL;
            m_dtmLast_Updated = CConst.DTM_VALUE_NULL;
            m_strLast_Updated_By = CConst.STR_VALUE_NULL;
            m_strLast_Updated_By_Function = CConst.STR_VALUE_NULL;
        }

        public long Auto_ID
        {
            get
            {
                return m_lngAuto_ID;
            }
            set
            {
                m_lngAuto_ID = value;
            }
        }

        public string So_Phieu_Xuat_Kho
        {
            get
            {
                return m_strSo_Phieu_Xuat_Kho;
            }
            set
            {
                m_strSo_Phieu_Xuat_Kho = value.Trim();
            }
        }

        public long Kho_ID
        {
            get
            {
                return m_lngKho_ID;
            }
            set
            {
                m_lngKho_ID = value;
            }
        }

        public DateTime? Ngay_Xuat_Kho
        {
            get
            {
                return m_dtmNgay_Xuat_Kho;
            }
            set
            {
                m_dtmNgay_Xuat_Kho = value;
            }
        }

        public string Ghi_Chu
        {
            get
            {
                return m_strGhi_Chu;
            }
            set
            {
                m_strGhi_Chu = value.Trim();
            }
        }

        public int deleted
        {
            get
            {
                return m_intdeleted;
            }
            set
            {
                m_intdeleted = value;
            }
        }

        public DateTime? Created
        {
            get
            {
                return m_dtmCreated;
            }
            set
            {
                m_dtmCreated = value;
            }
        }

        public string Created_By
        {
            get
            {
                return m_strCreated_By;
            }
            set
            {
                m_strCreated_By = value.Trim();
            }
        }

        public string Created_By_Function
        {
            get
            {
                return m_strCreated_By_Function;
            }
            set
            {
                m_strCreated_By_Function = value.Trim();
            }
        }

        public DateTime? Last_Updated
        {
            get
            {
                return m_dtmLast_Updated;
            }
            set
            {
                m_dtmLast_Updated = value;
            }
        }

        public string Last_Updated_By
        {
            get
            {
                return m_strLast_Updated_By;
            }
            set
            {
                m_strLast_Updated_By = value.Trim();
            }
        }

        public string Last_Updated_By_Function
        {
            get
            {
                return m_strLast_Updated_By_Function;
            }
            set
            {
                m_strLast_Updated_By_Function = value.Trim();
            }
        }

        public string Ten_Kho
        {
            get
            {
                return m_strTen_Kho;
            }
            set
            {
                m_strTen_Kho = value.Trim();
            }
        }

        public bool IsValid(out string p_strMessage)
        {
            if (m_lngKho_ID <= 0)
            {
                p_strMessage = "Mã kho không hợp lệ.";
                return false;
            }
            if (string.IsNullOrEmpty(m_strSo_Phieu_Xuat_Kho))
            {
                p_strMessage = "Số phiếu xuất kho không được trống";
                return false;
            }
            if (!m_dtmNgay_Xuat_Kho.HasValue)
            {
                p_strMessage = "Ngày xuất Kho không được để trống.";
                return false;
            }
            p_strMessage = string.Empty;
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj is CXNK_Xuat_Kho other)
            {
                return Kho_ID == other.Kho_ID &&
                       string.Equals(So_Phieu_Xuat_Kho, other.So_Phieu_Xuat_Kho, StringComparison.OrdinalIgnoreCase) &&
                       Nullable.Equals(Ngay_Xuat_Kho, other.Ngay_Xuat_Kho);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Kho_ID, So_Phieu_Xuat_Kho?.ToLower(), Ngay_Xuat_Kho);
        }

    }
}
