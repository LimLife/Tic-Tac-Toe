using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour, ISubscribe, IUnSubscribe, IInitialize
{
    public event Action<GameState> OnChangeStste;

    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private Restart _restart;
    [SerializeField] private BlockUI _block;
    [SerializeField] private Pause _pause;
    [SerializeField] private Exit _exit;
    [SerializeField] private Menu _menu;

    private bool _isPause;
    private bool _isMenu;

    private GameState _state;

    public void Initialize()
    {
        Subscribe();

        _isPause = false;
        _isMenu = true;

        _menu.Initialize();
        _exit.Initialize();
        _exit.Close();

        _block.Initialize();
        _pause.Initialize();
        _restart.Initialize();
        _restart.Close();

        _mainMenu.Initialize();
        _mainMenu.Close();
    }
    public void Subscribe()
    {
        MenuButton();
        ExitButton();
        PauseButton();
        RestartButton();
        MainMenuButton();

    }
    public void ShowMenu()
    {
        Menu();
    }
   
    private void ExitButton()
    {
        _exit.Button.onClick.AddListener(() =>Exit());      
    }
    private void Exit()
    {
        _state = GameState.EndGame;
        OnChangeStste?.Invoke(_state);
        //i don`t know need wait unsubscribe
        Application.Quit();
    }

    private void MenuButton()
    {
        _menu.Button.onClick.AddListener(() => Menu());
    }
    private void Menu()
    {
        if (_isMenu == true)
        {
            _restart.Show();
            _mainMenu.Show();
            _exit.Show();
            _block.Show();
            _isMenu = false;

        }
        else
        {
            _restart.Close();
            _mainMenu.Close();
            _exit.Close();
            _block.Close();
            _isMenu = true;
        }
    }

    private void PauseButton()
    {
        _pause.Button.onClick.AddListener(() =>Pause());
       
    }
    private void Pause()
    {
        if (_isPause == true)
        {
            _isPause = false;
            _block.Show();
        }
        else
        {
            _block.Close();
            _isPause = true;
        }
    }

    private void RestartButton()
    {
        _restart.Button.onClick.AddListener(() =>Restart());      
    }
    private void Restart()
    {
        _state = GameState.Game;
        _block.Close();
        Menu();
        OnChangeStste?.Invoke(_state);
    }

    private void MainMenuButton()
    {
        _mainMenu.Button.onClick.AddListener(() =>MainMenu());
       
    }
    private void MainMenu()
    {
        _state = GameState.EndGame;
        OnChangeStste?.Invoke(_state);
        UnSubscribe();
        SceneManager.LoadScene(ConfigConst.MAIN_MENU);
    }

    public void UnSubscribe()
    {
        _menu.Button.onClick.RemoveListener(() => Menu());
        _mainMenu.Button.onClick.RemoveListener(() => MainMenu());
        _restart.Button.onClick.RemoveListener(() => Restart());
        _pause.Button.onClick.RemoveListener(() => Pause());
        _exit.Button.onClick.RemoveListener(() => Exit());
    }

}
