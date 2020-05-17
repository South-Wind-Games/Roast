using System;
using System.Collections;
using System.Collections.Generic;
using Roasts;
using UnityEngine;

public abstract class Others<T> : Skill<T> where T : SkillData
{
    // Start is called before the first frame update
    protected void OnTriggerEnter(Collider other) {}
    protected void OnTriggerStay(Collider other) {}
    protected void OnTriggerExit(Collider other) {}
    protected void OnPlayerEnter(RoastPlayer other) {}
    protected void OnPlayerStay(RoastPlayer other) {}
    protected void OnPlayerExit(RoastPlayer other) {}
    protected void OnSkillEnter(Skill<T> other) {}
    protected void OnSkillStay(Skill<T> other) {}
    protected void OnSkillExit(Skill<T> other) {}
}
