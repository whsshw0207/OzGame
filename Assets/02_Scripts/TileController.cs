using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public enum TILETYPE
    {
        UPANDDOWN,
        RIGHTANDLEFT,
        HEAVYTILE,
        LIGHTTILE
    }
    public TILETYPE tIleType;

    public int moveFlag = 1;  // Ÿ���� �̵� ������ ���� ǥ�� ( ���� ���� 1, ���� ���� 2 )
    public float moveSpeed = 0.5f;   // Ÿ�� �̵� �ӵ�

    void Start()
    {
        StartCoroutine(TileMoveController());
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        if(moveFlag == 1)
        {
            if(tIleType == TILETYPE.UPANDDOWN)
            {
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }
            else if(tIleType == TILETYPE.RIGHTANDLEFT)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (tIleType == TILETYPE.UPANDDOWN)
            {
                transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            }
            else if (tIleType == TILETYPE.RIGHTANDLEFT)
            {
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            }
        }
    }

    IEnumerator TileMoveController()
    {
        moveFlag = (moveFlag == 1) ? 2 : 1;

        yield return new WaitForSeconds(2);
        StartCoroutine(TileMoveController());
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        PlayerController _player = coll.gameObject.GetComponent<PlayerController>();

        if (_player != null)
        {
            // ������ Ÿ�� ����� �� ó��
            if(tIleType == TILETYPE.LIGHTTILE)
            {
                if (_player.playerType == PlayerController.PLAYERTYPE.SCARECROW)
                {

                }
                else
                {

                }
            }

            // ���ſ� Ÿ�� ����� �� ó��
            if(tIleType == TILETYPE.HEAVYTILE)
            {
                if (_player.playerType == PlayerController.PLAYERTYPE.WOODCUTTER)
                {

                }
                else
                {

                }
            }
        }
    }
}