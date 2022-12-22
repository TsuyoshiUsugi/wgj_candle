using UnityEngine;

public class EndGame : MonoBehaviour
{
  public  void _EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
