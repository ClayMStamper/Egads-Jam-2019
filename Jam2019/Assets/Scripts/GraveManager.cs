using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveManager : MonoBehaviour
{
    
    #region singleton

    public static GraveManager instance { get; private set; }

    private void Awake() {

        if (instance)
            Destroy(gameObject);
        else {
            instance = this;
        }
        
    }

    #endregion

    public List<Transform> graves;

    public Transform GetTarget() {
        return graves.Random();
    }
}
