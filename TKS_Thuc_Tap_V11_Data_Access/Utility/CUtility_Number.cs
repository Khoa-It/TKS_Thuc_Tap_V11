using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKS_Thuc_Tap_V11_Data_Access.Utility
{
    public class CUtility_Number
    {
        static readonly string[] m_strDon_Vi = { "", "nghìn", "triệu", "tỷ", "nghìn tỷ", "triệu tỷ", "tỷ tỷ" };
        static readonly string[] m_strChu_So = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };

        public static string ReadNumberToText(long p_iNumber)
        {
            if (p_iNumber == 0)
                return "không";

            if (p_iNumber < 0)
                return "âm " + ReadNumberToText(-p_iNumber);

            var v_strHandle = new StringBuilder();
            int v_iGroup = 0;

            while (p_iNumber > 0)
            {
                int v_iThree_Digits = (int)(p_iNumber % 1000);
                if (v_iThree_Digits != 0)
                {
                    string v_iGroupText = ReadThreeNumber(v_iThree_Digits);
                    if (v_iGroup > 0)
                        v_strHandle.Insert(0, v_iGroupText + " " + m_strDon_Vi[v_iGroup] + " ");
                    else
                        v_strHandle.Insert(0, v_iGroupText + " ");
                }

                p_iNumber /= 1000;
                v_iGroup++;
            }

            // Chuẩn hóa kết quả
            string v_strResult = v_strHandle.ToString().Trim();
            v_strResult = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(v_strResult.ToLower());

            return v_strResult;
        }

        private static string ReadThreeNumber(int p_iNumber)
        {
            int tram = p_iNumber / 100;
            int chuc = (p_iNumber % 100) / 10;
            int donvi = p_iNumber % 10;
            var v_strResult = "";

            if (tram != 0)
            {
                v_strResult += m_strChu_So[tram] + " trăm";
                if (chuc == 0 && donvi != 0)
                    v_strResult += " lẻ";
            }

            if (chuc != 0 && chuc != 1)
            {
                v_strResult += " " + m_strChu_So[chuc] + " mươi";
                if (donvi == 1)
                    v_strResult += " mốt";
                else if (donvi == 5)
                    v_strResult += " lăm";
                else if (donvi != 0)
                    v_strResult += " " + m_strChu_So[donvi];
            }
            else if (chuc == 1)
            {
                v_strResult += " mười";
                if (donvi == 5)
                    v_strResult += " lăm";
                else if (donvi != 0)
                    v_strResult += " " + m_strChu_So[donvi];
            }
            else if (chuc == 0 && donvi != 0)
            {
                v_strResult += " " + m_strChu_So[donvi];
            }

            return v_strResult.Trim();
        }

    }
}
