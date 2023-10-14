using UnityEngine;
using System;
using System.Linq;

public class WinController : MonoBehaviour
{
    [field: SerializeField] public WinCheckerType WinCheckerType { get; private set; }
    [Header("Start Settings")]
    [Space(5)]
    [SerializeField] private WinForDestroyOneColorAllBallsSettings _winForDestroyOneColorAllBallsSettings; 
    [Space(5)]
    [SerializeField] private WinForDestroyCertainCountBallsOneColorSettings _winForDestroyCertainCountBallsOneColorSettings;

    private IWinChecker _winChecker;

    private void OnValidate()
    {
        SetWinCheckerType(WinCheckerType);
    }
    private void Start()
    {
        SetWinCheckerType(WinCheckerType);
    }
    private bool CanSetType() => true;
    private void ProcessDestroyBall(Ball ball)
    {
        if (_winChecker == null)
            throw new NullReferenceException(nameof(_winChecker));

        if (_winChecker.CheckWin())
            SetWin();
    }
    private void SubscribeDestroyBall() => Ball.FindObjectsOfType<Ball>().ToList().ForEach(ball => ball.OnDestroyEvent += ProcessDestroyBall);
    private void SetWin()
    {
        Debug.Log("Win");
    }
    public void SetWinCheckerType(WinCheckerType newWinCheckerType)
    {
        if (!CanSetType())
            return;

        WinCheckerType = newWinCheckerType;

        SubscribeDestroyBall();

        if (WinCheckerType == WinCheckerType.WinForDestroyAllBalls)
            SetWinForDestroyAllBalls();

        else if (WinCheckerType == WinCheckerType.WinForDestroyOneColorAllBalls)
            SetWinForDestroyOneColorAllBalls();

        else if (WinCheckerType == WinCheckerType.WinForDestroyOneBall)
            SetWinForDestroyOneBall();

        else if (WinCheckerType == WinCheckerType.WinForDestroyCertainCountBallsOneColor)
            SetWinForDestroyCertainCountBallsOneColor();

        Debug.Log($"Set new a goal for winning this: {WinCheckerType}");
    }

    #region Set IWinChecker
    private void SetWinForDestroyAllBalls() => _winChecker = new WinForDestroyAllBalls();
    private void SetWinForDestroyOneColorAllBalls() => _winChecker = new WinForDestroyOneColorAllBalls(_winForDestroyOneColorAllBallsSettings);
    private void SetWinForDestroyOneBall() => _winChecker = new WinForDestroyOneBall();
    private void SetWinForDestroyCertainCountBallsOneColor() => _winChecker = new WinForDestroyCertainCountBallsOneColor(_winForDestroyCertainCountBallsOneColorSettings);

    #endregion
}
public enum WinCheckerType
{
    WinForDestroyOneBall,
    WinForDestroyAllBalls,
    WinForDestroyOneColorAllBalls,
    WinForDestroyCertainCountBallsOneColor
}