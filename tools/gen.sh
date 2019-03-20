#!/usr/bin/env bash
set -e
cd "$(dirname "$0")"
dotnet run -p Generator > ../src/TaskTupleAwaiter/TaskTupleExtensions.g.cs
