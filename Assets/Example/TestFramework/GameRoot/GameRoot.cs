using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private UIManager UIManager;
    public UIManager UIManager_Root { get => UIManager; }
    private SceneControl SceneControl;
    public SceneControl SceneControl_Root { get => SceneControl; }

    private static GameRoot instance;
    public static GameRoot GetInstance()
    {
        if(instance == null)
        {
            Debug.Log("GameRoot»ñµÃÊµÀýÊ§°Ü");
            return instance;
        }    
        return instance;

    }


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
   
        UIManager=new UIManager();
        SceneControl=new SceneControl();
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        UIManager_Root.CanvasObj = UIMehod.GetInstance().FindCanvas(); 
        Scene1 scene1=new Scene1();
      
        SceneControl_Root.dict_sences.Add(scene1.SceneName, scene1);
       // UIManager_Root.Push()
       UIManager_Root.Push(new StarPanel());
    }

}
