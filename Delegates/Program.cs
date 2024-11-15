public delegate void XHandler(int a, string b);

public delegate void YHandler();

public delegate (int, char) AnimalHandler(Animal animal, (string, int) tupleParam);

public delegate void ZHandler();

//Covariance
public delegate Animal WHandler<out Animal>();

//Contravariance

public delegate Cat CHandler<in Animal>();




public class Animal
{

}

public class Cat : Animal
{

}


public class Program
{
    static public Animal WMethod()
    {
        return new Animal();
    }

    static public void XMethod(int a, string b)
    {
        
    }

    static public void YMethod()
    {
        Console.WriteLine("Y Method is running.");
    }

    static public(int, char) AnimalMethod(Animal animal, (string, int) tupleParam)
    {
        Console.WriteLine("Animal Method is running.");

        return (3, 'a');
    }

    static void ZMethod1() => Console.WriteLine("ZMethod 1");
    static void ZMethod2() => Console.WriteLine("ZMethod 2");
    static void ZMethod3() => Console.WriteLine("ZMethod 3");
    static void ZMethod4() => Console.WriteLine("ZMethod 4");



    private static void Main(string[] args)
    {
        XHandler xDelegate = new XHandler(XMethod);
        //XHandler xDelegate = XMethod;
        //YHandler yDelegate = () => { };
        YHandler yDelegate = new YHandler(YMethod);

        YHandler yAnonymous = delegate ()
        {

        };

        XHandler xAnonymous = delegate (int a, string b)
        {

        };

        AnimalHandler animalDelegate = new AnimalHandler(AnimalMethod);

        xDelegate(123, "Deneme");
        yDelegate.Invoke();

        animalDelegate(new(), ("Deneme", 3));
        animalDelegate.Invoke(new(), ("Deneme", 3));

        //-----------------------------------Multicast Delegates--------------------------------------//

        ZHandler zDelegate = ZMethod1;
        zDelegate += ZMethod2;
        zDelegate += ZMethod3;
        zDelegate += ZMethod4; // -= operatörü de kullanılabilir.

        zDelegate();

        var delegates = zDelegate.GetInvocationList();

        foreach (var method in delegates)
        {
            Console.WriteLine(method.Method.Name);
        }

        //-----------------------------------Covariance - Contravariance------------------------------//

        //Covariance
        WHandler<Cat> catDelegate = () => new();

        WHandler<Animal> animDelegate = catDelegate;

        //Contravariance

        CHandler<Animal> animContraDelegate = () => new();

        CHandler<Cat> catContraDelegate = animContraDelegate;


    }
}



