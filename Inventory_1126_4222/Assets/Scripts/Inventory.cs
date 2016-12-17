using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	private RectTransform inventoryRect;

	private float inventoryWidth,inventoryHeight;

	public int slots;//numbers of items 背包里总元素个数
	public int rows;

	public float slotPaddingLeft, slotPaddingTop;

	public float slotSize;

	public GameObject slotPrefab;

	private List<GameObject> allSlots;

	// Use this for initialization
	void Start () {
		CreatLayout ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void CreatLayout(){
		allSlots = new List<GameObject> ();

		inventoryWidth = (slots / rows) * (slotSize + slotPaddingLeft) + slotPaddingLeft;//背包宽度

		inventoryHeight = rows * (slotSize + slotPaddingTop) + slotPaddingTop;//背包高度

		inventoryRect = GetComponent<RectTransform> ();

		inventoryRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, inventoryWidth);
		inventoryRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, inventoryHeight);

		int colunms = slots / rows;//列数

		for (int y = 0; y < rows; y++) 
		{
			for (int x = 0; x < colunms; x++) 
			{
				GameObject newSlots = (GameObject)Instantiate (slotPrefab);

				RectTransform slotRect = newSlots.GetComponent<RectTransform> ();

				newSlots.name = "Slot";

				newSlots.transform.SetParent (this.transform.parent);//成为当前物体的自物件

				slotRect.localPosition = inventoryRect.localPosition + 
										 new Vector3 (slotPaddingLeft + (x + 1) + (slotSize * x), 
													 -slotPaddingTop * (y + 1) - (slotSize * y));//左上开始坐标为0，0

				slotRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, slotSize);
				slotRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, slotSize);

				allSlots.Add (newSlots);
			}
		}


	}
}
