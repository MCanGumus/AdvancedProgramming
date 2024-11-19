//----------------------------------------Actions--------------------------------//

Action action = () =>
{

};

Action<int> action1 = (integerParam) => { Console.WriteLine("Value: " + integerParam); };

Action<int, string> action2 = (integerParam, stringParam) => Console.WriteLine($"Values: {integerParam}, {stringParam}");

action();
action1.Invoke(45);
action2(45, "Trial");

//--------------------------------------Func--------------------------------------//

//Verilen son generic type func metodunun geri dönüş tipini belirler.

Func<int, string, bool> funcBool = (i, s) => true;

Func<int> funcInteger = () => 5;

funcBool(5, "Trial");
funcInteger();

Func<byte, int, string, (int, char)> example = (b, i, s) => (5, 'a');

//-----------------------------------Predicate------------------------------------//
//Mutlaka bool dönüşlü bir delegate yapısıdır.

Predicate<bool> predicate = b => true;

Predicate<int> predicate2 = i => i < 10;

predicate(false);

predicate2(5);

//------------------------------------Lambda Discard Parameters-------------------//

Func<int, int, string, char> func = (_, _, s1) => 'a';  //Parametreleri bu şekilde discard(dışarı itme) edebiliriz.





