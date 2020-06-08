#if !INTERACTIVE
module Types
#endif

////// Record
type Person = { FirstName : string; LastName : string }

let person = { FirstName = "SomeName"; LastName = "AlsoLastName" }

// creates new person
let person2 = { person with FirstName = "Miro" } 

let person3 = { FirstName = "SomeName"; LastName = "AlsoLastName" }

printfn "Structural equality %b" (person = person3)


////// Discriminated Union

type Shape = 
    | Square of float
    | Rectangle of float * float
    | Circle of float

let square = Square 3.4
let rectangle = Rectangle (2.2, 1.9)
let circle = Circle 1.0

let drawings = [|square; rectangle; circle |]

let PrintDrawing (shape : Shape) = 
    match shape with
    | Square f -> sprintf "We have square %f" f 
    | Rectangle (f, s) -> sprintf "We have Rectangle %f %f" f s 
    | Circle f -> sprintf "We have circle %f" f 

let d = drawings |> Array.map (fun drawing -> PrintDrawing drawing)