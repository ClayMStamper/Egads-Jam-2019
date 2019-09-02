using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IteratorTrigger : MonoBehaviour {

    public Sprite[] sprites;
    public Image image;
    public GameObject player;

    private int spriteIndex = 0;
    
    
    private void OnTriggerEnter(Collider other) {

        if (other.gameObject == player) {
            if (transform.position.x < player.transform.position.x) {
                spriteIndex = (int)Mathf.Repeat(spriteIndex + 1, sprites.Length - 1);
            }
            else {
                spriteIndex = (int)Mathf.Repeat(spriteIndex - 1, sprites.Length - 1);
            }
        }
        
        print(spriteIndex);

        image.sprite = sprites[spriteIndex];

    }
    
    
    
}
