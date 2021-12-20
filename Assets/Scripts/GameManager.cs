using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        PAUSED = 0, PLAYER1, PLAYER2
    };

    private GameState _currentState = GameState.PAUSED;

    private int[] _gameField = new int[9]{
        0, 0, 0,
        0, 0, 0,
        0, 0, 0
    };

    private void Start()
    {
        int randNumber = Random.Range(0, 1);
        _currentState = randNumber == 0 ? GameState.PLAYER1 : GameState.PLAYER2;
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

    public bool MakeMove(int pPlayerNumber, int index)
    {
        if (_gameField[index] != 0)
        {
            Debug.Log("Field is already taken");
            return false;
        }
        else
        {
            _gameField[index] = pPlayerNumber;
            return true;
        }
    }

    public void ShowGameFieldInConsole()
    {
        Debug.Log($"{_gameField[0]}     {_gameField[1]}     {_gameField[2]}");
        Debug.Log($"{_gameField[3]}     {_gameField[4]}     {_gameField[5]}");
        Debug.Log($"{_gameField[6]}     {_gameField[7]}     {_gameField[8]}");
    }
}
