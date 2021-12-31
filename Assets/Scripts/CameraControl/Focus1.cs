using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus1 : MonoBehaviour
{
    public Transform target;
    public float distanceUp = 5f;//相机与目标的竖直高度参数
    public float distanceAway = 10f;//相机与目标的水平距离参数
    public float smooth = 2f;//位置平滑移动插值参数值
    public float camDepthSmooth = 20f;

    void LateUpdate()
    {
        //计算出相机的位置
        Vector3 disPos = target.position + Vector3.up * distanceUp - target.forward * distanceAway;
 
        transform.position = Vector3.Lerp(transform.position, disPos, Time.deltaTime * smooth);
        //相机的角度
        transform.LookAt(target.position);
    }
    public void GetTarget(Transform target)
    {
        this.target = target;
    }
}
