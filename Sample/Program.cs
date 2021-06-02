using System;
using System.Collections.Generic;
using CSharpOption;


// The simple use case
const string testValue = "6";
Console.WriteLine(
    Parse(testValue) switch
    {
        Success<int>(> 6) => $"Value is valid and greater than 6",
        Success<int> => "Value is valid",
        var Failure => "Invalid value"
    }
);


// The use case when nullable value is allowed
var dict = new Dictionary<string, string?> { { "key", null } };
Console.WriteLine(
    dict.Get("key") switch
    {
        Success<string?>(null) => "Got a valid null",
        Success<string?>(var notNull) => $"Got a valid notnull: {notNull}",
        _ => "Got invalid"
    }
);




static Success<int>? Parse(string? s)
    => int.TryParse(s, out var res) ? new(res) : null;

public static class Extensions
{
    public static Success<TValue>? Get<TKey, TValue>(this Dictionary<TKey, TValue> dic, TKey key)
        => dic.TryGetValue(key, out var res) ? new(res) : null;
}