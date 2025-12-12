using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoBase : MonoBehaviour, IDashable
{
    public virtual void ActiveDash()
    {
        EventManager.player.GetTarget?.Invoke(transform);
    }
}
