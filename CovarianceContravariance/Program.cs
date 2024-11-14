
internal class Program
{
    private static void Main(string[] args)
    {
        #region Polymorphizm

        Animal a = new Cat();

        #endregion

        #region Covariance - Küçük kapsar nesnenin, büyük kapsar nesneye yönelimidir.

        object stringObj = new string("This is string example....");

        IEnumerable<Cat> _b = new List<Cat>();
        IEnumerable<Animal> _a = _b;

        #region Array Types

        object[] objArr = new string[2];

        objArr[0] = "FirstData";
        //objArr[1] = true; //Derleme sürecinde hata vermez ancak runtime sırasında hata verir. Çalışamaz.

        #endregion

        #region Delegate Types

        Func<Animal> getAnimal = GetCat;

        Cat GetCat() => new();


        #endregion

        #region Generic Types

        IAnimal<object> objAnimal = new Animal<string>();

        IAnimal<Animal> aAnimal = new Animal<Cat>();
        IAnimal<Animal> Animal = new Animal<Animal>();


        #endregion


        #endregion End of Covariance

        #region Contravariance - Programlamanın normal şartlarda izin vermediği büyük kapsar nesnenin küçüğe doğru yönelimidir.

        //B b = new A(); HATA VERİR!

        //string strObj = new object(); //HATA VERİR

        void XMethod(Animal a) { }

        Action<Animal> aDelegate = XMethod;
        Action<Cat> bDelegate = aDelegate;

        void YMethod(object a) { }

        Action<string> oDelegate = YMethod;
        Action<string> dDelegate = YMethod; 

        IMammal<string> s = new Mammal<object>();
        IMammal<Cat> cat = new Mammal<Animal>();

        #endregion End of Contravariance

    }
}

class Animal
{
    public virtual Animal GetAnimal() => new();
}

class Cat : Animal
{
    public override Cat GetAnimal() => new();
}

interface IAnimal<out T> { } //out olmadan hata verir. out parametresi burada normal classlarda kullanılamaz. line39

class Animal<T> : IAnimal<T>
{

}


interface IMammal<in T> { } // in olmadan hata verir. Buradaki in sayesinde contravariance davranış sergilenir.

class Mammal<T> : IMammal<T> { }

