using UnityEngine;

public class PlayerBase : MonoBehaviour
{    public enum PlayerState
    {
        CanPlay, CanNotPlay
    };

    private PlayerState _playerState;
    private int _playerNumber;

    public PlayerState GetPlayerState() => _playerState;
    public void SetPlayerState(PlayerState pState) => _playerState = pState;

    public int GetPlayerNumber() => _playerNumber;
    public void SetPlayerNumber(int pNumber) => _playerNumber = pNumber;

    public new string ToString() => $"Player number: {_playerNumber}";
}
