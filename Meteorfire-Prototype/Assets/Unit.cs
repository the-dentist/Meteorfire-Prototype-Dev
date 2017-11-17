using UnityEngine;
using UnityEditor;

public class Unit : MonoBehaviour {
	public string unitName;

	[SerializeField]
	protected bool isMoveable, isVulnerable, isFriendly, isPickup;

	[SerializeField]
	protected int baseAcceleration, maxspeed, armor;

	protected int level, maxhp;

	public int getLevel() { return level; }
	public int getMaxHP() { return maxhp; }

	public virtual void levelUp() { level += 1; }

	public virtual void damage (int damage, Unit source) {
		HealthManager hm = GetComponent<HealthManager> ();
		hm.damage (damage, source);
	}

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

			unit.isMoveable = EditorGUILayout.Toggle ("Unit is Moveable" , unit.isMoveable);
			unit.isVulnerable = EditorGUILayout.Toggle ("Unit is Vulnerable" , unit.isVulnerable);
			unit.isFriendly = EditorGUILayout.Toggle ("Unit is Friendly" , unit.isFriendly);
			unit.isPickup = EditorGUILayout.Toggle ("Unit is a Pickup" , unit.isPickup);
			unit.armor = EditorGUILayout.IntField ("Armor Value", unit.armor);

			if (unit.isMoveable) {
				unit.baseAcceleration = EditorGUILayout.IntField("Base Acceleration", unit.baseAcceleration);
				unit.maxspeed = EditorGUILayout.IntField("Top Speed", unit.maxspeed);
			}

			if (GUI.changed) {
				EditorUtility.SetDirty (target);
			}
		}
	}
}
