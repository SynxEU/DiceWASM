namespace Dice.Pages.Helpers;

public interface ISessionStorage
{
    Task<T?> GetItemAsync<T>(string key);
    Task SetItemAsync<T>(string key, T value);
}