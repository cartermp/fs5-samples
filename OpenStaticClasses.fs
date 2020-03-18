module OpenStaticClasses

// We can "open" the Math static class
open System.Math

[<AbstractClass;Sealed>]
type A =
    static member Add(x, y) = x + y
    
open A

let printStaticClassValue () =
    printfn "%f" <| Add(2.0, PI)