using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAndar : PersonalityChanger
{
    private void OnDisable(){
        this.ghost.chase.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other){
        Caminhos caminho = other.GetComponent<Caminhos>();

        if(caminho != null && this.enabled && !this.ghost.blue.enabled){
            int index = Random.Range(0, caminho.direcLivres.Count);

            if(caminho.direcLivres[index] ==  -this.ghost.movement.direction && caminho.direcLivres.Count > 1){
                index++;

                if(index >= caminho.direcLivres.Count){
                    index = 0;
                }
            }

            this.ghost.movement.SetDirection(caminho.direcLivres[index]);
        }
    }
    
}
