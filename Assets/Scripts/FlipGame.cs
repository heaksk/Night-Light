using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipGame : MonoBehaviour
{
    public int gridSize = 5; // 棋盘大小
    public GameObject gridPrefab; // 棋盘单元格预制件
    public Color[] colors; // 棋子颜色数组

    private bool[,] grid; // 棋盘数据
    private GameObject[,] tiles; // 棋盘单元格数组

    // 初始化棋盘
    void Start()
    {
        // 创建棋盘单元格
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

        // 初始化棋盘数据
        grid = new bool[gridSize, gridSize];
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                grid[x, y] = Random.value > 0.5f;
                tiles[x, y].GetComponent<Image>().color = grid[x, y] ? colors[0] : colors[1]; // 设置棋子颜色
            }
        }
    }

    // 点击棋子时触发反转逻辑
    public void FlipTile(int x, int y)
    {
        Flip(x, y);
        if (x > 0) Flip(x - 1, y);
        if (x < gridSize - 1) Flip(x + 1, y);
        if (y > 0) Flip(x, y - 1);
        if (y < gridSize - 1) Flip(x, y + 1);

        // 检查游戏是否结束
        if (IsGameOver())
        {
            Debug.Log("Game over");
            // 在此添加游戏结束的处理逻辑
        }
    }

    // 反转指定位置的棋子
    private void Flip(int x, int y)
    {
        grid[x, y] = !grid[x, y];
        tiles[x, y].GetComponent<Image>().color = grid[x, y] ? colors[0] : colors[1]; // 更新棋子颜色
    }

    // 检查游戏是否结束
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
