// 20190623_基于文件的班级管理系统.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//
#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

//学生信息
struct STUDENT
{
	int sCode;			//学号
	char name[20];		//姓名
	char gender[2];		//性别
	int classNum;		//班级号
	char tel[20];		//电话
	char addr[30];		//地址
};

//班级信息
struct CLASS
{
	int classNum;	//班级号
};

const char* stuFilePath = "stuInfo.txt";		//存储学生信息的文件路径
const char* classFilePath = "classInfo.txt";	//存储班级信息的文件路径
#define SIZELIST 100						//学生或班级结构体数组的最大长度

//文件读写操作
void SaveData_Stu(STUDENT * stuList, int& count, const char* filePath);
void LoadData_Stu(STUDENT* stuList, int& count, const char* filePath);
void SaveData_Class(CLASS* stuList, int& count, const char* filePath);
void LoadData_Class(CLASS* stuList, int& count, const char* filePath);

/**
* 函 数 名: SaveData
* 说    明：将学生数组的数据存入文件
* 参    数: STUDENT * stuArr - 学生数组
* 参    数: int count - 数组的有效长度
* 参    数: const char * filePath - 文件路径
* 返 回 值: void
*/
void SaveData_Stu(STUDENT* arr, int& count, const char* filePath)
{
	FILE* pFile = fopen(filePath, "wb");//打开用于写入的空文件。 如果给定文件存在，则其内容会被销毁。
	if (pFile == NULL) { printf("【error】pFile is null...\n"); return; }
	for (int i = 0; i < count; i++)
	{
		fwrite(&arr[i], sizeof(STUDENT), 1, pFile);
		fwrite("\n", 1, 1, pFile); //多写入一个换行符，方便查看
	}
	fclose(pFile);
}

/**
* 函 数 名: SaveData_Class
* 说    明：保存班级数组至文件
* 参    数: CLASS * arr -
* 参    数: int & count -
* 参    数: const char * filePath -
* 返 回 值: void
*/
void SaveData_Class(CLASS* arr, int& count, const char* filePath)
{
	FILE* pFile = fopen(filePath, "wb");//打开用于写入的空文件。 如果给定文件存在，则其内容会被销毁。
	if (pFile == NULL) { printf("【error】pFile is null...\n"); return; }
	for (int i = 0; i < count; i++)
	{
		fwrite(&arr[i], sizeof(CLASS), 1, pFile);
		fwrite("\n", 1, 1, pFile); //多写入一个换行符，方便查看
	}
	fclose(pFile);
}


/**
* 函 数 名: LoadData_Stu
* 说    明：从文件读取数据至学生数组
* 参    数: STUDENT * arr -
* 参    数: int & count -
* 参    数: const char * filePath -
* 返 回 值: void
*/
void LoadData_Stu(STUDENT* arr, int& count, const char* filePath)
{
	FILE* pFile = fopen(filePath, "rb");//打开以便读取。 如果文件不存在或无法找到fopen调用失败。
	if (pFile == NULL) { return; }
	count = 0;
	while (fread(&arr[count], sizeof(STUDENT), 1, pFile) != 0)
	{
		char tempBuffer;
		fread(&tempBuffer, 1, 1, pFile); //多读一个换行符
		count++;
	}
	fclose(pFile);
}

/**
* 函 数 名: LoadData_Class
* 说    明：从文件读取数据至班级数组
* 参    数: CLASS * arr -
* 参    数: int & count -
* 参    数: const char * filePath -
* 返 回 值: void
*/
void LoadData_Class(CLASS* arr, int& count, const char* filePath)
{
	FILE* pFile = fopen(filePath, "rb");//打开以便读取。 如果文件不存在或无法找到fopen调用失败。
	if (pFile == NULL) { return; }
	count = 0;
	while (fread(&arr[count], sizeof(CLASS), 1, pFile) != 0)
	{
		char tempBuffer;
		fread(&tempBuffer, 1, 1, pFile); //多读一个换行符
		count++;
	}
	fclose(pFile);
}


/**
* 函 数 名: CreateClass
* 说    明：新建班级
* 参    数: CLASS * arr - 班级数组
* 参    数: int & count - 班级数组的有效长度
* 返 回 值: void
*/
void AddClassInfo(CLASS* arr, int& count)
{
	CLASS destClass = { 0 };
	int i = 0;
	printf("请输入班级号：");
	scanf("%d", &destClass.classNum);

	//查询该班级是否已存在
	for (i = 0; i < count; i++)
	{
		if (arr[i].classNum == destClass.classNum)
		{
			printf("[增加班级失败,该班级已存在]\n");
			system("pause");
			return;
		}
	}

	//增加班级
	arr[count++] = destClass;

	//存入文件
	SaveData_Class(arr, count, classFilePath);
	printf("[新增班级成功]\n");
	system("pause");
}


/**
* 函 数 名: ShowAllClassInfo
* 说    明：显示所有的班级
* 参    数: CLASS * arr -
* 参    数: int count -
* 返 回 值: void
*/
void ShowAllClassInfo(STUDENT* stuArr, int& stuCount, CLASS* classArr, int& classCount)
{

	printf("[打印所有班级列表，班级总数=%d]\n", classCount);
	int i = 0;
	for (i = 0; i < classCount; i++)
	{
		printf("*\t%d班", classArr[i].classNum);
		int currentClassStudentCount = 0;
		int j = 0;
		for (j = 0; j < stuCount; j++)
		{
			if (stuArr[j].classNum == classArr[i].classNum) 
			{
				currentClassStudentCount++;
			}
		}
		printf("\t班级人数=%d", currentClassStudentCount);

		printf("\n");
	}
	printf("\n");
	system("pause");
}



/**
* 函 数 名: DropClassByNum
* 说    明：根据班级号删除班级
* 参    数: CLASS * arr -
* 参    数: int & count -
* 返 回 值: void
*/
void DropClassInfoByNum(CLASS* arr, int& count)
{
	int destClassNum = 0;
	int i = 0;
	printf("请输入要删除的班级号：");
	scanf("%d", &destClassNum);

	//查询该班级是否已存在
	for (i = 0; i < count; i++)
	{
		if (arr[i].classNum == destClassNum)
		{
			//如果班级存在，则从班级数组中移除
			int j = 0;
			for (j = i; j < count - 1; j++)
			{
				arr[i] = arr[i + 1];
			}
			count--;
			i--;
			//写入文件
			SaveData_Class(arr, count, classFilePath);
			printf("[成功删除'%d班']\n", destClassNum);
			system("pause");
			return;
		}
	}
	printf("[删除班级失败,'%d班'不存在]\n", destClassNum);
	system("pause");
	return;
}
/**
* 函 数 名: DropStuInfoBySCode
* 说    明：删除指定学号的学生
* 参    数: STUDENT * stuArr -
* 参    数: int & stuCount -
* 参    数: CLASS * classArr -
* 参    数: int & classCount -
* 返 回 值: void
*/
void DropStuInfoBySCode(STUDENT* stuArr, int& stuCount, CLASS* classArr, int& classCount)
{
	int destSCode = 0;
	int i = 0;
	printf("请输入要删除的学号：");
	scanf("%d", &destSCode);

	//查询指定学号是否存在
	for (i = 0; i < stuCount; i++)
	{
		if (stuArr[i].sCode == destSCode)
		{
			int k = 0;
			for (k = i; k < stuCount - 1; k++)
			{
				stuArr[k] = stuArr[k + 1];
			}
			stuCount--;
			printf("[删除成功]\n");
			system("pause");
			return;
		}
	}
	printf("[删除学生失败,学号为'%08d'的学生不存在]\n", destSCode);
	system("pause");
	return;

}
/**
* 函 数 名: DropClassMateByNum
* 说    明：删除指定班级的所有同学
* 参    数: STUDENT * stuArr -
* 参    数: int & stuCount -
* 参    数: CLASS * classArr -
* 参    数: int & classCount -
* 返 回 值: void
*/
void DropClassMateByNum(STUDENT* stuArr, int& stuCount, CLASS* classArr, int& classCount)
{
	int destClassNum = 0;
	int i = 0;
	printf("请输入要删除班级同学的班级号：");
	scanf("%d", &destClassNum);

	//查询该班级是否已存在
	for (i = 0; i < classCount; i++)
	{
		if (classArr[i].classNum == destClassNum)
		{
			//如果班级存在，遍历查询所有该班级的同学
			int j = 0;
			for (j = 0; j < stuCount; j++)
			{
				//如果找到该班级的同学，则从学生数组中删除该学生
				if (stuArr[j].classNum == destClassNum)
				{
					printf("[删除'%d班'的'%s'同学]\n", destClassNum, stuArr[j].name);
					int k = 0;
					for (k = j; k < stuCount - 1; k++)
					{
						stuArr[k] = stuArr[k + 1];
					}
					stuCount--;
					j--;
				}
			}

			//写入文件
			SaveData_Stu(stuArr, stuCount, stuFilePath);
			printf("[已成功删除'%d班'的所有同学]\n", destClassNum);
			system("pause");
			return;
		}
	}
	printf("[删除班级同学,'%班'不存在]\n", destClassNum);
	system("pause");
	return;
}
/**
* 函 数 名: AddStuInfo
* 说    明：新增班级的学生
* 参    数: STUDENT * arr -
* 参    数: int & count -
* 返 回 值: void
*/
void AddStuInfo(STUDENT* stuArr, int& stuCount, CLASS* classArr, int& classCount)
{
	//输入班级号
	int destClassNum = 0;
	int i = 0;
	int j = 0;
	printf("输入要录入学生的班级号：");
	scanf("%d", &destClassNum);

	//判断该班级是否已存在
	for (i = 0; i < classCount; i++)
	{
		//如果班级存在
		if (classArr[i].classNum == destClassNum)
		{
			//输入学生信息
			STUDENT student;
			printf("请输入学号："); scanf("%d", &student.sCode);
			printf("请输入姓名：");  scanf("%s", student.name);
			printf("请输入性别：");  scanf("%s", student.gender);
			printf("请输入电话号码：");  scanf("%s", student.tel);
			printf("请输入地址：");  scanf("%s", student.addr);
			student.classNum = destClassNum;

			//向学生数组中添加元素
			stuArr[stuCount++] = student;

			//写入文件
			SaveData_Stu(stuArr, stuCount, stuFilePath);
			printf("[录入班级同学成功]\n");
			system("pause");
			return;
		}
	}

	printf("[班级同学录入失败,找不到‘%d班’]\n", destClassNum);
	system("pause");
	return;
}

/**
* 函 数 名: ShowClassMate
* 说    明：显示指定班级的所有同学
* 参    数: STUDENT * stuArr -
* 参    数: int & stuCount -
* 参    数: CLASS * classArr -
* 参    数: int & classCount -
* 返 回 值: void
*/
void ShowClassMate(STUDENT* stuArr, int& stuCount, CLASS* classArr, int& classCount)
{
	if (stuCount == 0)
	{
		printf("[查询同学录失败,当前学生的数量为0]\n");
		system("pause");
		return;
	}

	//输入班级号
	int destClassNum = 0;
	int i = 0;
	int j = 0;
	printf("输入要查询同学录的班级号：");
	scanf("%d", &destClassNum);

	printf("[查询'%d班'的同学录]\n", destClassNum);
	//判断该班级是否已存在
	for (i = 0; i < classCount; i++)
	{
		//如果班级存在
		if (classArr[i].classNum == destClassNum)
		{
			//显示该班级的所有学生
			for (j = 0; j < stuCount; j++)
			{
				if (stuArr[j].classNum == destClassNum)
				{
					printf("*\t学号=%08d\t姓名=%s\t性别=%s\t班级号=%d\t电话号=%s\t地址=%s\n",
						stuArr[j].sCode,
						stuArr[j].name,
						stuArr[j].gender,
						stuArr[j].classNum,
						stuArr[j].tel,
						stuArr[j].addr
					);
				}
			}
			system("pause");
			return;
		}
	}

	printf("[查询同学录失败,找不到‘%d班’]\n", destClassNum);
	system("pause");
	return;
}


int main()
{
	//班级、学生数组初始化
	STUDENT stuArr[SIZELIST] = { 0 };
	CLASS classArr[SIZELIST] = { 0 };

	//从文件中读取记录至数组
	int classCount = 0;
	int stuCount = 0;
	LoadData_Class(classArr, classCount, classFilePath);
	LoadData_Stu(stuArr, stuCount, stuFilePath);

	//主菜单
	while (true)
	{
		system("cls");
		printf("\t\t************************\n");
		printf("\t\t**班级管理系统\n");
		printf("\t\t*1.显示班级列表\n");
		printf("\t\t*2.增加班级\n");
		printf("\t\t*3.删除班级\n");
		printf("\t\t*4.班级同学录入\n");
		printf("\t\t*5.班级同学删除\n");
		printf("\t\t*6.显示指定班级同学录\n");
		printf("\t\t*7.退出\n");
		printf("\t\t************************\n");

		int option = 0;
		scanf("%d", &option);
		getchar();
		switch (option)
		{
			case 1:ShowAllClassInfo(stuArr, stuCount, classArr, classCount);	break;
			case 2:AddClassInfo(classArr, classCount);							break;
			case 3:DropClassInfoByNum(classArr, classCount);					break;
			case 4:AddStuInfo(stuArr, stuCount, classArr, classCount);			break;
			case 5:DropStuInfoBySCode(stuArr, stuCount, classArr, classCount);	break;
			case 6:ShowClassMate(stuArr, stuCount, classArr, classCount);		break;
			case 7:return 0;
			default:
				break;
		}
	}

	system("pause");
}

