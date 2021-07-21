using UnityEngine;

public class Passage : MonoBehaviour
{
    public Transform passage;
    private void OnTriggerEnter2D(Collider2D other){
        Vector3 position = other.transform.position;
        position.x = this.passage.position.x;
        position.y = this.passage.position.y;

        other.transform.position = position;
    }
}


