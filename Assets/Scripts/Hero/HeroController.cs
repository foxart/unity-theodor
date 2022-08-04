using UnityEngine;

namespace Hero {
	public class HeroController : MonoBehaviour {
		private const float Gravity = -50f;
		private const float VelocityJump = 5f;
		[SerializeField] private LayerMask groundLayerMask;
		[SerializeField] private float runSpeed = 1;
		[SerializeField] private float jumpHeight = 2f;
		private CharacterController _characterController;
		private float _horizontalInput;
		private bool _isGrounded;
		private bool _jumpKey;
		private Rigidbody _rigidbody;
		private Vector3 _velocity;

		// Start is called before the first frame update
		private void Start() {
			_rigidbody = GetComponent<Rigidbody>();
			_characterController = GetComponent<CharacterController>();
		}

		// Update is called once per frame
		private void Update() {
			_horizontalInput = 1;

			// Face forward
			transform.forward = new Vector3(_horizontalInput, 0, Mathf.Abs(_horizontalInput) - 1);
			_isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayerMask, QueryTriggerInteraction.Ignore);
			if (_isGrounded && _velocity.y < 0) {
				_velocity.y = 0;
			} else {
				// Add gravity
				_velocity.y += Gravity * Time.deltaTime;
			}

			_characterController.Move(new Vector3(_horizontalInput * runSpeed, 0, 0) * Time.deltaTime);
			if (_isGrounded && Input.GetButtonDown("Jump")) {
				_jumpKey = true;
			}

			// Vertical velocity
			_characterController.Move(_velocity * Time.deltaTime);
		}

		private void FixedUpdate() {
			// _rigidbody.velocity = new Vector3(_horizontalInput * velocityMovement, _rigidbody.velocity.y, 0);
			//
			if (!_jumpKey) {
				return;
			}

			// _rigidbody.AddForce(Vector3.up * VelocityJump, ForceMode.VelocityChange);
			_velocity.y += Mathf.Sqrt(jumpHeight * -2 * Gravity);
			_jumpKey = false;
		}
	}
}
