using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BorrarDespues : MonoBehaviour
{
    [SerializeField] SceneField scene;
    void Start()
    {
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
    }
}
