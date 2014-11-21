using UnityEngine;
using System.Collections;

public class Scene : MonoBehaviour {
    
    public GameObject weaponGroup,switchWeapon;

    private GameObject phyWeapon, magicWeapon;
	// Use this for initialization

	void Start () {
        PlayerData playerData = PlayerData.getInstance();
        playerData.init();

        phyWeapon = buildWeapon(playerData.PhyWeaponTemplet, playerData.PhyArrowTemplet);
        magicWeapon = buildWeapon(playerData.MagicWeaponTemplet, playerData.MagicArrowTemplet);      

        //初始，魔法武器隐藏在后面，不显示
        magicWeapon.transform.localEulerAngles = new Vector3(0, 0, 180);
        magicWeapon.SetActive(false);

        SwitchWeapon sw = switchWeapon.GetComponent<SwitchWeapon>();
        sw.PhyWeapon = phyWeapon;
        sw.MagicWeapon = magicWeapon;
	}

    private GameObject buildWeapon(WeaponTemplet templet,ArrowTemplet arrowTemplet)
    {
        GameObject weaponObj = Instantiate(Resources.Load(templet.Prefab), Vector3.zero, Quaternion.identity) as GameObject;
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

	
}
