namespace PalindromeChecker.Core;

public class PalindromeService : IPalindromeService
{
    public bool IsPalindrome(string phrase)
    {
        ArgumentNullException.ThrowIfNull(phrase);
        var chars = new string(phrase.ToLowerInvariant()
            //.Normalize(NormalizationForm.FormD)
            .Where(char.IsLetterOrDigit)
            .ToArray());
        if (chars.Length == 0)
            return false;
        var cpt = chars.Length - 1;
        for (int i = 0; i < chars.Length / 2; i++)
        {
            if (chars[i] != chars[cpt - i])
                return false;
        }
        return true;
    }
}
