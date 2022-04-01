module CalculatorController

open Giraffe.Core
open Giraffe
open CalculatorF.Program

[<CLIMutable>]
type Values=
    {
        val1 : string
        operation : string
        val2 : string
    }

let CalculatorController : HttpHandler =
    fun next context ->
        let values = context.TryBindQueryString<Values>()
        match values with
        | Ok v ->
            let res = GetResult [| v.val1; v.operation; v.val2 |]
            match res with
            | Some res -> (setStatusCode 200 >=> json res) next context
            | None -> (setStatusCode 450 >=> json "Error") next context
        | Error err ->
            (setStatusCode 400 >=> json err) next context