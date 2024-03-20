using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using UnityEngine;
using Random = System.Random;

public class AIActionBatFlyToLocation : AIAction {
		/// if this is true, movement will be constrained to not overstep a certain distance to the target on the x axis
		public float MinimumXDistance = 1f;
		
		protected CharacterMovement _characterMovement;
		private List<Transform> _possibleTargets;

		private bool _hasDelayed = false;
		private int _currentTransformIndex = -1;

		/// <summary>
		/// On init we grab our CharacterMovement ability
		/// </summary>
		public override void Initialization()
		{
			if(!ShouldInitialize) return;
			base.Initialization();
			_characterMovement = this.gameObject.GetComponentInParent<Character>()?.FindAbility<CharacterMovement>();
			_possibleTargets = this.gameObject.GetComponentInParent<HauntedHouseRoom>()?.moveableLocations;
		}

		/// <summary>
		/// On PerformAction we move
		/// </summary>
		public override void PerformAction()
		{
			Move();
		}

		/// <summary>
		/// Moves the character towards the target if needed
		/// </summary>
		protected virtual void Move()
		{
			if (!_hasDelayed) {
				return;
			}

			if (this.transform.position.x < _brain.Target.position.x) {
				_characterMovement.SetHorizontalMovement(1f);
			}
			else {
				_characterMovement.SetHorizontalMovement(-1f);
			}

			if (this.transform.position.y < _brain.Target.position.y) {
				_characterMovement.SetVerticalMovement(1f);
			}
			else {
				_characterMovement.SetVerticalMovement(-1f);
			}

			if (Mathf.Abs(this.transform.position.x - _brain.Target.position.x) < MinimumXDistance) {
				_characterMovement.SetHorizontalMovement(0f);
			}

			if (Mathf.Abs(this.transform.position.y - _brain.Target.position.y) < MinimumXDistance) {
				_characterMovement.SetVerticalMovement(0f);
			}

			if (Mathf.Abs(this.transform.position.x - _brain.Target.position.x) < MinimumXDistance && Mathf.Abs(this.transform.position.y - _brain.Target.position.y) < MinimumXDistance) {
				_hasDelayed = false;
				StartCoroutine(delayBeforeMoving());
			}
		}

		private IEnumerator delayBeforeMoving() {
			float delay = UnityEngine.Random.Range(2.0f, 7.0f);
			yield return new WaitForSeconds(delay);
			getNextTarget(_possibleTargets.Count);
		}


		private void getNextTarget(int listLength) {
			Random rnd = new Random();
			int randomIndex = rnd.Next(0, listLength);

			do {
				randomIndex = rnd.Next(0, listLength);
			} 
			while (randomIndex == _currentTransformIndex);

			_currentTransformIndex = randomIndex;
			_brain.Target = _possibleTargets[randomIndex];
			_hasDelayed = true;
		}

		/// <summary>
		/// On exit state we stop our movement
		/// </summary>
		public override void OnExitState()
		{
			base.OnExitState();
			
			StopAllCoroutines();

			_characterMovement?.SetHorizontalMovement(0f);
			_characterMovement?.SetVerticalMovement(0f);
		}

		public override void OnEnterState() {
			getNextTarget(_possibleTargets.Count);
		}
}
