using UnityEngine;
using UnityEditor;
using System;

public class Unit : MonoBehaviour {
	public string unitName;
	public bool isMoveable, isVulnerable, isFriendly, isPickup;
	public int movespeed, maxspeed, maxhp, level;

	public int getLevel() { return level; }
	public int getMaxhp() { return maxhp; }

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
			Unit myUnit = target as Unit;

			myUnit.isMoveable = EditorGUILayout.Toggle ("isMoveable" , myUnit.isMoveable);
			if (myUnit.isMoveable) {
				myUnit.movespeed = EditorGUILayout.IntSlider("Acceleration Rate",myUnit.movespeed,-10,40);
				myUnit.maxspeed = EditorGUILayout.IntSlider("Top Speed",myUnit.maxspeed,-10,40);
			}
			if (GUI.changed) {
				EditorUtility.SetDirty (target);
			}
		}
	}
}