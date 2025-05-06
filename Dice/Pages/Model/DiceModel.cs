namespace Dice.Model;

public class DiceModel
{
    public int Id { get; set; }
    public int Value { get; set; }
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    public TimeSpan Time { get; set; } = DateTime.UtcNow.TimeOfDay;
}