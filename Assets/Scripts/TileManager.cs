using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
	private const int TileSize = 2;
	private const int TilesToDisplay = 14;
	[SerializeField] private GameObject[] tilePrefabs;
	[SerializeField] private Transform player;
	private List<GameObject> _tileList;
	private float _tilePositionX;

	// Start is called before the first frame update
	private void Start() {
		_tileList = new List<GameObject>();
		for (var i = 0; i < TilesToDisplay; i++) {
			CreateTile(0);
		}
	}

	// Update is called once per frame
	private void Update() {
		if (!(player.transform.position.x > _tilePositionX - TilesToDisplay * TileSize / 1.5)) {
			return;
		}

		CreateTile(0.5f);
		DeleteTile();
	}

	private void CreateTile(float prefabIndex ) {
		var tileGameObject = Instantiate(tilePrefabs[0], transform);
		tileGameObject.transform.position = new Vector3(_tilePositionX, player.position.y + prefabIndex, 0);
		_tilePositionX += TileSize;
		_tileList.Add(tileGameObject);
	}

	private void DeleteTile() {
		Destroy(_tileList[0]);
		_tileList.RemoveAt(0);
	}
}
