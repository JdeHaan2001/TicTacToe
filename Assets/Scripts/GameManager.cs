using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        PAUSED = 0, PLAYER1, PLAYER2
    };

    [SerializeField] private Image[] _imageField = new Image[9];

    private GameState _currentState = GameState.PAUSED;

    //private Dictionary<int, PlayerBase> _players = new Dictionary<int, PlayerBase>();
    private Dictionary<Image, int> _gameFieldDict = new Dictionary<Image, int>();

    public static GameManager Instance { get; private set; }

    private int[] _gameField = new int[9]{
        0, 0, 0,
        0, 0, 0,
        0, 0, 0
    };

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        int randNumber = Random.Range(0, 1);
        _currentState = GameState.PLAYER1;

        for (int i = 0; i < _gameField.Length; i++)
        {
            _gameFieldDict.Add(_imageField[i], i);
        }
    }

    

    public void TestMove()
    {
        int randNumber = getRandNumber();

        if (_gameField[randNumber] != 0)
            TestMove();
        else
        {
            _gameField[randNumber] = (int)_currentState;
            _currentState = _currentState == GameState.PLAYER1 ? GameState.PLAYER2 : GameState.PLAYER1;

            ShowGameFieldInConsole();
        }
    }

    private int getRandNumber() => Random.Range(0, 9);

    public void MakeMove(Image pImage, int pPlayerNumber)
    {
        int gamePos = _gameField[_gameFieldDict[pImage]];


        if (gamePos != 0)
            Debug.Log("Field has already been taken");
        else
        {
            Debug.Log("Field has not been taken");
            _gameField[_gameFieldDict[pImage]] = pPlayerNumber;
            if (pPlayerNumber == 1)
                pImage.color = Color.green;
            else
                pImage.color = Color.red;
        }

        if ((int)_currentState == pPlayerNumber)
            _currentState = GameState.PLAYER2;
        else
            _currentState = GameState.PLAYER1;
    }

    public Image[] GetImageList() => _imageField;

    public void ShowGameFieldInConsole()
    {
        Debug.Log($"{_gameField[0]}     {_gameField[1]}     {_gameField[2]}");
        Debug.Log($"{_gameField[3]}     {_gameField[4]}     {_gameField[5]}");
        Debug.Log($"{_gameField[6]}     {_gameField[7]}     {_gameField[8]}");
    }
}
