using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementPoolController : MonoBehaviour
{

    /// <summary>
    /// Analog of destroy. All components are disabled, object hiding.
    /// </summary>
    public void AddInPool()
    {
        gameObject.SetActive(false);
    }

  
}