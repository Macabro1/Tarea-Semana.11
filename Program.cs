using System;
using System.Collections.Generic;

class Traductor
{
    static void Main(string[] args)
    {
        // Diccionario inicial inglés-español
        Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"time", "tiempo"},
            {"person", "persona"},
            {"year", "año"},
            {"way", "camino"},
            {"day", "día"},
            {"thing", "cosa"},
            {"man", "hombre"},
            {"world", "mundo"},
            {"life", "vida"},
            {"hand", "mano"},
            {"part", "parte"},
            {"child", "niño"},
            {"eye", "ojo"},
            {"woman", "mujer"},
            {"place", "lugar"},
            {"work", "trabajo"},
            {"week", "semana"},
            {"case", "caso"},
            {"point", "punto"},
            {"government", "gobierno"},
            {"company", "empresa"}
        };

        int opcion = -1;

        while (opcion != 0)
        {
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("⚠ Opción no válida. Intente de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    TraducirFrase(diccionario);
                    break;
                case 2:
                    AgregarPalabra(diccionario);
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa... 👋");
                    break;
                default:
                    Console.WriteLine("⚠ Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }

    static void TraducirFrase(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese la frase a traducir: ");
        string frase = Console.ReadLine();

        string[] palabras = frase.Split(' ', ',', '.', ';', ':', '!', '?');
        foreach (var palabra in palabras)
        {
            if (string.IsNullOrWhiteSpace(palabra)) continue;

            string palabraLimpia = palabra.ToLower();
            if (diccionario.ContainsKey(palabraLimpia))
            {
                Console.Write(diccionario[palabraLimpia] + " ");
            }
            else
            {
                Console.Write(palabra + " ");
            }
        }
        Console.WriteLine();
    }

    static void AgregarPalabra(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese la palabra en inglés: ");
        string ingles = Console.ReadLine().Trim().ToLower();

        Console.Write("Ingrese la traducción en español: ");
        string espanol = Console.ReadLine().Trim().ToLower();

        if (!diccionario.ContainsKey(ingles))
        {
            diccionario.Add(ingles, espanol);
            Console.WriteLine($"✅ Se agregó '{ingles}' -> '{espanol}' al diccionario.");
        }
        else
        {
            Console.WriteLine($"⚠ La palabra '{ingles}' ya existe en el diccionario.");
        }
    }
}