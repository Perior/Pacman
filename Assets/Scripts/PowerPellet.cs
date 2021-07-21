using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : Pellet
{
    public float duration = 6.0f;

    protected override void Comeu(){
        FindObjectOfType<Gerenciador>().ComeuPower(this);
    }
}
