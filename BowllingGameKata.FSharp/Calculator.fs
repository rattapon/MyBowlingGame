namespace BowllingGameKata.FSharp

module Calculator =
    
    let rec sumScores rolls frame =
        match rolls with
        | _ when frame = 10                 -> 0
        | a::b::c::tail when a = 10         -> a + b + c + sumScores (b::c::tail) (frame+1)     //strike
        | a::b::c::tail when a + b = 10     -> a + b + c + sumScores (c::tail) (frame+1)        //spare
        | a::b::tail                        -> a + b + sumScores (tail) (frame+1)               //normal case
        | _                                 -> 0

    let sumScoresUnfold (rolls, frame) =
        match rolls with
        | _ when frame = 10                 -> None
        | a::b::c::tail when a = 10         -> Some (a + b + c, ((b::c::tail), (frame+1)))     //strike
        | a::b::c::tail when a + b = 10     -> Some (a + b + c, ((c::tail), (frame+1)))        //spare
        | a::b::tail                        -> Some (a + b, ((tail), (frame+1)))               //normal case
        | _                                 -> None

    
    [<CompiledName("CalculateScore")>]
    let calculateScore rolls = sumScores rolls 0

    [<CompiledName("CalculateScoreUnfold")>]
    let unfold rolls = Seq.unfold sumScoresUnfold (rolls, 0) |> Seq.sum
        


