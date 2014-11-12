using UnityEngine;
using System.Collections;

public class SwitchWeapon : IClickEvent
{
    public float speed = 10;
    public Transform weaponGroup;
    public GameObject phyWeapon;
    public GameObject magicWeapon;

    /**
     * 目标角度
     */
    private int targetAngle = 180;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override bool click(GameObject prevChoose)
    {
        //magicWeapon.SetActive(!magicWeapon.activeSelf);
        StartCoroutine(rotate());  
        
        return false;
    }

    public override void unClick()
    {
        
    }

    public override bool isUnchoosePrevObject(GameObject prevChoose)
    {
        return true;
    }

    /**
     * 旋转武器
     */
    private IEnumerator rotate()
    {
        setCurrentWeapon(true);
        while ((int)weaponGroup.eulerAngles.z != targetAngle)//我操，必须转成整型，好心塞
        {
            //print(weaponGroup.eulerAngles.z + "=" + targetAngle + "?" + (weaponGroup.eulerAngles.z == targetAngle));
            weaponGroup.rotation = Quaternion.Slerp(weaponGroup.rotation, Quaternion.Euler(0, 0, targetAngle), Time.deltaTime * speed);
            
            yield return new WaitForEndOfFrame();
        }
        
        toggle();
        setCurrentWeapon(false);
    }

    /**
     * 把放到后面的weapon设置为无效，把放到前面的weapon设置为有效
     */
    private void setCurrentWeapon(bool isBegin){
        if (isBegin)
        {
            print("begin");
            if (magicWeapon.activeSelf) magicWeapon.SetActive(false);
            else phyWeapon.SetActive(false);
        }
        else
        {
            print("end");
            if (!phyWeapon.activeSelf) magicWeapon.SetActive(true);
            else phyWeapon.SetActive(true);
        }
       // magicWeapon.SetActive(!magicWeapon.activeSelf);
        //phyWeapon.SetActive(!phyWeapon.activeSelf);
        //print(weaponGroup.localRotation.z);
        //if (weaponGroup.localRotation.z > -2)
        //{
        //    print("物理武器无效，魔法武器有效");
            
        //}
        //else
        //{
        //    print("物理武器有效，魔法武器无效");
        //    magicWeapon.SetActive(false);
        //    phyWeapon.SetActive( true );
        //}
    }
    private void toggle()
    {
        
        if (targetAngle == 0)
        {
            targetAngle = 180;
        }
        else
        {
            targetAngle = 0;
        }
    }



    
}
