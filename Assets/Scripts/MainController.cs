using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour {

  public Transform     littleF;
  public Button        buttonReset;
  public RectTransform buttonsContainer;

  private Quaternion   littleFTargetRot = Quaternion.identity;


  void Start() {
    buttonReset  .onClick.AddListener(onClickReset  );
    addRotateButton("x +90", new Vector3( 90,   0,   0));
    addRotateButton("x -90", new Vector3(-90,   0,   0));
    addRotateButton("y +90", new Vector3(  0,  90,   0));
    addRotateButton("y -90", new Vector3(  0, -90,   0));
    addRotateButton("z +90", new Vector3(  0,   0,  90));
    addRotateButton("z -90", new Vector3(  0,   0, -90));
  }

  void Update() {
    littleF.localRotation = Quaternion.Slerp(littleF.localRotation, littleFTargetRot, 0.2f);
  }

  void addRotateButton(string label, Vector3 eulers) {
    Button btn = Instantiate<Button>(buttonReset);
    btn.GetComponentInChildren<Text>().text = label;
    btn.onClick.AddListener(() => {
      onClickRotateEulers(eulers);
    });
    btn.transform.SetParent(buttonsContainer);
    btn.transform.localScale = Vector3.one;
  }

  void onClickReset() {
    littleFTargetRot = Quaternion.identity;
  }

  void onClickRotateEulers(Vector3 eulers) {
    littleFTargetRot = littleFTargetRot * Quaternion.Euler(eulers);
  }
}
