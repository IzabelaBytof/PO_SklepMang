using System.Text;
using static Manga;

public class Klient : IKoszyk
{
    private Manga[] koszyk;
    public Manga[] Koszyk
    {
        get { return koszyk; }
    }
    private int liczbaMangWKoszyku;
    public int LiczbaMangWKoszyku
    {
        get { return liczbaMangWKoszyku; }
    }
    public static int maksymalnyStanKoszyka = 3;
    private Sklep sklep;
    public Klient(Sklep sklep)
    {
        this.sklep = sklep;
        koszyk = new Manga[maksymalnyStanKoszyka];
        liczbaMangWKoszyku = 0;
    }
    public void DodajDoKoszyka(Manga manga)
    {
        if (liczbaMangWKoszyku < maksymalnyStanKoszyka)
        {
            for (int i = 0; i < koszyk.Length; i++){
                if (koszyk[i] == null)
                {
                    koszyk[liczbaMangWKoszyku] = manga;
                    liczbaMangWKoszyku++;
                    break;
                }
            }
        }
        else
        {
            throw new MangaException("Koszyk jest pełny");
        }
    }
    public void UsunZKoszyka(Manga manga)
    {
        for(int i = 0; i < koszyk.Length; i++)
        {
            if (koszyk[i] == manga)
            {
                koszyk[i] = null;
                liczbaMangWKoszyku--;
                return;
            }
        }throw new MangaException("Nie znaleziono mangi w koszyku");
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Mangi w koszyku:");
        if(liczbaMangWKoszyku == 0)
        {
            sb.Append("-");
        }
        else
        {
            for (int i = 0; i < koszyk.Length; i++)
            {
                sb.AppendLine(koszyk[i].ToString());
            }
        }return sb.ToString();
    }
}