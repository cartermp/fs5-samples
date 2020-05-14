// Learn more about F# at http://fsharp.org
open Slices
open Nameof
open OpenStaticClasses
open Applicatives
open CSharp

[<EntryPoint>]
let main _ =
    emptySlices()
    fixedIndexSlices()
    reverseSlices()
    doNameof()
    printStaticClassValue()
    printApplicatives()

    let x = { new MyDim }
    printfn "%d" x.Z

    0 // return an integer exit code
