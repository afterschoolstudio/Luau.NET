using System;
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

    [NativeTypeName("unsigned int")]
    public enum lua_Status : uint
    {
        LUA_OK = 0,
        LUA_YIELD,
        LUA_ERRRUN,
        LUA_ERRSYNTAX,
        LUA_ERRMEM,
        LUA_ERRERR,
        LUA_BREAK,
    }

    [NativeTypeName("unsigned int")]
    public enum lua_CoStatus : uint
    {
        LUA_CORUN = 0,
        LUA_COSUS,
        LUA_CONOR,
        LUA_COFIN,
        LUA_COERR,
    }

    public partial struct lua_State
    {
    }

    [NativeTypeName("unsigned int")]
    public enum lua_Type : uint
    {
        LUA_TNIL = 0,
        LUA_TBOOLEAN = 1,
        LUA_TLIGHTUSERDATA,
        LUA_TNUMBER,
        LUA_TVECTOR,
        LUA_TSTRING,
        LUA_TTABLE,
        LUA_TFUNCTION,
        LUA_TUSERDATA,
        LUA_TTHREAD,
        LUA_TPROTO,
        LUA_TUPVAL,
        LUA_TDEADKEY,
        LUA_T_COUNT = LUA_TPROTO,
    }

    [NativeTypeName("unsigned int")]
    public enum lua_GCOp : uint
    {
        LUA_GCSTOP,
        LUA_GCRESTART,
        LUA_GCCOLLECT,
        LUA_GCCOUNT,
        LUA_GCCOUNTB,
        LUA_GCISRUNNING,
        LUA_GCSTEP,
        LUA_GCSETGOAL,
        LUA_GCSETSTEPMUL,
        LUA_GCSETSTEPSIZE,
    }

    public unsafe partial struct lua_Debug
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const char *")]
        public sbyte* what;

        [NativeTypeName("const char *")]
        public sbyte* source;

        [NativeTypeName("const char *")]
        public sbyte* short_src;

        public int linedefined;

        public int currentline;

        [NativeTypeName("unsigned char")]
        public byte nupvals;

        [NativeTypeName("unsigned char")]
        public byte nparams;

        [NativeTypeName("char")]
        public sbyte isvararg;

        public void* userdata;

        [NativeTypeName("char[256]")]
        public fixed sbyte ssbuf[256];
    }

    public unsafe partial struct lua_Callbacks
    {
        public void* userdata;

        [NativeTypeName("void (*)(lua_State *, int)")]
        public delegate* unmanaged[Cdecl]<lua_State*, int, void> interrupt;

        [NativeTypeName("void (*)(lua_State *, int)")]
        public delegate* unmanaged[Cdecl]<lua_State*, int, void> panic;

        [NativeTypeName("void (*)(lua_State *, lua_State *)")]
        public delegate* unmanaged[Cdecl]<lua_State*, lua_State*, void> userthread;

        [NativeTypeName("int16_t (*)(const char *, size_t)")]
        public delegate* unmanaged[Cdecl]<sbyte*, nuint, short> useratom;

        [NativeTypeName("void (*)(lua_State *, lua_Debug *)")]
        public delegate* unmanaged[Cdecl]<lua_State*, lua_Debug*, void> debugbreak;

        [NativeTypeName("void (*)(lua_State *, lua_Debug *)")]
        public delegate* unmanaged[Cdecl]<lua_State*, lua_Debug*, void> debugstep;

        [NativeTypeName("void (*)(lua_State *, lua_Debug *)")]
        public delegate* unmanaged[Cdecl]<lua_State*, lua_Debug*, void> debuginterrupt;

        [NativeTypeName("void (*)(lua_State *)")]
        public delegate* unmanaged[Cdecl]<lua_State*, void> debugprotectederror;
    }

    public unsafe partial struct luaL_Reg
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("lua_CFunction")]
        public delegate* unmanaged[Cdecl]<lua_State*, int> func;
    }

    public unsafe partial struct luaL_Buffer
    {
        [NativeTypeName("char *")]
        public sbyte* p;

        [NativeTypeName("char *")]
        public sbyte* end;

        public lua_State* L;

        [NativeTypeName("struct TString *")]
        public TString* storage;

        [NativeTypeName("char[512]")]
        public fixed sbyte buffer[512];

        public partial struct TString
        {
        }
    }

    public static unsafe partial class Luau
    {
        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* luau_compile([NativeTypeName("const char *")] sbyte* source, [NativeTypeName("size_t")] nuint size, lua_CompileOptions* options, [NativeTypeName("size_t *")] nuint* outsize);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern lua_State* lua_newstate([NativeTypeName("lua_Alloc")] delegate* unmanaged[Cdecl]<void*, void*, nuint, nuint, void*> f, void* ud);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_close(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern lua_State* lua_newthread(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern lua_State* lua_mainthread(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_resetthread(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_isthreadreset(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_absindex(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_gettop(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_settop(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushvalue(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_remove(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_insert(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_replace(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_checkstack(lua_State* L, int sz);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_rawcheckstack(lua_State* L, int sz);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_xmove(lua_State* from, lua_State* to, int n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_xpush(lua_State* from, lua_State* to, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_isnumber(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_isstring(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_iscfunction(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_isLfunction(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_isuserdata(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_type(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lua_typename(lua_State* L, int tp);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_equal(lua_State* L, int idx1, int idx2);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_rawequal(lua_State* L, int idx1, int idx2);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_lessthan(lua_State* L, int idx1, int idx2);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern double lua_tonumberx(lua_State* L, int idx, int* isnum);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_tointegerx(lua_State* L, int idx, int* isnum);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint lua_tounsignedx(lua_State* L, int idx, int* isnum);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const float *")]
        public static extern float* lua_tovector(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_toboolean(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lua_tolstring(lua_State* L, int idx, [NativeTypeName("size_t *")] nuint* len);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lua_tostringatom(lua_State* L, int idx, int* atom);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lua_namecallatom(lua_State* L, int* atom);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_objlen(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lua_CFunction")]
        public static extern delegate* unmanaged[Cdecl]<lua_State*, int> lua_tocfunction(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* lua_tolightuserdata(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* lua_touserdata(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* lua_touserdatatagged(lua_State* L, int idx, int tag);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_userdatatag(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern lua_State* lua_tothread(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const void *")]
        public static extern void* lua_topointer(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushnil(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushnumber(lua_State* L, double n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushinteger(lua_State* L, int n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushunsigned(lua_State* L, [NativeTypeName("unsigned int")] uint n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushvector(lua_State* L, float x, float y, float z);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushlstring(lua_State* L, [NativeTypeName("const char *")] sbyte* s, [NativeTypeName("size_t")] nuint l);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushstring(lua_State* L, [NativeTypeName("const char *")] sbyte* s);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lua_pushvfstring(lua_State* L, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* argp);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lua_pushfstringL(lua_State* L, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushcclosurek(lua_State* L, [NativeTypeName("lua_CFunction")] delegate* unmanaged[Cdecl]<lua_State*, int> fn, [NativeTypeName("const char *")] sbyte* debugname, int nup, [NativeTypeName("lua_Continuation")] delegate* unmanaged[Cdecl]<lua_State*, int, int> cont);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushboolean(lua_State* L, int b);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_pushthread(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushlightuserdata(lua_State* L, void* p);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* lua_newuserdatatagged(lua_State* L, [NativeTypeName("size_t")] nuint sz, int tag);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* lua_newuserdatadtor(lua_State* L, [NativeTypeName("size_t")] nuint sz, [NativeTypeName("void (*)(void *)")] delegate* unmanaged[Cdecl]<void*, void> dtor);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_gettable(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_getfield(lua_State* L, int idx, [NativeTypeName("const char *")] sbyte* k);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_rawgetfield(lua_State* L, int idx, [NativeTypeName("const char *")] sbyte* k);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_rawget(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_rawgeti(lua_State* L, int idx, int n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_createtable(lua_State* L, int narr, int nrec);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_setreadonly(lua_State* L, int idx, int enabled);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_getreadonly(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_setsafeenv(lua_State* L, int idx, int enabled);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_getmetatable(lua_State* L, int objindex);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_getfenv(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_settable(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_setfield(lua_State* L, int idx, [NativeTypeName("const char *")] sbyte* k);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_rawsetfield(lua_State* L, int idx, [NativeTypeName("const char *")] sbyte* k);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_rawset(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_rawseti(lua_State* L, int idx, int n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_setmetatable(lua_State* L, int objindex);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_setfenv(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luau_load(lua_State* L, [NativeTypeName("const char *")] sbyte* chunkname, [NativeTypeName("const char *")] sbyte* data, [NativeTypeName("size_t")] nuint size, int env);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_call(lua_State* L, int nargs, int nresults);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_pcall(lua_State* L, int nargs, int nresults, int errfunc);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_yield(lua_State* L, int nresults);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_break(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_resume(lua_State* L, lua_State* from, int narg);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_resumeerror(lua_State* L, lua_State* from);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_status(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_isyieldable(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* lua_getthreaddata(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_setthreaddata(lua_State* L, void* data);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_costatus(lua_State* L, lua_State* co);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_gc(lua_State* L, int what, int data);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_setmemcat(lua_State* L, int category);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("size_t")]
        public static extern nuint lua_totalbytes(lua_State* L, int category);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_error(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_next(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_rawiter(lua_State* L, int idx, int iter);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_concat(lua_State* L, int n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("uintptr_t")]
        public static extern nuint lua_encodepointer(lua_State* L, [NativeTypeName("uintptr_t")] nuint p);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern double lua_clock();

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_setuserdatatag(lua_State* L, int idx, int tag);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_setuserdatadtor(lua_State* L, int tag, [NativeTypeName("lua_Destructor")] delegate* unmanaged[Cdecl]<lua_State*, void*, void> dtor);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lua_Destructor")]
        public static extern delegate* unmanaged[Cdecl]<lua_State*, void*, void> lua_getuserdatadtor(lua_State* L, int tag);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_clonefunction(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_cleartable(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lua_Alloc")]
        public static extern delegate* unmanaged[Cdecl]<void*, void*, nuint, nuint, void*> lua_getallocf(lua_State* L, void** ud);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_ref(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_unref(lua_State* L, int @ref);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_stackdepth(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_getinfo(lua_State* L, int level, [NativeTypeName("const char *")] sbyte* what, lua_Debug* ar);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_getargument(lua_State* L, int level, int n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lua_getlocal(lua_State* L, int level, int n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lua_setlocal(lua_State* L, int level, int n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lua_getupvalue(lua_State* L, int funcindex, int n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lua_setupvalue(lua_State* L, int funcindex, int n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_singlestep(lua_State* L, int enabled);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_breakpoint(lua_State* L, int funcindex, int line, int enabled);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_getcoverage(lua_State* L, int funcindex, void* context, [NativeTypeName("lua_Coverage")] delegate* unmanaged[Cdecl]<void*, sbyte*, int, int, int*, nuint, void> callback);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lua_debugtrace(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern lua_Callbacks* lua_callbacks(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_register(lua_State* L, [NativeTypeName("const char *")] sbyte* libname, [NativeTypeName("const luaL_Reg *")] luaL_Reg* l);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_getmetafield(lua_State* L, int obj, [NativeTypeName("const char *")] sbyte* e);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_callmeta(lua_State* L, int obj, [NativeTypeName("const char *")] sbyte* e);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_typeerrorL(lua_State* L, int narg, [NativeTypeName("const char *")] sbyte* tname);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_argerrorL(lua_State* L, int narg, [NativeTypeName("const char *")] sbyte* extramsg);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* luaL_checklstring(lua_State* L, int numArg, [NativeTypeName("size_t *")] nuint* l);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* luaL_optlstring(lua_State* L, int numArg, [NativeTypeName("const char *")] sbyte* def, [NativeTypeName("size_t *")] nuint* l);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern double luaL_checknumber(lua_State* L, int numArg);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern double luaL_optnumber(lua_State* L, int nArg, double def);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_checkboolean(lua_State* L, int narg);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_optboolean(lua_State* L, int narg, int def);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_checkinteger(lua_State* L, int numArg);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_optinteger(lua_State* L, int nArg, int def);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint luaL_checkunsigned(lua_State* L, int numArg);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint luaL_optunsigned(lua_State* L, int numArg, [NativeTypeName("unsigned int")] uint def);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const float *")]
        public static extern float* luaL_checkvector(lua_State* L, int narg);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const float *")]
        public static extern float* luaL_optvector(lua_State* L, int narg, [NativeTypeName("const float *")] float* def);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_checkstack(lua_State* L, int sz, [NativeTypeName("const char *")] sbyte* msg);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_checktype(lua_State* L, int narg, int t);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_checkany(lua_State* L, int narg);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_newmetatable(lua_State* L, [NativeTypeName("const char *")] sbyte* tname);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* luaL_checkudata(lua_State* L, int ud, [NativeTypeName("const char *")] sbyte* tname);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_where(lua_State* L, int lvl);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_errorL(lua_State* L, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_checkoption(lua_State* L, int narg, [NativeTypeName("const char *")] sbyte* def, [NativeTypeName("const char *const[]")] sbyte** lst);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* luaL_tolstring(lua_State* L, int idx, [NativeTypeName("size_t *")] nuint* len);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern lua_State* luaL_newstate();

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* luaL_findtable(lua_State* L, int idx, [NativeTypeName("const char *")] sbyte* fname, int szhint);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* luaL_typename(lua_State* L, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_buffinit(lua_State* L, luaL_Buffer* B);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* luaL_buffinitsize(lua_State* L, luaL_Buffer* B, [NativeTypeName("size_t")] nuint size);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* luaL_extendbuffer(luaL_Buffer* B, [NativeTypeName("size_t")] nuint additionalsize, int boxloc);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_reservebuffer(luaL_Buffer* B, [NativeTypeName("size_t")] nuint size, int boxloc);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_addlstring(luaL_Buffer* B, [NativeTypeName("const char *")] sbyte* s, [NativeTypeName("size_t")] nuint l, int boxloc);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_addvalue(luaL_Buffer* B);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_addvalueany(luaL_Buffer* B, int idx);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_pushresult(luaL_Buffer* B);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_pushresultsize(luaL_Buffer* B, [NativeTypeName("size_t")] nuint size);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_base(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_coroutine(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_table(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_os(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_string(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_bit32(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_utf8(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_math(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_debug(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_openlibs(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_sandbox(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_sandboxthread(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern double macros_lua_tonumber(lua_State* L, int i);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int macros_lua_tointeger(lua_State* L, int i);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint macros_lua_tounsigned(lua_State* L, int i);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void macros_lua_pop(lua_State* L, int n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void macros_lua_newtable(lua_State* L);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* macros_lua_newuserdata(lua_State* L, [NativeTypeName("size_t")] nuint s);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int macros_lua_strlen(lua_State* L, int i);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int macros_lua_isfunction(lua_State* L, int n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int macros_lua_istable(lua_State* L, int n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int macros_lua_islightuserdata(lua_State* L, int n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int macros_lua_isnil(lua_State* L, int n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int macros_lua_isboolean(lua_State* L, int n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int macros_lua_isvector(lua_State* L, int n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int macros_lua_isthread(lua_State* L, int n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int macros_lua_isnone(lua_State* L, int n);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int macros_lua_isnoneornil(lua_State* L, int n);

        // [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        // public static extern void macros_lua_pushliterals(lua_State* L, [NativeTypeName("const char *")] sbyte* s);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void macros_lua_pushcfunction(lua_State* L, [NativeTypeName("lua_CFunction")] delegate* unmanaged[Cdecl]<lua_State*, int> fn, [NativeTypeName("const char *")] sbyte* debugname);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void macros_lua_pushcclosure(lua_State* L, [NativeTypeName("lua_CFunction")] delegate* unmanaged[Cdecl]<lua_State*, int> fn, [NativeTypeName("const char *")] sbyte* debugname, int nup);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void macros_lua_setglobal(lua_State* L, [NativeTypeName("const char *")] sbyte* s);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        public static extern int macros_lua_getglobal(lua_State* L, [NativeTypeName("const char *")] sbyte* s);

        [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* macros_lua_tostring(lua_State* L, int i);

        // [DllImport("lib/luau", CallingConvention = CallingConvention.Cdecl)]
        // [return: NativeTypeName("const char *")]
        // public static extern sbyte* macros_lua_pushfstring(lua_State* L, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [NativeTypeName("#define LUA_MULTRET (-1)")]
        public const int LUA_MULTRET = (-1);

        [NativeTypeName("#define LUA_REGISTRYINDEX (-LUAI_MAXCSTACK - 2000)")]
        public const int LUA_REGISTRYINDEX = (-8000 - 2000);

        [NativeTypeName("#define LUA_ENVIRONINDEX (-LUAI_MAXCSTACK - 2001)")]
        public const int LUA_ENVIRONINDEX = (-8000 - 2001);

        [NativeTypeName("#define LUA_GLOBALSINDEX (-LUAI_MAXCSTACK - 2002)")]
        public const int LUA_GLOBALSINDEX = (-8000 - 2002);

        [NativeTypeName("#define LUA_TNONE (-1)")]
        public const int LUA_TNONE = (-1);

        [NativeTypeName("#define LUA_NOREF -1")]
        public const int LUA_NOREF = -1;

        [NativeTypeName("#define LUA_REFNIL 0")]
        public const int LUA_REFNIL = 0;

        [NativeTypeName("#define LUA_COLIBNAME \"coroutine\"")]
        public static ReadOnlySpan<byte> LUA_COLIBNAME => "coroutine"u8;

        [NativeTypeName("#define LUA_TABLIBNAME \"table\"")]
        public static ReadOnlySpan<byte> LUA_TABLIBNAME => "table"u8;

        [NativeTypeName("#define LUA_OSLIBNAME \"os\"")]
        public static ReadOnlySpan<byte> LUA_OSLIBNAME => "os"u8;

        [NativeTypeName("#define LUA_STRLIBNAME \"string\"")]
        public static ReadOnlySpan<byte> LUA_STRLIBNAME => "string"u8;

        [NativeTypeName("#define LUA_BITLIBNAME \"bit32\"")]
        public static ReadOnlySpan<byte> LUA_BITLIBNAME => "bit32"u8;

        [NativeTypeName("#define LUA_UTF8LIBNAME \"utf8\"")]
        public static ReadOnlySpan<byte> LUA_UTF8LIBNAME => "utf8"u8;

        [NativeTypeName("#define LUA_MATHLIBNAME \"math\"")]
        public static ReadOnlySpan<byte> LUA_MATHLIBNAME => "math"u8;

        [NativeTypeName("#define LUA_DBLIBNAME \"debug\"")]
        public static ReadOnlySpan<byte> LUA_DBLIBNAME => "debug"u8;
    }
