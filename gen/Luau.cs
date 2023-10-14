using System.Runtime.InteropServices;

namespace Luau;

public unsafe partial struct lua_CompileOptions
{
    public int optimizationLevel;

    public int debugLevel;

    public int coverageLevel;

    [NativeTypeName("const char *")]
    public sbyte* vectorLib;

    [NativeTypeName("const char *")]
    public sbyte* vectorCtor;

    [NativeTypeName("const char *")]
    public sbyte* vectorType;

    [NativeTypeName("const char *const *")]
    public sbyte** mutableGlobals;
}

public static unsafe partial class Luau
{
    [DllImport("luau", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z12luau_compilePKcmP18lua_CompileOptionsPm", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern sbyte* luau_compile([NativeTypeName("const char *")] sbyte* source, [NativeTypeName("size_t")] nuint size, lua_CompileOptions* options, [NativeTypeName("size_t *")] nuint* outsize);
}
