namespace BookVerse.Application.Common;

public static class IsbnValidator
{
    public static bool IsValid(string? isbn)
    {
        if (string.IsNullOrWhiteSpace(isbn)) return false;

        var clean = new string(isbn.Where(c => !char.IsWhiteSpace(c) && c != '-').ToArray()).ToUpperInvariant();

        return clean.Length switch
        {
            10 => IsValidIsbn10(clean),
            13 => IsValidIsbn13(clean),
            _ => false
        };
    }

    private static bool IsValidIsbn10(string isbn)
    {
        for (int i = 0; i < 9; i++)
            if (!char.IsDigit(isbn[i])) return false;

        var last = isbn[9];
        if (last != 'X' && !char.IsDigit(last)) return false;

        int sum = 0;
        for (int i = 0; i < 9; i++)
            sum += (isbn[i] - '0') * (10 - i);
        sum += last == 'X' ? 10 : (last - '0');

        return sum % 11 == 0;
    }

    private static bool IsValidIsbn13(string isbn)
    {
        for (int i = 0; i < 13; i++)
            if (!char.IsDigit(isbn[i])) return false;

        int sum = 0;
        for (int i = 0; i < 13; i++)
        {
            int weight = i % 2 == 0 ? 1 : 3;
            sum += (isbn[i] - '0') * weight;
        }
        return sum % 10 == 0;
    }
}
