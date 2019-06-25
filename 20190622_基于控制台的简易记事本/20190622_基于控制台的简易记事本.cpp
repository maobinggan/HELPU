// 20190622_基于控制台的简易记事本.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//
#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>
#include <string.h>

#include<windows.h>
#include<Commdlg.h>//打开保存文件对话框
#include<Shlobj.h>	//选择文件夹对话框
#pragma comment(lib,"Shell32.lib")


void TcharToChar(const TCHAR* tchar, char* _char)
{
	int iLength;
	//获取字节长度   
	iLength = WideCharToMultiByte(CP_ACP, 0, tchar, -1, NULL, 0, NULL, NULL);
	//将tchar值赋给_char    
	WideCharToMultiByte(CP_ACP, 0, tchar, -1, _char, iLength, NULL, NULL);

	return;
}

/**
* 函 数 名: ShowNotePad_ByDialog
* 说    明：以对话框打开记事本
* 返 回 值: void
*/
void ShowNotePad_ByDialog()
{
	/* 定义一个结构体，用以初始化对话框和接收返回值 */
	OPENFILENAME ofn = { 0 };
	TCHAR strFilename[MAX_PATH] = { 0 };//用于接收文件名
	ofn.lStructSize = sizeof(OPENFILENAME);//结构体大小
	ofn.hwndOwner = NULL;//拥有着窗口句柄，为NULL表示对话框是非模态的，实际应用中一般都要有这个句柄
	ofn.lpstrFilter = TEXT("所有文件\0*.*\0C/C++ Flie\0*.cpp;*.c;*.h\0\0");//设置过滤
	ofn.nFilterIndex = 1;//过滤器索引
	ofn.lpstrFile = strFilename;//接收返回的文件名，注意第一个字符需要为NULL
	ofn.nMaxFile = sizeof(strFilename);//缓冲区长度
	ofn.lpstrInitialDir = NULL;//初始目录为默认
	ofn.lpstrTitle = TEXT("请选择一个文件");//使用系统默认标题留空即可
	ofn.Flags = OFN_FILEMUSTEXIST | OFN_PATHMUSTEXIST | OFN_HIDEREADONLY;//文件、目录必须存在，隐藏只读选项

	/*
		* GetOpenFileName函数
		* 参数：一个指向 OPENFILENAME 结构的指针，其中包含用于初始化对话框的信息。GetOpenFileName 返回时，此结构包含有关用户的文件选择的信息。
		* 返回值：如果用户指定的文件名，并单击确定按钮，返回值不为零。指向的 OPENFILENAME 结构的 lpstrFile 成员在缓冲区中包含完整的路径和文件名称。如果用户取消或关闭打开对话框或发生错误，则返回值为零。
	*/
	if (GetOpenFileName(&ofn))
	{
		char fileName[100] = { 0 };
		char content[1000] = { 0 };

		//将TCHAR转为char
		TCHAR* buffer = (TCHAR*)malloc(0x50);
		TcharToChar(strFilename, fileName);

		//打开文件
		FILE* pFile = fopen(fileName, "r");//打开以便读取。 如果文件不存在或无法找到fopen调用失败。
		if (pFile == NULL) { printf("打开失败，不存在名为[%s]的记事本文件\n", fileName); system("pause"); return; }
		printf("打开路径[%s]  \n", fileName);

		//读取文件
		fscanf(pFile, "%[^\n]", content);
		printf("%s \n", content);

		//关闭文件
		fclose(pFile);
		system("pause");

	}
	else {
		MessageBox(NULL, TEXT("您没有选择一个文件"), NULL, MB_ICONERROR);
		return;
	}

}

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
	if (pFile == NULL) { printf("打开失败，不存在名为[%s]的记事本文件\n", fileName); system("pause"); return; }
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

	//输入文本内容
	printf("输入文本内容：\n");
	scanf("%[^\n]", &content);



	//存入文件
	FILE* pFile = fopen(fileName, "w");//打开用于写入的空文件。 如果给定文件存在，则其内容会被销毁。
	if (pFile == NULL) { printf("【error】pFile is null..."); return; }
	fprintf(pFile, "%s", content);
	fclose(pFile);

	printf("新建记事本[%s]成功\n", fileName);
	system("pause");
}



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
		printf("\t\t*4.手动查找记事本\n");
		printf("\t\t************************\n");
		int option = 0;
		scanf("%d", &option);
		switch (option)
		{
			case 1:	CreateNopePad(); break;
			case 2:	ShowNotePad(); break;
			case 3:	DeleteNopePad(); break;
			case 4:	ShowNotePad_ByDialog(); break;
			default:
				break;
		}
	}

	system("pause");
}
