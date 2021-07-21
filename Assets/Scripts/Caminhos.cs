using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminhos : MonoBehaviour
{
    public LayerMask obstacle;
    public List<Vector2> direcLivres {get; private set;}

    private void Start(){
        this.direcLivres = new List<Vector2>();

        ChecaCaminhoLivre(Vector2.up);
        ChecaCaminhoLivre(Vector2.down);
        ChecaCaminhoLivre(Vector2.left);
        ChecaCaminhoLivre(Vector2.right);
    }

    private void ChecaCaminhoLivre(Vector2 caminho){
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.4f, 0.0f, caminho, 0.8f, this.obstacle);
        if(hit.collider == null){
            this.direcLivres.Add(caminho);
        }
    }
}
