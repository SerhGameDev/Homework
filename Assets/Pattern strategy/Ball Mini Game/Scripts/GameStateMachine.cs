using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    // Перечисление для состояний игры
    public enum GameState
    {
        MainMenu,
        InGame,
        GameOver
    }

    private GameState currentState; // Текущее состояние игры

    // Вызывается при запуске игры
    private void Start()
    {
        // Устанавливаем начальное состояние игры
        SetState(GameState.MainMenu);
    }

    // Метод для установки состояния игры
    private void SetState(GameState newState)
    {
        // Завершаем текущее состояние
        EndCurrentState();

        // Устанавливаем новое состояние
        currentState = newState;

        // Начинаем новое состояние
        StartCurrentState();
    }

    // Метод для начала текущего состояния
    private void StartCurrentState()
    {
        switch (currentState)
        {
            case GameState.MainMenu:
                // Логика для главного меню
                break;
            case GameState.InGame:
                // Логика для игрового состояния
                break;
            case GameState.GameOver:
                // Логика для состояния "конец игры"
                break;
        }
    }
    private void EndCurrentState()
    {
        switch (currentState)
        {
            case GameState.MainMenu:
                // Завершение главного меню
                break;
            case GameState.InGame:
                // Завершение игрового состояния
                break;
            case GameState.GameOver:
                // Завершение состояния "конец игры"
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
