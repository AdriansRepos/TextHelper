namespace TextHelper
{
    public static class UpravaVstupu
    {
        public static T ZeptejSeAUprav<T>(
            T aktualni,
            string popis,
            Func<T, string> formatter,   // jak zobrazit hodnotu
            Func<string, T> parser,      // jak zpracovat vstup
            bool jeNove = false)
        {
            try
            {
                if (!jeNove)
                {
                    Console.WriteLine($"Aktuální {popis}: {formatter(aktualni)}\nChcete upravit tuto položku? A/N");
                    if (!Console.ReadLine()!.Equals("A", StringComparison.CurrentCultureIgnoreCase))
                        return aktualni;
                }

                while (true)
                {
                    Console.Write($"Nový/á {popis}: ");
                    try
                    {
                        string vstup = Console.ReadLine()!.Trim();
                        T novaHodnota = parser(vstup);
                        return novaHodnota;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Neplatné zadání ({ex.Message}), zkuste znovu:");
                        Console.ResetColor();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba při úpravě {popis}: {ex.Message}");
                return aktualni;
            }
        }
    }
}