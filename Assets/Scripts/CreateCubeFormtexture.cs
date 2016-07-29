/*
作者名称:YHB

脚本作用:读取图片像素

建立时间:2016.7.29.14.03
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateCubeFormtexture : MonoBehaviour
{
    #region 字段
    public Renderer cube;
    public Texture2D texture;
    public float alpha = 30;

    private Dictionary<Color32, Material> colorDic = new Dictionary<Color32, Material>();
    #endregion

    void Start()
    {
        //Color32[] c = texture.GetPixels32();

        //Debug.Log(c.Length);

        /*for (int i = 0; i < c.Length; i++)
        {
            Debug.Log(c[i]);
        }*/

        //Debug.Log(texture.width);

        Create();
    }

    void Create()
    {
        int x = 0;
        int y = 0;
        int c = 0;

        foreach (Color32 color in texture.GetPixels32())
        {
            if (x >= texture.width)
            {
                x = 0;
                y++;
            }

            if (color.a > alpha)
            {
                c++;

                Debug.Log("X:" + x + "\tY:" + y);

                Renderer cubeRenderer = Instantiate(cube, transform.position + transform.right * x + transform.up * y, Quaternion.identity) as Renderer;

                if (!colorDic.ContainsKey(color))
                {
                    cubeRenderer.material.color = color;
                    colorDic.Add(color, cubeRenderer.sharedMaterial);
                }
                else
                {
                    cubeRenderer.sharedMaterial = colorDic[color];
                }

                cubeRenderer.transform.parent = this.transform;
            }

            x++;
        }

        Debug.Log(c);
    }

}
