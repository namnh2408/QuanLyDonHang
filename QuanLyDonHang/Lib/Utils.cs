using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyDonHang.Lib
{
    public static class Utils
    {
        public static DateTime DateTimeNow()
        {
            return DateTime.Now;
        }

        public static string NumberToText(int number)
        {
            var unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            var placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };

            string sign = " ";

            if (number < 0)
            {
                sign += "âm ";
                number = number * -1;
            }

            string numberString = number.ToString();

            int position = numberString.Length;

            string result = " ";

            if (position == 0 || number == 0)
            {
                result = unitNumbers[0] + result;
            }
            else
            {
                int ones, tens, hundreds;
                int placeValue = 0;

                while (position > 0)
                {
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(numberString.Substring(position - 1, 1));
                    position--;

                    if (position > 0)
                    {
                        tens = Convert.ToInt32(numberString.Substring(position - 1, 1));
                        position--;

                        if (position > 0)
                        {
                            hundreds = Convert.ToInt32(numberString.Substring(position - 1, 1));
                            position--;
                        }
                    }

                    if (ones > 0 || tens > 0 || hundreds > 0 || placeValue == 3)
                    {
                        result = placeValues[placeValue] + result;
                    }

                    placeValue++;

                    if (placeValue > 3)
                    {
                        placeValue = 1;
                    }

                    if (ones == 1 && tens > 1)
                    {
                        result = "mốt " + result;
                    }
                    else
                    {
                        if (ones == 5 && tens > 0)
                        {
                            result = "lăm " + result;
                        }
                        else if (ones > 0)
                        {
                            result = unitNumbers[ones] + " " + result;
                        }
                    }

                    if (tens < 0)
                    {
                        break;
                    }
                    else
                    {
                        if (tens == 0 && ones > 0) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }

                    if (hundreds < 0)
                    {
                        break;
                    }
                    else
                    {
                        if (hundreds > 0 || tens > 0 || ones > 0)
                        {
                            result = unitNumbers[hundreds] + " trăm " + result;
                        }
                    }

                    result = " " + result;
                }
            }

            result = (sign + result.Trim()).Trim();

            if (!string.IsNullOrEmpty(result))
            {
                result = char.ToUpper(result[0]) + result.Substring(1);
            }

            return result;
        }

        public static string RemoveAcentuationFinder(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            text = text.Normalize(NormalizationForm.FormD);
            var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();

            return new string(chars).Normalize(NormalizationForm.FormC).Replace("đ", "d").Replace("Đ", "D").ToLower();
        }

        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z 0-9-/-]", "");
        }
    }
}
