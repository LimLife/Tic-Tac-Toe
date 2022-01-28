using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameHandler : MonoBehaviour, IInitialize, ISubscribe, IUnSubscribe, IState
{
    [SerializeField] private Map _map; //2 level reference
    [SerializeField] private DrawLine _drawLine;
    private GameCondition _gameCondition;
    private GameState _state;
    public IMediator Mediator { get; private set; }

    public void Initialize()
    {
        _gameCondition = new GameCondition(_map.MapCell);
        _map.Initialize(_gameCondition);
        _drawLine.Initialize();
        Subscribe();
    }



    public void Subscribe()
    {
        _gameCondition.OnDeadHeat += DeadHeat;
        _gameCondition.OnWin += WinGame;
    }

    private void DeadHeat()
    {
        _drawLine.RemoveLine();
        _state = GameState.Draw;
        Mediator.Send(this, _state);
    }

    private void WinGame(List<Segment> cell)
    {
        _drawLine.SetUpLine(cell);
        _state = GameState.Win;
        StartCoroutine(WaitCallBack(_state));
    }

    public void UnSubscribe()
    {
        _gameCondition.OnDeadHeat -= DeadHeat;
        _gameCondition.OnWin -= WinGame;
        _map.UnSubscribe();
    }

    public void Notyfi(GameState state) //future (
    {
        switch (state)
        {
            case GameState.Game:
                _gameCondition.RestartBoard();
                _drawLine.RemoveLine();
                break;
            case GameState.EndGame:
                UnSubscribe();
                break;
            default:
                break;
        }
    }

    public void GetMediator(IMediator mediator)
    {
        Mediator = mediator;
    }
    private IEnumerator WaitCallBack(GameState state)
    {
        yield return new WaitForSeconds(3f);//test wiat
        Mediator.Send(this, state);
        yield break;
    }
}


