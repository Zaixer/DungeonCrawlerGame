﻿using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {
    public float speed = 0.1f;

	void Update () {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * speed, 0f);
    }
}
