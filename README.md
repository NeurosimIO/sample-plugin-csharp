# Sample Plugin (C#)

This is a sample plugin implementation for the NeuroSim Simulator using the [`SimSDK`](https://www.nuget.org/packages/SimSDK) C# SDK.

It demonstrates:
- Plugin structure using `IPlugin`
- Serving via ASP.NET Core with gRPC
- Compatibility with the simulator-core using protocol version `v0.0.18`

---

## 🧱 Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Optional: [grpcurl](https://github.com/fullstorydev/grpcurl) for testing

---

## 🚀 Build and Run

```bash
dotnet restore
dotnet build
dotnet run
```

The plugin will start a gRPC server on:

```
http://localhost:5000
```

---

## 🧪 Test with `grpcurl`

Make sure the plugin is running, then test using `grpcurl` (requires server reflection):

### 🔍 List Services

```bash
grpcurl -plaintext localhost:5000 list
```

Expected output:
```
grpc.reflection.v1alpha.ServerReflection
simsdkrpc.PluginService
```

---

### 📜 Get Manifest

```bash
grpcurl -plaintext -d '{}' localhost:5000 simsdkrpc.PluginService.GetManifest
```

Expected output:
```json
{
  "manifest": {
    "name": "sample-plugin",
    "version": "v0.0.1",
    "message_types": [
      {
        "id": "sample.echo",
        "display_name": "Sample Echo",
        "description": "Echoes back the input payload",
        "fields": [
          {
            "name": "message",
            "type": "STRING",
            "description": "The message to echo"
          }
        ]
      }
    ],
    "component_types": [
      {
        "id": "sample.component",
        "display_name": "Sample Component",
        "description": "A dummy component"
      }
    ]
  }
}
```

---

## 📦 Packaging

To publish a NuGet-compatible plugin or Docker container, additional instructions can be added later.

---

## 📝 License

MIT — see `LICENSE` file.