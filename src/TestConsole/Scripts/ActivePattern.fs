module ActivePattern

    let (|Int|_|) (str:string) = 
        match System.Int32.TryParse(str) with
        | (true, int) -> Some(int)
        | _ -> None

    let (|Bool|_|) (str:string) = 
        match System.Boolean.TryParse(str) with
        | (true, int) -> Some(int)
        | _ -> None


    let testParse str = 
        match str with 
        | Int nr -> printfn "String is a number: %i" nr
        | Bool b -> printfn "String is a bool: %b" b
        | _ -> printfn "Can't recognize"

    testParse "135"
    testParse "true"
    testParse "654sd"