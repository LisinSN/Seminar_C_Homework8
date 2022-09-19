// Урок 8. Двумерные массивы. Домашняя работа. 

Console.WriteLine();
Console.WriteLine("*** Дан двумерный массив случайных чисел ***");

// Метод содания двумерного массива
int[,] CreateRandom2dArray(int rows, int cols, int min, int max)
{
    int[,] array = new int[rows, cols];
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
            array[i, j] = new Random().Next(min, max + 1);
    return (array);
}

// Метод показа двумерного массива
void Show2dArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++) //array.GetLength(0) - значит берем длинну по строкам
    {
        Console.WriteLine();
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " | ");
        }
    }
}

// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит 
// по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

// Метод упорядочивания строк двумерного массива
int[,] OrderingCols(int[,] array, int rows, int cols)
{
    Console.WriteLine();
    Console.WriteLine("*** Давайте расставим по убываию элементы каждой строки массива ***");

    for (int i = 0; i < rows; i++) // цикл проверки по строкам
    {
        bool chekСhanges = true; //переменная проверки изменеий в строке
        int temp = 0;
        while (chekСhanges != false) // проверяет были ли изменения в строке.
        {
            chekСhanges = false;
            for (int j = 0; j < cols - 1; j++) // цикл проверки по стобцам
            {
                if (array[i, j] > array[i, j + 1]) // сравнение
                {
                    temp = array[i, j + 1];
                    array[i, j + 1] = array[i, j];
                    array[i, j] = temp;
                    chekСhanges = true; // индикатор изменений
                }
            }
        }
    }
    return array;
}

// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку 
//с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

// Метод подсчета суммы элементов строки

void SumRows(int[,] array, int cols, int max)
{
    Console.WriteLine();
    Console.WriteLine("*** Давайте определим строку с наименьшей суммой элементов ***");
    Console.WriteLine("* Суммы элементов массива построчно: ");
    int tempSumRow = 0;
    int tepmSumMin = max * cols;
    int tempRow = 0;
    for (int i = 0; i < array.GetLength(0); i++) //array.GetLength(0) - значит берем длинну по строкам
    {
        tempSumRow = 0; // переменная подсчета
        for (int j = 0; j < array.GetLength(1); j++) tempSumRow = tempSumRow + array[i, j];
        if (tempSumRow < tepmSumMin)
        {
            tepmSumMin = tempSumRow;
            tempRow = i + 1; // Обозначает № строки визуального ряда
        }
        Console.WriteLine(tempSumRow);
    }
    Console.WriteLine();
    Console.WriteLine("* Cтрока с наименьшей суммой элементов: " + tempRow);
}

// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

// Метод построения спирального массива
int[,] Create2dSpiralArray(int rows, int cols, int min, int max)
{
    Console.WriteLine();
    Console.WriteLine("*** Давайте построим спиральный массив ***");
    int[,] array2 = new int[rows, cols];
    int s = 1; // переменная количества шагов
    int col = 0;
    int row = 0;
    // Переменные бега и остановки
    int colRun = 0; 
    int colStop = 0;
    int rowRun = 0;
    int rowStop = 0;
    while (s <= rows * cols) // условия бега по периметру
    {
        array2[row, col] = s;
        if (row == rowRun && col < cols - colStop - 1)
            col++;
        else if (col == cols - colStop - 1 && row < rows - rowStop - 1)
            row++;
        else if (row == rows - rowStop - 1 && col > colRun)
            col--;
        else
            row--;
        if ((row == rowRun + 1) && (col == colRun) && (colRun != cols - colStop - 1)) //Условие и проверка разворота
        {
            rowRun++;
            rowStop++;
            colRun++;
            colStop++;
        }
        s++;
    }
    return (array2);
}

// Метод показа двумерного массива
void Show2dSpiralArray(int[,] array2)
{
    for (int i = 0; i < array2.GetLength(0); i++) //array.GetLength(0) - значит берем длинну по строкам
    {
        Console.WriteLine();
        for (int j = 0; j < array2.GetLength(1); j++)
        {
            Console.Write(array2[i, j] + " | ");
        }
    }
}
// Ввод данных для всех задач
int rows = 4, cols = 4;
int min = 10, max = 99;
// Console.Write("* Введите количество строк массива: ");
// int rows = Convert.ToInt32(Console.ReadLine());
// Console.Write("* Введите количество столбцов массива: ");
// int cols = Convert.ToInt32(Console.ReadLine());
// Console.Write("* Введите минимальное значение массива: ");
// int min = Convert.ToInt32(Console.ReadLine());
// Console.Write("* Введите максимальное значение массива: ");
// int max = Convert.ToInt32(Console.ReadLine());


int[,] array = CreateRandom2dArray(rows, cols, min, max);
Show2dArray(array);

Console.WriteLine();
OrderingCols(array, rows, cols);

Show2dArray(array);
Console.WriteLine();

SumRows(array, cols, max);

int[,] array2 = Create2dSpiralArray(rows, cols, min, max);
Show2dSpiralArray(array2);

