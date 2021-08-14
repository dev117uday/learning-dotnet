module Arthmetic = 
    let add(a:int,b:int):int =
        a+b
    let sub(a:int,b:int):int =
        a-b

open Arthmetic

System.Console.WriteLine($"{add(4,5)}")
System.Console.WriteLine($"{sub(4,5)}")


      