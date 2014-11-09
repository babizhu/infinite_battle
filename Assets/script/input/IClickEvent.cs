using UnityEngine;
using System.Collections;

public abstract class IClickEvent : MonoBehaviour {

    public abstract bool click(GameObject prevChoose);

    /**
     * 取消选择时候执行
     */
    public abstract void unClick();
    /**
     * 是否反选上一个被选择项目，比如点选grid就不应该反选上一个点击对象，而点击武器模板就应该要反选择上一个点击对象
     */
    public abstract bool isUnchoosePrevObject(GameObject prevChoose);
}
