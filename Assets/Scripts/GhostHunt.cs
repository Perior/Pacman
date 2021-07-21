using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHunt : PersonalityChanger
{
    private void OnDisable(){
        this.ghost.andar.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other){
        Caminhos caminho = other.GetComponent<Caminhos>();

        if(caminho != null && this.enabled && !this.ghost.blue.enabled){
            Vector2 direction = Vector2.zero;
            float minDistance = float.MaxValue;

            foreach(Vector2 direcLivre in caminho.direcLivres){
                Vector3 newPosition = this.transform.position + new Vector3(direcLivre.x, direcLivre.y, 0.0f);
                float distance = (this.ghost.target.position - newPosition).sqrMagnitude;

                if(distance < minDistance){
                    direction = direcLivre;
                    minDistance = distance;
                }
            }

            this.ghost.movement.SetDirection(direction);
        }
    }
}
