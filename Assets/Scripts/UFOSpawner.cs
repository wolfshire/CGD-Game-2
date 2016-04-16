using UnityEngine;
using System.Collections;

public class UFOSpawner : MonoBehaviour {
	// [SerializeField]
	// private GameObject prefab;
	private WeightedSpawn[] spawnables;
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

		spawnables = this.GetComponents<WeightedSpawn> ();
		float sum = 0;
		foreach (WeightedSpawn s in spawnables) {
			sum += s.weight;
		}
		foreach (WeightedSpawn s in spawnables) {
			s.weight /= sum;
		}

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

        if (Random.Range(0f, 1f) < currentFrequency)
        {
            Debug.Log("WHAT");
            SpawnUFO();
        }
	}

	private GameObject GetRandomPrefab() {
		float r = Random.Range (0.0f, 1.0f);
		float add = 0;
		foreach (WeightedSpawn s in spawnables) {
			if (r < add + s.weight)
				return s.prefab;
			add += s.weight;
		}
		return null;
	}

	private GameObject SpawnUFO() {
		Vector3 randPos = spawnPoint.position;
		randPos.x += Random.Range (-spawnPositionRandomRange, spawnPositionRandomRange);
		randPos.z = spawnPoint.position.z;//Random.Range (-spawnPositionRandomRange, spawnPositionRandomRange);
		GameObject inst = (GameObject)Instantiate (GetRandomPrefab(), randPos, Quaternion.identity);
		inst.transform.SetParent (this.transform, false);
		inst.GetComponent<UFO> ().Init (currentBaseSpeed + currentBaseSpeed * Random.Range (speedPercentRange.x, speedPercentRange.y), direction);
        inst.active = true;
		return inst;
	}
}
