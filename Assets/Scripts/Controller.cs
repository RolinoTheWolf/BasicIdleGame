using BreakInfinity;
using System;
using TMPro;
using UnityEngine;

public class Controller : MonoBehaviour {

	#region Instance
	public static Controller Instance;
	private void Awake() {
		Instance = this;
	}
	#endregion

	[SerializeField]
	private TMP_Text moneyText;

	[SerializeField]
	private TMP_Text moneyButtonText;

	[SerializeField]
	private TMP_Text moneyPerSecondText;

	[SerializeField] Currency Currency;

	private float timer = 0f;
	private void Update() {
		timer += Time.deltaTime;
		if (timer >= 1f) {
			timer -= 1f;
			Currency.Amount += ClickPower(UpgradeType.Production);
			UpdateUi();
		}
	}

	public void GenerateMoney() {
		Currency.Amount += ClickPower(UpgradeType.ClickPower);
		UpdateUi();
	}

	private BigDouble ClickPower(UpgradeType type) {

		BigDouble total = 0;
		if (UpgradeType.ClickPower == type) {
			total += 1; // Base click power
		}

		foreach (var upgrade in UpgradeManager.Instance.GetUpgrade(type)) {
			total += upgrade.Power();
		}

		return total;
	}

	public void UpdateUi() {
		try {
			if (Currency != null) {
				moneyText.text = $"{Currency.Amount.ToString("F0")} {Currency.CurrencyName}";
				moneyButtonText.text = $"+{ClickPower(UpgradeType.ClickPower).ToString("F0")} {Currency.CurrencyName}";
				moneyPerSecondText.text = $"+{ClickPower(UpgradeType.Production).ToString("F0")}/ s";
			}
		} catch (Exception ex) {
			var t = ex;
		}
	}
}
