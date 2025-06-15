using UnityEngine;
using UnityEngine.UI;

public class NavigationButton : MonoBehaviour {

	[SerializeField]
	private GameObject Panel;

	public void SetVisible(bool visible) {
		Panel.SetActive(visible);

		Image image = GetComponent<Image>();
		if (visible) {
			image.color = Color.white;
		} else {
			image.color = Color.gray;
		}
	}

	public void Click() {
		NavigationManager.Instance.ButtonClick(this);
	}
}
