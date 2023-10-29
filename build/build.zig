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
    
    lib.addCSourceFile(.{
        .file = .{ .path = "luau.c" },
        .flags = &[_][]const u8{},
    });
    b.lib_dir = "../Luau.NET.Test/lib";
    b.installArtifact(lib);
}