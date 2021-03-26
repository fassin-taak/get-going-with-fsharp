namespace Fractals

module Fractals =
    open Avalonia.Controls
    open Avalonia.FuncUI.DSL
    open Avalonia.Media.Imaging
    open Avalonia.Layout
    open Microsoft.FSharp.NativeInterop
    
    /// The fractal type.
    type FractalType = Julia | Mandelbrot

    /// The state.
    type State = { ft: FractalType; bmp: WriteableBitmap }

    /// Initializes the fractal type.
    let Init = {
      ft = Julia
      bmp = new WriteableBitmap(size = Avalonia.PixelSize(1024, 1024),
                                dpi = Avalonia.Vector(72.0, 72.0))

    }

    let drawRedDiskOnBlueBackground (bmp: WriteableBitmap) =
      let buffer = bmp.Lock()
      let pixels = NativePtr.ofNativeInt buffer.Address
      let nPixels = (int bmp.Size.Width) * (int bmp.Size.Height)
      for i in 0 .. nPixels do
        NativeInterop.NativePtr.set pixels i 0xff0000ff
      buffer.Dispose()

    /// Updates the fractal type.
    let Update (msg: FractalType) (state: State) (fun bmp:WriteableBitmap -> bmp: WriteableBitmap) : State =
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
                            Button.onClick (fun _ -> dispatch Julia drawRedDiskOnBlueBackground)
                            Button.content "Julia"
                        ]                
                        Button.create [
                            Button.dock Dock.Bottom
                            Button.height 250.0
                            Button.onClick (fun _ -> dispatch Mandelbrot drawRedDiskOnBlueBackground)
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