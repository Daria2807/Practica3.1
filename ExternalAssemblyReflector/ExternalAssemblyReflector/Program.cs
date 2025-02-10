using System;
using System.Reflection;
using System.IO; // для использования FileNotFoundException.

namespace ExternalAssemblyReflector
{
    class Program
    {
        static void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("\n***** Типы в сборке *****");
            Console.WriteLine("->{0}", asm.FullName);
            Type[] types = asm.GetTypes();
            foreach (Type t in types)
                Console.WriteLine("Type: {0}", t);
            Console.WriteLine("");
        }

        static void Main() // Удалили параметр args
        {
            Console.WriteLine("***** Просмотр внешней сборки *****");
            string asmName; // Нет присваивания
            Assembly asm; // Нет присваивания

            do
            {
                Console.WriteLine("\nВведите сборку для оценки");
                Console.Write("или Q для выхода: ");

                // Получение имени сборки.
                asmName = Console.ReadLine();

                // Пользователь хочет выйти?
                if (asmName.ToUpper() == "Q")
                {
                    break;
                }

                // Проверка загрузки сборки.
                try
                {
                    asm = Assembly.Load(asmName);
                    DisplayTypesInAsm(asm);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Sorry, can’t find assembly (FileNotFoundException).");
                }
                catch (FileLoadException)
                {
                    Console.WriteLine("Sorry, can’t load assembly (FileLoadException).");
                }
                catch (BadImageFormatException)
                {
                    Console.WriteLine("Sorry, can’t load assembly (BadImageFormatException).");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Sorry, can't load assembly (General Exception): {ex.Message}");
                }

            } while (true);
        }
    }
}