// Learn more about F# at http://fsharp.org
open Slices
open Nameof
open OpenStaticClasses
open Applicatives
open DefaultInterfaceImplementationsInterop

[<EntryPoint>]
let main _ =
    emptySlices()
    fixedIndexSlices()
    reverseSlices()
    doNameof()
    printStaticClassValue()
    printApplicatives()
    printDefaultInterfaceStuff()

    0 // return an integer exit code
