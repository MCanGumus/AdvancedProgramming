//int b = 5;

//X(b);


//void X(int a)
//{

//}

////Bu şekilde bellekte hem a hem b değerinde iki değişken oluşur. Bu durumda b veya a da oluşacak 
////herhangi bir değişiklik birbirlerini etkilemeyecek.

////----------------------------------------------------------------------------------------------------

//int c = 5;

//Y(ref c);

//void Y(ref int a)
//{

//}

//Burada a ve c aynı bellek adresini işaretlemektedir. Bu da a için yapılacak herhangi bir değişimin
//c değeri için de gerçekleşeceğini gösterir a artık c dir. a = c yanlıştır. *a = *c doğrudur.

//-----------------------------------------------------------------------------------------------------

int d = 5;

ref int x = ref Z(ref d);

Console.WriteLine(d);
Console.WriteLine(x);
d = 787878;
Console.WriteLine(x);

ref int Z(ref int a)
{
    a = 124;

    return ref a;  //ref return örneği
}

//-----------------------------------------------------------------------------------------------------

char o = 'a';

ref char p = ref o; //ref local örneği
