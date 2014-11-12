using UnityEngine;
using System.Collections;

public class SwitchWeapon : IClickEvent
{
    public float speed = 10;
    public Transform weaponGroup;
    public GameObject phyWeapon;
    public GameObject magicWeapon;

    /**
     * 切换武器需要旋转，在旋转的时候是不能在接受点击命令的
     */
    private bool canClick = true;
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
        if (canClick)
        {
            canClick = false;
            StartCoroutine(rotate());
        }
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
        setCurrentWeapon();
        while ((int)weaponGroup.eulerAngles.z != targetAngle)//我操，必须转成整型，好心塞
        {
            //print(weaponGroup.eulerAngles.z + "=" + targetAngle + "?" + (weaponGroup.eulerAngles.z == targetAngle));
            weaponGroup.rotation = Quaternion.Slerp(weaponGroup.rotation, Quaternion.Euler(0, 0, targetAngle), Time.deltaTime * speed);
            
            yield return new WaitForEndOfFrame();
        }
        
        toggle();
        
    }

    /**
     * 把放到后面的weapon设置为无效，把放到前面的weapon设置为有效
     */
    private void setCurrentWeapon(){
        
            magicWeapon.SetActive(true);
        
            phyWeapon.SetActive(true);
        
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
            phyWeapon.SetActive(false);
        }
        else
        {
            targetAngle = 0;
            magicWeapon.SetActive(false);
            
        }
        canClick = true;
    }



    
}
