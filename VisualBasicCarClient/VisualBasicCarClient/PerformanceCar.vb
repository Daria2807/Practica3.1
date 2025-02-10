Imports CarLibrary

' Этот класс VB является производным от класса C# SportsCar.
Public Class PerformanceCar
    Inherits SportsCar

    Public Overrides Sub TurboBoost()
        Console.WriteLine("От нуля до 60 за 4,8 секунды!")
    End Sub

End Class