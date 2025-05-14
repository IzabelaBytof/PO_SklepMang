public class Manga
{
    public string Tytul { get; }
    public string Autor { get; }
    public decimal Cena { get; set; }

    public Manga(Manga manga) : this(manga.Tytul, manga.Autor, manga.Cena)
    {
    }

    public Manga(string tytul, string autor, decimal cena)
    {
        if (cena < 0)
        {
            throw new ArgumentException("Cena nie może być niższa niż 0 zł");
        }

        Tytul = tytul;
        Autor = autor;
        Cena = cena;
    }

    public override string ToString()
    {
        return $"{Tytul} {Autor} {Cena:C}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Manga other)
        {
            return Tytul == other.Tytul && Autor == other.Autor;
        }
        return false;
    }

    public override int GetHashCode()
    {   
        return HashCode.Combine(Tytul, Autor);
    }

    public class MangaException : Exception
    {
        public MangaException(string message) : base("\t" + message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}