using System.Security.Cryptography;
using System.Text;

public class Sklep : IKoszyk
{
    private Manga[] mangi;
    public Manga[] Mangi
    {
        get { return mangi; }
    }
    public static int maksymalnyStanMagazynowy = 100;
    public Sklep()
    {
        mangi = new Manga[maksymalnyStanMagazynowy];
        mangi[0] = new Manga("Pokemon Adventures", "Hidenori Kusaka", 39.99m);
        mangi[1] = new Manga("Czarodziejki z Księżyca", "Naoko Takeuchi", 49.99m);
        mangi[2] = new Manga("Muminki", "Tove Marika Jansson", 29.99m);
        mangi[3] = new Manga("Jak zaliczyć Programowanie Obiektowe", "Ada Lovelace", 999.99m);
        mangi[4] = new Manga("Toradora", "Yuyuko Takemiya", 44.99m);
        mangi[5] = new Manga("Death Note", "Tsugumi Ohba", 24.99m);
    }
    public void KupMangi(Klient klient)
    {
        System.Console.WriteLine("Zakupione mangi:");
        if (klient.LiczbaMangWKoszyku == 0)
        {
            System.Console.Write("-");
            throw new Manga.MangaException("Nie można kupić pustego koszyka");
        }
        else
        {


            decimal cena = 0;
            for (int i = 0; i < klient.Koszyk.Length; i++)
            {
                if (klient.Koszyk[i] != null)
                {
                    System.Console.WriteLine(klient.Koszyk[i].ToString());
                    for (int j = 0; j < mangi.Length; j++)
                    {
                        if (mangi[j] == klient.Koszyk[i])
                        {
                            UsunZKoszyka(mangi[j]);
                            break;
                        }
                    }
                    cena += klient.Koszyk[i].Cena;
                    klient.UsunZKoszyka(klient.Koszyk[i]);
                }
            }
            System.Console.WriteLine($"Łączna cena: {cena}");
        }
    }
    public void DodajDoKoszyka(Manga manga)
    {
        for (int i = 0; i < mangi.Length; i++)
        {
            if (mangi[i] == null)
            {
                mangi[i] = manga;
                return;
            }
        }
        throw new Manga.MangaException("Magazyn pełny, nie można dodać więcej mang!");
    }
    public void UsunZKoszyka(Manga manga)
    {
        for (int i = 0; i < mangi.Length; i++)
        {
            if (mangi[i] == manga)
            {
                mangi[i] = null;
                return;
            }
        }
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Mangi w sklepie:");
        for (int i = 0; i < mangi.Length; i++)
        {
            if (mangi[i] != null)
            {
                sb.AppendLine(mangi[i].ToString());
            }
        }
        return sb.ToString();
    }
}