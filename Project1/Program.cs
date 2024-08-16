
internal class Program
{
    private static void Main(string[] args)
    {
        using var game = new Project1.Game1();
        game.Window.AllowUserResizing=true;
        game.Run();
    }
}