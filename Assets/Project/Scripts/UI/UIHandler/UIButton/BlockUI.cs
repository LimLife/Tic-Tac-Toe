using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(RectTransform))]
public class BlockUI :MonoBehaviour, IInitialize
{
    [SerializeField] private Image _block;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private CanvasGroup _canvasGroup;
    public void Initialize()
    {
        _block.color = Color.white;
        _block.gameObject.SetActive(false);
        _canvasGroup.blocksRaycasts = true;
        _rectTransform.localPosition = new Vector3(_rectTransform.localPosition.x, _rectTransform.localPosition.y, ConfigConst.BLOCK_LAYERS);
    }

    public void Show()
    {
        _block.gameObject.SetActive(true);
    }
    public void Close()
    {
        _block.gameObject.SetActive(false);
    }
}
