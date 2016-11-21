using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

    public void ReloadLevel() {
        Application.LoadLevel("Game");
    }
    
}
