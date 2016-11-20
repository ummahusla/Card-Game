using UnityEngine;
using System.Collections;

public class CardClick : MonoBehaviour {

    void OnMouseDown() {
        transform.Translate(0, 3, 0);
    }
}
