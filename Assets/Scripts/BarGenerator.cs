using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarGenerator : MonoBehaviour
{
    public List<GameObject> boxSpeed;
    public ColorData colorData;
    public float minSpaceBetweenBox;
    public float maxSpaceBetweenBox;

    private float boxStartingPoint = -3f; 
    private float unitHaftScreen = 6f;

    private void Start() {
        Debug.Log("Starting: " + boxSpeed.Count);
        BarGen();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Generator: " + other.gameObject.name);
        BarGen();
    }

    private void BarGen() {
        // Vector3 currentPos = transform.position;
        bool isValid = true;
        do {
            float spaceBox = Random.Range(minSpaceBetweenBox, maxSpaceBetweenBox);
            int boxSpeedIndex = Random.Range(0, boxSpeed.Count);
            Debug.Log("Box speed index: " + boxSpeedIndex + " count: " + boxSpeed.Count);
            boxStartingPoint += spaceBox;
            Debug.Log("boxStartingPoint: " + boxStartingPoint);
            GameObject obj = boxSpeed[boxSpeedIndex];
            // Debug.Log("gameobject name: " + obj.GetComponentsInChildren<GameObject>().Length);
            // MeshRenderer currentMesh = obj.GetComponentInChildren<GameObject>().GetComponent<MeshRenderer>();
            // int randomColorIndex = Random.Range(0, colorData.colors.Length);
            // Debug.Log("random color index :" + colorData.colors.Length);
            // currentMesh.material = colorData.colors[randomColorIndex];
            Vector3 boxPos = new Vector3(transform.position.x, boxStartingPoint);
            Instantiate(obj, boxPos, Quaternion.identity);
            if (boxPos.y > transform.position.y) 
            {
                Debug.Log("boxPos: " + boxPos);
                isValid = false;
            }
                
        } while(isValid);
        //Updated bar top position
        transform.position = new Vector3(transform.position.x, transform.position.y + unitHaftScreen, transform.position.z);
    }
}
