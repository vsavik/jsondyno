# Development

Developer helpers.

### JetBrains code analyzer

```sh
dotnet tool update JetBrains.ReSharper.GlobalTools

dotnet tool restore

dotnet tool run jb inspectcode -- --telemetry-optout --no-build --project="Jsondyno" --format=Sarif --output="./artifacts/jb-ca.sarif" Jsondyno.sln
```

Check the file `jb-ca.sarif` in `artifacts` directory.