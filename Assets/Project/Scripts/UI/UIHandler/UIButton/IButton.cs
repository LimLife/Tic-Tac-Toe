using UnityEngine.UI;

public interface IButton 
{
    Button Button { get; }
    void Show();
    void Close();
}
