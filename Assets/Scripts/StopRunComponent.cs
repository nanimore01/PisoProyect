using UnityEngine;
using UnityEngine.SceneManagement;
public class StopRunComponent : MonoBehaviour
{
    [SerializeField] Canvas _canvas;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseButton();
        }
    }

    public void PauseButton()
    {
        _canvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeButton()
    {
        _canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }


    public void OnStopRun()
    {
        EventManager.player.OnDead.Invoke();
        SceneManager.LoadScene(1);
    }
}
