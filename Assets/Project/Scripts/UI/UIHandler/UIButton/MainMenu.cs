using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(RectTransform))]
public class MainMenu : MonoBehaviour ,IButton,IInitialize
{  
    public Button Button => _mainMenu;

    [SerializeField] private Button _mainMenu;
    [SerializeField] private RectTransform _rectTransform;
    public void Initialize()
    {
        _rectTransform.localPosition = new Vector3(_rectTransform.localPosition.x, _rectTransform.localPosition.y, ConfigConst.UI_LAYERS);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

}
