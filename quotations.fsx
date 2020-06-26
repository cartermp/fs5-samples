open FSharp.Linq.RuntimeHelpers

let eval q = LeafExpressionConverter.EvaluateQuotation q

let inline negate x = -x
// Crucially, 'negate' has the following signature:
//
// val inline negate: x: ^a ->  ^a when  ^a : (static member ( ~- ) :  ^a ->  ^a)
//
// This constraint is critical to F# type safety and is now retained in quotations


<@ negate 1.0 @>  |> eval |> printfn "%A"