
public class WinForDestroyCertainCountBallsOneColor : IWinChecker
{
    private WinForDestroyCertainCountBallsOneColorSettings _settings;
    private int _ballsDestroyCount;
    public WinForDestroyCertainCountBallsOneColor(WinForDestroyCertainCountBallsOneColorSettings settings)
    {
        _settings = settings;
    }
    public bool CheckWin()
    {
        _ballsDestroyCount++;
        return _ballsDestroyCount >= _settings.NeedDestroyCount;
    }
}
[System.Serializable]
public class WinForDestroyCertainCountBallsOneColorSettings
{
    public TipeColorBall DestroyColor;
    public int NeedDestroyCount;
}
