using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ResultSceneLoad : MonoBehaviour
{
    [SerializeField] string ScneName1 = "Scene1";
    [SerializeField] string ScneName2 = "Scene02"; // Scene‚Ì–¼‘O
    [SerializeField] string ScneName3 = "Scene03";
    public void SceneLoad1()
    {
        SceneManager.LoadScene(ScneName1);
    }
    public void SceneLoad2()
    {
        SceneManager.LoadScene(ScneName2);
    }
    public void SceneGame()
    {
        //   SceneMoveManager.Instance.LoadPrevious();
    }
}
