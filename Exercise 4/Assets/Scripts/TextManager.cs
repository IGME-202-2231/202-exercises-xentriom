using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    // Variable field
    [SerializeField] InputController inputController;
    [SerializeField] TextMesh textMesh;
    private TextMesh text;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate text
        text = Instantiate(textMesh, new Vector3(0, -1.85f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // Update text based on collision type
        switch (inputController.Collision)
        {
            case CollisionType.AABB:
                text.text = "Current Mode: AABB";
                break;
            case CollisionType.Circle:
                text.text = "Current Mode: Circle";
                break;
        }
    }
}
