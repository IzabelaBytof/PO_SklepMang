using System.Text;

public class Sklep : IKoszyk
{
    public List<Manga> Mangi { get; set; } = new List<Manga>();
    private Manga[] mangi;
    public static int MaksymalnyStanMagazynowy { get; } = 10;

    public Sklep()
    {
        mangi = new Manga[MaksymalnyStanMagazynowy];
    }

    public void DodajDoKoszyka(Manga manga)
    {
        for (int i = 0; i < MaksymalnyStanMagazynowy; i++)
        {
            if (mangi[i] == null)
            {
                mangi[i] = manga;
                return;
            }
        }

        throw new Manga.MangaException("Przekroczono wielkość magazynu sklepu!");
    }

    public void UsunZKoszyka(Manga manga)
    {
        for (int i = 0; i < MaksymalnyStanMagazynowy; i++)
        {
            if (mangi[i] != null && mangi[i].Equals(manga))
            {
                mangi[i] = null;
                return;
            }
        }

        throw new Manga.MangaException("Nie znaleziono takiej mangi w sklepie!");
    }

    public void KupMangi(Klient klient)
    {
        if (klient.LiczbaMangWKoszyku == 0)
        {
            throw new Manga.MangaException("Koszyk klienta jest pusty!");
        }

        Console.WriteLine("Zakup mang:");
        decimal suma = 0;

        for (int i = 0; i < klient.Koszyk.Length; i++)
        {
            if (klient.Koszyk[i] != null)
            {
                Console.WriteLine(klient.Koszyk[i]);
                suma += klient.Koszyk[i].Cena;
                klient.UsunZKoszyka(klient.Koszyk[i]);
            }
        }

        Console.WriteLine($"Suma do zapłaty: {suma:C}");
    }


    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine("Dostępne Mangi w sklepie:");
        foreach (var manga in mangi)
        {
            if (manga != null)
            {
                builder.AppendLine(manga.ToString());
            }
        }
        return builder.ToString();
    }
}