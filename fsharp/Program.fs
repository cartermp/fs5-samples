// Learn more about F# at http://fsharp.org
open Slices
open Nameof
open OpenTypeDeclarations
open Applicatives
open DefaultInterfaceImplementationsInterop
open NullableInterop
open InterpolatedStrings

[<EntryPoint>]
let main _ =
    emptySlices()
    fixedIndexSlices()
    reverseSlices()
    doNameof()
    printOpenTypeDeclarationsStuff()
    printApplicatives()
    printDefaultInterfaceStuff()
    checkIfDateTimeHasValue()
    doInterpolatedStrings()

    0 // return an integer exit code
