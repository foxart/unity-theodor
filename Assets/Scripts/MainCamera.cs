using UnityEngine;

public class MainCamera : MonoBehaviour {
	[SerializeField] private Vector3 offset;
	[SerializeField] private Transform target;
	private float _distance;

	// Start is called before the first frame update
	private void Start() {
		offset = transform.position - target.position;
		_distance = 10f;
	}

	// Update is called once per frame
	private void LateUpdate() {
		var pos = target.position;
		transform.position = Vector3.Lerp(transform.position, new Vector3(pos.x, 0, pos.z) + offset, Time.deltaTime * 3);
		// Debug.Log(_distance - pos.x);
		if (_distance - pos.x < 0) {
			_distance = pos.x;

		}
	}
}
