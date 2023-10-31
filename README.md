# Luau.NET

very basic luau lib + bindings generator
demonstrates:
* ability to load in and compile a script
* function binding between luau/c#
* no marshalled bindings (fast!)

i don't know anything about luau (or really even lua) but will happily work with other people to make this better

the script will "fail" due to errors in the script, but that's the point.
expected output:
```
creating a state
state created
compiling
loading bytecode with size 424
hello world from luau
true
LUA_ERRRUN
[string "test"]:5: attempt to compare number < string
[string "test"]:5 function ispositive
[string "test"]:10

exited
```

zig build in build/ to build
use ClangSharpPInvokeGenerator in gen/ for gen.rsp to generate bindings

only tested on osx and dylib building and it all works
i suspect the declspec define thing for windows may break when trying to build

to test, `dotnet run` in Luau.NET.Test
