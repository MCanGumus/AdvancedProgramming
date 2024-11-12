using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        Student student = new()
        {
            Name = "Can",
        };

        Book book = new()
        {
            Name = "Deneme",
            Author = "Deneme Yazar"
        };

        Student stuRes = student + book; //Normal şartlarda editörün işleyemediği kodları işletmemizi sağlayan yapıdır.
        Student stuResult = book + student;

        //--------------------------------------------------------------------------------------------


        //Server.Download(5);
        //Server.Upload(5);

        Server server = new();

        if (server << 5)
        {

        }
        if (server >> 5)
        {

        }

        //-------------------------------------------------------------------------------------

        Database db = new();

        bool connectionState = db + DatabaseType.SqlServer;

        if (connectionState)
        {
            Console.WriteLine("Başarıyla bağlandı...");
        }
    }
}

class Student
{
    public string Name{ get; set; }

    public List<Book> Books { get; set; } = new();

    public static Student operator +(Student s, Book b) //Operator overloading. void türlü olamaz.
                                                        //Mutlaka bir şey geri dönmelidir.
                                                        //public ve static olmak zorundadır.
                                                        //Mutlaka parametre kısımında tanımlandığı sınıfı içermelidir.
    {
        s.Books.Add(b);
        return s;
    }

    public static Student operator +(Book b, Student s) //Operator overloading.
    {
        s.Books.Add(b);
        return s;
    }
}

class Book 
{
    public string Name{ get; set; }
    public string Author{ get; set; }
}

class Server
{
    static void Download(int fileCount)
    {
        for (int i = 0; i < fileCount; i++)
            Console.WriteLine($"{i + 1}. file downloaded.");
    }

    static void Upload(int fileCount)
    {
        for (int i = 0; i < fileCount; i++)
            Console.WriteLine($"{i + 1}. file uploaded.");
    }

    public static bool operator <<(Server server, int fileCount)
    {
        Download(fileCount);
        return true;
    }
    public static bool operator >>(Server server, int fileCount)
    {
        Upload(fileCount);
        return true;
    }
}

class MyClass
{
    public int Count { get; set; }

    public static int operator+(Book b, MyClass c)
    {
        return 3;
    }

    public static int operator -(Book b, MyClass c)
    {
        return 3;
    }

    public static int operator <(Book b, MyClass c) //Eğer < işaret kullanılıyosa bunun tersi de mutlaka olmalıdır.
    {
        return 3;
    }

    public static int operator >(Book b, MyClass c)
    {
        return 3;
    }

    public static MyClass operator ++( MyClass c) // Bu kullanımda ise mutlaka tek parametre olmalıdır.
                                              // Mutlaka kullanıldığı Class türünden bir değer döndürmelidir.

    {
        c.Count++;

        return c;
    }

    public static MyClass operator --(MyClass c)
    {
        c.Count--;

        return c;
    }

    public static bool operator true(MyClass c)
    {
        return true;
    }

    public static bool operator false(MyClass c)
    {
        return true;
    }


}

class Database
{
    static string _connectionString;

    public static bool operator+ (Database db, DatabaseType dt)
    {
        _connectionString = dt switch
        {
            DatabaseType.SqlServer => "sqlserver",
            DatabaseType.PostgreSQL => "postgresql",
            DatabaseType.Oracle => "oracle",
        };

        //Connection.Open();

        return true;
    }
}

enum DatabaseType
{
    SqlServer, Oracle, PostgreSQL
}