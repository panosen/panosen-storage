@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.Storage.Qiniu\bin\Release\Panosen.Storage.Qiniu.*.nupkg D:\LocalSavoryNuget\

pause