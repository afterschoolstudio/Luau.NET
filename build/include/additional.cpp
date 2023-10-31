#include "additional.h"
#include "../../luau/VM/include/lua.h"
#include <luacode.h>
#include <Luau/Compiler.h>
#include <stdarg.h>
#include <stddef.h>
#include <stdint.h>

double macros_lua_tonumber(lua_State* L, int i) {return lua_tonumberx(L, i, NULL);}
int macros_lua_tointeger(lua_State* L, int i) {return lua_tointegerx(L, i, NULL);}
unsigned macros_lua_tounsigned(lua_State* L, int i) {return lua_tounsignedx(L, i, NULL);}

void macros_lua_pop(lua_State* L, int n) {lua_settop(L, -(n)-1);}

void macros_lua_newtable(lua_State* L) {lua_createtable(L, 0, 0);}
void* macros_lua_newuserdata(lua_State* L, size_t s) {return lua_newuserdatatagged(L, s, 0);}

int macros_lua_strlen(lua_State* L, int i) {return lua_objlen(L, (i));}

int macros_lua_isfunction(lua_State* L, int n) {return lua_type(L, (n)) == LUA_TFUNCTION;}
int macros_lua_istable(lua_State* L, int n) {return lua_type(L, (n)) == LUA_TTABLE;}
int macros_lua_islightuserdata(lua_State* L, int n) {return lua_type(L, (n)) == LUA_TLIGHTUSERDATA;}
int macros_lua_isnil(lua_State* L, int n) {return lua_type(L, (n)) == LUA_TNIL;}
int macros_lua_isboolean(lua_State* L, int n) {return lua_type(L, (n)) == LUA_TBOOLEAN;}
int macros_lua_isvector(lua_State* L, int n) {return lua_type(L, (n)) == LUA_TVECTOR;}
int macros_lua_isthread(lua_State* L, int n) {return lua_type(L, (n)) == LUA_TTHREAD;}
int macros_lua_isnone(lua_State* L, int n) {return lua_type(L, (n)) == LUA_TNONE;}
int macros_lua_isnoneornil(lua_State* L, int n) {return lua_type(L, (n)) <= LUA_TNIL;}

// void macros_lua_pushliterals(lua_State* L, const char* s) {lua_pushlstring(L, "" s, (sizeof(s) / sizeof(char)) - 1);}
void macros_lua_pushcfunction(lua_State* L, lua_CFunction fn, const char* debugname) {lua_pushcclosurek(L, fn, debugname, 0, NULL);}
void macros_lua_pushcclosure(lua_State* L, lua_CFunction fn, const char* debugname, int nup) {lua_pushcclosurek(L, fn, debugname, nup, NULL);}

void macros_lua_setglobal(lua_State* L, const char* s) {lua_setfield(L, LUA_GLOBALSINDEX, (s));}
int macros_lua_getglobal(lua_State* L, const char* s) {return lua_getfield(L, LUA_GLOBALSINDEX, (s));}

const char* macros_lua_tostring(lua_State* L, int i) {return lua_tolstring(L, (i), NULL);}
// LUA_PRINTF_ATTR(2, 3) const char* macros_lua_pushfstring(lua_State* L, const char* fmt, ...) {return lua_pushfstringL(L, fmt, ##__VA_ARGS__);}