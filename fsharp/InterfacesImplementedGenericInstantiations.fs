module InterfacesImplementedGenericInstantiations

type IA<'T> =
    abstract member Get : unit -> 'T

type MyClass() =
    interface IA<int> with
        member x.Get() = 1
    interface IA<string> with
        member x.Get() = "hello"

let printInterfaceStuff() =
    let mc = MyClass()
    let iaInt = mc :> IA<int>
    let iaString = mc :> IA<string>

    printfn "%d" (iaInt.Get()) // 1
    printfn "%s" (iaString.Get()) // "hello"