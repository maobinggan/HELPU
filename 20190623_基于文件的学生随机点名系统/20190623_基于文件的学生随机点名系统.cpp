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
	bool isLeader;		//是否为班干部
};
const char* filePath = "data.txt"; //存储学生信息的文件路径
#define SIZELIST 100			//学生结构体数组的最大长度

//文件读写操作
void SaveData(STUDENT * stuList, int& count, const char* filePath);
void LoadData(STUDENT* stuList, int& count, const char* filePath);


/**
* 函 数 名: SaveData
* 说    明：将学生数组的数据存入文件
* 参    数: STUDENT * stuArr - 学生数组
* 参    数: int count - 数组的有效长度
* 参    数: const char * filePath - 文件路径
* 返 回 值: void
*/
void SaveData(STUDENT* stuList, int& count, const char* filePath)
{
	FILE* pFile = fopen(filePath, "wb");//打开用于写入的空文件。 如果给定文件存在，则其内容会被销毁。
	if (pFile == NULL) { printf("【error】pFile is null...\n"); return; }
	for (int i = 0; i < count; i++)
	{
		fwrite(&stuList[i], sizeof(STUDENT), 1, pFile);
		fwrite("\n", 1, 1, pFile); //多写入一个换行符，方便查看
	}
	fclose(pFile);
}

/**
* 函 数 名: LoadData
* 说    明：
* 参    数: STUDENT * stuArr - 学生数组
* 参    数: int count - 数组的有效长度
* 参    数: const char * filePath - 文件路径
* 返 回 值: void
*/
void LoadData(STUDENT* stuList, int& count, const char* filePath)
{
	FILE* pFile = fopen(filePath, "rb");//打开以便读取。 如果文件不存在或无法找到fopen调用失败。
	if (pFile == NULL) { return; }
	count = 0;
	while (fread(&stuList[count], sizeof(STUDENT), 1, pFile) != 0)
	{
		char tempBuffer;
		fread(&tempBuffer, 1, 1, pFile); //多读一个换行符
		count++;
	}
	fclose(pFile);
}

/**
* 函 数 名: InputStuInfo
* 说    明：录入学生信息
* 参    数: STUDENT * stuArr - 学生数组
* 参    数: int count - 数组的有效长度
* 返 回 值: void
*/
void InputStuInfo(STUDENT* stuArr, int& count)
{
	STUDENT student;
	printf("请输入学号："); scanf("%d", &student.sCode);
	printf("姓名：");  scanf("%s", student.name);
	printf("是否为班干部？(是1/否0)：");  scanf("%d", &student.isLeader);

	//向学生数组中添加元素
	stuArr[count++] = student;

	//存入文件
	SaveData(stuArr, count, filePath);
	printf("录入学生信息成功...\n");
	system("pause");
}

/**
* 函 数 名: PrintAllStuInfo
* 说    明：打印所有学生信息
* 参    数: STULIST & stuArr -学生数组的有效长度
* 返 回 值: void
*/
void PrintAllStuInfo(STUDENT* stuArr, int count)
{
	printf("[打印所有学生信息]\n");
	int i = 0;
	for (i = 0; i < count; i++)
	{
		printf("学号=%08d\t", stuArr[i].sCode);
		printf("姓名=%5s\t", stuArr[i].name);
		printf("是否班干部=%d\t", stuArr[i].isLeader);
		printf("\n");
	}
	system("pause");
}

/**
* 函 数 名: RollFromLeader
* 说    明：从学生干部中随机点名
* 参    数: STUDENT * stuArr - 学生数组
* 参    数: int count - 数组的有效长度
* 返 回 值: void
*/
void RollFromLeader(STUDENT* stuArr, int count)
{
	int leaderCount = 0;
	STUDENT buffer[SIZELIST] = { 0 };

	//获取班干部的人数
	int i = 0;
	for (i = 0; i < count; i++)
	{
		if (stuArr[i].isLeader == 1)
		{
			buffer[leaderCount++] = stuArr[i];
		};
	}
	if (leaderCount == 0) { printf("随机点名失败,班级中没有学生干部...\n"); system("pause"); return; }

	//随机点名
	srand((unsigned)time(NULL)); //重新生成随机数种子，确保每次随机数不同
	int a = rand() % leaderCount; //生成随机数
	printf("[随机点名班干部的结果] 学号=%d 姓名=%s 是否班干部=%d \n", buffer[a].sCode, buffer[a].name, buffer[a].isLeader);;
	system("pause"); return;
}

/**
* 函 数 名: RollFromCommon
* 说    明：从普通学生中随机点名
* 参    数: STUDENT * stuArr - 学生数组
* 参    数: int count - 数组的有效长度
* 返 回 值: void
*/
void RollFromCommon(STUDENT* stuArr, int count)
{
	//获取普通学生的人数
	int commonCount = 0;
	STUDENT buffer[SIZELIST] = { 0 };
	int i = 0;
	for (i = 0; i < count; i++)
	{
		if (stuArr[i].isLeader == 0)
		{
			buffer[commonCount++] = stuArr[i];
		};
	}
	if (commonCount == 0) { printf("随机点名失败,班级中没有普通学生成员...\n"); system("pause"); return; }

	//随机点名
	srand((unsigned)time(NULL)); //重新生成随机数种子，确保每次随机数不同
	int a = rand() % commonCount; //生成随机数
	printf("[随机点名普通学生的结果] 学号=%d 姓名=%s 是否班干部=%d \n", buffer[a].sCode, buffer[a].name, buffer[a].isLeader);;
	system("pause"); return;
}

/**
* 函 数 名: RollFromAllStu
* 说    明：从所有学生中随机点名
* 参    数: STUDENT * stuArr - 学生数组
* 参    数: int count - 数组的有效长度
* 返 回 值: void
*/
void RollFromAllStu(STUDENT* stuArr, int count)
{

	if (count == 0) { printf("随机点名失败,班级中没有学生...\n"); system("pause"); return; }

	//随机点名
	srand((unsigned)time(NULL)); //重新生成随机数种子，确保每次随机数不同
	int a = rand() % count; //生成随机数
	printf("[对所有学生随机点名的结果] 学号=%d 姓名=%s 是否班干部=%d \n", stuArr[a].sCode, stuArr[a].name, stuArr[a].isLeader);;
	system("pause"); return;
}

int main()
{
	//数组初始化
	STUDENT stuArr[SIZELIST] = { 0 };

	//从文件中读取学生记录至数组
	int count = 0;
	LoadData(stuArr, count, filePath);

	//主菜单
	while (true)
	{
		system("cls");
		printf("\t\t************************\n");
		printf("\t\t**学生随机点名系统\n");
		printf("\t\t*1.录入学生信息\n");
		printf("\t\t*2.浏览所有学生信息\n");
		printf("\t\t*3.从班干部中随机点名\n");
		printf("\t\t*4.从普通学生中随机点名\n");
		printf("\t\t*5.从所有学生中随机点名\n");
		printf("\t\t************************\n");

		int option = 0;
		scanf("%d", &option);
		switch (option)
		{
			case 1:InputStuInfo(stuArr, count);		break;
			case 2:PrintAllStuInfo(stuArr, count);	break;
			case 3:RollFromLeader(stuArr, count);	break;
			case 4:RollFromCommon(stuArr, count);	break;
			case 5:RollFromAllStu(stuArr, count);	break;
			default:
				break;
		}
		getchar();
	}

	system("pause");
}

