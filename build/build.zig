const std = @import("std");
const builtin = @import("builtin");
const Builder = std.build.Builder;
const LibExeObjStep = std.build.LibExeObjStep;
const CrossTarget = std.zig.CrossTarget;
const Mode = std.builtin.Mode;

// Although this function looks imperative, note that its job is to
// declaratively construct a build graph that will be executed by an external
// runner.
pub fn build(b: *std.Build) void {
    const target = b.standardTargetOptions(.{});
    const lib = b.addSharedLibrary(.{
        .name = "luau",
        .target = target,
        // Standard optimization options allow the person running `zig build` to select
        // between Debug, ReleaseSafe, ReleaseFast, and ReleaseSmall. Here we do not
        // set a preferred release mode, allowing the user to decide how to optimize.
        .optimize = b.standardOptimizeOption(.{})
    });
    lib.linkLibC();
    lib.linkLibCpp();
    
    // lib.addCSourceFiles(&[_][]const u8{
    //     "defines.cpp"
    // },&[_][]const u8{});
    var lua_api_flag = if (lib.target.isWindows()) "-DLUA_API=extern\"C\" __declspec(dllexport) " else "-DLUA_API=extern\"C\"";
    var luacode_api_flag = if (lib.target.isWindows()) "-DLUA_API=extern\"C\" __declspec(dllexport) " else "-DLUACODE_API=extern\"C\"";
    lib.addCSourceFiles(&[_][]const u8{
        // "defines.cpp"
  
        "../luau/Ast/src/Ast.cpp",
        "../luau/Ast/src/Confusables.cpp",
        "../luau/Ast/src/Lexer.cpp",
        "../luau/Ast/src/Location.cpp",
        "../luau/Ast/src/Parser.cpp",
        "../luau/Ast/src/StringUtils.cpp",
        "../luau/Ast/src/TimeTrace.cpp",

        // "../luau/CodeGen/src/AssemblyBuilderA64.cpp",
        // "../luau/CodeGen/src/AssemblyBuilderX64.cpp",
        // // "../luau/CodeGen/src/BitUtils.h",
        // // "../luau/CodeGen/src/ByteUtils.h",
        // "../luau/CodeGen/src/CodeAllocator.cpp",
        // "../luau/CodeGen/src/CodeBlockUnwind.cpp",
        // "../luau/CodeGen/src/CodeGen.cpp",
        // "../luau/CodeGen/src/CodeGenA64.cpp",
        // // "../luau/CodeGen/src/CodeGenA64.h",
        // "../luau/CodeGen/src/CodeGenAssembly.cpp",
        // // "../luau/CodeGen/src/CodeGenLower.h",
        // "../luau/CodeGen/src/CodeGenUtils.cpp",
        // // "../luau/CodeGen/src/CodeGenUtils.h",
        // "../luau/CodeGen/src/CodeGenX64.cpp",
        // // "../luau/CodeGen/src/CodeGenX64.h",
        // "../luau/CodeGen/src/EmitBuiltinsX64.cpp",
        // // "../luau/CodeGen/src/EmitBuiltinsX64.h",
        // // "../luau/CodeGen/src/EmitCommon.h",
        // // "../luau/CodeGen/src/EmitCommonA64.h",
        // "../luau/CodeGen/src/EmitCommonX64.cpp",
        // // "../luau/CodeGen/src/EmitCommonX64.h",
        // "../luau/CodeGen/src/EmitInstructionX64.cpp",
        // // "../luau/CodeGen/src/EmitInstructionX64.h",
        // "../luau/CodeGen/src/IrAnalysis.cpp",
        // "../luau/CodeGen/src/IrBuilder.cpp",
        // "../luau/CodeGen/src/IrCallWrapperX64.cpp",
        // "../luau/CodeGen/src/IrDump.cpp",
        // "../luau/CodeGen/src/IrLoweringA64.cpp",
        // // "../luau/CodeGen/src/IrLoweringA64.h",
        // "../luau/CodeGen/src/IrLoweringX64.cpp",
        // // "../luau/CodeGen/src/IrLoweringX64.h",
        // "../luau/CodeGen/src/IrRegAllocA64.cpp",
        // // "../luau/CodeGen/src/IrRegAllocA64.h",
        // "../luau/CodeGen/src/IrRegAllocX64.cpp",
        // "../luau/CodeGen/src/IrTranslateBuiltins.cpp",
        // // "../luau/CodeGen/src/IrTranslateBuiltins.h",
        // "../luau/CodeGen/src/IrTranslation.cpp",
        // // "../luau/CodeGen/src/IrTranslation.h",
        // "../luau/CodeGen/src/IrUtils.cpp",
        // "../luau/CodeGen/src/IrValueLocationTracking.cpp",
        // // "../luau/CodeGen/src/IrValueLocationTracking.h",
        // "../luau/CodeGen/src/lcodegen.cpp",
        // "../luau/CodeGen/src/NativeState.cpp",
        // // "../luau/CodeGen/src/NativeState.h",
        // "../luau/CodeGen/src/OptimizeConstProp.cpp",
        // "../luau/CodeGen/src/OptimizeFinalX64.cpp",
        // "../luau/CodeGen/src/UnwindBuilderDwarf2.cpp",
        // "../luau/CodeGen/src/UnwindBuilderWin.cpp",

        "../luau/Compiler/src/BuiltinFolding.cpp",
        // "../luau/Compiler/src/BuiltinFolding.h",
        "../luau/Compiler/src/Builtins.cpp",
        // "../luau/Compiler/src/Builtins.h",
        "../luau/Compiler/src/BytecodeBuilder.cpp",
        "../luau/Compiler/src/Compiler.cpp",
        "../luau/Compiler/src/ConstantFolding.cpp",
        // "../luau/Compiler/src/ConstantFolding.h",
        "../luau/Compiler/src/CostModel.cpp",
        // "../luau/Compiler/src/CostModel.h",
        "../luau/Compiler/src/lcode.cpp",
        "../luau/Compiler/src/TableShape.cpp",
        // "../luau/Compiler/src/TableShape.h",
        "../luau/Compiler/src/Types.cpp",
        // "../luau/Compiler/src/Types.h",
        "../luau/Compiler/src/ValueTracking.cpp",
        // "../luau/Compiler/src/ValueTracking.h",

        "../luau/VM/src/lapi.cpp",
        // "../luau/VM/src/lapi.h",
        "../luau/VM/src/laux.cpp",
        "../luau/VM/src/lbaselib.cpp",
        "../luau/VM/src/lbitlib.cpp",
        "../luau/VM/src/lbuiltins.cpp",
        // "../luau/VM/src/lbuiltins.h",
        // "../luau/VM/src/lbytecode.h",
        // "../luau/VM/src/lcommon.h",
        "../luau/VM/src/lcorolib.cpp",
        "../luau/VM/src/ldblib.cpp",
        "../luau/VM/src/ldebug.cpp",
        // "../luau/VM/src/ldebug.h",
        "../luau/VM/src/ldo.cpp",
        // "../luau/VM/src/ldo.h",
        "../luau/VM/src/lfunc.cpp",
        // "../luau/VM/src/lfunc.h",
        "../luau/VM/src/lgc.cpp",
        // "../luau/VM/src/lgc.h",
        "../luau/VM/src/lgcdebug.cpp",
        "../luau/VM/src/linit.cpp",
        "../luau/VM/src/lmathlib.cpp",
        "../luau/VM/src/lmem.cpp",
        // "../luau/VM/src/lmem.h",
        "../luau/VM/src/lnumprint.cpp",
        // "../luau/VM/src/lnumutils.h",
        "../luau/VM/src/lobject.cpp",
        // "../luau/VM/src/lobject.h",
        "../luau/VM/src/loslib.cpp",
        "../luau/VM/src/lperf.cpp",
        "../luau/VM/src/lstate.cpp",
        // "../luau/VM/src/lstate.h",
        "../luau/VM/src/lstring.cpp",
        // "../luau/VM/src/lstring.h",
        "../luau/VM/src/lstrlib.cpp",
        "../luau/VM/src/ltable.cpp",
        // "../luau/VM/src/ltable.h",
        "../luau/VM/src/ltablib.cpp",
        "../luau/VM/src/ltm.cpp",
        // "../luau/VM/src/ltm.h",
        "../luau/VM/src/ludata.cpp",
        // "../luau/VM/src/ludata.h",
        "../luau/VM/src/lutf8lib.cpp",
        // "../luau/VM/src/lvm.h",
        "../luau/VM/src/lvmexecute.cpp",
        "../luau/VM/src/lvmload.cpp",
        "../luau/VM/src/lvmutils.cpp"
    },&[_][]const u8{
        "-DLUA_USE_LONGJMP=1",
        lua_api_flag,
        luacode_api_flag
        // "-DLUA_API=extern\"C\"",
        // "-DLUACODE_API=extern\"C\"",
    });

    // lib.addIncludePath(.{ .path = "./include" });
    lib.addIncludePath(.{ .path = "../luau/Ast/include" });
    // lib.addIncludePath(.{ .path = "../luau/CodeGen/include" });
    lib.addIncludePath(.{ .path = "../luau/Compiler/include" });
    lib.addIncludePath(.{ .path = "../luau/VM/include" });
    lib.addIncludePath(.{ .path = "../luau/VM/src" });
    lib.addIncludePath(.{ .path = "../luau/Common/include" });

    // lib.addIncludePath(.{ .path = "/Library/Developer/CommandLineTools/usr/include/c++/v1" });
    b.lib_dir = "../Luau.NET.Test/lib";
    b.installArtifact(lib);
}