using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipGame : MonoBehaviour
{
    public int gridSize = 5; // ���̴�С
    public GameObject gridPrefab; // ���̵�Ԫ��Ԥ�Ƽ�
    public Color[] colors; // ������ɫ����

    private bool[,] grid; // ��������
    private GameObject[,] tiles; // ���̵�Ԫ������

    // ��ʼ������
    void Start()
    {
        // �������̵�Ԫ��
        tiles = new GameObject[gridSize, gridSize];
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                GameObject tile = Instantiate(gridPrefab, new Vector3(x, y, 0), Quaternion.identity);
                tile.transform.SetParent(transform);
                tiles[x, y] = tile;
            }
        }

        // ��ʼ����������
        grid = new bool[gridSize, gridSize];
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                grid[x, y] = Random.value > 0.5f;
                tiles[x, y].GetComponent<Image>().color = grid[x, y] ? colors[0] : colors[1]; // ����������ɫ
            }
        }
    }

    // �������ʱ������ת�߼�
    public void FlipTile(int x, int y)
    {
        Flip(x, y);
        if (x > 0) Flip(x - 1, y);
        if (x < gridSize - 1) Flip(x + 1, y);
        if (y > 0) Flip(x, y - 1);
        if (y < gridSize - 1) Flip(x, y + 1);

        // �����Ϸ�Ƿ����
        if (IsGameOver())
        {
            Debug.Log("Game over");
            // �ڴ������Ϸ�����Ĵ����߼�
        }
    }

    // ��תָ��λ�õ�����
    private void Flip(int x, int y)
    {
        grid[x, y] = !grid[x, y];
        tiles[x, y].GetComponent<Image>().color = grid[x, y] ? colors[0] : colors[1]; // ����������ɫ
    }

    // �����Ϸ�Ƿ����
    private bool IsGameOver()
    {
        bool firstTile = grid[0, 0];
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                if (grid[x, y] != firstTile) return false;
            }
        }
        return true;
    }
}
