using UnityEngine;

public class NavigationManager : MonoBehaviour {

	#region Instance
	public static NavigationManager Instance;
	private void Awake() {
		Instance = this;
	}
	#endregion

	[SerializeField]
	private NavigationButton[] NavigationButtons;

	[SerializeField]
	public NavigationButton ActiveMenu;

	private void Start() {
		UpdatePanel();

	}

	public void ButtonClick(NavigationButton button) {
		if (ActiveMenu == button) {
			ActiveMenu = null;
		} else {
			ActiveMenu = button;
		}
		UpdatePanel();
	}

	private void UpdatePanel() {
		for (int i = 0; i < NavigationButtons.Length; i++) {
			NavigationButtons[i].SetVisible(false);
		}

		ActiveMenu?.SetVisible(true);
	}
}
