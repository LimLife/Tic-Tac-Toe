using UnityEngine;

public class EnterGame :MonoBehaviour,IInitialize
{
    [SerializeField] private GameHandler _gameHandler;
    [SerializeField] private UiHandler _uiHandler;
    private IMediator _mdiator;
    private void Awake()
    {
        Initialize();
    }
    public void Initialize()
    {
        _gameHandler.Initialize();
        _uiHandler.Initialize();
        _mdiator = new Mediator(_gameHandler, _uiHandler);
        _uiHandler.GetMediator(_mdiator);
        _gameHandler.GetMediator(_mdiator);
    }

    /*
    * Init and foget this entity only for init game
    */
}
