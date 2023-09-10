using meetroomreservation.Business.Utils;
using System.Text.RegularExpressions;

namespace meetroomreservation.Business.Validations
{
    public class CustomValidations
    {
        public static Regex GetDateRegex()
        {
            return new Regex(@"^(\d{4})-(\d{2})-(\d{2}$)");
        }

        public static Regex GetTimeRegex()
        {
            return new Regex(@"^([01][0-9]|2[0-3]):[0-5][0-9]$");
        }

        public static Regex GetRepeatedDigitsRegex()
        {
            return new Regex(@"^(.)\1+$");
        }

        public static bool ValidateDate(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                return true;
            }

            if (!GetDateRegex().IsMatch(date))
            {
                return false;
            }

            try
            {
                Convert.ToDateTime(date);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ValidatePasswordStrength(string password)
        {
            Regex atLeastOneLowerCaseCharacter;
            Regex atLeastOneUpperCaseCharacter;
            Regex atLeastOneNumberCharacter;
            Regex atLeastOneSpecialCharacter;

            if (password.Length < BusinessRulesConstants.MinimumLengthPassword || password.Length > BusinessRulesConstants.MaximumLengthPassword)
            {
                return false;
            }

            atLeastOneLowerCaseCharacter = new Regex(@"[a-z]+");
            atLeastOneUpperCaseCharacter = new Regex(@"[A-Z]+");
            atLeastOneNumberCharacter = new Regex(@"\d+");
            atLeastOneSpecialCharacter = new Regex(@"[!@#$%^&*(),.-]+");

            if (!atLeastOneLowerCaseCharacter.IsMatch(password))
            {
                return false;
            }

            if (!atLeastOneUpperCaseCharacter.IsMatch(password))
            {
                return false;
            }

            if (!atLeastOneSpecialCharacter.IsMatch(password))
            {
                return false;
            }

            if (!atLeastOneNumberCharacter.IsMatch(password))
            {
                return false;
            }

            return true;
        }



        public static bool ValidateDatabaseId(int id)
        {
            return id > 0;
        }

        public static bool ValidateDatabaseIdString(string id)
        {
            int response = Convert.ToInt32(id);
            return response > 0;
        }


        public static bool IsInLengthInterval(int min, int max, string s)
        {
            if (s == null)
            {
                return true;
            }

            return s.Length <= max && s.Length >= min;
        }
        
        public static bool IsOneOrZero(int number)
        {
            return number is 0 or 1;
        }

        public static bool IsValidTime(string time)
        {
            return GetTimeRegex().IsMatch(time);
        }

    }
}