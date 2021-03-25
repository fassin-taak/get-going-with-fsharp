namespace Fractals

module Counter =
    open Avalonia.Controls
    open Avalonia.FuncUI.DSL
    open Avalonia.Layout
    
    /// The fractal type.
    type FractalType = Julia | Mandelbrot

    /// The state.
    type State = { ft : FractalType }

    /// Initializes the fractal type.
    let Init = { ft = Julia }

    /// Updates the fractal type.
    let Update (msg: FractalType) (state: State) : State =
      match msg with
      | Julia -> { state with ft = Julia }
      | Mandelbrot -> { state with ft = Mandelbrot }

    
    let View (state: State) (dispatch) =
        DockPanel.create [
            DockPanel.children [
                DockPanel.create [
                    DockPanel.children [
                        Button.create [
                            Button.dock Dock.Top
                            Button.height 250.0
                            Button.onClick (fun _ -> dispatch Julia)
                            Button.content "Julia"
                        ]                
                        Button.create [
                            Button.dock Dock.Bottom
                            Button.height 250.0
                            Button.onClick (fun _ -> dispatch Mandelbrot)
                            Button.content "Mandel"
                        ]
                    ]
                ]
                TextBlock.create [
                    TextBlock.dock Dock.Right
                    TextBlock.fontSize 48.0
                    TextBlock.verticalAlignment VerticalAlignment.Center
                    TextBlock.horizontalAlignment HorizontalAlignment.Center
                    TextBlock.text (string state.ft)
                ]
            ]
        ]