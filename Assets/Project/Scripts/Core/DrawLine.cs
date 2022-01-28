using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class DrawLine : MonoBehaviour, IInitialize
{
    [SerializeField] private LineRenderer _line;

    private float _startLine = 1f;
    private float _endLine = 1f;

    private Vector3[] _posints;
    public void Initialize()
    {
        _line.sortingOrder = ConfigConst.SORTING_LAYER_LINE_RENDER;
        _line.positionCount = 3;
        _line.startWidth = _startLine;
        _line.endWidth = _endLine;
        _line.useWorldSpace = true;
    }

    public void SetUpLine(List<Segment> cell)
    {
        _posints = new Vector3[3];
        byte cells = 0;

        foreach (var item in cell)
        {
            _posints[cells] = item.Postion;
            cells++;
        }
        _line.SetPositions(_posints);
    }
    public void RemoveLine()
    {
        _line.positionCount = 0;
    }

    
}

