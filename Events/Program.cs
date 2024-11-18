using Events;
using System.Globalization;

//Notlar: Delegate'lere instance üzerinden erişilemez. 

//Soru: C#'TA bir sınıfın içerisinde tanımlanmış olan delegate'e instance üzerinden nasıl erişilir.
//Cevap: Event yapısı ile.

string path = @"PathInfo";

MyEventPublisher myEventPublisher = new MyEventPublisher();

myEventPublisher.MyEvent += X;
myEventPublisher.MyEvent += X;
myEventPublisher.MyEvent -= X;

myEventPublisher.RaiseEvent();

MyEventPublisher.XHandler dHandler = new MyEventPublisher.XHandler(X);

//-----------------------------------------------------------------------------

PathControl pathControl = new PathControl();

pathControl.PathControlEvent += (sizeMB) =>
{
    Console.WriteLine($"Boyut 50 MB aştı.{sizeMB}");
};

await pathControl.ControlPanel(path);

//------------------------------------------------------------------------------

void X()
{

}

class MyEventPublisher
{
    public delegate void XHandler();

    XHandler xDelegate;

    public event XHandler MyEvent 
    {
        add
        {
            Console.WriteLine("Event'e metot bağlandı.");
            xDelegate += value;
        }
        remove
        {
            Console.WriteLine("Event'ten metot kaldırıldı.");
            xDelegate -= value;
        }
    }

    public void RaiseEvent()
    {
        //MyEvent();

        xDelegate();
    }
}