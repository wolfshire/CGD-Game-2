using UnityEngine;
using System.Collections;

public class UFOSpawner : MonoBehaviour {
	[SerializeField]
	private GameObject prefab;
	[SerializeField]
	private Transform spawnPoint;

	[SerializeField]
	private float initialPopulatingFrequency;
	[SerializeField]
	private float startingFrequency;
	[SerializeField]
	private float frequencyPercentChange;
	[SerializeField]
	private float currentFrequency;

	[SerializeField]
	private Vector3 direction;
	[SerializeField]
	private Vector2 speedPercentRange;
	[SerializeField]
	private float percentIncrease;
	[SerializeField]
	private float spawnPositionRandomRange;

	[SerializeField]
	private float startingSpeed;
	private float currentBaseSpeed;

	// Use this for initialization
	void Start () {
		currentBaseSpeed = startingSpeed;
		currentFrequency = startingFrequency;

		// Initial populating
		for (int i = 0; i < spawnPoint.position.z; i++) {
			if (Random.Range (0f, 1f) < initialPopulatingFrequency) {
				GameObject inst = SpawnUFO ();
				Vector3 pos = inst.transform.position;
				pos.z = i;
				inst.transform.position = pos;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		currentBaseSpeed += (currentBaseSpeed*percentIncrease - currentBaseSpeed) * Time.deltaTime;
		currentFrequency += (currentFrequency*frequencyPercentChange - currentFrequency) * Time.deltaTime;

		if (Random.Range (0f, 1f) < currentFrequency)
			SpawnUFO ();
	}

	private GameObject SpawnUFO() {
		Vector3 randPos = spawnPoint.position;
		randPos.x += Random.Range (-spawnPositionRandomRange, spawnPositionRandomRange);
		randPos.z = spawnPoint.position.z;//Random.Range (-spawnPositionRandomRange, spawnPositionRandomRange);
		GameObject inst = (GameObject)Instantiate (prefab, randPos, Quaternion.identity);
		inst.GetComponent<UFO> ().Init (currentBaseSpeed * Random.Range (speedPercentRange.x, speedPercentRange.y), direction);
		inst.transform.SetParent (this.transform, false);

		return inst;
	}
}
