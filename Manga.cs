public class Manga
{
    private string autor;
    private decimal cena;
    public decimal Cena{
        get { return cena; }
    }
    private string tytul;
    public Manga(string tytul, string autor, decimal cena)
    {
        this.tytul = tytul;
        this.autor = autor;
        if (cena < 0)
        {
            throw new ArgumentOutOfRangeException("Cena nie może być ujemna");
        }
        this.cena = cena;
    }
    public override string ToString()
    {
        return $"Tytuł: {tytul}, Autor: {autor}, Cena: {cena}";
    }
    public class MangaException:Exception{
        public MangaException(string message) : base("\t" + message){

        }
    }
}