using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyLoadingImage",2f);
    }

    private void DestroyLoadingImage()
    {
        Destroy(gameObject);
    }
}
