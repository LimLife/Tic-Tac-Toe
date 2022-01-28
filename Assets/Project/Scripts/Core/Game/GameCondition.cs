using System;
using System.Collections.Generic;
public class GameCondition
{
    public event Action<List<Segment>> OnWin;
    public event Action OnDeadHeat;
    private readonly Segment[] _map;
    private readonly List<Segment> _cell;
    public GameCondition(Segment[] map)
    {
        _cell = new List<Segment>(3);
        _map = map;
    }

    public void GetWin()
    {
        Diagonal();
        Row();
        Clumn();
        DiagonalInverse();
        CheckDraw();
    }

    /*    
    [] arr

    1. 0-3-6 | +3
    2. 1-4-7 | +3
    3. 2-5-8 | +3

    4. 0-1-2 - +1
    5. 3-4-5 - +1
    6. 6-7-8 - +1

    7. 0-4-8 / +4
    9. 2-4-6 \ +2

    */
    public void RestartBoard()
    {
        foreach (var item in _map)
        {
            item.Restart();
        }
    }
    public void CheckDraw()
    {
        byte cellIsClick = 0;
        foreach (var item in _map)
        {
            if (item.IsClick == true)
            {
                cellIsClick++;
                if (cellIsClick == 9)
                {
                    OnDeadHeat?.Invoke();
                }
            }
        }
    }
    private void Row()
    {
        byte count = 3;
        byte reference = 0;
        while (count > 0)
        {
            count--;
            var temp = _map[reference];
            for (int i = 0; i < _map.Length; i++)
            {
                if (temp.StateCell == _map[i].StateCell && _map[i].StateCell != TicTac.Toe)
                {
                    _cell.Add(_map[i]);
                    if (_cell.Count == 3)
                    {
                        OnWin?.Invoke(_cell);
                        break;
                    }
                }
            }
            _cell.Clear();
            reference += 3;
        }

    }
    private void Clumn()
    {
        byte count = 3;
        byte reference = 0;
        byte startIteration = 0;
        while (count > 0)
        {
            count--;
            var temp = _map[reference];
            reference += 1;

            for (int i = startIteration; i < _map.Length; i += 3)
            {
                if (temp.StateCell == _map[i].StateCell && _map[i].StateCell != TicTac.Toe)
                {
                    _cell.Add(_map[i]);
                    if (_cell.Count == 3)
                    {
                        OnWin?.Invoke(_cell);
                        break;
                    }
                }
                
            }
            startIteration += 1;
            _cell.Clear();
        }
    }
    private void DiagonalInverse()
    {
        byte reference = 2;
        byte startIteration = 2;
        var temp = _map[reference];
        for (int i = startIteration; i < _map.Length - 2; i += 2)
        {
            if (temp.StateCell == _map[i].StateCell && _map[i].StateCell != TicTac.Toe)
            {
                _cell.Add(_map[i]);
                if (_cell.Count == 3)
                {
                    OnWin?.Invoke(_cell);                   
                }
            }
        }
        _cell.Clear();
    }
    private void Diagonal()
    {
        byte reference = 0;
        byte startIteration = 0;
        var temp = _map[reference];
        for (int i = startIteration; i < _map.Length; i += 4)
        {
            if (temp.StateCell == _map[i].StateCell && _map[i].StateCell != TicTac.Toe)
            {
                _cell.Add(_map[i]);
                if (_cell.Count == 3)
                {
                    OnWin?.Invoke(_cell);                   
                }
            }
        }
        _cell.Clear();
    }
}
