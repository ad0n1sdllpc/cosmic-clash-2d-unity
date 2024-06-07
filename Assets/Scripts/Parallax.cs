using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.XR;
using UnityEngine;

public class Paralle : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] bool scrollLeft;

    float singleTextureWidth;

    void Start()
    {
        SetupTexture();
        if (scrollLeft) moveSpeed = -moveSpeed;
    }

    void SetupTexture()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        singleTextureWidth = sprite.texture.width / sprite.pixelsPerUnit;
    }

    void Scroll()
    {
        float delta = moveSpeed * Time.deltaTime;
        transform.position += new Vector3(delta, 0f, 0f);
    }

    void CheckReset()
    {
        if ( (Mathf.Abs(transform.position.x) - singleTextureWidth) > 0 )
        {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
        CheckReset();
    }
}
