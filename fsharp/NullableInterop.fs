module NullableInterop

open CSharp
open System

let checkIfDateTimeHasValue() =
    let c = SomeCSharpClass()
    let x = Nullable<DateTime>()
    let y = DateTime.Now
    printfn "Null datetime has value: %b" (c.TakeANullableDateTime(x))
    printfn "Null datetime has value: %b" (c.TakeANullableDateTime(y))