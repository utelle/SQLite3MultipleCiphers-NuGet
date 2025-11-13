powershell iwr https://github.com/ericsink/SQLitePCL.raw/raw/main/src/providers/provider.tt -OutFile provider.tt

dotnet tool update -g dotnet-t4
t4 provider.tt -o SQLite3Provider_sqlite3mc.cs -p NAME=sqlite3mc -p CONV=Cdecl -p KIND=dllimport -p NAME_FOR_DLLIMPORT=sqlite3mc -p FEATURE_WIN32DIR=FEATURE_WIN32DIR/true -p FEATURE_LOADEXTENSION=FEATURE_LOADEXTENSION/true -p FEATURE_FUNCPTRS=FEATURE_FUNCPTRS/false -p FEATURE_KEY=FEATURE_KEY/true
