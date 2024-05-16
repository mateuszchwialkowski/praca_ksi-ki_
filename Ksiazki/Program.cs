using Ksiazki;

// Funkcja wyświetlająca menu i obsługująca interakcję użytkownika
void menu(string? message = "") {
  Console.Clear(); // Czyści ekran konsoli

  // Jeśli jest przekazana wiadomość, wyświetla ją
  if(!string.IsNullOrEmpty(message)) Console.WriteLine(message);

  // Wyświetla opcje menu
  Console.WriteLine("1. Wyswietl wszystkie ksiazki");
  Console.WriteLine("2. Wyswietl szczegolna ksiazke");
  Console.WriteLine("3. Dodaj ksiazke");
  Console.WriteLine("4. Usun ksiazke");

  // Pobiera wybór użytkownika i konwertuje go na liczbę całkowitą
  int i = Convert.ToInt16(Console.ReadLine());
  
  // Obsługa wyboru użytkownika za pomocą instrukcji switch
  switch (i)
  {
    default: 
      // Jeśli wybór nie pasuje do żadnej z opcji, ponownie wywołuje menu
      menu();
      break;

    case 1: 
      // Wyświetla wszystkie książki
      Ksiazka.ShowAll();
      Console.ReadKey(); // Czeka na naciśnięcie klawisza

      menu(); // Ponownie wywołuje menu
      break;

    case 2:
      // Wyświetla szczegóły wybranej książki
      Console.WriteLine("Podaj id ksiazki, ktora chcesz wyswietlic");
      Ksiazka.Show(Convert.ToInt16(Console.ReadLine()));
      Console.ReadKey(); // Czeka na naciśnięcie klawisza

      menu(); // Ponownie wywołuje menu
      break;

    case 3:
      // Dodaje nową książkę
      Console.WriteLine("Podaj tytul");
      string title = Console.ReadLine(); // Pobiera tytuł od użytkownika

      Console.WriteLine("Podaj autora");
      string author = Console.ReadLine(); // Pobiera autora od użytkownika

      Console.WriteLine("Podaj rok wydania");
      int releaseDate = Convert.ToInt16(Console.ReadLine()); // Pobiera rok wydania od użytkownika

      Console.WriteLine("Podaj gatunek");
      string genre = Console.ReadLine(); // Pobiera gatunek od użytkownika

      // Dodaje książkę do listy
      Ksiazka.Add(title, author, releaseDate, genre);

      // Wywołuje menu z komunikatem o dodaniu książki
      menu("Ksiazka dodana!");
      break;

    case 4:
      // Usuwa książkę
      Console.WriteLine("Podaj id ksiazki, ktora chcesz usunac");
      Ksiazka.Remove(Convert.ToInt16(Console.ReadLine())); // Pobiera id książki do usunięcia

      // Wywołuje menu z komunikatem o usunięciu książki
      menu("Ksiazka usunieta!");
      break;
  }
}
menu(); 
// Wywołuje funkcję menu przy starcie programu