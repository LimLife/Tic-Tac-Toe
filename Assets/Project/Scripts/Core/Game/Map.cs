using UnityEngine;

public class Map : MonoBehaviour,ISubscribe,IUnSubscribe
{
    public Segment[] MapCell => _mapCell;
    [SerializeField] private Segment[] _mapCell;
    
    private GameCondition _gameCondition;
    private Move _move = Move.Fisrst;

    public void Initialize(GameCondition game)
    {
        _gameCondition = game;
        Subscribe();
    }

    public void UnSubscribe()
    {

        foreach (var item in _mapCell)
        {       
            item.Click.onClick.RemoveListener(() =>
            {
                SetState(item);
            });
        }
    }
   
    public void Subscribe()
    {

        foreach (var item in _mapCell)
        {
            item.Initialize();
            item.Click.onClick.AddListener(() =>
            {
                SetState(item);
            });
        }
    }
    private void SetState(Segment cell)
    {
        cell.Clcik(_move);
        if (_move == Move.Fisrst)
        {
            _move = Move.Second;
        }
        else
        {
            _move = Move.Fisrst;
        }
        _gameCondition.GetWin();
        _gameCondition.CheckDraw();
    } 
}
