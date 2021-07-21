using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int points = 10;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.transform.tag == "Player"){
            Comeu();
        }
    }

    protected virtual void Comeu(){
        FindObjectOfType<Gerenciador>().ComeuPellet(this);
    }
}
