using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public Transform mainGame;

    //public Transform overlayGame;

    void Start()
    {
        ScreenManager.Instance.Push(new ScreenGO(mainGame));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ScreenManager.Instance.Push(new ScreenGO(Instantiate(overlayGame)));
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            var screenPause = Instantiate(Resources.Load<ScreenPause>("Canvas_Pause"));
            ScreenManager.Instance.Push(screenPause);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScreenManager.Instance.Pop();
        }
    }

    public void PauseBTN()
    {
        var screenPause = Instantiate(Resources.Load<ScreenPause>("Canvas_Pause"));
        ScreenManager.Instance.Push(screenPause);
    }
}
