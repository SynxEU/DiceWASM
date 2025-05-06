using System.Text.Json;
using Microsoft.JSInterop;

namespace Dice.Pages.Helpers;

public class SessionStorage
{
    private readonly IJSRuntime jsRuntime;
    public SessionStorage(IJSRuntime jsRuntime)
    {
        this.jsRuntime = jsRuntime;
    }

    public async Task SetItemAsync<T>(string key, T value)
    {
        var json = JsonSerializer.Serialize(value);
        await jsRuntime.InvokeVoidAsync("sessionStorageHelper.set", key, json);
    }

    public async Task<T?> GetItemAsync<T>(string key)
    {
        var json = await jsRuntime.InvokeAsync<string>("sessionStorageHelper.get", key);
        if (string.IsNullOrWhiteSpace(json)) return default;
        return JsonSerializer.Deserialize<T>(json);
    }
}
