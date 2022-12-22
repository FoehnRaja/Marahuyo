using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Node : MonoBehaviour
{
    public static Action<Node> onNodeSelected;
   public Turret Turret { get; set; }

    public void SetTurret(Turret turret)
    {
        Turret = turret;
        turret.transform.localPosition = new Vector3(0f, 0.47f,0f);
    }

    public bool isEmpty()
    {
        return Turret == null;
    }
    public void SelectTurret()
    {
        onNodeSelected?.Invoke(this);
    }
}
