using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class LevelManager : MonoBehaviour
{
    [SerializeField] int _piso = 1;
    public int piso { get { return _piso; } }
    [SerializeField] TMP_Text _text;
    [SerializeField] Animator animator;
    
    public void UpdateText()
    {
        _text.text = "Piso " + piso;
    }

    private void Start()
    {
        UpdateText();
        EventManager.level.SceneChanged += OnLevelUp;
    }

    public void OnLevelUp()
    {
        _piso++;
        UpdateText();
    }
}
