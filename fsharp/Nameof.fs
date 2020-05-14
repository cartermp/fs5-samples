module Nameof

open System

module private M =
    let f x = nameof x

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