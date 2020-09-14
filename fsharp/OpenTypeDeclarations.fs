module OpenTypeDeclarations

// We can "open" the Math static class
open type System.Math

type AClass() =
    static member Add(x, y) = x + y

module M =
    type DU = A | B | C
    let someOtherFunction x = x + 1

// We can "open" our own type
open type AClass

// We can "open" a DU inside of a module
open type M.DU

let printOpenTypeDeclarationsStuff () =
    printfn "%f" <| Add(2.0, PI)
    printfn "case A is: %A" A