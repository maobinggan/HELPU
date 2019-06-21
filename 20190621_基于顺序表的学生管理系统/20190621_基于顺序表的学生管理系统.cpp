// 学生管理系统20190621.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//
#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

//学生信息
struct STUDENT
{
	int sCode;			//学号
	char name[20];		//姓名
	float chineseScore;	//语文成绩
	float mathScore;	//数学成绩
	float englishScore;	//外语成绩
	float examScore;	//考试成绩 = （语+数+英）/ 3
	float finalScore;	//综合总分 = 考试成绩 * 0.6 + 同学互评分*0.1 + 品德评分*0.1 + 老师评分*0.2
	int examRank;		//考试成绩的排名
	int finalRank;		//综合总分的排名

	char address[50];	//住址
	char tel[50];		//联系方式
	char gender[4];		//性别

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

//业务逻辑
void AddOrUpdateStuInfo(STULIST& sqList);
void OrderBySCode_ASC(STULIST& sqList);
void PrintAllStuInfo(STULIST& sqList);
void PrintStuInfoBySCode(STULIST& sqList);
void DropStuInfo(STULIST& sqList);

//顺序表的基本操作函数
void ListInit(STULIST& sqList);
bool ListInsert(STULIST& sqList, STUDENT destNode, int pos);
bool ListDelete(STULIST& sqList, int pos);
bool ListUpdate(STULIST& sqList, STUDENT destNode, int pos);
bool ListGetElem(STULIST& sqList, int pos, STUDENT& elem);
int ListLocate(STULIST& sqList, STUDENT destNode);

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


/**
* 函 数 名: OrderBySCode_ASC
* 说    明：根据学号排序(升序)
* 参    数: STULIST & sqList -
* 返 回 值: void
*/
void OrderBySCode_ASC(STULIST& sqList)
{
	//冒泡排序法
	int i = 0;
	int j = 0;
	for (i = 0; i < sqList.length - 1; i++)
	{
		for (j = 0; j < sqList.length - i - 1; j++)
		{
			if (sqList.elements[j].sCode > sqList.elements[j + 1].sCode)
			{
				STUDENT temp = sqList.elements[j];
				sqList.elements[j] = sqList.elements[j + 1];
				sqList.elements[j + 1] = temp;
			}
		}
	}
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
		printf("性别=%s\t", sqList.elements[i].gender);
		printf("联系方式=%s\t", sqList.elements[i].tel);
		printf("家庭住址=%s\t", sqList.elements[i].address);
		printf("语文成绩=%.1f\t", sqList.elements[i].chineseScore);
		printf("数学成绩=%.1f\t", sqList.elements[i].mathScore);
		printf("英语成绩=%.1f\t", sqList.elements[i].englishScore);
		printf("考试成绩=%.1f\t", sqList.elements[i].examScore);
		printf("考试成绩排名=%02d\t", sqList.elements[i].examRank);
		printf("综合成绩=%.1f\t", sqList.elements[i].finalScore);
		printf("综合成绩排名=%02d\t", sqList.elements[i].finalRank);
		printf("\n");
	}
	system("pause");
}

/**
* 函 数 名: ListFindBySCode
* 说    明：根据学号查询
* 参    数: STULIST & sqList -
* 参    数: int destScode -
* 返 回 值: int - 返回逻辑位置，若返回值为0，则说明无结果
*/
int ListFindBySCode(STULIST& sqList, int destScode)
{
	int i = 0;
	for (i = 0; i < sqList.length; i++)
	{
		if (sqList.elements[i].sCode == destScode)
		{
			return i + 1;
		}
	}
	return 0;
}
/**
* 函 数 名: AddOrUpdateStuInfo
* 说    明：增加或修改学生信息
* 参    数: STULIST & sqList -
* 返 回 值: void
*/
void AddOrUpdateStuInfo(STULIST& sqList)
{
	STUDENT student;
	STUDENT oldStu;
	printf("请输入学号："); scanf("%d", &student.sCode);
	int destPos = ListFindBySCode(sqList, student.sCode);
	if (destPos == 0)
	{
		printf("将添加新的学生信息...\n");
	}
	else
	{
		printf("[该学号已存在，将更新原有的学生信息]\n");

		ListGetElem(sqList, destPos, oldStu);
		printf("[原有的学生信息] 学号=%d\t姓名=%s\t家庭住址=%s\t联系方式=%s\t性别=%s\t语文=%.1f\t数学=%.1f\t英语=%.1f\t考试成绩=%.1f\t考试成绩排名=%d\t综合成绩=%.1f\t综合成绩排名=%d\n",
			oldStu.sCode,
			oldStu.name,
			oldStu.address,
			oldStu.tel,
			oldStu.gender,
			oldStu.chineseScore,
			oldStu.mathScore,
			oldStu.englishScore,
			oldStu.examScore,
			oldStu.examRank,
			oldStu.finalScore,
			oldStu.finalRank);
	}
	printf("姓名：");	scanf("%s", student.name);
	printf("家庭住址："); scanf("%s", student.address);
	printf("联系方式："); scanf("%s", student.tel);
	printf("性别：");	scanf("%s", student.gender);
	printf("语文成绩："), scanf("%f", &student.chineseScore);
	printf("数学成绩："), scanf("%f", &student.mathScore);
	printf("英语成绩："), scanf("%f", &student.englishScore);
	printf("同学互评分："); float classMateScore = 0; scanf("%f", &classMateScore);
	printf("品德评分："); float pingdeScore = 0; scanf("%f", &pingdeScore);
	printf("老师评分："); float teacherScore = 0; scanf("%f", &teacherScore);

	//计算考试成绩 = （语+数+英）/ 3
	student.examScore = (student.chineseScore + student.mathScore + student.englishScore) / 3;
	//计算综合总分 = 考试成绩 * 0.6 + 同学互评分*0.1 + 品德评分*0.1 + 老师评分*0.2
	student.finalScore = student.examScore * 0.6 + +classMateScore * 0.1 + pingdeScore * 0.1 + teacherScore * 0.2;

	if (destPos == 0)
	{	//计算排名
		student.examRank = 1;
		student.finalRank = 1;
		for (int i = 0; i < sqList.length; i++)
		{
			if (sqList.elements[i].examScore > student.examScore) { student.examRank++; }
			else { sqList.elements[i].examRank++; }
			if (sqList.elements[i].finalScore > student.finalScore) { student.finalRank++; }
			else { sqList.elements[i].finalRank++; }
		}
		//新增顺序表节点
		ListInsert(sqList, student, sqList.length + 1);
	}
	else
	{
		student.examRank = oldStu.examRank;
		student.finalRank = oldStu.finalRank;
		//计算排名
		for (int i = 0; i < sqList.length; i++)
		{
			if (sqList.elements[i].examScore > student.examScore
				&& sqList.elements[i].examRank > oldStu.examRank)
			{
				sqList.elements[i].examRank--;
				student.examRank--;
			}
			if (sqList.elements[i].examScore < student.examScore
				&& sqList.elements[i].examRank < oldStu.examRank)
			{
				sqList.elements[i].examRank++;
				student.examRank--;
			}

			if (sqList.elements[i].finalScore > student.finalScore
				&& sqList.elements[i].examRank > oldStu.examRank)
			{
				sqList.elements[i].finalRank--;
				student.finalRank--;
			}
			if (sqList.elements[i].finalScore < student.finalScore
				&& sqList.elements[i].examRank < oldStu.examRank)
			{
				sqList.elements[i].finalRank++;
				student.finalRank--;
			}
		}

		//更新顺序表节点
		ListUpdate(sqList, student, destPos);
	}

	//排序
	OrderBySCode_ASC(sqList);

	//存入文件
	SaveData(sqList, "data.txt");
	printf("修改学生信息成功...\n");
	system("pause");
}

/**
* 函 数 名: DropStuInfo
* 说    明：移除学生信息
* 参    数: STULIST & sqList -
* 返 回 值: void
*/
void DropStuInfo(STULIST& sqList)
{
	printf("请输入要删除的学生信息的学号：");
	int destSCode = 0;
	scanf("%d", &destSCode);
	int destPos = ListFindBySCode(sqList, destSCode);
	if (destPos == 0) { printf("删除失败,该学号不存在...\n"); system("pause"); return; }
	STUDENT destStu;
	ListGetElem(sqList, destPos, destStu);
	printf("[您要删除的学生信息] 学号=%d\t姓名=%s\t家庭住址=%s\t联系方式=%s\t性别=%s\t语文=%.1f\t数学=%.1f\t英语=%.1f\t考试成绩=%.1f\t考试成绩排名=%d\t综合成绩=%.1f\t综合成绩排名=%d\n",
		destStu.sCode,
		destStu.name,
		destStu.address,
		destStu.tel,
		destStu.gender,
		destStu.chineseScore,
		destStu.mathScore,
		destStu.englishScore,
		destStu.examScore,
		destStu.examRank,
		destStu.finalScore,
		destStu.finalRank);
	printf("是否确认删除？( y / n ) \n");
	getchar();
	char option;
	scanf("%c", &option);
	if (option == 'n') { system("pause"); return; }
	//删除
	ListDelete(sqList, destPos);
	//重新计算排名
	for (int i = 0; i < sqList.length; i++)
	{
		if (sqList.elements[i].examScore > destStu.examScore) {}
		else { sqList.elements[i].examRank--; }
		if (sqList.elements[i].finalScore > destStu.finalScore) {}
		else { sqList.elements[i].finalRank--; }
	}
	//写入文件
	SaveData(sqList, filePath);
	printf("删除成功\n");
	system("pause");
}

/**
* 函 数 名: PrintStuInfoBySCode
* 说    明：通过学号打印学生信息
* 参    数: STULIST & sqList -
* 返 回 值: void
*/
void PrintStuInfoBySCode(STULIST& sqList)
{
	printf("请输入要查询的学号：");
	int destSCode = 0;
	scanf("%d", &destSCode);
	int destPos = ListFindBySCode(sqList, destSCode);
	if (destPos == 0) { printf("查询失败，无此学号...\n"); system("pause"); return; }
	STUDENT oldStu;
	ListGetElem(sqList, destPos, oldStu);
	printf("[查询到的学生信息] 学号=%d\t姓名=%s\t家庭住址=%s\t联系方式=%s\t性别=%s\t语文=%.1f\t数学=%.1f\t英语=%.1f\t考试成绩=%.1f\t考试成绩排名=%d\t综合成绩=%.1f\t综合成绩排名=%d\n",
		oldStu.sCode,
		oldStu.name,
		oldStu.address,
		oldStu.tel,
		oldStu.gender,
		oldStu.chineseScore,
		oldStu.mathScore,
		oldStu.englishScore,
		oldStu.examScore,
		oldStu.examRank,
		oldStu.finalScore,
		oldStu.finalRank);
	system("pause"); return;
}

int main()
{
	system("mode con cols=200 lines=30");
	//顺序表初始化
	STULIST sqList;
	ListInit(sqList);
	//从文件中读取数据
	LoadData(sqList, filePath);
	while (true)
	{
		system("cls");
		printf("\t\t************************\n");
		printf("\t\t**学生信息管理系统\n");
		printf("\t\t*1.新增或修改学生信息\n");
		printf("\t\t*2.删除学生信息\n");
		printf("\t\t*3.浏览所有学生信息\n");
		printf("\t\t*4.按学号查找学生信息\n");
		printf("\t\t************************\n");

		int option = 0;
		scanf("%d", &option);
		switch (option)
		{
			case 1:AddOrUpdateStuInfo(sqList);	break;
			case 2:DropStuInfo(sqList);			break;
			case 3:PrintAllStuInfo(sqList);		break;
			case 4:PrintStuInfoBySCode(sqList); break;
			default:
				break;
		}
		getchar();
	}

	system("pause");
	return 0;
}
