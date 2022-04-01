namespace CalculatorF 

module Program = 

open MaybeBuilder
open Calculator
open Parser

    
    let main argv =
        let result = maybeBuilder {
            let! parsed = Parse argv
            let! result = Calculate parsed
            return result
        }
        
        match result with
        | Some value ->
            printf $"{value}"
            0
        | None ->
            printf "None"
            1