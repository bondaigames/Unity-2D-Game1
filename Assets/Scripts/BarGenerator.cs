using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarGenerator : MonoBehaviour
{
    public List<GameObject> boxSpeed;
    public ColorData colorData;
    public float minSpaceBetweenBox;
    public float maxSpaceBetweenBox;

    private float unitHaftScreen = 6f;
    private GameObject[] bars;

    private Camera cam;

    private void Start() {
        Debug.Log("Starting: " + boxSpeed.Count);
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        InitializedBar(8);
    }

    private void Update()
    {
        RecreatedBar();
    }

    private void InitializedBar(int numberOfBars)
    {
        Debug.Log("init:  " + cam.transform.position.y);
        bars = new GameObject[numberOfBars];
        float posY = cam.transform.position.y;
        for (int i = 0; i < numberOfBars; i++)
        {
            float spaceBox = GetRandomSpaceBox();
            GameObject obj = GetRandomObject();
            posY += spaceBox;
            //Debug.Log("cam: " + cam.transform.position.y + "posY:  " + posY + " space box: " + spaceBox);
            Vector3 boxPos = new Vector3(transform.position.x, posY);
            GameObject gamePlay = GameObject.FindWithTag("GamePlay");
            GameObject newBar = Instantiate(obj, boxPos, Quaternion.identity);
            newBar.transform.parent = gamePlay.transform;
            bars[i] = newBar;
        }
    }

    private GameObject GetRandomObject()
    {
        int boxSpeedIndex = Random.Range(0, boxSpeed.Count);
        return boxSpeed[boxSpeedIndex];
    }

    private float GetRandomSpaceBox()
    {
        float spaceBox = Random.Range(minSpaceBetweenBox, maxSpaceBetweenBox);
        return spaceBox;
    }

    private void RecreatedBar()
    {
        float fullScreenSize = unitHaftScreen * 2;
        for (int i = 0; i < bars.Length; i++)
        {
            GameObject bar = bars[i];
            //calculated from center to bar
            float bottomPosY = cam.transform.position.y - fullScreenSize;
            if (bar.transform.position.y < bottomPosY)
            {
                //Debug.Log("bar pos: " + bar.transform.position + " bar: " + bar.gameObject.name + " pos Y:" + bottomPosY);
                Destroy(bar);
                //Recreated bar on top
                float spaceBox = GetRandomSpaceBox();
                GameObject obj = GetRandomObject();

                //Debug.Log("first bar pos: " + i + " top object pos: " + (bars.Length - i - 1));
                int previousIndex = i - 1 < 0 ? bars.Length - 1 : i - 1;
                GameObject topObject = bars[previousIndex];
                Vector3 boxPos = new Vector3(transform.position.x, topObject.transform.position.y + spaceBox);

                GameObject gamePlay = GameObject.FindWithTag("GamePlay");
                GameObject newBar = Instantiate(obj, boxPos, Quaternion.identity);
                newBar.transform.parent = gamePlay.transform;
                bars[i] = newBar;


                //bars[i] = Instantiate(obj, boxPos, Quaternion.identity);
            }
        }
    }
}
