module Nameof

open System
open System.Text.Json
open System.Runtime.CompilerServices

module private M =
    let f x = nameof x

type C<'TType> =
    member _.TypeName = nameof<'TType> // Nameof with a generic type parameter via 'nameof<>'

module SimplifiedEventStore =
    /// Simplified version of EventStore's API
    [<Struct; IsByRefLike>]
    type RecordedEvent = { EventType: string; Data: ReadOnlySpan<byte> }

    /// My concrete type:
    type MyEvent =
        | AData of int
        | BData of string

    // use 'nameof' instead of the string literal in the match expression
    let deserialize (e: RecordedEvent) : MyEvent =
        match e.EventType with
        | nameof AData -> AData (JsonSerializer.Deserialize<int> e.Data)
        | nameof BData -> BData (JsonSerializer.Deserialize<string> e.Data)
        | t -> failwithf "Invalid EventType: %s" t

let doNameof () =
    let months =
        [
            "January"; "February"; "March"; "April";
            "May"; "June"; "July"; "August"; "September";
            "October"; "November"; "December"
        ]

    let lookupMonth month =
        if (month > 12 || month < 1) then
            invalidArg (nameof month) (sprintf "Value passed in was %d." month)

        months.[month-1]

    printfn "%s" (lookupMonth 12)
    printfn "%s" (lookupMonth 1)

    try
        printfn "%s" (lookupMonth 13)
    with
    | :? ArgumentException as ae -> printfn "%s" ae.Message

    printfn "%s" (M.f 12)
    printfn "%s" (nameof M)
    printfn "%s" (nameof M.f)

    printfn "%s" (nameof(+)) // gives '+'
    printfn "%s" (nameof op_Addition) // gives 'op_Addition'
