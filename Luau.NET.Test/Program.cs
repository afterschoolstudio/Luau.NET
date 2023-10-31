// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Luau;
using Luau.NET.Test;

var script = @"
--!strict

function ispositive(x)
    return x > 0
end

print('hello world from luau')
print(ispositive(1))
print(ispositive('2'))

function isfoo(a)
    return a == 'foo'
end

print(isfoo('bar'))
print(isfoo(1))
";

// nm -gU to compile

unsafe
{
    var scriptBytes = System.Text.Encoding.UTF8.GetBytes(script);
    Luau.lua_CompileOptions compOpts = default;
    compOpts.debugLevel = 2;
    nuint outsize = 0;
    
    Console.WriteLine("creating a state");
    var L = Luau.Luau.luaL_newstate();
    Luau.Luau.luaL_openlibs(L);
    
    //route print to console
    // luaL_setfuncs(L, printlib, 0);
    var print_debug_name = System.Text.Encoding.UTF8.GetBytes("print");
    fixed (byte* ptr = print_debug_name)
    {
        Luau.Luau.lua_pushvalue(L,Luau.Luau.LUA_GLOBALSINDEX);
        
        //create bind in functions via array (for multiple)
        // var funcs = new Utils.NativeArray<Luau.luaL_Reg>(2);
        // funcs[0].func = &Print;
        // funcs[0].name = (sbyte*)ptr;
        // funcs[1].func = null;
        // funcs[1].name = null;
        // Luau.Luau.luaL_register(L,null,funcs.Ptr);
        
        // create and bind in a single function
        Luau.Luau.macros_lua_pushcfunction(L,&Print,(sbyte*)ptr);
        
        Luau.Luau.macros_lua_pop(L,1);
    }
    
    // var state = Luau.Luau.lua_newstate;
    Console.WriteLine("state created");
    var chunkname = System.Text.Encoding.UTF8.GetBytes("test");
    fixed (byte* ptr = scriptBytes, chunk = chunkname)
    {
        Console.WriteLine("compiling");
        var compiledBytecode = Luau.Luau.luau_compile(
            (sbyte*)ptr,
            (nuint)(scriptBytes.Length * sizeof(byte)), 
            &compOpts,
            &outsize
            );
        Console.WriteLine($"loading bytecode with size {outsize}");
        int result = Luau.Luau.luau_load(
            L, 
            (sbyte*)chunk, 
            compiledBytecode, 
            outsize,
            0);
        Console.WriteLine(result);
    }

    var status = 0;
    bool run = true;
    while (run)
    {
        status = Luau.Luau.lua_resume(L, null, 0);
        switch ((Luau.lua_Status)status)
        {
            case lua_Status.LUA_ERRRUN:
                var s = Luau.Luau.macros_lua_tostring(L, -1);
                Console.WriteLine(Marshal.PtrToStringAnsi((IntPtr)s));
                var trace = Luau.Luau.lua_debugtrace(L);
                Console.WriteLine(Marshal.PtrToStringAnsi((IntPtr)trace));
                Luau.Luau.lua_close(L);
                run = false;
                break;
        }
    }
}

Console.WriteLine("exited");
//https://pastebin.com/2kAt4fKq
[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
static unsafe int Print(Luau.lua_State* L)
{
    int nargs = Luau.Luau.lua_gettop(L);
    Console.WriteLine($"my print in managed with nargs {nargs}");
    for (int i = 1; i <= nargs; i++)
    {
        if (Luau.Luau.lua_isstring(L, i) == 1) {
            var s = Luau.Luau.macros_lua_tostring(L, i);
            Console.WriteLine(Marshal.PtrToStringAnsi((IntPtr)s));
        }
        else
        {
            var t = Luau.Luau.lua_type(L, i);
            switch ((Luau.lua_Type)t)
            {
                case lua_Type.LUA_TBOOLEAN:
                    var b = Luau.Luau.lua_toboolean(L, i);
                    Console.WriteLine(b == 0 ? "false" : "true");
                    break;
                case lua_Type.LUA_TNUMBER:
                    var n = Luau.Luau.macros_lua_tonumber(L, i);
                    Console.WriteLine(n);
                    break;
            }
        }
    }
    return 0;
}

