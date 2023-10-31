#pragma once

#include "../../luau/VM/include/lua.h"

// Can be used to reconfigure visibility/exports for public APIs
#ifndef LUACODE_API
#define LUACODE_API extern
#endif

LUACODE_API double macros_lua_tonumber(lua_State* L, int i);
LUACODE_API int macros_lua_tointeger(lua_State* L, int i);
LUACODE_API unsigned macros_lua_tounsigned(lua_State* L, int i);

LUACODE_API void macros_lua_pop(lua_State* L, int n);

LUACODE_API void macros_lua_newtable(lua_State* L);
LUACODE_API void* macros_lua_newuserdata(lua_State* L, size_t s);

LUACODE_API int macros_lua_strlen(lua_State* L, int i);

LUACODE_API int macros_lua_isfunction(lua_State* L, int n);
LUACODE_API int macros_lua_istable(lua_State* L, int n);
LUACODE_API int macros_lua_islightuserdata(lua_State* L, int n);
LUACODE_API int macros_lua_isnil(lua_State* L, int n);
LUACODE_API int macros_lua_isboolean(lua_State* L, int n);
LUACODE_API int macros_lua_isvector(lua_State* L, int n);
LUACODE_API int macros_lua_isthread(lua_State* L, int n);
LUACODE_API int macros_lua_isnone(lua_State* L, int n);
LUACODE_API int macros_lua_isnoneornil(lua_State* L, int n);

// LUACODE_API void macros_lua_pushliterals(lua_State* L, const char* s); not working idk
LUACODE_API void macros_lua_pushcfunction(lua_State* L, lua_CFunction fn, const char* debugname);
LUACODE_API void macros_lua_pushcclosure(lua_State* L, lua_CFunction fn, const char* debugname, int nup);

LUACODE_API void macros_lua_setglobal(lua_State* L, const char* s);
LUACODE_API int macros_lua_getglobal(lua_State* L, const char* s);

LUACODE_API const char* macros_lua_tostring(lua_State* L, int i);
// LUACODE_API LUA_PRINTF_ATTR(2, 3) const char* macros_lua_pushfstring(lua_State* L, const char* fmt, ...); not working idk





























//trying to implement this file with the macros themselves instead of rebound functions the macros call
//not really working
// LUACODE_API double macros_lua_tonumber(lua_State* L, int i) {return lua_tonumber(L,i);}
// LUACODE_API int macros_lua_tointeger(lua_State* L, int i) {return lua_tointeger(L, i);}
// LUACODE_API unsigned macros_lua_tounsigned(lua_State* L, int i) {return lua_tounsigned(L, i);}

// LUACODE_API void macros_lua_pop(lua_State* L, int n) {lua_pop(L,n);}

// LUACODE_API void macros_lua_newtable(lua_State* L) {lua_newtable(L);}
// LUACODE_API void* macros_lua_newuserdata(lua_State* L, size_t s) {return lua_newuserdata(L,s);}

// LUACODE_API int macros_lua_strlen(lua_State* L, int i) {return lua_strlen(L,i);}

// LUACODE_API int macros_lua_isfunction(lua_State* L, int n) {return lua_isfunction(L,n);}
// LUACODE_API int macros_lua_istable(lua_State* L, int n) {return lua_istable(L,n);}
// LUACODE_API int macros_lua_islightuserdata(lua_State* L, int n) {return lua_islightuserdata(L,n);}
// LUACODE_API int macros_lua_isnil(lua_State* L, int n) {return lua_isnil(L,n);}
// LUACODE_API int macros_lua_isboolean(lua_State* L, int n) {return lua_isboolean(L,n);}
// LUACODE_API int macros_lua_isvector(lua_State* L, int n) {return lua_isvector(L,n);}
// LUACODE_API int macros_lua_isthread(lua_State* L, int n) {return lua_isthread(L,n);}
// LUACODE_API int macros_lua_isnone(lua_State* L, int n) {return lua_isnone(L,n);}
// LUACODE_API int macros_lua_isnoneornil(lua_State* L, int n) {return lua_isnoneornil(L,n);}

// LUACODE_API void macros_lua_pushliteral(lua_State* L, const char* s) { lua_pushliteral(L,s); }
// LUACODE_API void macros_lua_pushcfunction(lua_State* L, lua_CFunction fn, const char* debugname) {lua_pushcfunction(L,fn,debugname);}
// LUACODE_API void macros_lua_pushcclosure(lua_State* L, lua_CFunction fn, const char* debugname, int nup) {lua_pushcfunction(L,fn,debugname,nup);}

// LUACODE_API void macros_lua_setglobal(lua_State* L, const char* s) {lua_setglobal(L, s);}
// LUACODE_API int macros_lua_getglobal(lua_State* L, const char* s) {return lua_getfield(L,s);}

// LUACODE_API const char* macros_lua_tostring(lua_State* L, int i) {return lua_tostring(L, i);}

// LUACODE_API LUA_PRINTF_ATTR(2, 3) const char* macros_lua_pushfstring(lua_State* L, const char* fmt, ...) {return lua_pushfstring(L, fmt, ...);}