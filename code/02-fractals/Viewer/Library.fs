namespace Fractals

module Fractals =
  /// Define a type for the fractal set type.
  type FractalType = Julia | Mandelbrot

  /// The model storing the type.
  type Model =
    { Type : FractalType }

  /// Initialization function for the Model type.
  let Init() = 
    { Type = Julia }

  /// Messages which can be sent to the fractals Model.
  type Msg =
    | SetFractalType of FractalType

  /// Updates the Model based on the message sent and
  /// returns a new Model.
  let Update msg m =
    match msg with
    | SetFractalType t -> { m with Type = t }

  open Elmish.WPF

  /// Binds the "FractalType" string from XAML views to the
  /// Model.
  let View () =
    [
      "FractalType" |> Binding.twoWay(
        (fun m -> m.Type),
        (fun newValue m -> newValue |> SetFractalType ))
    ]

  let main window =
    Program.mkSimpleWpf Init Update View
    |> Program.runWindow window