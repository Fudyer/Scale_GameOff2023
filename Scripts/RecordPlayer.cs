using UnityEngine;

public class RecordPlayer : MonoBehaviour
{
	public GameObject record; // Reference to the record GameObject
	public float rotationSpeed = 60f; // Rotation speed in degrees per second
	public float wobbleAmount = 10f;  // Maximum wobble angle in degrees
	public float wobbleFrequency = 1f; // Wobble frequency in cycles per second

	private float wobbleTimer = 0f;
	private float yRotation = 0f;

	private void Update()
	{
		// Rotate the record player constantly on the Y-axis
		float rotationAngle = rotationSpeed * Time.deltaTime;
		yRotation += rotationAngle;

		// Apply wobbling effect to the record on X and Z axes
		wobbleTimer += Time.deltaTime;
		float wobbleAngle = Mathf.Sin(wobbleTimer * wobbleFrequency * 2 * Mathf.PI) * wobbleAmount;
		Vector3 newRotation = new Vector3(wobbleAngle, yRotation, wobbleAngle);
		record.transform.rotation = Quaternion.Euler(newRotation);
	}
}
