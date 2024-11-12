using System.Dynamic;
using System.Net.Http.Headers;

internal class Program
{
    private static void Main(string[] args)
    {
        #region Generate Object with Activator

        Type type = typeof(MyClass);

        MyClass m = (MyClass)Activator.CreateInstance(type);

        #endregion

        #region Generate Object with Dynamic Object

        dynamic x = new MyClass();
        //x.A(); //Hata vermez. Runtime sırasında kontrol eder.

        dynamic instance = new DynamicMyClass();

        instance.DynamicProperty1 = 123;
        instance.DynamicProperty2 = "123"; //Bu satırlar TrySetMember metodunu tetikler.

        Console.WriteLine(instance.DynamicProperty1);//Bu satırlar TryGetMember metodunu tetikler.
        Console.WriteLine(instance.DynamicProperty2);

        #endregion

        #region Generate Object with dynamic keyword (ExpandoObject)

        dynamic obj = new ExpandoObject();

        obj.Prop1 = 123;
        obj.Prop2 = "123";

        Console.WriteLine(obj.Prop1);
        Console.WriteLine(obj.Prop2);

        #endregion

        Console.ReadLine();
    }
}


class MyClass
{
    public MyClass()
    {
        Console.WriteLine($"{nameof(MyClass)} instance created.");
    }
}

class DynamicMyClass : DynamicObject
{
    public DynamicMyClass()
    {
        Console.WriteLine($"{nameof(DynamicMyClass)} instance created.");
    }

    readonly private Dictionary<string, object> properties = new();

    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
        properties.Add(binder.Name, value);
        return true;
    }
    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        return properties.TryGetValue(binder.Name, out result);
    }
}