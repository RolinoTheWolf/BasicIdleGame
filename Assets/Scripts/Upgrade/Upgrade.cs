using BreakInfinity;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Upgrade : MonoBehaviour {

	#region Text 

	[SerializeField]
	public TMP_Text LevelText;

	[SerializeField]
	public TMP_Text NameText;

	[SerializeField]
	public TMP_Text CostText;

	#endregion

	[SerializeField]
	private BigDouble BasePower;

	[SerializeField]
	private BigDouble BaseCost;

	[SerializeField]
	private BigDouble CostMultiplier;

	[SerializeField]
	private BigDouble Level;

	[SerializeField]
	private Currency Currency;

	[SerializeField]
	public UpgradeType UpgradeType;

	private void Start() {
		UpdateUI();
		UpgradeManager.Instance.Upgrades.Add(this);
	}

	public void BuyUpgrade() {
		if (Currency.Amount >= Cost()) {
			Currency.Amount -= Cost();
			Level++;
			UpdateUI();
		}
	}

	private BigDouble Cost() {
		return BaseCost * BigDouble.Pow(CostMultiplier, Level);
	}

	public BigDouble Power() {
		return BasePower * Level;
	}

	private void UpdateUI() {
		NameText.text = $"+{BasePower}";
		LevelText.text = Level.ToString();
		if (Currency != null) {
			CostText.text = $"{Cost().ToString("F0")} {Currency.CurrencyName}";
		}
		Controller.Instance?.UpdateUi();

	}

	// This method is called when the script is loaded or a value is changed in the inspector
	private void OnValidate() {
		UpdateUI();
	}
}
