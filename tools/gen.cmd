@echo off
pushd "%~dp0"
dotnet run -p Generator > ..\src\TaskTupleAwaiter\TaskTupleExtensions.g.cs
