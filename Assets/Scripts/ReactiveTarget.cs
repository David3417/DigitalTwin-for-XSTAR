﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(0, -45.0f, 0);

        yield return new WaitForSeconds(2.5f);

//        Destroy(this.gameObject);
    }
}
