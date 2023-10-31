#if defined(_WIN32)
#define LUACODE_API extern "C" __declspec(dllexport)
#define LUA_API extern "C" __declspec(dllexport)
#else
#define LUACODE_API extern "C"
#define LUA_API extern "C"
#endif

#include "../luau/Ast/include/Luau/Ast.h"
#include "../luau/Ast/include/Luau/Confusables.h"
#include "../luau/Ast/include/Luau/Lexer.h"
#include "../luau/Ast/include/Luau/Location.h"
#include "../luau/Ast/include/Luau/ParseOptions.h"
#include "../luau/Ast/include/Luau/Parser.h"
#include "../luau/Ast/include/Luau/ParseResult.h"
#include "../luau/Ast/include/Luau/StringUtils.h"
#include "../luau/Ast/include/Luau/TimeTrace.h"
#include "../luau/Compiler/src/BuiltinFolding.h"
#include "../luau/Compiler/src/Builtins.h"
#include "../luau/Compiler/src/ConstantFolding.h"
#include "../luau/Compiler/src/CostModel.h"
#include "../luau/Compiler/src/TableShape.h"
#include "../luau/Compiler/src/Types.h"
#include "../luau/Compiler/src/ValueTracking.h"
#include "../luau/VM/src/lapi.h"
#include "../luau/VM/src/lbuiltins.h"
#include "../luau/VM/src/lbytecode.h"
#include "../luau/VM/src/lcommon.h"
#include "../luau/VM/src/ldebug.h"
#include "../luau/VM/src/ldo.h"
#include "../luau/VM/src/lfunc.h"
#include "../luau/VM/src/lgc.h"
#include "../luau/VM/src/lmem.h"
#include "../luau/VM/src/lnumutils.h"
#include "../luau/VM/src/lobject.h"
#include "../luau/VM/src/lstate.h"
#include "../luau/VM/src/lstring.h"
#include "../luau/VM/src/ltable.h"
#include "../luau/VM/src/ltm.h"
#include "../luau/VM/src/ludata.h"
#include "../luau/VM/src/lvm.h"




//---------------------
// #include "../luau/Common/include/Luau/BytecodeUtils.h"
// #include "../luau/Common/include/Luau/Bytecode.h"
// #include "../luau/Common/include/Luau/Common.h"
// #include "../luau/Common/include/Luau/DenseHash.h"
// #include "../luau/Common/include/Luau/ExperimentalFlags.h"

// #include "../luau/Ast/include/Luau/Ast.h"
// #include "../luau/Ast/include/Luau/Confusables.h"
// #include "../luau/Ast/include/Luau/Lexer.h"
// #include "../luau/Ast/include/Luau/Location.h"
// #include "../luau/Ast/include/Luau/ParseOptions.h"
// #include "../luau/Ast/include/Luau/Parser.h"
// #include "../luau/Ast/include/Luau/ParseResult.h"
// #include "../luau/Ast/include/Luau/StringUtils.h"
// #include "../luau/Ast/include/Luau/TimeTrace.h"





// #include "../luau/Compiler/include/luacode.h"
// #include "../luau/Compiler/include/Luau/Compiler.h"
// #include "../luau/Compiler/include/BytecodeBuilder.h"