/***********************************************************************
        filename:   RectMaskEffect.cs
        created:    2012.04.28
        author:     Twj

        purpose:    ��������Ч��
                    �����н�ʹ��10����������Ⱦ���֣��������£�
                    8----1/9----2
                    |     |     |
                    7-----0-----3
                    |     |     |
                    6-----5-----4
*************************************************************************/

using UnityEngine;
using System.Collections;

public class RectMaskEffect : MaskEffect
{
    // public variables
    public enum TYPE    // ����
    {
        NONE,       // ��
        CIRCLE,     // Բ��
        L_TO_R,     // ������
        R_TO_L,     // ���ҵ���
        T_TO_B,     // ���ϵ���
        B_TO_T,     // ���µ���
        LT_TO_RB,   // �����ϵ�����
        RB_TO_LT,   // �����µ�����
        LB_TO_RT,   // �����µ�����
        RT_TO_LB,   // �����ϵ�����
    }
    public TYPE type = TYPE.NONE;

    public float                halfHeight = 0.5f;      // ���ο���һ��
    public float                halfWidth = 0.5f;       // ���θߵ�һ��
    /////////////////////////////////////////////////////////////////////

    // private variables

    private const int   VERTEX_COUNT = 10;  // ��Ⱦ���ֵĶ�������
    private Vertex[]    arrVertices = new Vertex[VERTEX_COUNT];
    /////////////////////////////////////////////////////////////////////

    // public functions

    public override void StartEffect( float time )
    {
        base.StartEffect( time );

        //
        SetMeshVertices( meshFilter.sharedMesh );
        GenMaskEffectUpdate();
    }
    /////////////////////////////////////////////////////////////////////

    // protected functions

    protected override void Awake()
    {
        base.Awake();

        StartEffect( 105.0f );
    }

    // ��ʼ��Mesh����
    // @return: true��ʼ��Mesh����ɹ���false��ʼ��Mesh����ʧ��
    protected override bool InitMeshVertices( Mesh mesh )
    {
        ResetVertices();

        //
        SetMeshVertices( mesh );

        return true;
    }

    // ��ʼ��Mesh����
    // @return: true��ʼ��Mesh�����ɹ���false��ʼ��Mesh����ʧ��
    protected override bool InitMeshIndices( Mesh mesh )
    {
        int[] indices = new int[]
                        {
                            0, 1, 2,
                            0, 2, 3,
                            0, 3, 4,
                            0, 4, 5,
                            0, 5, 6,
                            0, 6, 7,
                            0, 7, 8,
                            0, 8, 9,
                        };
    
        mesh.triangles = indices;

        return true;
    }

    // ��������Ч�����¶���
    protected override void GenMaskEffectUpdate()
    {
        switch ( type )
        {
        case TYPE.CIRCLE:
            {
                maskEffectUpdate = new RectMaskEffectUpdateCircle(
                                            startTime,
                                            totalTime,
                                            halfHeight,
                                            halfWidth );
            }
            break;

        case TYPE.L_TO_R:
            {
                maskEffectUpdate = new RectMaskEffectUpdateLToR(
                                            startTime,
                                            totalTime,
                                            halfHeight,
                                            halfWidth );
            }
            break;

        case TYPE.R_TO_L:
            {
                maskEffectUpdate = new RectMaskEffectUpdateRToL(
                                            startTime,
                                            totalTime,
                                            halfHeight,
                                            halfWidth );
            }
            break;

        case TYPE.T_TO_B:
            {
                maskEffectUpdate = new RectMaskEffectUpdateTToB(
                                            startTime,
                                            totalTime,
                                            halfHeight,
                                            halfWidth );
            }
            break;

        case TYPE.B_TO_T:
            {
                maskEffectUpdate = new RectMaskEffectUpdateBToT(
                                            startTime,
                                            totalTime,
                                            halfHeight,
                                            halfWidth );
            }
            break;

        case TYPE.LT_TO_RB:
            {
                maskEffectUpdate = new RectMaskEffectUpdateLTToRB(
                                            startTime,
                                            totalTime,
                                            halfHeight,
                                            halfWidth,
                                            meshFilter.sharedMesh );
            }
            break;

        case TYPE.RB_TO_LT:
            {
                maskEffectUpdate = new RectMaskEffectUpdateRBToLT(
                                            startTime,
                                            totalTime,
                                            halfHeight,
                                            halfWidth,
                                            meshFilter.sharedMesh );
            }
            break;

        case TYPE.LB_TO_RT:
            {
                maskEffectUpdate = new RectMaskEffectUpdateLBToRT(
                                            startTime,
                                            totalTime,
                                            halfHeight,
                                            halfWidth,
                                            meshFilter.sharedMesh );
            }
            break;

        case TYPE.RT_TO_LB:
            {
                maskEffectUpdate = new RectMaskEffectUpdateRTToLB(
                                            startTime,
                                            totalTime,
                                            halfHeight,
                                            halfWidth,
                                            meshFilter.sharedMesh );
            }
            break;

        default:
            maskEffectUpdate = null;
            break;
        }
    }
    /////////////////////////////////////////////////////////////////////

    // private functions

    // ���ö�������
    private void ResetVertices()
    {
        arrVertices[0].pos = new Vector3( 0.0f, 0.0f, 0.0f );
        arrVertices[1].pos = new Vector3( 0.0f, halfHeight, 0.0f );
        arrVertices[2].pos = new Vector3( halfWidth, halfHeight, 0.0f );
        arrVertices[3].pos = new Vector3( halfWidth, 0.0f, 0.0f );
        arrVertices[4].pos = new Vector3( halfWidth, -halfHeight, 0.0f );
        arrVertices[5].pos = new Vector3( 0.0f, -halfHeight, 0.0f );
        arrVertices[6].pos = new Vector3( -halfWidth, -halfHeight, 0.0f );
        arrVertices[7].pos = new Vector3( -halfWidth, 0.0f, 0.0f );
        arrVertices[8].pos = new Vector3( -halfWidth, halfHeight, 0.0f );
        arrVertices[9].pos = new Vector3( 0.0f, halfHeight, 0.0f );
    }

    // ����Mesh��������
    private void SetMeshVertices( Mesh mesh )
    {
        Vector3[] vertices = new Vector3[arrVertices.Length];
        for ( int i = 0; i < arrVertices.Length; ++i )
        {
            vertices[i] = arrVertices[i].pos;
        }

        mesh.vertices = vertices;
    }
    /////////////////////////////////////////////////////////////////////
}