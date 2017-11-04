using UnityEngine;
using UnityEditor;

public class Unit : MonoBehaviour {
	public string unitName;

	[SerializeField]
	protected bool isMoveable, isVulnerable, isFriendly, isPickup;

	[SerializeField]
	protected int baseAcceleration, maxspeed;

	protected int level, maxhp;

	public int getLevel() { return level; }
	public int getMaxHP() { return maxhp; }

	public virtual void levelUp() { level += 1; }
	public virtual void getKilled(Unit killer) { 
		die ();
	}

	public virtual void die() {
		Destroy (gameObject); 
	}

	[CustomEditor(typeof(Unit),true)]
	public class UnitEditor : Editor {
		public override void OnInspectorGUI() {
			Unit unit = target as Unit;

			unit.isMoveable = EditorGUILayout.Toggle ("isMoveable" , unit.isMoveable);
			unit.isVulnerable = EditorGUILayout.Toggle ("isVulnerable" , unit.isVulnerable);
			unit.isFriendly = EditorGUILayout.Toggle ("isFriendly" , unit.isFriendly);
			unit.isPickup = EditorGUILayout.Toggle ("isPickup" , unit.isPickup);

			if (unit.isMoveable) {
				unit.baseAcceleration = EditorGUILayout.IntSlider("Acceleration Rate", unit.baseAcceleration,-10,40);
				unit.maxspeed = EditorGUILayout.IntSlider("Top Speed", unit.maxspeed,-10,40);
			}
			if (GUI.changed) {
				EditorUtility.SetDirty (target);
			}
		}
	}
}
