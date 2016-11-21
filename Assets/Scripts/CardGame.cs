using UnityEngine;
using System.Collections;

public class CardGame : MonoBehaviour {

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
	                ResolveBattle(CardClicked.name, CardEnemyPlayed);
                    DrawNewCard(CardClicked);
                }
	        }
	    }

        // Check if AI or player ran out of lives
	    if (MyLife <= 0) {
            // Player ran out of lives
	        PlayerHasWon = false;
	        EndGame();
	    } else if (EnemyLife <= 0) {
            // Enemy ran out of lives
	        PlayerHasWon = true;
            EndGame();
	    }

	}

    // Check who won the game
    void EndGame() {
        if (PlayerHasWon == true) {
            // Player won, AI lost, load Victory scene
            Application.LoadLevel("Victory");
        } else {
            // Player lost, AI won, load Game Over scene
            Application.LoadLevel("Game Over");
        }
    }

    string EnemyTurn() {

        // Picks a totally random card
        int PickACardAtRandom = Random.Range(0, HandSize);
        GameObject ChosenCard = EnemyHand[PickACardAtRandom];
        string EnemyCard = ChosenCard.name;


        // Enemy chooses a new card
        int NewDraw = Random.Range(0, 5);
        EnemyHand[PickACardAtRandom] = WithcDeck[NewDraw];
        CardName = string.Format("Witch{0}", NewDraw);

        // Draws a new card
        GameObject go = GameObject.Instantiate(WithcDeck[NewDraw]) as GameObject;
        go.name = CardName;
        go.transform.position = ChosenCard.transform.position;

        // Destroys a previous chosen card
        Destroy(ChosenCard);

        return EnemyCard;

    }

    void ResolveBattle(string CardClicked, string CardsEnemyPlayed) {

        // Basic examples of how cards can affect player and AI

        if (CardClicked == "Fairy0") {
            // Damage is dealt to the enemy
            EnemyLife--;
        }
        if (CardClicked == "Fairy5") {
            // Players is healed
            MyLife++;
        }
        if (CardsEnemyPlayed == "Witch0") {
            // Damage is dealt to the player
            MyLife--;
        }

        // Add remaining Card description
        // Attack, Block, Heal

    }

    void DrawNewCard(GameObject oldCard) {
        
    }

    void OnGUI() {
        GUI.Label(new Rect(10, 70, 100, 20), "Witch: " + EnemyLife);
        GUI.Label(new Rect(10, 230, 100, 20), "My Life: " + MyLife);
    }

}
