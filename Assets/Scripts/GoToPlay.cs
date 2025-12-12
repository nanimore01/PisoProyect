using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToPlay : MonoBehaviour
{
    public TMP_Text textProgress;
    public Slider slider;
    public float currentPercent;
    public AsyncOperation loadAsync;
    [SerializeField] SceneField _persistentGame;
    

    public void LoadSceneButton(int numero)
    {
        StartCoroutine(LoadScene(numero));
    }

    public IEnumerator LoadScene(int nameToLoad)
    {

        loadAsync = SceneManager.LoadSceneAsync(nameToLoad);
        loadAsync.allowSceneActivation = false;
        while (!loadAsync.isDone)
        {
            currentPercent = loadAsync.progress * 100 / 0.9f;
            loadAsync.allowSceneActivation = true;
            yield return null;
        }
    }

    public void ActivarEscena()
    {
        if (loadAsync != null && currentPercent >= 100)
        {
                
        }
    }

    public void LoadSceneInstanly(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    
    
}
