using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Sklep sklep = new Sklep();
        Klient klient = new Klient(sklep);
        System.Console.WriteLine("PIERWSZE SPRAWDZENIE");
        System.Console.WriteLine(klient.ToString());
        System.Console.WriteLine(sklep.ToString());
        try
        {
            sklep.DodajDoKoszyka(new Manga("Dragon Ball", "Akira Toriyama", 39.99m));
            sklep.DodajDoKoszyka(new Manga("JoJo's Bizarre Adventure", "Hirohiko Araki", 49.99m));
            sklep.DodajDoKoszyka(new Manga("Higurashi No Naku Koro Ni Sotsu", "Ryukishi07", -49.99m));
            sklep.UsunZKoszyka(new Manga("Demon Slayer", "Koyoharu Gotouge", 29.99m));
            sklep.UsunZKoszyka(new Manga("Demon Slayer", "Koyoharu Gotouge", 29.99m));
        }
        catch (Manga.MangaException e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
        }


        System.Console.WriteLine("DRUGIE SPRAWDZENIE");
        System.Console.WriteLine(klient.ToString());
        System.Console.WriteLine(sklep.ToString());

        try
        {
            klient.DodajDoKoszyka(sklep.Mangi[0]);
            klient.DodajDoKoszyka(sklep.Mangi[1]);
            klient.DodajDoKoszyka(sklep.Mangi[2]);
        }
        catch (Manga.MangaException e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
        }

        System.Console.WriteLine("TRZECIE SPRAWDZENIE");
        System.Console.WriteLine(klient.ToString());
        System.Console.WriteLine(sklep.ToString());

        System.Console.WriteLine("ZAKUP MANG");
        try
        {
            sklep.KupMangi(klient);
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
        }

        Console.WriteLine("Po zakupie:");
        Console.WriteLine(klient);
        Console.WriteLine(sklep);

        System.Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n-------------------------------");


        Manga[] magazyn = {
        new Manga("Pokemon Adventures", "Hidenori Kusaka", 39.99m),

        new Manga("Czarodziejki z Księżyca", "Naoko Takeuchi", 49.99m),

        new Manga("Muminki", "Tove Marika Jansson", 29.99m),

        new Manga("Jak zaliczyć Programowanie Obiektowe", "Ada Lovelace", 999.99m),

        new Manga("Toradora", "Yuyuko Takemiya", 44.99m),

        new Manga("Death Note", "Tsugumi Ohba", 24.99m)};

        Klient klient1 = new Klient(new Sklep());
        klient1.DodajDoKoszyka(magazyn[0]);
        klient1.DodajDoKoszyka(magazyn[1]);
        System.Console.WriteLine($"\nPO DODANIU MANG DO KOSZYKA: \n");
        System.Console.WriteLine(MangiToString(magazyn));
        System.Console.WriteLine(klient1.ToString());
        ZmienCeneWszystkichMang(magazyn, -2.99m);
        System.Console.WriteLine($"\nPO ZMIANIE CENY WSZYSTKICH MANG: \n");
        System.Console.WriteLine(MangiToString(magazyn));
        System.Console.WriteLine(klient1.ToString());
        klient1.UsunZKoszyka(magazyn[0]);
        System.Console.WriteLine(klient1.ToString());

        ModyfikujMangi(magazyn, PiatkowaPromocjaPoczatek);
        System.Console.WriteLine($"\nPO POCZATKU PIATKOWEJ PROMOCJI: \n");
        System.Console.WriteLine(MangiToString(magazyn));
        System.Console.WriteLine(klient1.ToString());
        ModyfikujMangi(magazyn, PiatkowaPromocjaKoniec);
        System.Console.WriteLine($"\nPO ZAKONCZENIU PIATKOWEJ PROMOCJI: \n");
        System.Console.WriteLine(MangiToString(magazyn));
        System.Console.WriteLine(klient1.ToString());
    }
    public static void ZmienCeneWszystkichMang(Manga[] mangi, decimal kwota)
    {
        foreach (var manga in mangi)
        {
            if (manga != null)
            {
                manga.Cena += kwota;
            }
        }
    }
    public static string MangiToString(Manga[] mangi){
        StringBuilder sb = new StringBuilder();
        foreach(var manga in mangi){
            sb.Append(manga.ToString()+"\n");
        }return sb.ToString();
    }
    public static void ModyfikujMangi(Manga[] mangi, Akcja akcja){
        foreach (var manga in mangi)
        {
            if (manga != null)
            {
                akcja(manga);
            }
        }
    }
    public static void PiatkowaPromocjaPoczatek(Manga manga){
        if (manga.Cena > 0)
        {
            manga.Cena -= 2;
        }
    }
    public static void PiatkowaPromocjaKoniec(Manga manga){
        if (manga.Cena > 0)
        {
            manga.Cena += 2;
        }
    }
}