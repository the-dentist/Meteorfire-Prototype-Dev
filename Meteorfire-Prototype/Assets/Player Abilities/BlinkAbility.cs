using System.Collections;

public class BlinkAbility : PlayerAbility {

	void Start () {
		cooldown = 0;
	}
	
	public override void effect() {
		// Player blinks towards crosshairs
	}
}
	