MyClass<int, string, bool> myClass = new();

class MyClass<T, T2, T3>
{
    T field;

    public T MyProperty { get; set; }

    //public T Method()
    //{
    //    ...
    //}

    //public T2 Method2(T3 param)
    //{
    //    ...
    //}
}

class NonGenericClass : MyClass<int, bool, string>
{

}

class GenericClass<T> : MyClass<T, T, T>
{
}

class ClassExample<T>
{
    public void Method<C>(T a)
    {
    }
}

internal partial class Program
{
    private void Main(string[] args)
    {
        Method<int>();  // null value almaması halinde herhangi bir yapı eklenebilir. int, long vs.
        MethodCl<A>();  //class yapısına sahip olmayan herhangi bir yapı buraya yazılamaz.
        MethodNew<A>(); // new'lenebilen herhangi bir yapı buraya yazılabilir. Constructor varsa kesinlikle public ve parametresiz olmalıdır.
        MethodBase<A>();

        MyClass1<A>.MyClass2<B> instance = new(); //B class'ı A'dan türemezse bu satır hata verir.
        //Method<string>(""); //Hata verir. NonNullable value istemektedir.
    }

    public void Method<T>() where T : struct
    {
    }

    public void MethodCl<T>() where T : class
    {
    }

    public void MethodNew<T>() where T : new()
    {
        T t = new T();
    }

    public void MethodBase<T>() where T : A
    {

    }
}

class A
{
    public virtual void Method<T>()
    {

    }

}

class B : A, IMyInterface
{
    public override void Method<T>() where T : default
    {

    }

    void IMyInterface.Y<T>() where T : default
    {
        throw new NotImplementedException();
    }
}

abstract class MyAbstractClass
{

}

interface IMyInterface
{
    void Y<T>();
}

record MyRecord
{

}

struct MyStruct
{

}

class OverloadExampleClass
{
    public void X()
    {

    }

    public void X(int a) { }

    public void X<T>() { }
}

class OverloadExampleClass<T>
{
    public void X()
    {

    }

    public void X(int a) { }

    public void X<T>() { }
}

class MyClass1<T1>
{
    public class MyClass2<T2> where T2 : T1 { }
}



