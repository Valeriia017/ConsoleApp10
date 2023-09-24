using System;

class Ar
{
    private int n;
    private int[] a;
    private int s;

    public Ar(int n, int x)
    {
        this.n = n;
        a = new int[n];
        Random random = new Random();

        for (int i = 0; i < n; i++)
        {
            a[i] = random.Next(-x, x + 1);
        }
    }

    public Ar(string numbers)
    {
        string[] numberArray = numbers.Split(' ');
        n = numberArray.Length;
        a = new int[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = int.Parse(numberArray[i]);
        }
    }

    public int S
    {
        get
        {
            s = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] < 0)
                {
                    s += a[i];
                }
            }
            return s;
        }
    }

    public int N
    {
        get { return n; }
    }

    public void Print()
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write(a[i] + " ");
        }
        Console.WriteLine();
    }

    public int P()
    {
        for (int i = n - 1; i >= 0; i--)
        {
            if (a[i] % 7 == 0)
            {
                return i;
            }
        }
        return -1;
    }

    public int Pr(int i1, int i2)
    {
        int product = 1;
        for (int i = i1; i <= i2; i++)
        {
            product *= a[i];
        }
        return product;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        try
        {
            Console.WriteLine("Оберіть конструктор:");
            Console.WriteLine("1 - конструктор з кількістю елементів та числом x");
            Console.WriteLine("2 - конструктор зі строковим параметром");

            int choice = int.Parse(Console.ReadLine());

            Ar obj;

            if (choice == 1)
            {
                Console.WriteLine("Введіть кількість елементів в масиві:");
                int n = int.Parse(Console.ReadLine());

                Console.WriteLine("Введіть число x:");
                int x = int.Parse(Console.ReadLine());

                obj = new Ar(n, x);
            }
            else if (choice == 2)
            {
                Console.WriteLine("Введіть числа, розділені пробілом:");
                string numbers = Console.ReadLine();

                obj = new Ar(numbers);
            }
            else
            {
                Console.WriteLine("Невірний вибір конструктора.");
                return;
            }

            obj.Print();

            Console.WriteLine("Сума негативних елементів масиву: " + obj.S);

            int pIndex = obj.P();
            if (pIndex != -1)
            {
                Console.WriteLine("Індекс останнього кратного 7 елемента: " + pIndex);
                int product = obj.Pr(0, pIndex);
                Console.WriteLine("Добуток елементів масиву лівіше знайденого: " + product);
            }
            else
            {
                Console.WriteLine("Елемент не знайдено.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Виникла помилка: " + ex.Message);
        }
    }
}