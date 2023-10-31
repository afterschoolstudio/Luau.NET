LUA_API double lua_tonumber(lua_State* L, int i) {return lua_tonumberx(L, i, NULL)}
LUA_API int lua_tointeger(lua_State* L, int i) {return lua_tointegerx(L, i, NULL)}
LUA_API unsigned lua_tounsigned(lua_State* L, int i) {return lua_tounsignedx(L, i, NULL)}

LUA_API void lua_pop(lua_State* L, int n) {lua_settop(L, -(n)-1)}

LUA_API void lua_newtable(lua_State* L) {lua_createtable(L, 0, 0)}
LUA_API void* lua_newuserdata(lua_State* L, size_t s) {return lua_newuserdatatagged(L, s, 0)}

LUA_API int lua_strlen(lua_State* L, int i) {return lua_objlen(L, (i))}
//finish these below this line
LUA_API int lua_isfunction(lua_State* L, n) (lua_type(L, (n)) == LUA_TFUNCTION)
LUA_API int lua_istable(lua_State* L, n) (lua_type(L, (n)) == LUA_TTABLE)
LUA_API int lua_islightuserdata(lua_State* L, n) (lua_type(L, (n)) == LUA_TLIGHTUSERDATA)
LUA_API int lua_isnil(lua_State* L, n) (lua_type(L, (n)) == LUA_TNIL)
LUA_API int lua_isboolean(lua_State* L, n) (lua_type(L, (n)) == LUA_TBOOLEAN)
LUA_API int lua_isvector(lua_State* L, n) (lua_type(L, (n)) == LUA_TVECTOR)
LUA_API int lua_isthread(lua_State* L, n) (lua_type(L, (n)) == LUA_TTHREAD)
LUA_API int lua_isnone(lua_State* L, n) (lua_type(L, (n)) == LUA_TNONE)
LUA_API int lua_isnoneornil(lua_State* L, n) (lua_type(L, (n)) <= LUA_TNIL)

LUA_API int lua_pushliteral(lua_State* L, s) lua_pushlstring(L, "" s, (sizeof(s) / sizeof(char)) - 1)
LUA_API int lua_pushcfunction(lua_State* L, fn, debugname) lua_pushcclosurek(L, fn, debugname, 0, NULL)
LUA_API int lua_pushcclosure(lua_State* L, fn, debugname, nup) lua_pushcclosurek(L, fn, debugname, nup, NULL)

LUA_API int lua_setglobal(lua_State* L, s) lua_setfield(L, LUA_GLOBALSINDEX, (s))
LUA_API int lua_getglobal(lua_State* L, s) lua_getfield(L, LUA_GLOBALSINDEX, (s))

LUA_API int lua_tostring(lua_State* L, i) lua_tolstring(L, (i), NULL)

LUA_API int lua_pushfstring(lua_State* L, fmt, ...) lua_pushfstringL(L, fmt, ##__VA_ARGS__)