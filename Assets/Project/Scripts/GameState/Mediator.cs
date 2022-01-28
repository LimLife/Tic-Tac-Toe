public class Mediator : IMediator
{
    private IState _game { get; set; }

    private IState _ui { get; set; }

    public Mediator(IState game, IState ui)
    {
        _game = game;
        _ui = ui;
    }
    public void Send(IState data, GameState state)
    {
        if (_ui == data)
        {
            _game.Notyfi(state);
        }
        else

        {
            _ui.Notyfi(state);
        }
    }
}
