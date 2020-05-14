module Slices

open System

let l = [ 1..10 ]
let a = [| 1..10 |]
let s = "hello!"

let emptySlices () =
    // Before: does not throw exception
    // F# 5: same as before
    let lCount = l.[-2..(-1)].Length

    // Before: throws exception
    // F# 5: does not throw exception
    let aCount = a.[-2..(-1)].Length

    // Before: throw exception
    // F# 5: does not throw exception
    let sCount = s.[-2..(-1)].Length

    printfn "%A" {| ``lCount`` = lCount; ``aCount`` = aCount; ``sCount`` = sCount |}

let fixedIndexSlices () =
    // First, create a 3D array to slice
    let dim = 2
    let m = Array3D.zeroCreate<int> dim dim dim

    let mutable cnt = 0

    for z in 0..dim-1 do
        for y in 0..dim-1 do
            for x in 0..dim-1 do
                m.[x,y,z] <- cnt
                cnt <- cnt + 1

    printfn "%A" m.[*, 0, 1]

module private SpanExtensions =
    type Span<'T> with
        // Note the 'inline' in the member definition
        member inline sp.GetSlice(startIdx, endIdx) =
            let s = defaultArg startIdx 0
            let e = defaultArg endIdx sp.Length
            sp.Slice(s, e - s)
        
        member inline sp.GetReverseIndex(_, offset: int) =
            sp.Length - offset

    let printSpan (sp: Span<int>) =
        let arr = sp.ToArray()
        printfn "%A" arr

open SpanExtensions

let reverseSlices () =
    let xs = [1..10]
    //Get element 1 from the end:
    printfn "%A" xs.[^1]

    let sp = [| 1; 2; 3; 4; 5 |].AsSpan()
    
    // Pre-# 5.0 slicing on a Span<'T>
    printSpan sp.[0..] // [|1; 2; 3; 4; 5|]
    printSpan sp.[..3] // [|1; 2; 3|]
    printSpan sp.[1..3] // |2; 3|]
    
    // Same slices, but only using from-the-end index
    printSpan sp.[..^0]
    printSpan sp.[..^2]
    printSpan sp.[^4..^2]
