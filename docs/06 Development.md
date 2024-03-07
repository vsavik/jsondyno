# Development Guide

describe build.ps1, run tools (jb)
common build tasks (nuke build, compile, etc)
exec nuke as global tool or with ps profile

## Dotnet tools

To restore all tools run command:

```sh
dotnet tool restore
```

### JetBrains code analyzer

This tool is used to analyze and cleanup code based on current .editorconfig settings. [Official JetBrains Docs](https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html)

To update the tool run command:

```sh
dotnet tool update JetBrains.ReSharper.GlobalTools
```

To run the tool against Jsondyno source code:

```sh
dotnet tool run jb inspectcode --build -o="./artifacts/code-analysis-jb-report.xml" ./src/Jsondyno/Jsondyno.csproj
```

Check the file `code-analysis-jb-report.xml` in `artifacts` directory.


# Artifacts

This folder is used as output directory for files produced by build tasks, code analysis, etc.
All files inside are ignored by source control.

