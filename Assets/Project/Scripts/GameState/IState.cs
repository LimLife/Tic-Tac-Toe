public interface IState
{
    IMediator Mediator { get; }
    void GetMediator(IMediator mediator);
    void Notyfi(GameState state);
}
