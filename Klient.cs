using System.Text;

public class Klient : IKoszyk
{
    public Manga[] Koszyk;
    public int LiczbaMangWKoszyku;
    public static int MaksymalnyStanKoszyka = 3;
    private Sklep sklep;

    public Klient(Sklep sklep)
    {
        this.sklep = sklep;
        Koszyk = new Manga[MaksymalnyStanKoszyka];
        LiczbaMangWKoszyku = 0;
    }

    public void DodajDoKoszyka(Manga manga)
    {
        for (int i = 0; i < MaksymalnyStanKoszyka; i++)
        {
            if (Koszyk[i] == null)
            {
                Koszyk[i] = new Manga(manga);
                LiczbaMangWKoszyku++;
                return;
            }
        }

        throw new Manga.MangaException("Koszyk jest już pełny.");
    }

    public void UsunZKoszyka(Manga manga)
    {
        for (int i = 0; i < MaksymalnyStanKoszyka; i++)
        {
            if (Koszyk[i] != null && Koszyk[i].Equals(manga))
            {
                Koszyk[i] = null;
                LiczbaMangWKoszyku--; 
                return;
            }
        }

        throw new Manga.MangaException("Manga nie znajduje się w koszyku klienta.");
    }


    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine("Mangi w koszyku klienta:");
        if (LiczbaMangWKoszyku == 0)
        {
            builder.AppendLine(" - ");
        }
        else
        {
            foreach (var manga in Koszyk)
            {
                if (manga != null)
                {
                    builder.AppendLine(manga.ToString());
                }
            }
        }
        return builder.ToString();
    }
}