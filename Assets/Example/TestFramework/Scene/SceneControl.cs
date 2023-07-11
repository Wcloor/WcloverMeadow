using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl 
{
    public Dictionary<string,SceneBase> dict_sences;

    public SceneControl() { 
        dict_sences = new Dictionary<string,SceneBase>();   
    }

    private static SceneControl instance;
    public static SceneControl GetInstance()
    {
        if(instance == null)
        {
            Debug.Log("SceneControl不存在");
            return instance;

        }
        return instance;

    }
    public void LoadScene(string scene_name,SceneBase sceneBase)
    {
        if(!dict_sences.ContainsKey(scene_name))
        {
            dict_sences.Add(scene_name, sceneBase);
        }
        if (dict_sences.ContainsKey(SceneManager.GetActiveScene().name)){
            dict_sences[SceneManager.GetActiveScene().name].ExitSence();
        }
        else
        {
            Debug.Log($"SceneControl的字典不包含{SceneManager.GetActiveScene().name}");
        }
        GameRoot.GetInstance().UIManager_Root.Pop(true);


        SceneManager.LoadScene(scene_name);
        sceneBase.EnterSence();

    }


}
