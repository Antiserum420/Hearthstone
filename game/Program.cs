namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var game = new Game())
            {
                game.Initialize();

                game.PushState(PlayState.Instance);

                while (game.Running)
                {
                    game.HandleEvents();

                    if (!game.Paused)
                    {
                        game.Update();

                        game.Draw();
                    }
                }
            } 
        }
    }
}
