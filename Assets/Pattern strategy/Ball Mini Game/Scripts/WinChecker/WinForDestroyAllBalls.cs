using System.Linq;

public class WinForDestroyAllBalls : IWinChecker
{
    public bool CheckWin() => !Ball.FindObjectsOfType<Ball>().Any();
}
