using Microsoft.JSInterop;
using System.Text.Json;
using Dice.Pages.Helpers;

public class LocalStorageCs : ILocalStorageCS
{
    private readonly IJSRuntime jsRuntime;
    public LocalStorageCs(IJSRuntime jsRuntime)
    {
        this.jsRuntime = jsRuntime;
    }

    public async Task SetItemAsync<T>(string key, T value)
    {
        var json = JsonSerializer.Serialize(value);
        await jsRuntime.InvokeVoidAsync("localStorageHelper.set", key, json);
    }

    public async Task<T?> GetItemAsync<T>(string key)
    {
        var json = await jsRuntime.InvokeAsync<string>("localStorageHelper.get", key);
        if (string.IsNullOrWhiteSpace(json)) return default;
        return JsonSerializer.Deserialize<T>(json);
    }
}