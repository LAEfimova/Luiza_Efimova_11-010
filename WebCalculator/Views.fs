module Views

type Message = { Text: string }
open Giraffe.ViewEngine


let layout (content: XmlNode list) =
    html [] [
        head [] [
            title [] [ encodedText "Calculator" ]
            link [ _rel "stylesheet"
                   _type "text/css"
                   _href "main.css" ]
        ]
        body [] content
    ]

let partial () = h1 [] [ encodedText "Calculator" ]

let index (model: Message) =
    [ partial ()
      p [] [ encodedText model.Text ] ]
    |> layout