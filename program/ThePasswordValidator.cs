internal class ThePasswordValidator
{
    public ThePasswordValidator() 
    {
        string password = "";
        bool isValid = false;

        do
        {
            Console.Write("Enter your password: ");
            password = Console.ReadLine();

            isValid = PasswordValidator.Validate(password);

            if (!isValid)
            {
                Console.WriteLine("That password is not valid");
            }
        } while (!isValid);
    }
}

class PasswordValidator
{
    public static bool Validate(string password)
    {
        if (password.Length < 6 || password.Length > 13) return false;

        (bool hasUpper, bool hasLower, bool hasDigit) checks = (false, false, false);

        foreach (char c in password) 
        {
            if (c == 'T' || c == '&') return false;

            if (char.IsUpper(c)) checks.hasUpper = true;

            if (char.IsLower(c)) checks.hasLower = true;

            if (char.IsDigit(c)) checks.hasDigit = true;
        }

        return checks.hasUpper && checks.hasLower && checks.hasDigit;
    }
}