using UnityEngine;
using System.Collections;

public class UIFloatingText : MonoBehaviour {
    public GameObject textObj;
    public static UIFloatingText current;
    public float offsetY = 2f;
    void Awake()
    {
        current = this;
    }

	public void Show(Vector3 position, string content) {
        position.y = position.y + offsetY;
        GameObject txt = Instantiate(textObj, position,
            Quaternion.identity) as GameObject ;
        TextMesh guiText = txt.GetComponent<TextMesh>();

        int amt;
        bool isNumeric = int.TryParse(content, out amt);
        if(isNumeric) {
            guiText.text = content;
            guiText.color = amt > 0 ? Color.green : Color.red;
            Destroy(txt, 1f);
        }
        else
        {
            guiText.text = content;
            guiText.color = Color.black;
            Destroy(txt, 1f);
        }
        
  
    }
	

}
