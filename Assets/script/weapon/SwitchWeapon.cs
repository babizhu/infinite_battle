using UnityEngine;
using System.Collections;

public class SwitchWeapon : IClickEvent
{
    public float speed = 5;
    public Transform weaponGroup;
    public GameObject PhyWeapon;
    public GameObject MagicWeapon;
    //物攻武器切换到后台之后应该保持的标准角度
    private static Vector3 PHY_WEAPON_STANDARD_ANGLE = new Vector3(0, 0, 0);

    //法攻武器切换到后台之后应该保持的标准角度
    private static Vector3 MAGIC_WEAPON_STANDARD_ANGLE = new Vector3(0, 0, 180);

    /**
     * 切换武器需要旋转，在旋转的时候是不能在接受点击命令的
     */
    private bool canClick = true;
    /**
     * 目标角度
     */
    private int targetAngle = 180;
	

    public override bool click(GameObject prevChoose)
    {
        
        if (canClick)
        {
            canClick = false;
            StartCoroutine(rotateWeapon());
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
    private IEnumerator rotateWeapon()
    {
        setCurrentWeaponActive();
        while ((int)weaponGroup.eulerAngles.z != targetAngle)//我操，必须转成整型，好心塞
        {
            //print(weaponGroup.eulerAngles.z + "=" + targetAngle + "?" + (weaponGroup.eulerAngles.z == targetAngle));
            weaponGroup.rotation = Quaternion.Slerp(weaponGroup.rotation, Quaternion.Euler(0, 0, targetAngle), Time.deltaTime * speed);
            
            yield return new WaitForEndOfFrame();
        }
        weaponGroup.eulerAngles = new Vector3(0, 0, targetAngle);//强制赋值，以免出现小数点后面莫名其妙的位数
        toggle();
        
    }

    /**
     * 把放到后面的weapon设置为无效，把放到前面的weapon设置为有效
     */
    private void setCurrentWeaponActive(){
        if (targetAngle == 180)
        {
            MagicWeapon.SetActive(true);
        }
        else
        {
            PhyWeapon.SetActive(true);
        }
        
    }
    private void toggle()
    {
        
        if (targetAngle == 180)
        {
            targetAngle = 0;
            PhyWeapon.transform.localEulerAngles = PHY_WEAPON_STANDARD_ANGLE;
            PhyWeapon.SetActive(false);
        }
        else
        {
            targetAngle = 180;
            MagicWeapon.transform.localEulerAngles = MAGIC_WEAPON_STANDARD_ANGLE;
            MagicWeapon.SetActive(false);
            
        }
        canClick = true;
    }    
}
