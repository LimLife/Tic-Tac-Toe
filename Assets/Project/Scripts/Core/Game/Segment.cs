using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(RectTransform))]
public class Segment : MonoBehaviour, IInitialize
{
    public Vector3 Postion => transform.position;
    public bool IsClick { get; private set; } = false;
    public TicTac StateCell => _ticTac;
    public Button Click => _click;
    public byte ID => id;

    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private SpriteRenderer _tic;
    [SerializeField] private SpriteRenderer _tak;
    [SerializeField] private Button _click;
    [SerializeField] byte id;

    private TicTac _ticTac;


    public void Initialize()
    {
        _rectTransform.localPosition = new Vector3(_rectTransform.localPosition.x, _rectTransform.localPosition.y, ConfigConst.MAP_LAYERS);

        _tic.gameObject.SetActive(false);
        _tic.sortingOrder = ConfigConst.SORTING_LAYER_BEFORE_MAP;
        _tak.gameObject.SetActive(false);
        _tak.sortingOrder = ConfigConst.SORTING_LAYER_BEFORE_MAP;
        _ticTac = TicTac.Toe;
    }

    public void Restart()
    {
        IsClick = false;
        _ticTac = TicTac.Toe;
        _tic.gameObject.SetActive(false);
        _tak.gameObject.SetActive(false);
    }
    public void Clcik(Move move)
    {
        if (!IsClick)
        {
            switch (move)
            {
                case Move.Fisrst:
                    Tic();
                    break;
                case Move.Second:
                    Tak();
                    break;
            }
        }
    }
    private void Tic()
    {
        IsClick = true;
        _ticTac = TicTac.Tic;
        _tic.gameObject.SetActive(true);
    }
    private void Tak()
    {
        IsClick = true;
        _ticTac = TicTac.Tak;
        _tak.gameObject.SetActive(true);
    }
}
