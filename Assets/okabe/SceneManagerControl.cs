using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneManagerControl : MonoBehaviour
{
    [SerializeField] string ScneName1 = "Asobikata";
    [SerializeField] string ScneName2 = "Title";//scene‚Ì–¼‘O
    [SerializeField] string ScneName3 = "Usugi";
    public void SceneLoad1()
    {
        SceneManager.LoadScene(ScneName1);
    }
    public void SceneLoad2()
    {
        SceneManager.LoadScene(ScneName2);
    }
    public void SceneLoad3()
    {
        SceneManager.LoadScene(ScneName3);
    }
    public void SceneGame()
    {
        //   SceneMoveManager.Instance.LoadPrevious();
    }
}
