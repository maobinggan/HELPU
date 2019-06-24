// 20190625_基于控制台的猜拳游戏.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//
#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include <time.h>

/* 比赛得分记录 */
typedef struct RECORD
{
	int win;	//赢的次数
	int lose;	//输的次数
	int draw;	//平局的次数
};

/**
* 函 数 名: LoadData
* 说    明：从文件中读取比赛就记录
* 参    数: RECORD & record -
* 返 回 值: void
*/
void LoadData(RECORD& record)
{
	//打开文件
	FILE* pFile = fopen("record.dat", "r"); //打开以便读取。 如果文件不存在或无法找到fopen调用失败。
	if (pFile == NULL) { return; }		//如果文件不存在，说明本系统没有任何记录

	//读取
	fread(&record, sizeof(RECORD), 1., pFile);

	//关闭文件
	fclose(pFile);
	return;
}


/**
* 函 数 名: SaveData
* 说    明：将比赛得分写入文件
* 参    数: Record record -
* 返 回 值: void
*/
void SaveData(RECORD record)
{
	//打开文件
	FILE* pFile = fopen("record.dat", "w"); //打开用于写入的空文件。 如果给定文件存在，则其内容会被销毁。
	if (pFile == NULL) { printf("【error】pFile is null...\n"); return; }

	//写入比赛信息至文件
	fwrite(&record, sizeof(RECORD), 1., pFile);

	//关闭文件
	fclose(pFile);
	printf("[保存数据成功]\n");

	return;
}

/**
* 函 数 名: DropRecord
* 说    明：抹掉比赛记录
* 返 回 值: void
*/
void DropRecord(RECORD& record)
{
	//内存中的记录置零
	record.draw = 0;
	record.win = 0;
	record.lose = 0;

	//文件中的记录置零（重新以'w'方式打开一次即可）
	FILE* pFile = fopen("record.dat", "w");
	fclose(pFile);

	printf("[成功删除所有记录]\n");
}

/**
* 函 数 名: ShowScore
* 说    明：显示比赛记录
* 参    数: RECORD record -
* 返 回 值: void
*/
void ShowRecord(RECORD record)
{
	//判断是否有比赛记录
	if (record.draw == 0 && record.lose == 0 && record.win == 00)
	{
		printf("[没有比赛记录]\n");
		return;
	}

	//打印比赛记录
	printf("---------------\n");
	printf("--石头剪子布游戏\n");
	printf("--胜局：%d 局\n", record.win);
	printf("--负局：%d 局\n", record.lose);
	printf("--平局：%d 局\n", record.draw);
	printf("---------------\n");
}

/**
* 函 数 名: PlayGame
* 说    明：开始比赛
* 返 回 值: void
*/
void PlayGame(RECORD& record)
{
	while (true)
	{
		system("cls");

		//打印游戏规则
		printf("---------------\n");
		printf("--石头剪子布游戏\n");
		printf("--用户操作\n");
		printf("--0表示石头\n");
		printf("--1表示剪刀\n");
		printf("--2表示布\n");
		printf("--3回到主界面\n");
		printf("---------------\n");

		//我先出拳
		int playerCard = 0;
		scanf("%d", &playerCard);
		getchar();

		switch (playerCard)
		{
			case 0:printf("[您出的是'石头']\n"); break;
			case 1:printf("[您出的是'剪刀']\n"); break;
			case 2:printf("[您出的是'布']\n"); break;
			case 3:return;
			default:printf("[输入错误，请重新输入]\n"); system("pause"); break;
		}

		//如果输入错误，直接跳过本次循环
		if (playerCard != 2 && playerCard != 1 && playerCard != 0) { continue; }

		//电脑随机出拳
		srand((unsigned)time(NULL));	//重新生成随机数种子，确保每次随机数不同
		int bossCard = rand() % 3;		//生成小于3的随机数（0、1、2）
		switch (bossCard)
		{
			//判断胜负
			case 0:
			{
				printf("[电脑出的是出的是'石头']\n");
				if (playerCard == 0) { printf("[平局！！!]\n\n"); record.draw++; }	//玩家出石头
				if (playerCard == 1) { printf("[输咯！!]\n\n"); record.lose++; }		//玩家出剪刀
				if (playerCard == 2) { printf("[你赢了！!]\n\n");  record.win++; }	//玩家出布
				break;
			}

			case 1:
			{
				printf("[电脑出的是'剪刀']\n");
				if (playerCard == 0) { printf("[你赢了！!]\n\n"); record.win++; }	//玩家出石头
				if (playerCard == 1) { printf("[平局！！!]\n\n"); record.draw++; }	//玩家出剪刀
				if (playerCard == 2) { printf("[输咯！!]\n\n"); record.lose++; }		//玩家出布
				break;
			}

			case 2:
			{
				printf("[电脑出的是'布']\n"); 
				if (playerCard == 0) { printf("[输咯！!]\n\n"); record.lose++; }		//玩家出石头
				if (playerCard == 1) { printf("[你赢了！!]\n\n"); record.win++; }	//玩家出剪刀
				if (playerCard == 2) { printf("[平局！！!]\n\n"); record.draw++; }	//玩家出布
				break;
			}
		}

		//将比赛成绩写入文件
		SaveData(record);

		system("pause");
	}
}


int main()
{
	//从文件读取比赛记录
	RECORD record;
	memset(&record, 0x0, sizeof(RECORD));
	LoadData(record);

	while (true)
	{
		printf("\n---------------\n");
		printf("--0进入比赛\n");
		printf("--1查看比赛记录\n");
		printf("--2删除比赛记录\n");
		printf("--3比赛退出\n");
		printf("---------------\n");

		int option = 0;
		scanf("%d", &option);
		getchar();

		switch (option)
		{
			case 0:PlayGame(record); break;
			case 1:ShowRecord(record); break;
			case 2:DropRecord(record); break;
			case 3:return 0;
			default:printf("[输入错误，请重新输入]\n"); break;
		}
		
		system("pause");
	}
}
