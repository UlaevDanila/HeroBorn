using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour, IManager
{
    [SerializeField] private int maxItems = 4;
    
    private int _itemsCollected = 0;

    private string _labelText = $"Collect 3 items to win this game";

    private bool _isWin = false;

    private bool _showLossScreen = false;

    private bool _isWinButtonClicked;

    private string _state;

    public string State
    {
        get { return _state; }
        set { _state = value; }
    }
    
    public int ItemsCollected
    {
        get
        {
            return _itemsCollected;
        }
        set
        {
            _itemsCollected = value;
            if (_itemsCollected >= maxItems)
            {
                ChangeAttributes(labelText: "Yep", isWin: true);
                Time.timeScale = 0f;
            }
            else
            {
                ChangeAttributes(labelText: $"You found {_itemsCollected} items");
            }
            Debug.LogFormat("Items collected: {0}", _itemsCollected);
        }
    }
    
    private int _playerHealthPoint = 100;
    
    public int PlayerHealthPoint
    {
        get
        {
            return _playerHealthPoint;
        }
        set
        {
            _playerHealthPoint = value;
            if (_playerHealthPoint <= 0)
            {
                ChangeAttributes(labelText: "Do you want another life with that?");
                Utilities.RestartLevel();
            }
            else
            {
                ChangeAttributes(labelText: "You loose");
            }
        }
    }
    
    private void OnGUI()
    {
        GUI.Box(new Rect(20,20,150,25), $"Player health: {_playerHealthPoint}");
        
        GUI.Box(new Rect(200, 20, 150, 25), $"Items collected: {_itemsCollected}");
        
        GUI.Label(new Rect(Screen.width/2 - 100, Screen.height - 50, 300, 50), _labelText);

        if(_isWin)
        {
            _isWinButtonClicked = GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100),
                "You won");
            if (_isWinButtonClicked)
            {
               Utilities.RestartLevel();
            }
        }

        if (_showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You loose"))
            {
                Utilities.RestartLevel();
            }
        }
    }

    private void ChangeAttributes(string labelText = "", bool showLossScreen = false, bool isWin = false)
    {
        _labelText = labelText;
        _showLossScreen = showLossScreen;
        _isWin = isWin;
    }

    public void Initialize()
    {
        _state = "Scene initialized...";
        Debug.Log(_state);
    }
    
}
