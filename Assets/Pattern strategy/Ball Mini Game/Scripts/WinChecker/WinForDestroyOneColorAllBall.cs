using System.Linq;

public class WinForDestroyOneColorAllBalls : IWinChecker
{
    private WinForDestroyOneColorAllBallsSettings _settings;
    public WinForDestroyOneColorAllBalls(WinForDestroyOneColorAllBallsSettings settings)
    {
        _settings = settings;
    }
    public bool CheckWin() => !Ball.FindObjectsOfType<Ball>().Any(ball => ball.Color == _settings.DestroyColor);
}
[System.Serializable]
public class WinForDestroyOneColorAllBallsSettings
{
    public TipeColorBall DestroyColor;
}
