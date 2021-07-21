using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerenciador : MonoBehaviour
{
    public GameObject[] ghost;
    public GameObject pacman;
    public Transform pellets;
    public GameObject gameOver;
    public AudioSource chomp;
    public AudioSource dead;
    public AudioSource eatGhost;
    public AudioSource intermission;
    private PlayerController2D pacontroller;
    private Ghost fant;


    public int score {get; private set;}
    public int vida {get; private set;}


    void Start()
    {
        this.pacontroller = this.pacman.GetComponent<PlayerController2D>();
        SetScore(0);
        SetVida(3);
        NewGame();
    }

    private void NewGame(){
        foreach (Transform pellet in this.pellets){
            pellet.gameObject.SetActive(true);
        }

        Reset();
    }

    private void Reset(){
        for(int i = 0; i<this.ghost.Length; i++){
            fant = ghost[i].GetComponent<Ghost>();
            fant.ResetState();
        }

        this.pacontroller.Respawn();
    }

    private void SetScore(int score){
        this.score = score;
    }

    private void SetVida(int vida){
        this.vida = vida;
    }


    public void ComeuGhost(Ghost ghost){
        SetScore(this.score + ghost.points);
        eatGhost.PlayOneShot(eatGhost.clip);

    }
    
    public void Damage(){
        this.pacman.gameObject.SetActive(false);

        SetVida(this.vida - 1);
        dead.PlayOneShot(dead.clip);
        
        if(this.vida <= 0){
            this.gameOver.gameObject.SetActive(true);
        } else{
            Invoke(nameof(Reset), 3.0f);
        }
    }

    public void ComeuPellet(Pellet pellet){
        if(chomp != null){
            chomp.PlayOneShot(chomp.clip);
        }
        pellet.gameObject.SetActive(false);
        SetScore(this.score + pellet.points);

        if(!FullofFood()){
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewGame), 3.0f);
        }
    }

    public void ComeuPower(PowerPellet power){
        for(int i = 0; i < this.ghost.Length; i++){
            fant = ghost[i].GetComponent<Ghost>();
            fant.blue.Enable(power.duration);
        }
        intermission.PlayOneShot(intermission.clip);

        ComeuPellet(power);
    }

    private bool FullofFood(){
        foreach (Transform pellet in this.pellets){

            if(pellet.gameObject.activeSelf){
                return true;
            }
        }

        return false;
    }
}
