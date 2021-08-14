# Learning F#

## What is F#

F# is pronounced as F Sharp. It is a functional programming language that supports approaches like object oriented and imperative programming approach. It is a cross-platform and _.Net Framework language_. The filename extension for F# source file is `.fs`.

### Functions
```f#
let hello() =
....

```

### Simple Program
```f#
open System

let hello() =
    printf "hello World"

hello()
```

### Reading from console
```
open System

let hello() =
    printf "___Hello World___"
    printf "\nEnter your name : "

    let name = Console.ReadLine()
    printfn "Hello : %s" name
    

hello()
```

### Unique Formatting
```f#
open System

let hello() =
    printfn "%-5s %5s" "a" "b"
    
hello()
```

### Big Decimal Number
```f#
open System

let hello() =

    let big_pi = 3.1436472392378263254936438743M
    printfn "\nBig PI : %M" big_pi
    
hello()
```

### Unique Formatting Returns
```f#
open System

let hello () =
    printfn "%*s" 10 "Hi"

hello ()
```

### Changing variable
```f#
open System

// varibles are immutable by defualt 
// to make them mutable, you have to mark them as mutable
// to change a mutable variable, use <- symbol

let hello () =
    let mutable  weight = 10
    printfn "%i weight" weight
    weight <- 100
    printfn "%i  weight" weight

    let change_me = ref 100
    change_me := 50
    printfn "Change %i" ###  change_me

hello ()
```

### functions returns
```f#
open System

let get_sum (x: int, y: int) : int = x + y

Console.WriteLine(get_sum(3,4))
```

### recursive function
```f#
open System

let do_funcs () =

    let rec factorial x =
        if x < 1 then
            1
        else
            x * factorial (x - 1)

    printfn "Factorial 4 : %i" (factorial 4)

do_funcs ()
```

### List in f#
```f#
open System

let do_funcs () =

    let rand_list = [ 1; 2; 3; 4 ]
    let rand_list2 = List.map (fun x -> x * 2) rand_list
    printfn "Double List : %A" rand_list2

    [ 5; 6; 7; 8; 9; 10 ]
    |> List.filter (fun v -> (v % 2) = 0)
    |> List.map (fun x -> x * 2)
    |> printfn "Elements : %A" 

do_funcs ()
```

### weird functions
```f#
open System

let do_funcs () =

    let mult_num x = x*3
    let add_num y = y+5

    let mult_add = mult_num >> add_num
    let add_mult = mult_num << add_num

    printfn "mult_add : %i" (mult_add 10)
    printfn "add_mult : %i" (add_mult 10)

do_funcs ()
```

### Basic Maths
```f#
open System

let do_funcs () =

    printfn "5+4 = %i" (5 + 4)
    // addition
    printfn "5-4 = %i" (5 - 4)
    // subtraction
    printfn "5*4 = %i" (5 * 4)
    // multiplication
    printfn "5/4 = %i" (5 / 4)
    // division
    printfn "5%%4 = %i" (5 % 4)
    // modulus : use %% to print % to console
    printfn "5**4 = %f" (5.0 ** 4.0)
    // power function, only works on float

do_funcs ()
```

### String basics
```f#
open System

let do_funcs () =

    let my_name = "Uday Yadav"
    printfn "Length : %i" (String.length my_name)
    printfn "%c" my_name.[1]
    printfn "hello : %s" (my_name.[0..4])


do_funcs ()
```

