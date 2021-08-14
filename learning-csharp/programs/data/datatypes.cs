using System;

class DataTypes 
{
    public static void EntryPoint()
    {
        byte myByte = 255;
        sbyte mysByte = 127;
        short myShort = 32767;
        ushort myUshort = 65535;
        uint myUint =  4294967295;
        long myLong = 9223372036854775807;
        ulong myuLong = 18446744073709551615;
        float myFloat = float.MaxValue;
        double myDouble = double.MaxValue;
        decimal myDecimal = decimal.MaxValue;
        char myChar = 'A';
        bool myBool = true;
        string myString = "Uday Yadav";

        Console.WriteLine(myByte);
        Console.WriteLine(mysByte);
        Console.WriteLine(myShort);
        Console.WriteLine(myUshort);
        Console.WriteLine(myUint);
        Console.WriteLine(myLong);
        Console.WriteLine(myuLong);
        Console.WriteLine(myFloat);
        Console.WriteLine(myDouble);
        Console.WriteLine(myDecimal);
        Console.WriteLine(myChar);
        Console.WriteLine(myBool);
        Console.WriteLine(myString);
       
    }
}