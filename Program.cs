while (true)
{
    Console.Clear();
    Console.WriteLine(new string('-', 30));
    Console.WriteLine("Введите номер задания:\n" +
    "1. Задание №1\n" +
    "2. Задание №2\n" +
    "3. Задание №3\n" +
    "4. Задание №4");
    Console.WriteLine(new string('-', 30));
    int numbeerTask = int.Parse(Console.ReadLine());
    switch (numbeerTask)
    {
        case 1: Task01(); break;
        case 2: Task02(); break;
        case 3: Task03(); break;
        case 4: Task04(); break;
        default: break;
    }
}
    

void Task01()
{
    Console.Clear();
    Console.WriteLine("Задание №1." +
    "\nВариант 8. Найти индекс первого максимального элемента.");

    Console.WriteLine("Введите размер массива:");
    int sizeArray = int.Parse(Console.ReadLine());

    Console.WriteLine("Введите минимальное число в массиве:");
    int minNumberArray = int.Parse(Console.ReadLine());

    Console.WriteLine("Введите максимальное число в массиве:");
    int maxNumberArray = int.Parse(Console.ReadLine());
    Console.WriteLine();

    int[] array = new int[sizeArray];
    Random rnd = new Random();
    int indexMax = -1;
    int tempMaxItem = -1;

    for (int i = 0; i < sizeArray; i++)
    {
        array[i] = rnd.Next(minNumberArray, maxNumberArray+1);
        Console.WriteLine($"{i}. {array[i]}");
        if (tempMaxItem < array[i])
        {
            tempMaxItem = array[i];
            indexMax = i;
        }
    }
    Console.WriteLine($"\nИндекс первого максимального элемента = {indexMax}");
    Console.ReadKey();
}

void Task02()
{
    Console.Clear();
    Console.WriteLine("Задание №2." +
    "\nВариант 8. Если количество строк в массиве четное, то поменять строки местами по правилу:\n" +
    "первую строку со второй, третью – с четвертой и т.д.Если количество строк в массиве\n" +
    "нечетное, то оставить массив без изменений.");

    Console.WriteLine("Введите размер массива:");
    int sizeArray = int.Parse(Console.ReadLine());

    Console.WriteLine("Введите минимальное число в массиве:");
    int minNumberArray = int.Parse(Console.ReadLine());

    Console.WriteLine("Введите максимальное число в массиве:");
    int maxNumberArray = int.Parse(Console.ReadLine());
    Console.WriteLine();

    int[,] array = new int[sizeArray,sizeArray];
    Random rnd = new Random();

    Console.WriteLine("Изначальный массив.");
    for (int i = 0; i < sizeArray; i++)
    {
        for (int j = 0; j < sizeArray; j++)
        {
            array[i,j] = rnd.Next(minNumberArray, maxNumberArray+1);
            Console.Write($"{array[i,j]}\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine("\n\nИзменненный массив.");
    ChangeArray(ref array);
    ShowArray(array);

    Console.ReadKey();
}
#region Методы для задачи №2 (Task02)
void ChangeArray<T>(ref T[,] Array)
{
    if (Array.GetLength(0) % 2 == 0) //Если четное количествово строк.
    {
        T temp;
        for (int i = 0; i < Array.GetLength(0); i += 2)
        {
            for (int j = 0; j < Array.GetLength(1); j++)
            {
                temp = Array[i, j];
                Array[i, j] = Array[i + 1, j];
                Array[i + 1, j] = temp;
            }
        }
    }
}
void ShowArray<T>(T[,] Array)
{
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            Console.Write(Array[i, j] + "\t");
        }
        Console.WriteLine();
    }
}
#endregion

void Task03()
{
    Console.Clear();
    Console.WriteLine("Задание №3." +
    "\nВариант 8. Для каждой строки подсчитать количество элементов, больших заданного числа, и\n"+
    "записать данные в новый массив.\n");

    Console.WriteLine("Введите размер массива:");
    int sizeArray = int.Parse(Console.ReadLine());

    Console.WriteLine("Введите минимальное число в массиве:");
    int minNumberArray = int.Parse(Console.ReadLine());

    Console.WriteLine("Введите максимальное число в массиве:");
    int maxNumberArray = int.Parse(Console.ReadLine());
    Console.WriteLine();

    int[][] array = new int[sizeArray][];
    Random rnd = new Random();
    List<List<int>> bigList = new List<List<int>>();
    
    //Инициализиуем и заполняем массив случайными числами.
    for (int i = 0; i < array.GetLength(0); i++)
    {
        array[i] = new int[rnd.Next(1, sizeArray+1)];
        for (int j = 0; j < array[i].Length; j++)
        {
            array[i][j] = rnd.Next(minNumberArray, maxNumberArray + 1);
            Console.Write($"{array[i][j]}\t");
        }
        Console.WriteLine();
    }

    Console.WriteLine($"\nВведите любое число.");
    int selectNumber = int.Parse(Console.ReadLine());

    //Находим числа больше заданного и записываем их в коллекции
    for (int i = 0; i < array.GetLength(0); i++)
    {
        List<int> smallList = new List<int>();
        int tempCount = 0;
        for (int j = 0; j < array[i].Length; j++)
        {
            if(array[i][j] > selectNumber)
            {
                tempCount++;
                smallList.Add(array[i][j]);
            }
        }
        if(smallList.Count != 0)
            bigList.Add(smallList);
    }

    //Переносим списки коллекций в массив.
    int[][] newArray = new int[bigList.Count][];
    for (int i = 0; i < bigList.Count; i++)
        newArray[i] = bigList[i].ToArray();

    //Выводим новый массив в консоль.
    ShowArrayЫtepped(newArray, selectNumber);
    Console.ReadKey();    
}
#region Методы для задачи №3 (Task03)
void ShowArrayЫtepped<T>(T[][] Array, int selectedNumber)
{
    Console.WriteLine($"Новый массив, где все числа из страрого массива больше - {selectedNumber} ") ;
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array[i].Length; j++)
        {
            Console.Write(Array[i][j] + "\t");
        }
        Console.WriteLine();
    }
}
#endregion

void Task04()
{
    Console.Clear();
    Console.WriteLine("Задание №4." +
    "\nМетод принимает 2 параметра bool и получает результат всех булевых операций над\n" +
    "ними((&, |, ^).Возвращение результата на ваше усмотрение.\n\n");
    
    Console.WriteLine("Демонстрация первого варианта работы метода, где 1-ый параметр = FALSE,  2-ой TRUE ");
    Console.WriteLine(ResultBool(false, true)+"\n"); 
    Console.WriteLine("Демонстрация первого варианта работы метода, где 1-ый параметр = TRUE,   2-ой FALSE ");
    Console.WriteLine(ResultBool(true, false) + "\n");
    Console.WriteLine("Демонстрация первого варианта работы метода, где 1-ый параметр = TRUE,   2-ой TRUE ");
    Console.WriteLine(ResultBool(true, true) + "\n"); 
    Console.WriteLine("Демонстрация первого варианта работы метода, где 1-ый параметр = FALSE,  2-ой FALSE ");
    Console.WriteLine(ResultBool(false, false) + "\n"); 
    Console.ReadKey();
}
#region Метод для задачи №3 (Task040)
string ResultBool(bool one, bool two)
{
    string result = "";
    bool bResult1 = one | two;
    bool bResult2 = one & two;
    bool bResult3 = one ^ two;
    result += "Результат операции '|' = " + bResult1.ToString().ToUpper() + "\t";
    result += "Результат операции '&' = " + bResult2.ToString().ToUpper() + "\t";
    result += "Результат операции '^' = " + bResult3.ToString().ToUpper();

    return result;
}
#endregion