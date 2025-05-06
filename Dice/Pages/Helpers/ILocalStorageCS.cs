namespace Dice.Pages.Helpers;

public interface ILocalStorageCS
{
    Task SetItemAsync<T>(string key, T value);
    Task<T?> GetItemAsync<T>(string key);
}