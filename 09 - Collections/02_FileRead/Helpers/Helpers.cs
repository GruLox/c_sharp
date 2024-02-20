public static class Helpers
{
    public static string ToEnglishAlphabetCharacters(this string text)
    {
        return text
            .Replace("á", "a")
            .Replace("é", "e")
            .Replace("í", "i")
            .Replace("ó", "o")
            .Replace("ö", "o")
            .Replace("ő", "o")
            .Replace("ú", "u")
            .Replace("ü", "u")
            .Replace("ű", "u")
            .Replace("Á", "A")
            .Replace("É", "E")
            .Replace("Í", "I")
            .Replace("Ó", "O")
            .Replace("Ö", "O")
            .Replace("Ő", "O")
            .Replace("Ú", "U")
            .Replace("Ü", "U")
            .Replace("Ű", "U");
    }
}
