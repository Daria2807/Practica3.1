using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLibrary; // Не забудьте импортировать пространство имен CarLibrary!
using System.Reflection; // Добавь эту строку!

namespace CSharpCarClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** C# CarLibrary Client App *****");
            // Создание объекта спортивной машины.
            SportsCar viper = new SportsCar("Viper", 240, 40);
            viper.TurboBoost();
            // Создание объекта минивена.
            MiniVan mv = new MiniVan();
            mv.TurboBoost();

            // Вызов InvokeMethodWithArgsUsingLateBinding:  ДОБАВЬ ЭТО:
            Assembly asm = Assembly.Load("CarLibrary");
            InvokeMethodWithArgsUsingLateBinding(asm);

            Console.WriteLine("Done. Press any key to terminate");
            Console.ReadKey();
        }

        // Метод InvokeMethodWithArgsUsingLateBinding.  ДОБАВЬ ЭТОТ МЕТОД СЮДА:
        static void InvokeMethodWithArgsUsingLateBinding(Assembly asm)
        {
            try
            {
                // Сначала получим метаданные для типа SportsCar.
                Type sport = asm.GetType("CarLibrary.SportsCar");

                // Затем создадим экземпляр типа SportsCar динамически.
                object obj = Activator.CreateInstance(sport);

                // Вызов метода TurnOnRadio() с аргументами.
                MethodInfo mi = sport.GetMethod("TurnOnRadio");
                mi.Invoke(obj, new object[] { true, 2 });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}