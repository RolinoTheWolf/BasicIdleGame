using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {

	public static UpgradeManager Instance;
	private void Awake() {
		Instance = this;
	}

	[HideInInspector]
	public List<Upgrade> Upgrades = new List<Upgrade>();

	public List<Upgrade> GetUpgrade(UpgradeType type) {
		return Upgrades.Where(upgrade => upgrade.UpgradeType == type).ToList();
	}
}

public enum UpgradeType {
	ClickPower,
	Production,
}

