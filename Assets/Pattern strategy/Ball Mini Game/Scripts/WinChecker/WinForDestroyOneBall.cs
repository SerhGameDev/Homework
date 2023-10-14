using UnityEngine;

public class WinForDestroyOneBall : IWinChecker
{
    public int StartCount;
    public WinForDestroyOneBall()
    {
        StartCount = Ball.FindObjectsOfType<Ball>().Length;
    }
    public bool CheckWin() => Ball.FindObjectsOfType<Ball>().Length < StartCount;
}
