using UnityEngine;

namespace Hero {

	public class HeroController : MonoBehaviour {
		private readonly float gravity = -50f;
		private CharacterController _characterController;
		private Vector3 velocity;

		// Start is called before the first frame update
		private void Start() {
			_characterController = GetComponent<CharacterController>();
		}

		// Update is called once per frame
		private void Update() {
			// Add gravity
			velocity.y += gravity * Time.deltaTime;
			// Vertical velocity
			_characterController.Move(velocity * Time.deltaTime);
		}
	}
}
