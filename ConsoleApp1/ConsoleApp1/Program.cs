using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

        dictionary.Add("apple", new List<string>() { "pomme" });
        dictionary.Add("book", new List<string>() { "livre" });
        dictionary.Add("computer", new List<string>() { "ordinateur" });

        while (true)
        {
            Console.WriteLine("\nEnglish-French Dictionary");
            Console.WriteLine("1. Add a word");
            Console.WriteLine("2. Delete a word");
            Console.WriteLine("3. Delete a translation");
            Console.WriteLine("4. Modify a word");
            Console.WriteLine("5. Modify a translation");
            Console.WriteLine("6. Search for a translation");
            Console.WriteLine("7. Exit");

            Console.Write("Enter the action number: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddWord(dictionary);
                    break;
                case 2:
                    DeleteWord(dictionary);
                    break;
                case 3:
                    DeleteTranslation(dictionary);
                    break;
                case 4:
                    ModifyWord(dictionary);
                    break;
                case 5:
                    ModifyTranslation(dictionary);
                    break;
                case 6:
                    SearchTranslation(dictionary);
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Unknown action number.");
                    break;
            }
        }
    }

    static void AddWord(Dictionary<string, List<string>> dictionary)
    {
        Console.Write("Enter the word in English: ");
        string englishWord = Console.ReadLine();

        Console.Write("Enter the translations in French (separated by comma): ");
        string[] translations = Console.ReadLine().Split(',');

        List<string> translationList = new List<string>();
        translationList.AddRange(translations);

        dictionary.Add(englishWord, translationList);

        Console.WriteLine("The word has been added to the dictionary.");
    }

    static void DeleteWord(Dictionary<string, List<string>> dictionary)
    {
        Console.Write("Enter the word in English to delete: ");
        string englishWord = Console.ReadLine();

        if (dictionary.ContainsKey(englishWord))
        {
            dictionary.Remove(englishWord);
            Console.WriteLine("The word has been removed from the dictionary.");
        }
        else
        {
            Console.WriteLine("Word not found.");
        }
    }

    static void DeleteTranslation(Dictionary<string, List<string>> dictionary)
    {
        Console.Write("Enter the word in English: ");
        string englishWord = Console.ReadLine();

        if (dictionary.ContainsKey(englishWord))
        {
            Console.Write("Enter the French translation to delete: ");
            string frenchTranslation = Console.ReadLine();

            if (dictionary[englishWord].Contains(frenchTranslation))
            {
                dictionary[englishWord].Remove(frenchTranslation);
                Console.WriteLine("The translation has been removed.");
            }
            else
            {
                Console.WriteLine("Translation not found.");
            }
        }
        else
        {
            Console.WriteLine("Word not found.");
        }
    }

    static void ModifyWord(Dictionary<string, List<string>> dictionary)
    {
        Console.Write("Enter the word in English to modify: ");
        string oldEnglishWord = Console.ReadLine();

        if (dictionary.ContainsKey(oldEnglishWord))
        {
            Console.Write("Enter the new word in English: ");
            string newEnglishWord = Console.ReadLine();

            dictionary[newEnglishWord] = dictionary[oldEnglishWord];
            dictionary.Remove(oldEnglishWord);

            Console.WriteLine("The word has been modified.");
        }
        else
        {
            Console.WriteLine("Word not found.");
        }
    }

    static void ModifyTranslation(Dictionary<string, List<string>> dictionary)
    {
        Console.Write("Enter the word in English: ");
        string englishWord = Console.ReadLine();

        if (dictionary.ContainsKey(englishWord))
        {
            Console.Write("Enter the French translation to modify: ");
            string oldFrenchTranslation = Console.ReadLine();

            if (dictionary[englishWord].Contains(oldFrenchTranslation))
            {
                Console.Write("Enter the new French translation: ");
                string newFrenchTranslation = Console.ReadLine();

                int index = dictionary[englishWord].IndexOf(oldFrenchTranslation);
                dictionary[englishWord][index] = newFrenchTranslation;

                Console.WriteLine("The translation has been modified.");
            }
            else
            {
                Console.WriteLine("Translation not found.");
            }
        }
        else
        {
            Console.WriteLine("Word not found.");
        }
    }

    static void SearchTranslation(Dictionary<string, List<string>> dictionary)
    {
        Console.Write("Enter the word in English: ");
        string englishWord = Console.ReadLine();

        if (dictionary.ContainsKey(englishWord))
        {
            Console.WriteLine("French translations: " + string.Join(", ", dictionary[englishWord]));
        }
        else
        {
            Console.WriteLine("Word not found.");
        }
    }
}