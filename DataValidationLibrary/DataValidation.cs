using System;
using System.Text.RegularExpressions;

namespace DataValidationLibrary
{
    public static class Validator
    {
        public static bool ValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        public static bool ValidPhoneNumber(string phoneNumber)
        {
            var phonePattern = @"^\+?[1-9]\d{1,14}$";
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        public static bool ValidDate(DateTime date)
        {
            return date <= DateTime.Now;
        }
    }
}
