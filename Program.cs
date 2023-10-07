using System;
using System.IO;

namespace TextEditor
{
  class Program
  {
    static void Main()
    {
      Menu();
    }

    static void Menu()
    {
      Console.Clear();
      Console.WriteLine("O que você deseja fazer? \n 1 - Abrir arquivo \n 2 - Criar novo arquivo \n 0 - Sair");
      short option = short.Parse(Console.ReadLine());

      switch (option)
      {
        case 0: Environment.Exit(0); break;
        case 1: Abrir(); break;
        case 2: Editar(); break;
        default: Menu(); break;
      }
    }

    private static void Abrir()
    {
      Console.Clear();
      Console.WriteLine("Qual caminho do arquivo?");
      string? path = Console.ReadLine();

      using (var file = new StreamReader(path))
      {
        string text = file.ReadToEnd();
        Console.WriteLine(text);
      };
      Console.WriteLine("");
      Console.Clear();
      Menu();
    }

    static void Editar()
    {
      Console.Clear();
      Console.WriteLine("Digite seu texto (ESC para sair) \n -------------------");
      string text = "";
      do
      {
        text += Console.ReadLine();
        text += Environment.NewLine;
      }
      while (Console.ReadKey().Key != ConsoleKey.Escape);

      Console.Clear();
      Console.WriteLine(text);
      Salvar(text);
    }

    static void Salvar(string text)
    {
      Console.Clear();
      Console.WriteLine("Qual caminho para salvar o arquivo?");
      var path = Console.ReadLine();

      using (var file = new StreamWriter(path))
      {
        file.Write(text);
      };
      Console.WriteLine($"Arquivo salvo com sucesso em {path}");
      Menu();
    }
  }
}
