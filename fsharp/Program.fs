// Learn more about F# at http://fsharp.org
open Slices
open Nameof
open OpenStaticClasses
open Applicatives
open DefaultInterfaceImplementationsInterop
open Quotations
open NullableInterop

[<EntryPoint>]
let main _ =
    emptySlices()
    fixedIndexSlices()
    reverseSlices()
    doNameof()
    printStaticClassValue()
    printApplicatives()
    printDefaultInterfaceStuff()
    checkIfDateTimeHasValue()

    0 // return an integer exit code
