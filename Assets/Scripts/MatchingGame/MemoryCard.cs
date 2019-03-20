using UnityEngine;
using System.Collections;

public class MemoryCard : MonoBehaviour {
	[SerializeField] private GameObject cardBack;
	[SerializeField] private SceneController controller;
    [SerializeField] private GameObject smokeParticlePrefab;

    private float _matchTime = -1;
    private Vector3 _originalPosition;

    public void Start()
    {
        _originalPosition = this.transform.localPosition;
    }

    public void Update()
    {
        if(_matchTime > -1)
        {
            float timeSinceMatch = Time.fixedTime - _matchTime;
            if(timeSinceMatch <= .5f)
            {
                float sineValue = Mathf.Sin(timeSinceMatch * 2f * Mathf.PI * 8);
                this.transform.localPosition = _originalPosition + new Vector3(sineValue + .25f, 0, 0);
            }
            else
            {
                Instantiate(smokeParticlePrefab, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }

    private int _id;
	public int id {
		get {return _id;}
	}

	public void SetCard(int id, Sprite image) {
		_id = id;
		GetComponent<SpriteRenderer>().sprite = image;
	}

	public void OnMouseDown() {
		if (cardBack.activeSelf && controller.canReveal) {
			cardBack.SetActive(false);
			controller.CardRevealed(this);
		}
	}

	public void Unreveal() {
		cardBack.SetActive(true);
	}

    public void OnMatched()
    {
        _matchTime = Time.fixedTime;
    }
}
