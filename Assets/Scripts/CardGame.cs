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

    public int CardType;
    public string CardName;

    public int MyLife = 5;
    public int EnemyLife = 5;

    public bool PlayerHasWon = false;

    void Start () {

        // Player hand
	    Hand = new GameObject[HandSize];

        for (int i = 0; i < HandSize; i++) {

            CardType = Random.Range(0, 5);
            GameObject go = GameObject.Instantiate(FairyDeck[CardType]) as GameObject;
            Vector3 positionCard = new Vector3((i * 4) + 1, 1, 0);
            go.transform.position = positionCard;

            Hand[i] = go;

        }

        // Enemy hand
        EnemyHand = new GameObject[HandSize];

        for (int y = 0; y < HandSize; y++) {

            CardType = Random.Range(0, 5);
            CardName = string.Format("Witch{0}", CardType);
            EnemyCards[y] = CardType;

            GameObject go = GameObject.Instantiate(CardBack) as GameObject;
            Vector3 positionEnemy = new Vector3((y * 4) + 1, 17, 0);
            go.transform.position = positionEnemy;

            EnemyHand[y] = go;

        }
    }

	void Update () {

        // If left mouse button is clicked
	    if (Input.GetMouseButtonDown(0)) {

	        RaycastHit hit;
	        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

	        if (Physics.Raycast(ray, out hit)) {

                // All cards should be labeled with Card tag
                // in order this fuction to work
	            if (hit.collider.tag == "Card") {
                    
                    // Displays the name of the clicked card
	                Debug.Log(hit.transform.gameObject.name);

	                GameObject CardClicked = hit.transform.gameObject;

	                string CardEnemyPlayed = EnemyTurn();
	                ResolveBattle(CardClicked, CardEnemyPlayed);
	                DrawNewCard(CardClicked);
	            }
	        }
	    }

	}

    string EnemyTurn() {

        return "Card";

    }

    void ResolveBattle(GameObject CardClicked, string CardsEnemyPlayed) {
        
    }

    void DrawNewCard(GameObject oldCard) {
        
    }

}
