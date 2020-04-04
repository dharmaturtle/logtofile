module Tests

open FSharp.Text.RegexProvider
open System
open Xunit

type BraceRegex = Regex< ".*" >

[<Fact>]
let ``My test`` () =
    let asdf = BraceRegex()
    Assert.True(true)
