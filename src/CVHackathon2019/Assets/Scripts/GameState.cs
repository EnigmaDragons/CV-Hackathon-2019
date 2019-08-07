
namespace Assets.Scripts
{
    public sealed class GameState
    {
        public bool IsGameOver { get; set; } = false;
        
        public static GameState Current = new GameState();
        private GameState() {}
    }
}
