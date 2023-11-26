using UnityEngine;
using DiasGames.Components;
using DiasGames.Controller;
using System.Collections;

using Sirenix.OdinInspector;
using DG.Tweening;

public class CheckpointManager : MonoBehaviour
{
	[SerializeField] private GameObject player = null;
	public float deathDelay = 2f;
	public float reviveTime = 2f;
	public float fadebuffer = 1f;
	// player components
	private CSPlayerController _playerController;
	private Ragdoll _playerRagdoll;
	// controller vars
	private bool _isRestarting = false;
	private Health _playerHealth;
	public static CheckpointManager Instance { get; private set;}
	private void Awake()
	{
		if(Instance == null) Instance = this;
		if (player == null)
			player = GameObject.FindGameObjectWithTag("Player");

		_playerController = player.GetComponent<CSPlayerController>();
		_playerRagdoll = player.GetComponent<Ragdoll>();
		_playerHealth = player.GetComponent<Health>();
	}
	[Button]
	public void SetCheckPointPos(Vector3 pos) {
		GameJefe.Instance.checkpointPositionMarker.position = pos;
	}
	[Button]
	public void SetCheckPointHere() {
		SetCheckPointPos(player.transform.position);
	}
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		if(_isRestarting) {
			player.transform.position = GameJefe.Instance.checkpointPositionMarker.position;
		}
	}
	private void OnEnable()
	{
		_playerController.OnDead += DoCheckPoint;
	}
	private void OnDisable()
	{
		_playerController.OnDead -= DoCheckPoint;
	}
	private void DoCheckPoint() {
		Sequence sequence = DOTween.Sequence();
		sequence.AppendInterval(deathDelay);
		sequence.AppendCallback(() => {
			
			GameJefe.Instance.transition.fadeOut();
			
		});
		sequence.AppendInterval(GameJefe.Instance.transition.transitionTime + fadebuffer);
		sequence.AppendCallback(() => {
			_isRestarting = true;
			
		});
		
		
		sequence.AppendInterval(reviveTime);
		sequence.AppendCallback(() => {
			GameJefe.Instance.transition.fadeIn();
			_playerHealth.RestoreFullHealth();
			_playerRagdoll.DeactivateRagdoll();
			_isRestarting = false;
		});
	}




}
