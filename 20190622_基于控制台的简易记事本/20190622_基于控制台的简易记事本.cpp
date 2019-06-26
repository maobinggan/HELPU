// 20190622_基于控制台的简易记事本.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//
#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>

/**
* 函 数 名: ShowNotePad
* 说    明：查看已有的记事本
* 返 回 值: void
*/
void ShowNotePad()
{
	char fileName[100];
	char content[100];

	//输入文件名
	printf("输入记事本名(不需要后缀名)：\n");
	scanf("%s", &fileName);
	getchar();
	sprintf(fileName, "%s.txt", fileName);

	//打开文件
	FILE* pFile = fopen(fileName, "r");//打开以便读取。 如果文件不存在或无法找到fopen调用失败。

	if (pFile == NULL)
	{
		printf("打开失败，不存在名为[%s]的记事本文件\n", fileName);
		system("pause");
		return;
	}
	fscanf(pFile, "%[^\n]", content);
	fclose(pFile);

	//打印文本内容
	printf("[%s] %s \n", fileName, content);
	system("pause");

}


/**
* 函 数 名: DeleteNopePad
* 说    明：删除记事本
* 返 回 值: void
*/
void DeleteNopePad()
{
	char fileName[100];
	char content[100];

	//输入文件名
	printf("输入要删除的记事本名(不需要后缀名)：\n");
	scanf("%s", &fileName);
	sprintf(fileName, "%s.txt", fileName);

	if (remove(fileName) == 0)
	{
		printf("删除记事本[%s]成功\n", fileName);
		system("pause");
	}
	else
	{
		printf("删除失败，记事本不存在\n");
		system("pause");
	}
}

/**
* 函 数 名: CreateNopePad
* 说    明：新建记事本
* 返 回 值: void
*/
void CreateNopePad()
{
	char fileName[100];
	char content[100];

	//输入文件名
	printf("输入新建的记事本名称(不需要后缀名)：\n");
	scanf("%s", &fileName);
	getchar();
	sprintf(fileName, "%s.txt", fileName);

	if (fopen(fileName, "r"))
	{
		printf("此文件的文件已存在...是否覆盖？(y / n)\n");
		char option = 0;
		scanf("%c", &option);
		if (option == 'n') { return; }
	}


	//输入文本内容
	printf("输入文本内容：\n");
	scanf("%[^\n]", &content);


	//存入文件
	FILE* pFile = fopen(fileName, "w");//打开用于写入的空文件。 如果给定文件存在，则其内容会被销毁。
	if (pFile == NULL)
	{
		printf("【error】pFile is null...");
		return;
	}

	fprintf(pFile, "%s", content);
	fclose(pFile);

	printf("新建记事本[%s]成功\n", fileName);
	system("pause");
}

/**
* 函 数 名: ToRed
* 说    明：
* 参    数: int i -
* 返 回 值: void
*/
void ToRed(int i)
{
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_INTENSITY | FOREGROUND_RED);
}


/**
* 函 数 名: ToWhite
* 说    明：
* 参    数: int i -
* 返 回 值: void
*/
void ToWhite(int i)
{
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_INTENSITY | FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE);
}

/**
* 函 数 名: main
* 说    明：
* 返 回 值: int
*/
int main()
{
	while (true)
	{
		system("cls");
		printf("\t\t************************\n");
		printf("\t\t**基于控制台的简易记事本\n");
		printf("\t\t*1.新建记事本\n");
		printf("\t\t*2.查看已保存的记事本\n");
		printf("\t\t*3.删除记事本\n");
		printf("\t\t*4.转为红色字体\n");
		printf("\t\t*5.转为白色字体\n");
		printf("\t\t************************\n");
		int option = 0;
		scanf("%d", &option);
		switch (option)
		{
			case 1:
			{
				CreateNopePad();
				break;
			}

			case 2:
			{
				ShowNotePad();
				break;
			}
			case 3:
			{
				DeleteNopePad();
				break;
			}
			case 4:
			{
				ToRed(1);
				break;
			}
			case 5:
			{
				ToWhite(1);
				break;
			}
			default:
				break;
		}
	}

	system("pause");
}
