using System.Text.Json;

namespace Ksiazki
{
  public class Ksiazka
  {
    // Lista przechowująca obiekty typu Ksiazka, inicjowana na początku programu
    static List<Ksiazka>? ksiazki = new List<Ksiazka>();

    // Ścieżka do pliku JSON, gdzie są zapisane dane książek
    static string path = "Ksiazki.json";

    // Konstruktor statyczny, który wywołuje metodę RefreshData, aby zaktualizować listę książek z pliku
    static Ksiazka() => RefreshData();

    // Metoda odświeżająca dane książek z pliku JSON
    public static void RefreshData() =>
      ksiazki = JsonSerializer.Deserialize<List<Ksiazka>>(File.ReadAllText(path));

    // Metoda sprawdzająca, czy książka o danym id istnieje w liście
    public static bool Exists(int id) {
      return ksiazki.Any(k => k.Id == id);
    }

    // Metoda dodająca nową książkę do listy i zapisująca zaktualizowaną listę do pliku JSON
    public static void Add(string tytul, string autor, int rokWydania, string gatunek)
    {
      ksiazki.Add(
        new Ksiazka {
            Id = ksiazki.Count + 1, // Przypisanie id jako liczby książek + 1
            Tytul = tytul,
            Autor = autor,
            RokWydania = rokWydania,
            Gatunek = gatunek,
          });

      // Zapisanie zaktualizowanej listy książek do pliku JSON
      File.WriteAllText(path, JsonSerializer.Serialize(ksiazki));
    }

    // Metoda usuwająca książkę o danym id z listy i zapisująca zmiany do pliku JSON
    public static void Remove(int id)
    {
      if (!Exists(id)) {
        Console.WriteLine("Ksiazka nie istnieje.");
        return;
      }

      // Usunięcie książki z listy
      ksiazki.RemoveAll((k) => k.Id == id);
      
      // Normalizacja id po usunięciu książki
      NormalizeIds();

      // Zapisanie zaktualizowanej listy książek do pliku JSON
      File.WriteAllText(path, JsonSerializer.Serialize(ksiazki));
    }

    // Metoda normalizująca id książek, aby nie było luk w numeracji po usunięciu książki
    public static void NormalizeIds() =>
      ksiazki.ForEach(k => k.Id = ksiazki.IndexOf(k) + 1);

    // Metoda wyświetlająca informacje o książce o danym id
    public static void Show(int id)
    {
      if (!Exists(id))
      {
        Console.WriteLine("Ksiazka nie istnieje.");
        return;
      }
      Ksiazka k = ksiazki.Find(k => k.Id == id);

      Info(k);
    }

    // Metoda wyświetlająca informacje o wszystkich książkach
    public static void ShowAll()
    {
      ksiazki.ForEach(k =>
      {
        Info(k);
        Console.WriteLine("---------------------");
      });
    }

    // Metoda wyświetlająca szczegółowe informacje o podanej książce
    public static void Info(Ksiazka k) {
      Console.WriteLine($"{k.Id} | {k.Tytul}");
      Console.WriteLine(k.Gatunek);
      Console.WriteLine(k.Autor);
      Console.WriteLine(k.RokWydania);
    }

    // Właściwości klasy Ksiazka
    public int Id { get; set; }
    public string? Tytul { get; set; }
    public string? Autor { get; set; }
    public int RokWydania { get; set; }
    public string? Gatunek { get; set; }
  }
}