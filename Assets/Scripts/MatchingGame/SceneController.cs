using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour {
	public int gridRows = 2;
	public int gridCols = 4;
	public float offsetX = 2f;
	public float offsetY = 2.5f;
    private int _defaultGridRows = 2;
    private int _defaultGridCols = 4;

    [SerializeField] private MemoryCard originalCard;
	[SerializeField] private string cardFacesFilePath;
	[SerializeField] private TextMesh scoreLabel;

    private Sprite[] _cardFaces;
	
	private MemoryCard _firstRevealed;
	private MemoryCard _secondRevealed;
	private int _score = 0;
    [SerializeField] private GameObject GameOverMenu;
    [SerializeField] private GameObject GameSizeMenu;
    private float _memoryCardSizeRatio;

    public bool canReveal {
		get {return _secondRevealed == null;}
	}

	// Use this for initialization
	void Start() {
        _cardFaces = Resources.LoadAll<Sprite>(cardFacesFilePath);
        _memoryCardSizeRatio = gridRows / gridCols;
        
	}

    private int[] GetCardIDs()
    {
        int[] integerArray = CreateIntegerArray(4);
        int[] shuffledDeck = ShuffleArray(integerArray);
        int[] topCards = GetFirstValues<int>(shuffledDeck, gridRows * gridCols/2);
        int[] shownCards = AppendArray<int>(topCards, topCards);
        return ShuffleArray(shownCards);
    }

    private T[] GetFirstValues<T>(T[] array, int numValues) {
        T[] newArray = new T[numValues];
        for(int i = 0; i < numValues; i++)
        {
            newArray[i] = array[i];
        }
        return newArray;
    }

    private T[] AppendArray<T>(T[] a, T[] b)
    {
        T[] newArray = new T[a.Length + b.Length];
        for(int i = 0; i < a.Length; i++)
        {
            newArray[i] = a[i];
        }
        for(int j = 0; j < b.Length; j++)
        {
            newArray[a.Length + j] = b[j];
        }
        return newArray;
    }

    private int[] CreateIntegerArray(int numValues)
    {
        int[] array = new int[numValues];
        for(int i = 0; i < numValues; i++)
        {
            array[i] = i;
        }
        return array;
    }

    public void CreateCards()
    {
        Destroy(GameSizeMenu);
        Vector3 startPos = originalCard.transform.position;

        float effectiveRatioX = 1.0f * _defaultGridCols / gridCols;
        float effectiveRatioY = 1.0f * _defaultGridRows / gridRows;

        originalCard.transform.localScale =new Vector3(originalCard.transform.localScale.x * effectiveRatioX, originalCard.transform.localScale.y * effectiveRatioY, originalCard.transform.localScale.z);
        offsetX *= effectiveRatioX;
        offsetY *= effectiveRatioY;
        // create shuffled list of cards
        int[] numbers = GetCardIDs();
        numbers = ShuffleArray(numbers);

        // place cards in a grid
        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card;

                // use the original for the first grid space
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MemoryCard;
                }

                // next card in the list for each grid space
                int index = j * gridCols + i;
                int id = numbers[index];
                card.SetCard(id, _cardFaces[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

	// Knuth shuffle algorithm
	private int[] ShuffleArray(int[] numbers) {
		int[] newArray = numbers.Clone() as int[];
		for (int i = 0; i < newArray.Length; i++ ) {
			int tmp = newArray[i];
			int r = Random.Range(i, newArray.Length);
			newArray[i] = newArray[r];
			newArray[r] = tmp;
		}
		return newArray;
	}

	public void CardRevealed(MemoryCard card) {
		if (_firstRevealed == null) {
			_firstRevealed = card;
		} else {
			_secondRevealed = card;
			StartCoroutine(CheckMatch());
		}
	}
	
	private IEnumerator CheckMatch() {

		// increment score if the cards match
		if (_firstRevealed.id == _secondRevealed.id) {
			_score++;
			scoreLabel.text = "Score: " + _score;
            _firstRevealed.OnMatched();
            _secondRevealed.OnMatched();
            if(_score == gridRows * gridCols / 2)
            {
                GameOverMenu.SetActive(true);
            }
		}

		// otherwise turn them back over after .5s pause
		else {
			yield return new WaitForSeconds(.5f);

			_firstRevealed.Unreveal();
			_secondRevealed.Unreveal();
		}
		
		_firstRevealed = null;
		_secondRevealed = null;
	}

    public void Exit()
    {
        Application.Quit();
    }

    public void Restart() {
		SceneManager.LoadScene("Scene");
	}
}
