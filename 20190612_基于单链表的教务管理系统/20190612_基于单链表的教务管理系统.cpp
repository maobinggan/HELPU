// HELPOO_教务信息关系系统.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//
#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

//重修情况
struct RESTUDY
{
	int term;			//重修学期
	float score;		//重修成绩
};
//课程基本信息
struct COURSE
{
	int no;					//课程编号(6位数字)
	char name[10];			//课程名称
	float examScore;		//考试成绩
	float usualScore;		//平时成绩
	float finalScore;		//综合成绩
	float point;			//学分
	char isReStudy[2];		//是否重修
	int resTimes;			//已重修次数
	RESTUDY reStudy[5];		//重修情况
};
//学生基本信息
struct STUDENT
{
	char no[15];			//学号（12位数字)
	char name[10];			//姓名
	int classNo;			//班级号
	char gender[2];			//性别
	int	 age;				//年龄
	char telephoneNum[20];	//电话号码
	int dormNum;			//宿舍号码（5位数字）
	int courseCount;		//此学生所修课程的数量
	float obtainedPoint;	//已获得的学分
	COURSE course[10];		//此学生所修课程的基本信息
	STUDENT* next;			//下一节点
};

void ShowAllStuInfo(STUDENT* headNode);					//显示所有学生信息
void AddStuInfo(STUDENT*& headNode);					//新增学生信息
void DeleteStuInfo(STUDENT*& headNode);					//删除学生信息
void SaveStuInfo(STUDENT* headNode);					//保存学生信息
void SortByCourse(STUDENT* headNode);					//统计：按课程
void SortByClass(STUDENT* headNode);					//统计：按班级
void SortByFailCourse(STUDENT* headNode);				//统计：按不及格课程
void LoadStuInfo(STUDENT*& headNode);					//加载学生信息（从文件）
void ListAppend(STUDENT*& headNode, STUDENT*& newNode);	//链表的插入：在末尾新增节点
void ListInit(STUDENT*& headNode);						//链表的初始化



//新增学生信息
void AddStuInfo(STUDENT*& headNode)
{
	int i = 0;
	int j = 0;
	while (1)
	{
		STUDENT* p; //创建新节点
		p = (STUDENT*)malloc(sizeof(STUDENT));
		p->next = 0;
		printf("请输入学号（12位数字，返回请输入0）：");
		scanf("%s", &p->no);
		if (strcmp(p->no, "0") == 0) { break; }
		printf("请输入班级号（软件R( )班）：");
		scanf("%d", &p->classNo);
		printf("请输入姓名：");
		scanf("%s", &p->name);
		printf("请输入性别：");
		scanf("%s", &p->gender);
		printf("请输入年龄：");
		scanf("%d", &p->age);
		printf("请输入宿舍号码（5位数字）：");
		scanf("%05d", &p->dormNum);
		printf("请输入电话号码（短号）：");
		scanf("%s", &p->telephoneNum);
		p->courseCount = 0;
		p->obtainedPoint = 0;

		//录入此学生的课程信息
		for (i = p->courseCount; i < 10; i++)
		{
			printf("请输入课程编号(6位数字，返回请输入0)：");
			scanf("%06d", &p->course[i].no);
			if (p->course[i].no == 0) { break; }
			printf("请输入课程名称：");
			scanf("%s", &p->course[i].name);
			printf("请输入考试成绩：");
			scanf("%f", &p->course[i].examScore);
			printf("请输入平时成绩：");
			scanf("%f", &p->course[i].usualScore);
			printf("请输入综合成绩：");
			scanf("%f", &p->course[i].finalScore);
			printf("请输入学分：");
			scanf("%f", &p->course[i].point);
			p->obtainedPoint += p->course[i].point;	//累加已获得的学分
			printf("是否需要重修（输入“是，否”,）：");
			scanf("%s", &p->course[i].isReStudy);
			if (strcmp(p->course[i].isReStudy, "是") == 0)
			{
				printf("请输入重修次数：");
				scanf("%d", &p->course[i].resTimes);
				for (j = 0; j < p->course[i].resTimes; j++)
				{
					printf("请输入重修学期：");
					scanf("%d", &p->course[i].reStudy[j].term);
					printf("请输入重修成绩：");
					scanf("%f", &p->course[i].reStudy[j].score);
				}
			}
			p->courseCount++;//该学生所选课程数+1
		}
		//向链表中插入新节点
		ListAppend(headNode, p);
	}
	//system("cls");//清屏
	return;
}

void DeleteStuInfo(STUDENT*& headNode)
{
	char destNo[20];
	int i = 0;
	printf("请输入要删除的学生的学生号（返回请输入0）：");
	scanf("%s", &destNo);
	if (strcmp(destNo, "0") == 0) { return; }
	STUDENT* tempNode = headNode;
	while (tempNode->next != NULL)
	{
		if (strcmp(tempNode->next->no, destNo) == 0)
		{
			tempNode->next = tempNode->next->next;
			printf("已成功删除该学生...\n");
			return;
		}
		tempNode = tempNode->next;
	}
	printf("错误：未找到该学生...\n");
}

//在链表的末尾新增节点
void ListAppend(STUDENT*& headNode, STUDENT*& newNode)
{
	STUDENT* tempNode = headNode;
	while (tempNode->next != NULL)
	{
		tempNode = tempNode->next;
	}
	tempNode->next = newNode;
	newNode->next = NULL;
}

//链表初始化
void ListInit(STUDENT*& headNode)
{
	headNode = (STUDENT*)malloc(sizeof(STUDENT));	//为头节点分配内存
	headNode->next = NULL;							//将头节点的后继节点设为空
	return;
}

//加载学生信息（从文件）
void LoadStuInfo(STUDENT*& headNode)
{
	int i = 0; int j = 0;
	FILE* fp = fopen("stu.txt", "r");	//打开以便读取。 如果文件不存在或无法找到fopen调用失败。
	if (fp == NULL) { return; }			//如果文件不存在，说明本系统没有任何学生记录

	//如果文件存在，则从文件中读取学生记录至链表
	STUDENT* newNode = (STUDENT*)malloc(sizeof(STUDENT));
	newNode->next = NULL;
	*newNode = { 0 };
	while (fscanf(fp, "%s %s %d %s %d %s %05d %d %f\n",
		&newNode->no,
		&newNode->name,
		&newNode->classNo,
		&newNode->gender,
		&newNode->age,
		&newNode->telephoneNum,
		&newNode->dormNum,
		&newNode->courseCount,
		&newNode->obtainedPoint
	) != EOF)
	{
		//读取该学生所选课程的基本信息（如果存在）
		for (i = 0; i < newNode->courseCount; i++)
		{
			fscanf(fp, "%06d %s %f %f %f %f %s %d \n",
				&newNode->course[i].no,
				&newNode->course[i].name,
				&newNode->course[i].examScore,
				&newNode->course[i].usualScore,
				&newNode->course[i].finalScore,
				&newNode->course[i].point,
				&newNode->course[i].isReStudy,
				&newNode->course[i].resTimes);
			//读取该学生所选课程的重修信息（如果存在）
			for (j = 0; j < newNode->course[i].resTimes; j++)
			{
				fscanf(fp, "%d %f \n",
					&newNode->course[i].reStudy[j].term,
					&newNode->course[i].reStudy[j].score);
			}
		}
		ListAppend(headNode, newNode);
		newNode->next = NULL;
		//重新申请内存
		newNode = (STUDENT*)malloc(sizeof(STUDENT));
		newNode->next = NULL;
		*newNode = { 0 };
	}
	//关闭文件指针
	fclose(fp);

}
//保存学生信息
void SaveStuInfo(STUDENT* headNode)
{
	int i = 0; int j = 0;
	FILE* fp = fopen("stu.txt", "w"); //打开用于写入的空文件。 如果给定文件存在，则其内容会被销毁。
	if (fp == NULL) { printf("【error】打开文件失败...\n"); return; }
	while (headNode->next != NULL)
	{
		//
		headNode->next->obtainedPoint;
		//保存学生基本信息
		fprintf(fp, "%s %s %d %s %d %s %05d %d %.1f\n",
			headNode->next->no,
			headNode->next->name,
			headNode->next->classNo,
			headNode->next->gender,
			headNode->next->age,
			headNode->next->telephoneNum,
			headNode->next->dormNum,
			headNode->next->courseCount,
			headNode->next->obtainedPoint
		);

		//保存该学生所选课程的基本信息（如果存在）
		for (i = 0; i < headNode->next->courseCount; i++)
		{
			fprintf(fp, "%06d %s %.1f %.1f %.1f %.1f %s %d \n",
				headNode->next->course[i].no,
				headNode->next->course[i].name,
				headNode->next->course[i].examScore,
				headNode->next->course[i].usualScore,
				headNode->next->course[i].finalScore,
				headNode->next->course[i].point,
				headNode->next->course[i].isReStudy,
				headNode->next->course[i].resTimes);

			//保存该学生所选课程的重修信息（如果存在）
			for (j = 0; j < headNode->next->course[i].resTimes; j++)
			{
				fprintf(fp, "%d %.1f \n",
					headNode->next->course[i].reStudy[j].term,
					headNode->next->course[i].reStudy[j].score);
			}
		}

		headNode = headNode->next;
	}
	//关闭文件指针
	fclose(fp);
	printf("保存学生数据成功！\n");
	return;
}

//按课程统计
void SortByCourse(STUDENT* headNode)
{

	int i = 0;
	while (true)
	{
		STUDENT* tempNode = headNode;
		printf("请输入课程编号（返回请输入0）：");
		int destCourse = 0;
		scanf("%d", &destCourse);
		if (destCourse == 0) { break; };
		printf("\n\t\t课程名称\t学号\t姓名\t平时成绩\t考试成绩\t综合成绩\t学分\t是否重修 \n");
		printf("\t\t--------------------------------------------------------------------------------\n");
		while (tempNode->next != NULL)
		{
			for (i = 0; i < tempNode->next->courseCount; i++)
			{
				if (tempNode->next->course[i].no == destCourse)//查找该学生是否已修该课
				{
					printf("\t\t%s\t%s\t%s\t%f\t%f\t%f\t%.1f\t%s\t\n",
						tempNode->next->course[i].name,
						tempNode->next->no,
						tempNode->next->name,
						tempNode->next->course[i].usualScore,
						tempNode->next->course[i].examScore,
						tempNode->next->course[i].finalScore,
						tempNode->next->course[i].point,
						tempNode->next->course[i].isReStudy);
				}
			}
			tempNode = tempNode->next;
		}
	}

}
//按班统计
void SortByClass(STUDENT* headNode)
{
	int sorted[100] = { 0 };
	int sortedCount = 0;
	int i = 0; int j = 0; int k = 0;
	STUDENT* tempNode = headNode;
	bool ISEXIST = false;
	while (tempNode->next != NULL)
	{
		for (i = 0; i < sortedCount; i++)
		{
			if (tempNode->next->classNo == sorted[i]) { ISEXIST = true; break; }
		}
		if (ISEXIST == false)
		{
			sorted[sortedCount] = tempNode->next->classNo;
			sortedCount++;

			STUDENT* temp = tempNode;
			printf("\n\t\t****************************软件R(%d)班的统计结果***********************************\n", temp->next->classNo);
			printf("学号\t姓名\t性别\t班级号\t课程号\t课程名称\t平时成绩\t考试成绩\t综合成绩\t学分\t是否重修\t重修次数\t重修情况 \n");
			while (temp->next != NULL)
			{//本次循环是打印班级相同的学生信息
				bool isFirstPrintSno = true;
				if (temp->next->classNo == tempNode->next->classNo)
				{
					for (j = 0; j < temp->next->courseCount; j++)
					{
						//仅打印一次学生基本信息
						if (isFirstPrintSno)
						{
							printf("%s\t%s\t%s\t%d\t",
								temp->next->no,
								temp->next->name,
								temp->next->gender,
								temp->next->classNo);
							isFirstPrintSno = false;
						}
						else
						{
							printf("\t\t\t\t");
						}
						//每次都打印学生的课程信息
						printf("%06d\t%s\t%.1f\t\t%.1f\t\t%.1f\t\t%.1f\t%s\t\t%d\t",
							temp->next->course[j].no,
							temp->next->course[j].name,
							temp->next->course[j].usualScore,
							temp->next->course[j].examScore,
							temp->next->course[j].finalScore,
							temp->next->course[j].point,
							temp->next->course[j].isReStudy,
							temp->next->course[j].resTimes
						);
						//每次都打印学生的重修信息
						for (i = 0; i < temp->next->course[j].resTimes; i++)
						{
							printf("|第%d次：第%d学期，%.1lf分|", i + 1, temp->next->course[j].reStudy[i].term, temp->next->course[j].reStudy[i].score);
						}
						printf("\n");
					}
				}

				temp = temp->next;
			}
		}
		ISEXIST = false;
		tempNode = tempNode->next;
	}
}

//统计每个学生的不及格课程
void SortByFailCourse(STUDENT* headNode)
{
	printf("\t\t  学号\t姓名\t班级\t已修学分\t不及格课程\n");
	STUDENT* tempNode = headNode;
	int i = 0;
	while (tempNode->next != NULL)
	{
		printf("\t\t%s\t%s\t%d班\t%.1f\t", tempNode->next->no, tempNode->next->name, tempNode->next->classNo, tempNode->next->obtainedPoint);
		for (i = 0; i < tempNode->next->courseCount; i++)
		{
			if (tempNode->next->course[i].finalScore < 60)
			{//小于60分认为是不及格，打印课程名称
				printf("%s ", tempNode->next->course[i].name);
			}
		}
		printf("\n");
		tempNode = tempNode->next;
	}
}

void ShowAllStuInfo(STUDENT* headNode)
{
	STUDENT* temp = headNode;
	int i = 0;
	int j = 0;
	printf("学号\t姓名\t性别\t班级号\t课程号\t课程名称\t平时成绩\t考试成绩\t综合成绩\t学分\t是否重修\t重修次数\t重修情况 \n");
	while (temp->next != NULL)
	{
		for (j = 0; j < temp->next->courseCount; j++)
		{
			printf("%s\t%s\t%s\t%d\t%06d\t%s\t%.1f\t\t%.1f\t\t%.1f\t\t%.1f\t%s\t\t%d\t",
				temp->next->no,
				temp->next->name,
				temp->next->gender,
				temp->next->classNo,
				temp->next->course[j].no,
				temp->next->course[j].name,
				temp->next->course[j].usualScore,
				temp->next->course[j].examScore,
				temp->next->course[j].finalScore,
				temp->next->course[j].point,
				temp->next->course[j].isReStudy,
				temp->next->course[j].resTimes);
			for (i = 0; i < temp->next->course[j].resTimes; i++)
			{
				printf("|第%d次：第%d学期，%.1lf分|", i + 1, temp->next->course[j].reStudy[i].term, temp->next->course[j].reStudy[i].score);
			}
			printf("\n");
		}
		temp = temp->next;
	}

}

int main()
{
	system("mode con cols=207 lines=200");
	//创建学生链表
	STUDENT* headNode;
	ListInit(headNode);
	//尝试从文件中读取记录
	LoadStuInfo(headNode);

	//打印主菜单
	int  n = 0;
	printf("\t\t*****************欢迎使用教务信息管理系统******************");
	do
	{
		printf("\n\t\t* ------------------------------------请选择------------------------------------ *\n");
		printf("\t\t* 1、新增学生信息及其课程成绩    \n");
		printf("\t\t* 2、按班统计学生选课情况及考试成绩\n");
		printf("\t\t* 3、按课程统计学生名单及考试成绩 \n");
		printf("\t\t* 4、统计并输出每个同学已修学分及不及格课程\n");
		printf("\t\t* 5、保存学生信息及其课程成绩并退出\n");
		printf("\t\t* 6、删除指定学生的信息\n");
		printf("\t\t* 7、显示所有学生信息\n");
		printf("\t\t* -----------------------------------0、退出------------------------------------ *\n\n");
		scanf("%d", &n);
		switch (n)
		{
			case 1:AddStuInfo(headNode); break;
			case 2:SortByClass(headNode); break;
			case 3:SortByCourse(headNode); break;
			case 4:SortByFailCourse(headNode); break;
			case 5:SaveStuInfo(headNode); break;
			case 6:DeleteStuInfo(headNode); break;
			case 7:ShowAllStuInfo(headNode); break;
			default:break;
		}

	} while (n != 0 && n != 8);

	system("pause");
}

