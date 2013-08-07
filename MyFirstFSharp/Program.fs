// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

let fb (n1, n2) =
    if (n1 < 10000) then
        Some (n1, (n2, n1+n2))
    else
        None

[<EntryPoint>]
let main argv = 
    Seq.unfold fb (1,1) |> Seq.iter System.Console.WriteLine |> ignore
    System.Console.ReadLine() |> ignore // return an integer exit code
    0