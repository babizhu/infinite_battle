using UnityEngine;
using System.Collections;


/**
 * 这里直接采用接口作为基类，问题是在getComponent函数的时候无法通过泛型返回这个基类，只能通过
 * IClickEvent1 clickEvent = hit.transform.gameObject.GetComponent("IClickEvent1") as IClickEvent1;
 * 这种效率比较低，感觉也不太好，立此存照，看看以后用不用得上
 * 
 * 相应的通过泛型的版本可查询IClickEvent虚基类
 */
public interface IClickEvent1 {

    /**
     * 如果此物体是可处于选中状态的则返回true（如武器）,否则返回false(如grid)
     */
    bool click(GameObject prevChoose);

    /**
     * 取消选择时候执行
     */
    void unClick();
    /**
     * 是否反选上一个被选择项目，比如点选grid就不应该反选上一个点击对象，而点击武器模板就应该要反选择上一个点击对象
     */
    bool isUnchoosePrevObject(GameObject prevChoose);
}
