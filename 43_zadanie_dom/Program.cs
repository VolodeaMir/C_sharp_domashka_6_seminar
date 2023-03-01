// Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, 
// заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; 
// значения b1, k1, b2 и k2 задаются пользователем.
// b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)
// Вводить надо в той же последовотельности как и высше 2, 5, 4, 9

const int COEFFICIENT = 0;
const int CONSTANT = 1;
const int X_COORD = 0;
const int Y_COORD = 1;
const int lINE1 = 1;
const int lINE2 = 2;

double[] lineData1 = InputLineData(lINE1);
double[] lineData2 = InputLineData(lINE2);

if (ValidateLines(lineData1, lineData2))
{
    double[] coord = FindCoords(lineData1, lineData2);
    Console.Write($"Точка пересечения уровний \ny = {lineData1[COEFFICIENT]} * x + {lineData1[CONSTANT]} и \ny = {lineData2[COEFFICIENT]} * x + {lineData2[CONSTANT]}");
    Console.WriteLine($" имеет координаты ({coord[X_COORD]}, {coord[Y_COORD]})");
}

// Ввод чисел
double Prompt(string message)
{
    System.Console.Write(message);
    string value = Console.ReadLine()!;
    double result = Convert.ToDouble(value);
    return result;
}

double[] InputLineData(int numberOfLine)
{
    double[] lineData = new double[2];
    lineData[CONSTANT] = Prompt($"Введите константу для {numberOfLine} прямой > ");
    lineData[COEFFICIENT] = Prompt($"Введите коэффециент для {numberOfLine} прямой > ");
    return lineData;
}

// Поиск координат
double[] FindCoords(double[] lineData1, double[] lineData2)
{
    double[] coord = new double[2];
    coord[X_COORD] = (lineData2[CONSTANT] - lineData1[CONSTANT]) / (lineData1[COEFFICIENT] - lineData2[COEFFICIENT]);
    coord[Y_COORD] = lineData1[COEFFICIENT] * coord[X_COORD] + lineData1[CONSTANT];
    return coord;
}

bool ValidateLines(double[] lineData1, double[] lineData2)
{
    if (lineData1[COEFFICIENT] == lineData2[COEFFICIENT])
    {
        if (lineData1[CONSTANT] == lineData2[CONSTANT])
        {
            Console.WriteLine("Прямые совпадают");
            return false;
        }
        else
        {
            Console.WriteLine("Прямые паралельны");
            return false;
        }
    }
    return true;
}