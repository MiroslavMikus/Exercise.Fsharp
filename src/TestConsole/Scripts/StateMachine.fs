namespace TimedOperation

open System

module StateMachine = 
    type todo = unit
    let todo () = ()

    // state data
    type ReadyData = Timed<TimeSpan list>

    type ReceivedMessageData = Timed<todo>
    
    type MoMessageData = Timed<TimeSpan list>

    // states
    type PollingConsumer = 
    | ReadyState of ReadyData
    | ReceivedMessageState of ReceivedMessageData
    | NoMessageState of MoMessageData
    | StoppedState

    let transformFromStopped  = StoppedState

    let transitionFromNoMessage shouldIdle idle (nm : MoMessageData) = 
        if shouldIdle nm
        then idle () |> Untimed.withResult nm.Result |> ReadyState
        else StoppedState

    let transmisionFromReady shouldPoll poll (r: ReadyData) : PollingConsumer =
        if shouldPoll r 
        then 
            let msg = poll ()
            match msg.Result with
            | Some _ -> msg |> Untimed.withResult () |> ReceivedMessageState
            | None -> msg |> Untimed.withResult r.Result |>  NoMessageState
        else StoppedState

