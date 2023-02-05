using System.Text.RegularExpressions;

void OutputBeforeAndAfterResult(string[] userData, string[] filteredArray)
{
    Console.WriteLine();
    Console.Write("[{0}]", string.Join(", ", userData));
    Console.Write(" -> ");
    Console.Write("[{0}]", string.Join(", ", filteredArray));
    Console.WriteLine("\n");
}

int CountNumberOfItemsBelowCharsLimit(int charsLimit, string[] userData)
{
    int counter = 0;

    foreach (string item in userData)
    {
        if (item.Length <= charsLimit)
            counter++;
    }

    return counter;
}

string[] FilterUserDataArray(int charsLimit, string[] userData)
{
    int numberOfItems = CountNumberOfItemsBelowCharsLimit(charsLimit, userData);

    if (numberOfItems > 0)
    {
        string[] filteredArray = new string[numberOfItems];
        int i = 0;

        foreach (string item in userData)
        {
            if (item.Length <= charsLimit)
            {
                filteredArray[i] = item;
                i++;
            }
        }

        return filteredArray;
    }
    else
    {
        string[] empty = new string[0];
        return empty;
    }
}

string[] CollectUserInputData(int numberOfItems)
{
    string[] userInputDataArray = new string[numberOfItems];

    for (int i = 0; i < numberOfItems; i++)
    {
        Console.Write("Введите строку " + (i + 1) + " из " + numberOfItems + ": ");
        string userRawData = Console.ReadLine();
        string userInputData = userRawData.Trim();
        RegexOptions options = RegexOptions.None;
        Regex regex = new Regex("[ ]{2,}", options);
        userInputData = regex.Replace(userInputData, " ");

        if (userInputData.Length > 0)
        {
            userInputDataArray[i] = userInputData;
        }
        else
        {
            Console.WriteLine("Неправильный формат данных, повторите ввод!");
            return CollectUserInputData(numberOfItems);
        }
    }
    return userInputDataArray;
}

Console.Clear();
const int charsLimit = 3;
const int numberOfItems = 4;
string[] userInputDataArray = CollectUserInputData(numberOfItems);
string[] filteredArray = FilterUserDataArray(charsLimit, userInputDataArray);
OutputBeforeAndAfterResult(userInputDataArray, filteredArray);
