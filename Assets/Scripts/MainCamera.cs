using UnityEngine;

public class MainCamera : MonoBehaviour {
	[SerializeField] private Vector3 offset;
	[SerializeField] private Transform target;

	// Start is called before the first frame update
	private void Start() {
		offset = transform.position - target.position;
	}

	// Update is called once per frame
	private void LateUpdate() {
		var pos = target.position;
		transform.position = Vector3.Lerp(transform.position, new Vector3(pos.x, pos.y, pos.z) + offset, Time.deltaTime * 3);
	}
}
