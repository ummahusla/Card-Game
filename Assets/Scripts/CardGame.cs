using UnityEngine;
using System.Collections;

public class CardGame : MonoBehaviour
{

    public int HandSize = 6;
    public GameObject CardBack;

    private GameObject[] Hand;
    private GameObject[] EnemyHand;

    public GameObject[] FairyDeck = new GameObject[6];
    public GameObject[] WithcDeck = new GameObject[6];

    private int[] MyCards = new int[6];
    private int[] EnemyCards = new int[6];

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
