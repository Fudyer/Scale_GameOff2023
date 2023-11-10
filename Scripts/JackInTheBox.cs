using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class JackInTheBox : MonoBehaviour
{
	public Transform door1;
	public Transform door2;
	public Transform crank;
	public Transform jack;
	public float jackUpY;
	public float jackDownY;
	public Vector3 door1OpenV3;
	public Vector3 door2OpenV3;
	public Vector3 door1CloseV3;
	public Vector3 door2CloseV3;
	public Ease doorOpenEase;
	public Ease doorCloseEase;
	public Ease jackUpEase;
	public Ease jackDownEase;
	public float crankRotationSpeed;
	public float doorOpenSpeed;
	public float doorCloseSpeed;
	public float jackUpSpeed;
	public float jackDownSpeed;
	public float jackUpPause;
	public float zenithValue = 40f;
	public float resetValue = 30f;
	public float crankPosition;
	bool isPopping = false;
	bool isAtZenith = false;
    // Start is called before the first frame update
    void Start()
    {
	    
    }

	public static float Clamp0360(float eulerAngles)
	{
		float result = eulerAngles - Mathf.CeilToInt(eulerAngles / 360f) * 360f;
		if (result < 0)
		{
			result += 360f;
		}
		return result;
	}

	void Update()
	{
		crankPosition = crank.localEulerAngles.x;
		if (!isPopping)
		{
			// If not at zenith, rotate the crank
			if (!isAtZenith)
			{
				crank.Rotate(Vector3.right * crankRotationSpeed * Time.deltaTime);
				
				// Check if the crank is at or beyond the zenith
				if (crank.localEulerAngles.x <= zenithValue)
				{
					isAtZenith = true;
					DoJackPop();
				}
			}
			else
			{
				// Crank is at zenith, you can choose to pause it or not
				// Resume rotating (optional)
				crank.Rotate(Vector3.right * crankRotationSpeed * Time.deltaTime);

				// Check if you want to exit the zenith state and continue checking for zenith
				// For example, you can check if the crank rotates back below a certain angle
				if (crank.localEulerAngles.x >= resetValue)
				{
					isAtZenith = false;
				}
			}
		}
		
	}

	void DoJackPop() {
		isPopping = true;
		Sequence sequence = DOTween.Sequence();
		sequence.Join(door1.DOLocalRotate(door1OpenV3,doorOpenSpeed).SetEase(doorOpenEase));
		sequence.Join(door2.DOLocalRotate(door2OpenV3,doorOpenSpeed).SetEase(doorOpenEase));
		sequence.Join(jack.DOLocalMoveY(jackUpY,jackUpSpeed).SetEase(jackUpEase));
		sequence.AppendInterval(jackUpPause);
		sequence.Append(door1.DOLocalRotate(door1CloseV3,doorCloseSpeed).SetEase(doorCloseEase));
		sequence.Join(door2.DOLocalRotate(door2CloseV3,doorCloseSpeed).SetEase(doorCloseEase));
		sequence.Join(jack.DOLocalMoveY(jackDownY,jackDownSpeed).SetEase(jackDownEase));
		sequence.AppendCallback(()=>{ isPopping = false;});
	}
}
