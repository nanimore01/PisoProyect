using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class LevelLoader : MonoBehaviour, IDashable
{
    [SerializeField] private SceneField[] totalLevels; 
    [SerializeField] private SceneField thisScene;    
    private AsyncOperation asyncLoad;
    private AsyncOperation asyncUnload;
    private SceneField sceneToLoad;

    private void Start()
    {
        ChargeNewLevel();
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            GoToNewLevel();
        }
    }

    public void ChargeNewLevel()
    {
        sceneToLoad = totalLevels[Random.Range(0, totalLevels.Length)];
        StartCoroutine(ChargeLevel());
    }

    public IEnumerator ChargeLevel()
    {
        asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad.SceneName, LoadSceneMode.Additive);
        
        asyncLoad.allowSceneActivation = false;

        
        while (asyncLoad.progress < 0.9f)
        {
            //EventManager.level.OnLoadingScene?.Invoke(asyncLoad.progress);
            yield return null;
        }

        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Jugador>() != null)
        {
            GoToNewLevel();
        }
    }
    public void GoToNewLevel()
    {
        if (asyncLoad != null)
        {
            asyncLoad.allowSceneActivation = true;

            
            asyncLoad.completed += operation =>
            {
                Scene sceneToActivate = SceneManager.GetSceneByName(sceneToLoad.SceneName);
                if (sceneToActivate.IsValid())
                {
                    SceneManager.SetActiveScene(sceneToActivate);
                    EventManager.level.SceneChanged?.Invoke();
                }
                else
                {
                    
                }

                
                asyncUnload = SceneManager.UnloadSceneAsync(thisScene.SceneName);
                asyncUnload.completed += _ =>
                {
                    
                };
            };
        }
        else
        {
            EventManager.level.OnSceneNotCharged?.Invoke();
        }
    }

    public void ActiveDash()
    {
        EventManager.player.GetTarget?.Invoke(transform);
    }
}
