dotnet new sln -n Fractals
dotnet new classlib -lang "F#" -n Viewer
dotnet sln add Viewer/Viewer.fsproj
Install-Package Elmish.WPF