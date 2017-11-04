using UnityEngine;

public class EventManager : MonoBehaviour
{
	public delegate void UnitKillEvent(Unit source, Unit victim);
	public static event UnitKillEvent signalKill;

	public static void SignalKill(Unit source, Unit victim) {
		signalKill (source, victim);
	}
}

