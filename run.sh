#!/usr/bin/env bash
set -Eeou pipefail

scriptdir=$(dirname -- "$(readlink -f -- "$0")")
dotnet run --project "$scriptdir"/TestApp.WebApp/TestApp.WebApp.csproj
