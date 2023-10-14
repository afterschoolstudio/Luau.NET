using System.Runtime.InteropServices;

namespace Luau;

public unsafe partial struct lua_CompileOptions
{
    public int optimizationLevel;

    public int debugLevel;

    public int coverageLevel;

    public sbyte* vectorLib;

    public sbyte* vectorCtor;

    public sbyte* vectorType;

    public sbyte** mutableGlobals;
}

public static unsafe partial class Luau
{
    [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* luau_compile(sbyte* source, nuint size, lua_CompileOptions* options, nuint* outsize);
}
