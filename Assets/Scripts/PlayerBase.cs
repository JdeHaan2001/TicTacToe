using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private int _playerNumber;


    public new string ToString()
    {
        return $"Player number: {_playerNumber}";
    }
}
