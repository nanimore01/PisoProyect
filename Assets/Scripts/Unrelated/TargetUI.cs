using UnityEngine;
using UnityEngine.UI;
public class TargetUI : MonoBehaviour
{
    [SerializeField] Animation _animation;
    [SerializeField] Image _image;
    [SerializeField] Jugador pj;
    public void Awake()
    {
        //Por alguna razon que no entiendo, no funciona...
        //EventManager.player.GetTarget += SetPosition;

        EventManager.player.OnDead += OnDead;
        EventManager.level.SceneChanged += OnLevelUp;

        pj.OnTarget += SetPosition;
    }

    public void SetPosition(Transform target)
    {

        if (target == null) return;

        _image.gameObject.SetActive(true);
        _animation.Rewind();
        _animation.Play();

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(target.position);

        Debug.Log("Posición local en UI: " + screenPosition);
        _image.rectTransform.position = screenPosition;

        //Debug.Log("Recibí el evento de TargetUI con el target: " + target.name);

        //_image.gameObject.SetActive(true);
        //_animation.Play();
        //Vector2 t = new Vector2(target.position.x, target.position.y);
        //_image.rectTransform.anchoredPosition = t;
    }

    public void OnLevelUp()
    {
        _image.gameObject.SetActive(false);
    }

    public void OnDead()
    {
        EventManager.level.SceneChanged -= OnLevelUp;
        EventManager.player.OnDead -= OnDead;
    }
}
