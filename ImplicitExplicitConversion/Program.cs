class A
{
    public int NumberA { get; set; }

    public static explicit operator B(A i) => new B();

}

class B
{
    public int NumberB { get; set; }

    public static implicit operator A(B i) => new A();
}


internal class Program
{
    private static void Main(string[] args)
    {
        A a = new B();

        A a2 = (A)new B();
    }
}

