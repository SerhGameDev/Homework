using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    // ������������ ��� ��������� ����
    public enum GameState
    {
        MainMenu,
        InGame,
        GameOver
    }

    private GameState currentState; // ������� ��������� ����

    // ���������� ��� ������� ����
    private void Start()
    {
        // ������������� ��������� ��������� ����
        SetState(GameState.MainMenu);
    }

    // ����� ��� ��������� ��������� ����
    private void SetState(GameState newState)
    {
        // ��������� ������� ���������
        EndCurrentState();

        // ������������� ����� ���������
        currentState = newState;

        // �������� ����� ���������
        StartCurrentState();
    }

    // ����� ��� ������ �������� ���������
    private void StartCurrentState()
    {
        switch (currentState)
        {
            case GameState.MainMenu:
                // ������ ��� �������� ����
                break;
            case GameState.InGame:
                // ������ ��� �������� ���������
                break;
            case GameState.GameOver:
                // ������ ��� ��������� "����� ����"
                break;
        }
    }
    private void EndCurrentState()
    {
        switch (currentState)
        {
            case GameState.MainMenu:
                // ���������� �������� ����
                break;
            case GameState.InGame:
                // ���������� �������� ���������
                break;
            case GameState.GameOver:
                // ���������� ��������� "����� ����"
                break;
        }
    }
    public void StartGame()
    {
        SetState(GameState.InGame);
    }
    public void GameOver()
    {
        SetState(GameState.GameOver);
    }
}
