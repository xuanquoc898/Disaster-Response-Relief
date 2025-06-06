using System.Text.RegularExpressions;

namespace D2R.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            phoneNumber = phoneNumber.Replace(" ", "").Replace("-", "");
            string mobilePattern = @"^0(3[2-9]|5[6|8|9]|7[0|6-9]|8[1-6|8|9]|9[0-9])\d{7}$";
            string fixedLinePattern = @"^0(2[0-9]{2})\d{7}$";
            return Regex.IsMatch(phoneNumber, mobilePattern) || Regex.IsMatch(phoneNumber, fixedLinePattern);
        }

        public static bool IsValidCanCuocCongDan(string cccd)
        {
            HashSet<string> ValidProvinceCodes = new HashSet<string>
            {
                "001", "002", "004", "006", "008", "010", "011", "012", "014", "015",
                "017", "019", "020", "022", "024", "025", "026", "027", "030", "031",
                "033", "034", "035", "036", "037", "038", "040", "042", "044", "045",
                "046", "048", "049", "051", "052", "054", "056", "058", "060", "062",
                "064", "066", "067", "068", "070", "072", "074", "075", "077", "079",
                "080", "082", "083", "084", "086", "087", "089", "091", "092", "093",
                "094", "095", "096"
            };

            if (string.IsNullOrWhiteSpace(cccd))
                return false;

            if (cccd.Length != 12 || !long.TryParse(cccd, out _))
                return false;

            string provinceCode = cccd.Substring(0, 3);
            if (!ValidProvinceCodes.Contains(provinceCode))
                return false;

            string genderCenturyCode = cccd.Substring(3, 1);
            if (!"0123456789".Contains(genderCenturyCode))
                return false;

            string birthYearPart = cccd.Substring(4, 2);
            if (!int.TryParse(birthYearPart, out int yearSuffix) || yearSuffix < 0 || yearSuffix > 99)
                return false;

            string last6Digits = cccd.Substring(6);
            if (!int.TryParse(last6Digits, out int serial) || serial < 1 || serial > 999999)
                return false;

            return true;
        }

        public static bool IsValidEmailAddress(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
        
        public static bool CheckName(string hoTen, out string message)
        {
            message = "";

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                message = "Họ và tên không được để trống.";
                return false;
            }

            hoTen = hoTen.Trim();

            if (hoTen.Length < 2)
            {
                message = "Họ và tên quá ngắn.";
                return false;
            }

            if (!Regex.IsMatch(hoTen, @"^[\p{L}\s]+$"))
            {
                message = "Họ và tên chỉ được chứa chữ cái và khoảng trắng.";
                return false;
            }

            if (hoTen.Replace(" ", "").Length == 0)
            {
                message = "Họ và tên không hợp lệ (chỉ có khoảng trắng).";
                return false;
            }
            return true;
        }

    }
}
