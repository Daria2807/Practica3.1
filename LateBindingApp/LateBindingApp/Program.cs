using System;
using System.Reflection;
using System.IO;  // Для использования FileNotFoundException

namespace LateBindingApp
{
    // Эта программа загрузит внешнюю библиотеку,
    // и создаст объект с помощью поздней привязки.
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Функция с поздним связыванием *****");

            // Попытка загрузить локальную копию CarLibrary.
            Assembly a;

            try
            {
                a = Assembly.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            if (a != null)
            {
                CreateUsingLateBinding(a);
            }

            Console.ReadLine();
        }

        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                // Получить метаданные для типа Minivan.
                Type miniVan = asm.GetType("CarLibrary.MiniVan");

                // Создание экземпляра типа Minivan динамически.
                object obj = Activator.CreateInstance(miniVan);
                Console.WriteLine("Created a {0} using late binding!", obj);

                // Получение информации о TurboBoost.
                MethodInfo mi = miniVan.GetMethod("TurboBoost");

                // Вызвать метод ('null' означает, что параметров нет).
                mi.Invoke(obj, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}