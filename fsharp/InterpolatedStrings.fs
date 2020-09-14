module InterpolatedStrings

let doInterpolatedStrings () =
    // Basic interpolated string
    let name = "Phillip"
    let age = 29
    printfn $"Name: {name}, Age: {age}"
    // Inline expressions
    printfn $"I think {3.0 + 0.14} is close to {System.Math.PI}!"

    // Typed interpolation
    // '%s' requires the interpolation to be of type string
    // '%d' requires the interpolation to be an integer
    let name = "Phillip"
    let age = 29
    printfn $"Name: %s{name}, Age: %d{age}"

    // This would give an error because the types don't match!
    // printfn $"Name: %s{age}, Age: %d{name}"