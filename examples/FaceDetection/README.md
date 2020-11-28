# Face Detection

This program is example call face detection api.

## How to run

### Server

````
$ cd FaceDetection.Server
$ dotnet run -c Release -r win-x64

info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: D:\Works\OpenSource\DlibDotNet\examples\ASP.NET\FaceDetection.Server
````

### Client

````
$ dotnet run -c Release -- http://localhost:5000 "images\2009_004587.jpg"

[Info] Find 2 faces
````

After this, you can see **result.jpg** in current directory.

![Result](images/result.jpg "Result")