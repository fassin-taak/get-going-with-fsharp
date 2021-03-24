open System

let getName =
  Console.ReadLine()

/// Says hello to the given name.
let sayHelloTo name =
  let greeting = String.Format ("Well, hello {0}!", [|name|])
  Console.WriteLine greeting

/// Adds two numbers.
let add x y =
  x + y

/// Returns the factorial of the given number.
let rec factorial n =
  match n with
  | 0 -> 1
  | n -> n * factorial (n - 1)

/// Returns the nth term in the Fibonacci sequence.
/// 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1597 ...
let rec fib n =
  match n with
  | 0 -> 1
  | 1 -> 1
  | n -> fib (n - 1) + fib (n - 2)

[<EntryPoint>]
let main(argv) =
  printfn "Exercise 1"
  printfn "----------"
  printfn "Greetings! What is your name?"
  sayHelloTo getName

  printfn ""
  printfn "Exercise 2"
  printfn "----------"
  printfn "2 + 3 = %d" (add 2 3)

  printfn ""
  printfn "Exercise 3"
  printfn "----------"
  printfn "5! = 5 * 4 * 3 * 2 * 1 = %d" (factorial 5)

  printfn ""
  printfn "Exercise 4"
  printfn "----------"
  let seq = [for i in 0 .. 16 -> i]
  let fs = seq |> List.map fib
  printfn "The first %d terms in the Fibonacci sequence are:" seq.Length
  for i in 0 .. seq.Length - 1 do
    printfn "%2d %4d" i fs.[i]

  0