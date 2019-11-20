﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class OnTriggerEvent : MonoBehaviour
{
  public UnityEvent onEnter;
  public string hitTag = "Player";
  // Start is called before the first frame update
  private void OnTriggerEnter(Collider other)
  {
    if (other.tag == hitTag)
    {
      onEnter.Invoke();
    }
  }

  // Update is called once per frame

}