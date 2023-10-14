// See https://aka.ms/new-console-template for more information
var script = @"
function ispositive(x)
    return x > 0
end

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
    nuint outsize = Int32.MaxValue;
    fixed (byte* ptr = scriptBytes)
    {
        var comp_result = Luau.Luau.luau_compile(
            (sbyte*)ptr,
            (nuint)(scriptBytes.Length * sizeof(byte)), 
            &compOpts,
            &outsize
            );
    }
}
