// 学生点名系统20190621.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <time.h>
//学生信息
struct STUDENT
{
	int sCode;			//学号
	char name[20];		//姓名
	bool isLeader;		//是否为班干部
};
const char* filePath = "data.txt";
/*
* 定义顺序表：线性表的顺序存储结构
* 用数组存储线性表中的各Elem元素，以保证逻辑上相邻的元素在物理存储上也是相邻的
*/
#define LISTSIZE 100      //线性表的最大长度
struct STULIST
{
	STUDENT elements[LISTSIZE];
	int length;
};
//顺序表的基本操作函数
void ListInit(STULIST& sqList);
bool ListInsert(STULIST& sqList, STUDENT destNode, int pos);
bool ListDelete(STULIST& sqList, int pos);
bool ListUpdate(STULIST& sqList, STUDENT destNode, int pos);
bool ListGetElem(STULIST& sqList, int pos, STUDENT& elem);
int ListLocate(STULIST& sqList, STUDENT destNode);
/**
* 函 数 名: ListInit
* 说    明：顺序表的初始化
* 参    数: STULIST & stuList -
* 返 回 值: void
*/
void ListInit(STULIST& sqList)
{
	//把结构体数组清零，方便对结构体进行比较(memcpy)
	memset(sqList.elements, 0x0, sizeof(sqList));
	//把顺序表的长度设置为0
	sqList.length = 0;
}

/**
* 函 数 名: ListInsert
* 说    明：向顺序表插入新节点，使长度为n的线性表变成长度为n+1的线性表,时间复杂度O(n)
* 参    数: STULIST & stuList -
* 参    数: STUDENT destNode - 要插入的目标节点
* 参    数: int pos - 要插入的逻辑位置（在长度为n的顺序表中，逻辑位置从1至n）
*					- 如果希望在顺序表末尾添加节点，则传入的pos应该为n+1
* 返 回 值: void
*/
bool ListInsert(STULIST& sqList, STUDENT destNode, int pos)
{
	//判断目标逻辑位置pos的合法性（pos的合法范围是 1<= pos <= n+1 ） 
	if (pos < 1 || pos > sqList.length + 1) { printf("【error】逻辑位置错误，无法插入新节点\n"); return false; }
	//判断线性表是否已满
	if (sqList.length == LISTSIZE) { printf("【error】顺序表已满，无法插入新节点\n"); return false; }

	//从第n个元素即最后一个元素开始，依次向后移动一个位置，直至第pos个元素。（共需移动 n-pos+1 次）
	for (int i = sqList.length; i >= pos; i--)
	{
		sqList.elements[i] = sqList.elements[i - 1];
	}
	//将要插入的新节点放入第pos个位置
	sqList.elements[pos - 1] = destNode;
	//线性表长度加一
	sqList.length++;
	return true;
}

/**
* 函 数 名: ListDelete
* 说    明：从顺序表中删除节点,时间复杂度O(n)
* 参    数: STULIST & sqList -
* 参    数: int pos - 要删除的节点的逻辑位置（在长度为n的顺序表中，逻辑位置从1至n）
* 返 回 值: bool
*/
bool ListDelete(STULIST& sqList, int pos)
{
	//判断目标逻辑位置pos的合法性（pos的范围是 1 <= pos <= n）
	if (pos<1 || pos>sqList.length) { printf("【error】逻辑位置错误，无法删除节点\n");  return false; }
	//判断线性表是否为空
	if (sqList.length < 1) { printf("【error】顺序表为空，无法删除节点\n");  return false; }

	//要删除第pos个元素，就需要将第pos+1个至第n个元素依次向前移动一个位置
	for (int i = pos; i <= sqList.length; i++)
	{
		sqList.elements[i - 1] = sqList.elements[i];
	}
	//线性表长度减一
	sqList.length--;
	return true;
}


/**
* 函 数 名: ListUpdate
* 说    明：更新替换顺序表的某个节点,时间复杂度O(n)
* 参    数: STULIST & sqList -
* 参    数: STUDENT destNode -
* 参    数: int pos -
* 返 回 值: bool
*/
bool ListUpdate(STULIST& sqList, STUDENT destNode, int pos)
{
	//判断目标逻辑位置pos的合法性（pos的范围是 1 <= pos <= n）
	if (pos<1 || pos>sqList.length) { printf("【error】逻辑位置错误，无法修改节点\n");  return false; }
	//elements[pos-1]存储的就是第pos个元素
	sqList.elements[pos - 1] = destNode;
	return true;
}

/**
* 函 数 名: ListLocate
* 说    明：查找与目标节点的数据相同的节点的逻辑位置（按内容查找）,时间复杂度O(n)
* 参    数: STULIST & sqList -
* 参    数: STUDENT destNode -
* 返 回 值: int - 返回的是逻辑位置，如果返回0，则说明找不到相同的节点
*/
int ListLocate(STULIST& sqList, STUDENT destNode)
{
	for (int i = 0; i < sqList.length; i++)
	{
		if (memcmp(&sqList.elements[i], &destNode, sizeof(destNode)) == 0)
		{
			return i + 1;//逻辑位置需要加1
		}
	}
	return 0;
}

/**
* 函 数 名: ListGetElem
* 说    明：按逻辑位置查找，时间复杂度O(1)
* 参    数: STULIST & sqList -
* 参    数: int pos - 逻辑位置
* 参    数: OUT STUDENT elem - 查找的结果
* 返 回 值: bool
*/
bool ListGetElem(STULIST& sqList, int pos, STUDENT& elem)
{
	//判断目标逻辑位置pos的合法性（pos的范围是 1 <= pos <= n）
	if (pos<1 || pos>sqList.length) { printf("【error】逻辑位置错误，无法查找节点\n");  return false; }
	//elements[pos-1]存储的就是第pos个元素
	elem = sqList.elements[pos - 1];
	return true;
}
//文件读写操作
void SaveData(STULIST& stuList, const char* filePath);
void LoadData(STULIST& stuList, const char* filePath);
/**
* 函 数 名: SaveData
* 说    明：将顺序表中的记录写入至文件
* 参    数: STULIST & stuList -
* 参    数: const char * filePath - 文件路径
* 返 回 值: void
*/
void SaveData(STULIST& stuList, const char* filePath)
{
	FILE* pFile = fopen(filePath, "wb");//打开用于写入的空文件。 如果给定文件存在，则其内容会被销毁。
	if (pFile == NULL) { printf("【error】pFile is null..."); return; }
	for (int i = 0; i < stuList.length; i++)
	{
		fwrite(&stuList.elements[i], sizeof(STUDENT), 1, pFile);
		fwrite("\n", 1, 1, pFile); //多写入一个换行符，方便查看
	}
	fclose(pFile);
}

/**
* 函 数 名: LoadData
* 说    明：从文件中读取记录至顺序表
* 参    数: STULIST & stuList -
* 参    数: const char * filePath - 文件路径
* 返 回 值: void
*/
void LoadData(STULIST& stuList, const char* filePath)
{
	FILE* pFile = fopen(filePath, "rb");//打开以便读取。 如果文件不存在或无法找到fopen调用失败。
	if (pFile == NULL) { return; }
	while (fread(&stuList.elements[stuList.length], sizeof(STUDENT), 1, pFile) != 0)
	{
		char tempBuffer;
		fread(&tempBuffer, 1, 1, pFile); //多读一个换行符
		stuList.length++;
	}
	fclose(pFile);
}
void InputStuInfo(STULIST& sqList)
{
	STUDENT student;
	printf("请输入学号："); scanf("%d", &student.sCode);
	printf("姓名：");  scanf("%s", student.name);
	printf("是否为班干部？(是1/否0)：");  scanf("%d", &student.isLeader);
	//新增顺序表节点
	ListInsert(sqList, student, sqList.length + 1);
	//存入文件
	SaveData(sqList, "data.txt");
	printf("录入学生信息成功...\n");
	system("pause");
}
/**
* 函 数 名: PrintAllStuInfo
* 说    明：打印所有学生信息
* 参    数: STULIST & sqList -
* 返 回 值: void
*/
void PrintAllStuInfo(STULIST& sqList)
{
	printf("[打印所有学生信息]\n");
	int i = 0;
	for (i = 0; i < sqList.length; i++)
	{
		printf("学号=%08d\t", sqList.elements[i].sCode);
		printf("姓名=%5s\t", sqList.elements[i].name);
		printf("是否班干部=%d\t", sqList.elements[i].isLeader);
		printf("\n");
	}
	system("pause");
}

void RollFromLeader(STULIST& sqList)
{
	int count = 0;
	STUDENT buffer[LISTSIZE] = { 0 };
	int i = 0;
	for (i = 0; i < sqList.length; i++)
	{
		if (sqList.elements[i].isLeader == 1)
		{
			buffer[count] = sqList.elements[i];
			count++;
		};
	}
	if (count == 0) { printf("随机点名失败,班级中没有学生干部...\n"); system("pause"); return; }
	srand((unsigned)time(NULL)); //重新生成随机数种子，确保每次随机数不同
	int a = rand() % count; //生成随机数
	printf("[随机点名班干部的结果] 学号=%d 姓名=%s 是否班干部=%d \n", buffer[a].sCode, buffer[a].name, buffer[a].isLeader);;
	system("pause"); return;
}
/**
* 函 数 名: RollFromCommon
* 说    明：从普通学生中点名
* 参    数: STULIST & sqList -
* 返 回 值: void
*/
void RollFromCommon(STULIST& sqList)
{
	int count = 0;
	STUDENT buffer[LISTSIZE] = { 0 };
	int i = 0;
	for (i = 0; i < sqList.length; i++)
	{
		if (sqList.elements[i].isLeader == 0)
		{
			buffer[count] = sqList.elements[i];
			count++;
		};
	}
	if (count == 0) { printf("随机点名失败,班级中没有普通学生成员...\n"); system("pause"); return; }
	srand((unsigned)time(NULL)); //重新生成随机数种子，确保每次随机数不同
	int a = rand() % count; //生成随机数
	printf("[随机点名普通学生的结果] 学号=%d 姓名=%s 是否班干部=%d \n", buffer[a].sCode, buffer[a].name, buffer[a].isLeader);;
	system("pause"); return;
}

void RollFromAllStu(STULIST& sqList)
{

	if (sqList.length == 0) { printf("随机点名失败,班级中没有学生...\n"); system("pause"); return; }
	srand((unsigned)time(NULL)); //重新生成随机数种子，确保每次随机数不同
	int a = rand() % sqList.length; //生成随机数
	printf("[对所有学生随机点名的结果] 学号=%d 姓名=%s 是否班干部=%d \n", sqList.elements[a].sCode, sqList.elements[a].name, sqList.elements[a].isLeader);;
	system("pause"); return;
}

int main()
{
	//顺序表初始化
	STULIST sqList;
	ListInit(sqList);
	//从文件中读取数据
	LoadData(sqList, filePath);
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
			case 1:InputStuInfo(sqList);	break;
			case 2:PrintAllStuInfo(sqList);	break;
			case 3:RollFromLeader(sqList);	break;
			case 4:RollFromCommon(sqList);	break;
			case 5:RollFromAllStu(sqList);	break;
			default:
				break;
		}
		getchar();
	}

	system("pause");
}

