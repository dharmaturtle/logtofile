module Tests

open System
open Xunit

type NullCoalesce = // https://stackoverflow.com/a/21194566
    static member Coalesce(a: 'a option, b: 'a Lazy) = 
        match a with 
        | Some a -> a 
        | _ -> b.Value
    static member Coalesce(a: 'a Nullable, b: 'a Lazy) = 
        if a.HasValue then a.Value
        else b.Value
    static member Coalesce(a: 'a, b: 'a Lazy) = 
        match obj.ReferenceEquals(a, null) with
        | true -> b.Value
        | false -> a
let inline nullCoalesceHelper< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Coalesce : ^a * ^b -> ^c)> a b = 
        // calling the statically inferred member
        ((^t or ^a) : (static member Coalesce : ^a * ^b -> ^c) (a, b))
let inline (|??) a b = nullCoalesceHelper<NullCoalesce, _, _, _> a b

type MyRec = {
    Created: DateTime
    Modified: Nullable<DateTime>
}

[<Fact>]
let ``My test`` () =
    {   Created = DateTime.UtcNow
        Modified = Nullable()
    } |> Seq.singleton
    |> Seq.maxBy (fun x -> x.Modified |?? lazy x.Created)
