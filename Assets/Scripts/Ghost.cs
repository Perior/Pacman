using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GhostMovement movement {get; private set;}
    public GhostHunt chase {get; private set;}
    public GhostBlue blue {get; private set;}
    public GhostAndar andar {get; private set;}

    public Transform target;
    public int points = 200;

    private void Awake(){
        this.movement = GetComponent<GhostMovement>();
        this.chase = GetComponent<GhostHunt>();
        this.blue = GetComponent<GhostBlue>();
        this.andar = GetComponent<GhostAndar>();
    }

    private void Start(){
        ResetState();
    }

    public void ResetState(){
        this.gameObject.SetActive(true);
        this.movement.ResetState();

        this.blue.Disable();
        this.chase.Disable();
        this.andar.Enable();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player")){
            if(this.blue.enabled){
                FindObjectOfType<Gerenciador>().ComeuGhost(this);
            } else {
                FindObjectOfType<Gerenciador>().Damage();
            }
        }
    }
}
