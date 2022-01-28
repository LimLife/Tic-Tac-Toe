using UnityEngine;

public class UiHandler : MonoBehaviour, IInitialize, IState, ISubscribe, IUnSubscribe
{
    [SerializeField] private ButtonHandler _buttonHandler;

    public IMediator Mediator { get; private set; }
    public void Initialize()
    {
        _buttonHandler.Initialize();
        Subscribe();
    }
    public void GetMediator(IMediator mediator)
    {
        Mediator = mediator;
    }

    public void Notyfi(GameState state)
    {
        switch (state)
        {
            case GameState.Draw:

                _buttonHandler.ShowMenu();
                break;
            case GameState.Win:

                _buttonHandler.ShowMenu();
                break;
        }
    }


    public void Subscribe()
    {
        _buttonHandler.OnChangeStste += ChangeState;
    }

    private void ChangeState(GameState state)
    {
        Mediator.Send(this, state);
        switch (state)
        {
            case GameState.EndGame:
                _buttonHandler.UnSubscribe();
                UnSubscribe();
                break;
        }
    }

    public void UnSubscribe()
    {
        _buttonHandler.OnChangeStste -= ChangeState;
    }
}
