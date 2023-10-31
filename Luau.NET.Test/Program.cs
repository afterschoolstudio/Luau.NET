// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Luau;

var script = @"
function ispositive(x)
    return x > 0
end

print('hello')
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
    nuint outsize = 0;
    
    Console.WriteLine("creating a state");
    var L = Luau.Luau.luaL_newstate();
    Luau.Luau.luaL_openlibs(L);
    
    //route print to console
    // luaL_setfuncs(L, printlib, 0);
    var print_debug_name = System.Text.Encoding.UTF8.GetBytes("print");
    fixed (byte* ptr = print_debug_name)
    {
        // Luau.Luau.lua_pushcclosurek(L,&Print,(sbyte*)ptr,0,null);
        // Luau.Luau.lua_setfield(L,-8000 - 2002,(sbyte*)ptr);
        // // Luau.Luau.lua_settop(L,-(1)-1); //Luau.Luau.pop(L, 1);
        //
        Luau.Luau.lua_pushvalue(L,-8000 - 2002);
        Luau.luaL_Reg funcs = default;
        funcs.func = &Print;
        funcs.name = (sbyte*)ptr;
        Luau.Luau.luaL_register(L,null,&funcs);
        Luau.Luau.lua_settop(L,-(1)-1); //Luau.Luau.pop(L, 1);
        Luau.lua_Debug db = default;
        Luau.Luau.lua_getinfo(L, 2, (sbyte*)ptr, &db);
        Console.WriteLine($"{(*db.name).ToString()} {(*db.what).ToString()}");
    }
    
    // var state = Luau.Luau.lua_newstate;
    Console.WriteLine("state created");
    var chunkname = System.Text.Encoding.UTF8.GetBytes("test");
    fixed (byte* ptr = scriptBytes, chunk = chunkname)
    {
        Console.WriteLine("compiling");
        var comp_result = Luau.Luau.luau_compile(
            (sbyte*)ptr,
            (nuint)(scriptBytes.Length * sizeof(byte)), 
            &compOpts,
            &outsize
            );
        Console.WriteLine("loading");
        int result = Luau.Luau.luau_load(
            L, 
            (sbyte*)chunk, 
            comp_result, 
            outsize,
            0);
        Console.WriteLine(result);
    }
    Console.WriteLine(outsize);
    //https://stackoverflow.com/questions/4508119/redirecting-redefining-print-for-embedded-lua
    // static int l_my_print(Luau.lua_State* L) {
    //     int nargs = Luau.Luau.lua_gettop(L);
    //     nuint stringSize = 0;
    //     for (int i=1; i <= nargs; i++) {
    //         if (Luau.Luau.lua_isstring(L, i) > 0)
    //         {
    //             var str = Luau.Luau.luaL_tolstring(L, i, &stringSize);
    //             Console.WriteLine((*str).ToString());
    //             /* Pop the next arg using lua_tostring(L, i) and do your print */
    //         }
    //         else {
    //             /* Do something with non-strings if you like */
    //         }
    //     }
    //
    //     return 0;
    // }
    Luau.Luau.lua_close(L);
}

while (true)
{
    
}
Console.WriteLine("exited");

[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
static unsafe int Print(Luau.lua_State* s)
{
    Console.WriteLine("printing");
    // int i;
    // int nargs = lua_gettop(L);
    // printf("in my_print:");
    // for (i=1; i <= nargs; ++i) {
    //     printf(lua_tostring(L, i));
    // }
    // printf("\n");
    // return 0;
    return 0;
}

