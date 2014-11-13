﻿using UnityEngine;
using System.Collections;

public class Scene : MonoBehaviour {
    
    public GameObject weaponGroup,switchWeapon;

    private GameObject phyWeapon, magicWeapon;
	// Use this for initialization
	void Awake () {
        Player player = Player.getInstance();
        

        //GameObject phyArrow = buildArrow(player.PhyArrowTemplet);
        //GameObject magicArrow = buildArrow(player.MagicArrowTemplet);

        phyWeapon = buildWeapon(player.PhyWeaponTemplet, player.PhyArrowTemplet);
        magicWeapon = buildWeapon(player.MagicWeaponTemplet, player.MagicArrowTemplet);      

        //初始，魔法武器隐藏在后面，不显示
        magicWeapon.transform.localEulerAngles = new Vector3(0, 0, 180);
        magicWeapon.SetActive(false);
	}

    private GameObject buildWeapon(WeaponTemplet templet,ArrowTemplet arrowTemplet)
    {
        GameObject weaponObj = Instantiate(Resources.Load(templet.Prefab), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        weaponObj.transform.parent = weaponGroup.transform;
        weaponObj.transform.localPosition = templet.Position;
        AbstractWeapon weapon = weaponObj.GetComponent<AbstractWeapon>();
        weapon.Arrow = buildArrow(arrowTemplet);
        weapon.ArrowTemplet = arrowTemplet;
        weapon.applyTemplet(templet);
        return weaponObj;
    }

    private GameObject buildArrow(ArrowTemplet templet)
    {
        //print(templet.Prefab);
        GameObject arrowObj = Resources.Load(templet.Prefab) as GameObject;
        //AbstractArrow arrow = arrowObj.GetComponent<AbstractArrow>();
        
        
        return arrowObj;
    }

    void Start() {
        SwitchWeapon sw = switchWeapon.GetComponent<SwitchWeapon>();
        sw.PhyWeapon = phyWeapon;
        sw.MagicWeapon = magicWeapon;
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
