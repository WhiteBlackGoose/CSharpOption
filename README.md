> **WARNING**: Deprecated.
> 
> Use [Honk#](https://github.com/WhiteBlackGoose/HonkSharp) instead.

## Option for C\#

Imagine using the `TryPattern` in 2021... compare this old-fashioned ugly bruuh
```cs
if (!...TryDo(..., out var res))
    return "Invalid";
if (res.Property > 0 and res.Property < 6)
    return res.ToString();
else
    return "Quack";
```
to this nice cool awesome
```cs
return Do(...) switch
{
    Success<YourType>({ Property: > 0 and < 6 } res) => res.ToString(),
    Success<YourType> => "Quack",
    _ => "Invalid"
};
```

### TryParse

With
```cs
static Success<int>? Parse(string? s)
    => int.TryParse(s, out var res) ? new(res) : null;
```
You now can write
```cs
Console.WriteLine(
    Parse(Console.WriteLine()) switch
    {
        Success<int>(> 6) => $"Value is valid and greater than 6",
        Success<int> => "Value is valid",
        var Failure => "Invalid value"
    }
);
```

### TryGet

Also, you can now use `null` as a valid type. With
```cs
public static class Extensions
{
    public static Success<TValue>? Get<TKey, TValue>(this Dictionary<TKey, TValue> dic, TKey key)
        => dic.TryGetValue(key, out var res) ? new(res) : null;
}
```
You can now write
```cs
var dict = new Dictionary<string, string?> { { "key", null } };
Console.WriteLine(
    dict.Get("key") switch
    {
        Success<string?>(null) => "Got a valid null",
        Success<string?>(var notNull) => $"Got a valid notnull: {notNull}",
        _ => "Got invalid"
    }
);
```
