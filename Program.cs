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
    }
}