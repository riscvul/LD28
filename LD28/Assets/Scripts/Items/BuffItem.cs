using UnityEngine;
using System;
using System.Collections;

public class BuffItem : Item {
	private Hashtable buffs;

	public BuffItem() {
	}

	public BuffItem(Hashtable ht) {
		buffs = ht;
	}

	public void AddBuff(BaseStat stat, int mod) {
		try {
			buffs.Add(stat.Name, mod);
		}
		catch(Exception e) {
			Debug.LogWarning(e.ToString());
		}
	}

	public void RemoveBuff(string name) {
		buffs.Remove(name);
	}

	public int BuffCount() {
		return buffs.Count;
	}

	public Hashtable GetBuffs() {
		return buffs;
	}
}
