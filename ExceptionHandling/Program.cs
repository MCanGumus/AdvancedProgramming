
internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            while (true)
            {
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.M)
                {
                    throw new CustomException("You pressed to key M.") { MyProperty = 5};
                } //throw ancak Exception ile imzalanmış sınıflarda kullanılabilir.
                else { Console.WriteLine(key.Key); }
            }
        }
        catch (CustomException ex)
        {

            throw;
        }
       
    }
}

class CustomException : Exception
{
    public CustomException() : base("Custom exception.")
    {
            
    }

    public CustomException(string message) : base(message)
    {
                
    }

    public int MyProperty { get; set; }
}

