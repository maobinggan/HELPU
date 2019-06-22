//
#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#include"windows.h"
//#include "easyx.h" 
#include "EasyX\easyx.h" //如果未安装easyX，可直接包含项目中的这个easyX头文件

//六张图片
IMAGE img_player;		//人物
IMAGE img_blank;		//空地
IMAGE img_destination;	//目的地
IMAGE img_box;			//箱子
IMAGE img_wall;			//墙壁
IMAGE img_gotIt;		//到达目的地的箱子
#define SIZE_IMAGE 50	//每张图片的大小（像素）

#define 空地 0
#define 墙壁 1
#define	目的地 3
#define 箱子 4
#define 人 5
#define 到达目的地的箱子 7
#define 到达目的地的人 8

//地图，共3个关卡，每个关卡都是7行8列的地图
int  map[3][7][8] =
{
	/*
		0: 空地
		1: 墙
		3: 目的地
		4: 箱子
		5：人
		7:到达目的地的箱子
		8:到达目的地的人
	*/
	{
		1, 1, 1, 1, 1, 1, 1, 1,
		1, 0, 0, 0, 0, 0, 0, 1,
		1, 0, 1, 0, 0, 0, 1, 1,
		1, 3, 0, 4, 0, 0, 3, 1,
		1, 0, 0, 0, 0, 0, 4, 1,
		1, 0, 0, 0, 5, 0, 0, 1,
		1, 1, 1, 1, 1, 1, 1, 1
	},
	{
		1, 1, 1, 1, 1, 1, 1, 1,
		1, 0, 0, 0, 0, 0, 0, 1,
		1, 3, 1, 0, 1, 1, 3, 1,
		1, 4, 0, 0, 4, 0, 3, 1,
		1, 0, 1, 0, 1, 1, 4, 1,
		1, 0, 0, 5, 0, 0, 0, 1,
		1, 1, 1, 1, 1, 1, 1, 1
	},
	{
		1, 1, 1, 1, 1, 1, 1, 1,
		1, 0, 0, 0, 0, 0, 0, 1,
		1, 3, 1, 0, 1, 1, 3, 1,
		1, 3, 4, 5, 4, 0, 3, 1,
		1, 4, 1, 0, 1, 1, 4, 1,
		1, 0, 0, 0, 0, 0, 0, 1,
		1, 1, 1, 1, 1, 1, 1, 1
	}
};

//当前关卡数，从0开始
int cas = 0;

//记录当前关卡箱子数 或者是项目和目的在一起的总数
int boxSum[3] = { 2,3,4 };

//结构体：历史记录
struct RECODE
{
	int highestRecod;//最高纪录
	int currentRecod;//当前记录
};

/**
* 函 数 名: GetPlayer
* 说    明：获取人物当前位置坐标
* 参    数: int & row -
* 参    数: int & col -
* 返 回 值: void
*/
void GetPlayer(int& row, int& col)
{
	//遍历整个地图寻找人物
	for (row = 0; row < 7; row++)
	{
		for (col = 0; col < 8; col++)
		{
			if (map[cas][row][col] == 人 || map[cas][row][col] == 到达目的地的人)
			{
				return;
			}
		}
	}
}


/**
* 函 数 名: Play
* 说    明：输入按键推箱子
* 返 回 值: void
*/
void Play()
{

	//得到人物的坐标
	int row, col;
	GetPlayer(row, col);

	//等待用户按键
	char ch = _getch();	//_getch函数不需要等待回车键就能接收s用户输入字符
	switch (ch)
	{
		//方向键 ↑ ↓ ← → 对应的ASCII码为 72 80 75 77 

		//w键W键或↑键
		case 'w':
		case 'W':
		case 72:
			if (map[cas][row - 1][col] == 空地 || map[cas][row - 1][col] == 目的地)
			{//如果上方是空地、目的地
				map[cas][row - 1][col] += 5; //空地+5=人 ； 目的地+5=到达目的地的人
				map[cas][row][col] -= 5;	//人-5=空地 ；到达目的地的人-5=目的地
			}
			//如果上方是箱子，要进一步判断能走
			else if (map[cas][row - 1][col] == 箱子 || map[cas][row - 1][col] == 到达目的地的箱子)
			{//如果上方是箱子或到达目的地的箱子，则要进一步判断能不能走
				if (map[cas][row - 2][col] == 空地 || map[cas][row - 2][col] == 目的地)
				{//如果此箱子上方是空地或目的地，则移动人物+移动箱子
					//修改箱子上方位置的状态
					map[cas][row - 2][col] += 4; //空地+4等于箱子；目的地+4=到达目的地的箱子
					//修改箱子位置的状态
					map[cas][row - 1][col] += 1; //箱子+1=人
					//修改人位置的状态
					map[cas][row][col] -= 5;	//人-5=空地 ；到达目的地的人-5=目的地
				}
			}
			//如果上方是其他东西(墙壁、人、到达目的地的人），则直接结束本次按键事件
			break;

			//s键或S键或↓键 
		case 's':
		case 'S':
		case 80:
			if (map[cas][row + 1][col] == 空地 || map[cas][row + 1][col] == 目的地)
			{//如果下方是空地、目的地
				map[cas][row + 1][col] += 5;
				map[cas][row][col] -= 5;
			}
			else if (map[cas][row + 1][col] == 箱子 || map[cas][row + 1][col] == 到达目的地的箱子)
			{//如果下方是箱子或到达目的地的箱子，则要进一步判断能不能走
				if (map[cas][row + 2][col] == 空地 || map[cas][row + 2][col] == 目的地)
				{
					map[cas][row + 2][col] += 4;
					map[cas][row + 1][col] += 1;
					map[cas][row][col] -= 5;
				}
			}
			//如果下方是其他东西(墙壁、人、到达目的地的人），则直接结束本次按键事件
			break;

			//a键或A键或←键 
		case 'a':
		case 'A':
		case 75:
			if (map[cas][row][col - 1] == 空地 || map[cas][row][col - 1] == 目的地)
			{
				map[cas][row][col - 1] = map[cas][row][col - 1] + 5;
				map[cas][row][col] = map[cas][row][col] - 5;
			}
			else if (map[cas][row][col - 1] == 箱子 || map[cas][row][col - 1] == 到达目的地的箱子)
			{
				if (map[cas][row][col - 2] == 空地 || map[cas][row][col - 2] == 目的地)
				{
					map[cas][row][col - 2] += 4;
					map[cas][row][col - 1] += 1;
					map[cas][row][col] -= 5;
				}
			}
			break;

			//d键或D键或→键
		case 'D':
		case 'd':
		case 77:
			if (map[cas][row][col + 1] == 空地 || map[cas][row][col + 1] == 目的地)
			{
				map[cas][row][col + 1] += 5;
				map[cas][row][col] -= 5;
			}
			else if (map[cas][row][col + 1] == 箱子 || map[cas][row][col + 1] == 到达目的地的箱子)
			{
				if (map[cas][row][col + 2] == 空地 || map[cas][row][col + 2] == 目的地)
				{
					map[cas][row][col + 2] += 4;
					map[cas][row][col + 1] += 1;
					map[cas][row][col] -= 5;
				}
			}
			break;
	}
}

/**
* 函 数 名: Judge
* 说    明：判断是否过关
* 返 回 值: bool
*/
bool Judge()
{
	int count = 0;
	//遍历地图，计算已到达目的地的箱子的数量
	for (int i = 0; i < 7; i++)
	{
		for (int j = 0; j < 8; j++)
		{
			if (map[cas][i][j] == 到达目的地的箱子)
				count++;
		}
	}
	//如果箱子数达到过关的要求，则判定为过关
	if (count == boxSum[cas])
	{
		return true;
	}
	return false;
}


/**
* 函 数 名: InitMap
* 说    明：初始化地图元素、绘图环境
* 返 回 值: void
*/
void InitMap()
{
	// 绘图环境初始化
	initgraph(8 * SIZE_IMAGE, 7 * SIZE_IMAGE + SIZE_IMAGE);

	// 加载图片（从文件）
	loadimage(&img_blank, _T("Image\\空地.png"), 50, 50, true);
	loadimage(&img_player, _T("Image\\人物.png"), 50, 50, true);
	loadimage(&img_destination, _T("Image\\目的地.png"), 50, 50, true);
	loadimage(&img_box, _T("Image\\箱子.png"), 50, 50, true);
	loadimage(&img_wall, _T("Image\\墙壁.png"), 50, 50, true);
	loadimage(&img_gotIt, _T("Image\\已到达目的地的箱子.png"), 50, 50, true);
}

/**
* 函 数 名: DrawMap
* 说    明：根据三维数组绘制地图
* 返 回 值: void
*/
void DrawMap()
{
	//绘制地图
	for (int i = 0; i < 7; i++)
	{
		for (int j = 0; j < 8; j++)
		{
			if (j == 0)
				printf("\t\t");
			switch (map[cas][i][j])
			{
				case 0:	//0:空地
					putimage(j * 50, i * 50, &img_blank);
					break;
				case 1://1:▆ :墙
					putimage(j * 50, i * 50, &img_wall);
					break;
				case 3://3:目的地
					putimage(j * 50, i * 50, &img_destination);
					break;
				case 4://4:到达目的地的箱子
					putimage(j * 50, i * 50, &img_box);
					break;
				case 5://5：人
				case 8://8：人与目的地重合
					putimage(j * 50, i * 50, &img_player);
					break;
				case 7://7:到达目的地的箱子
					putimage(j * 50, i * 50, &img_gotIt);
					break;
			}
		}
		printf("\n");
	}
}


/**
* 函 数 名: SaveData
* 说    明：将记录存入文件
* 参    数: RECODE & recode -
* 参    数: const char * filePath -
* 返 回 值: void
*/
void SaveData(RECODE& recode, const char* filePath)
{
	FILE* pFile = fopen(filePath, "wb");//打开用于写入的空文件。 如果给定文件存在，则其内容会被销毁。
	if (pFile == NULL) { printf("【error】pFile is null..."); return; }
	fwrite(&recode, sizeof(RECODE), 1, pFile);
	fwrite("\n", 1, 1, pFile);
	fclose(pFile);
}
/**
* 函 数 名: LoadData
* 说    明：从文件中读取记录
* 参    数: RECODE & recode -
* 参    数: const char * filePath -
* 返 回 值: void
*/
void LoadData(RECODE& recode, const char* filePath)
{
	FILE* pFile = fopen(filePath, "rb");//打开以便读取。 如果文件不存在或无法找到fopen调用失败。
	if (pFile == NULL) { return; }
	fread(&recode, sizeof(RECODE), 1, pFile);
	fclose(pFile);
}

int main()
{
	//从文件中读取历史记录
	RECODE recode = { 0 };
	LoadData(recode, "recode.txt");

	// 绘图窗口初始化
	InitMap();

	while (true)
	{
		//在while死循环中休眠1毫秒，能有效减少cpu使用率
		Sleep(1);

		//绘制地图
		DrawMap();

		//打印关卡记录
		TCHAR str[50] = { 0 };
		wsprintf(str, TEXT("当前第%d关 ，您的最高纪录：第%d关"), cas + 1, recode.highestRecod + 1);
		RECT r = { 0, 7 * SIZE_IMAGE,  7 * SIZE_IMAGE + SIZE_IMAGE, 8 * SIZE_IMAGE };
		drawtext(str, &r, DT_CENTER | DT_VCENTER | DT_SINGLELINE); //drawtext参数要求TCHAR，取决于项目的字符集

		//等待玩家输入按键
		Play();

		//判断是否过关
		if (Judge())
		{
			//先绘制一次地图
			DrawMap();

			//当前关卡数+1
			cas++;

			//提示过关
			if (cas == 3)
			{
				MessageBox(0, TEXT("太厉害了！您已通关了！"), TEXT("恭喜"), 0);
				break;
			}
			//保存记录
			recode.currentRecod = cas;
			recode.highestRecod = recode.highestRecod < cas ? cas : recode.highestRecod;
			SaveData(recode, "recode.txt");
			MessageBox(0, TEXT("过关了！"), TEXT("恭喜"), 0);

		}

	}

	// 按任意键退出
	_getch();
	closegraph();
	system("pause");

	return 0;
}
