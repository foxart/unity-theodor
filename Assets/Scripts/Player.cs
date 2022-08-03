using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField] private Transform groundCheckTransform;
	[SerializeField] private LayerMask playerMask;
	[SerializeField] private float velocityJump = 5;
	[SerializeField] private float velocityMovement = 3;
	private readonly Collider[] _overlapResults = new Collider[10];
	private float _horizontalInput;
	private bool _jumpKeyPressed;
	private Rigidbody _rigidbody;

	// Start is called before the first frame update
	private void Start() {
		// velocityJump = 5;
		// velocityMovement = 3;
		_rigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	private void Update() {
		_horizontalInput = Input.GetAxis("Horizontal");
		// Check is space key is pressed down
		if (Input.GetKeyDown(KeyCode.Space)) {
			_jumpKeyPressed = true;
		}
	}

	// FixedUpdate is called once per physics update
	private void FixedUpdate() {
		_rigidbody.velocity = new Vector3(_horizontalInput * velocityMovement, _rigidbody.velocity.y, 0);
		if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0) {
			// return;
		}

		if (!_jumpKeyPressed) {
			return;
		}

		_rigidbody.AddForce(Vector3.up * velocityJump, ForceMode.VelocityChange);
		_jumpKeyPressed = false;
	}

	private void OnCollisionEnter(Collision collision) { }

	private void OnCollisionExit(Collision collision) { }
}
