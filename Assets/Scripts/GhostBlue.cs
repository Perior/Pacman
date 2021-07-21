using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBlue : PersonalityChanger
{
    public GameObject spawn;
    public bool eaten {get; private set;}
    public Animator animator;

    public override void Enable(float duration){
        base.Enable(duration);
        animator.SetBool("ComMedo", true);
        Invoke(nameof(Stop), duration);
    }

    private void Stop(){
        animator.SetBool("ComMedo", false);
    }

    private void OnEnable(){
        this.ghost.chase.Disable();
        this.ghost.movement.speedMult = 0.5f;
        this.eaten = false;
    }

    private void OnDisable(){
        this.ghost.movement.speedMult = 1.0f;
        this.eaten = false;
    }

    private void Respawn(){

        this.ghost.gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player")){
            if(this.enabled){
                this.eaten = true;

                Vector3 position = this.spawn.transform.position;
                this.ghost.transform.position = position;
                this.ghost.gameObject.SetActive(false);
                Invoke(nameof(Respawn), 3.0f);
                

            }
        }
    }
    
}
