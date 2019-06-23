// 20190623_基于链表的学生成绩管理系统.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
#define _CRT_SECURE_NO_WARNINGS

#include<stdio.h>
#include<string.h>
#include<stdlib.h>
#define MAXSIZE 100	/*给定结构体数组的最大值*/

/*学生信息*/
struct STUDENT
{
	char student_name[20];/*学生的名字*/
	char score3lass[20];//学生的班级
	char sex[5];
	int student_number;/*学生的学号*/
	float score1;//各科成绩
	float score2;
	float score3;
	float score4;
	float score5;
	float all, aver;
};

/*链表*/
typedef struct NODE
{
	STUDENT data;
	NODE* next;
}NODE, * LINKLIST;

/*链表基本操作*/
int ListGetLength(NODE* headNode);
void ListInit(NODE** headNode);
void ListAppend(NODE** headNode, NODE** newNode);
bool ListDeleteByPos(NODE** headNode, int pos);
bool ListGetNodeByPos(NODE* headNode, int pos, NODE** node);
bool ListLocateByStuNum(NODE* headNode, int studentNumber, int& pos);
bool ListLocateByStuName(NODE* headNode, char* destNumber, int& pos);
void ListOrderByStuNumber(NODE* headNode);
void ListOrderByTotalScore(NODE* headNode);

/*业务逻辑*/
void Service_ShowAllStuInfo_OrderByStuNum(NODE** headNode);
void Service_ShowAllStuInfo_OrderByTotalScore(NODE** headNode);
void Service_AddStuInfo(NODE** headNode);
void Service_AlterStuInfoByStuNumber(NODE* headNode);
void Service_SearchByStuName(NODE* headNode);
void Service_SearchByStuNumber(NODE* headNode);
void Service_DropStuInfoByStuNumber(NODE* headNode);
void ev_grade(NODE* headNode);
void evsub_ave(NODE* headNode);

/*文件读写*/
void SaveData(NODE* headNode);
void LoadData(NODE* headNode);


/**
* 函 数 名: ListInit
* 说    明：链表初始化
* 参    数: LINKLIST & headNode -
* 返 回 值: void
*/
void ListInit(NODE** headNode)
{
	*headNode = (NODE*)malloc(sizeof(NODE));			//为头节点分配内存
	memset(&(*headNode)->data, 0x0, sizeof(STUDENT));	//将头节点的数据域清零
	(*headNode)->next = NULL;								//将头节点的指针域置空
	return;
}


/**
* 函 数 名: ListGetNodeByPos
* 说    明：根据逻辑位置序号获取节点
* 参    数: LINKLIST & headNode -
* 参    数: int pos -
* 参    数: NODE & node - 获取的节点
* 返 回 值: bool
*/
bool ListGetNodeByPos(NODE* headNode, int pos, NODE** node)
{
	NODE* tempNode = headNode;
	int count = 1;
	while (count < pos && tempNode->next != NULL)
	{
		tempNode = tempNode->next;
		count++;
	}
	//未找到，指定的逻辑位置超过了链表末尾
	if (tempNode->next == NULL) { return false; }

	//找到
	if (count == pos) { *node = tempNode->next; return true; }
}


/**
* 函 数 名: ListAppend
* 说    明：在链表的末尾新增节点
* 参    数: NODE * & headNode -
* 参    数: NODE * & newNode -
* 返 回 值: void
*/
void ListAppend(NODE** headNode, NODE** newNode)
{
	NODE* tempNode = *headNode;
	while (tempNode->next != NULL)
	{
		tempNode = tempNode->next;
	}
	tempNode->next = *newNode;
	(*newNode)->next = NULL;
}

/**
* 函 数 名: ListDeleteByPos
* 说    明：根据逻辑位置序号删除节点
* 参    数: NODE * & headNode -
* 参    数: int pos -
* 返 回 值: bool
*/
bool ListDeleteByPos(NODE** headNode, int pos)
{
	//查找指定位置的节点
	NODE* tempNode = *headNode;
	int count = 1;
	while (count < pos && tempNode->next != NULL)
	{
		tempNode = tempNode->next;
		count++;
	}

	//未找到，指定的逻辑位置超过了链表末尾
	if (tempNode->next == NULL) { return false; }

	//找到，则删除该节点
	if (count == pos)
	{
		tempNode->next = tempNode->next->next;
		return true;
	}
}

/**
* 函 数 名: ShowAllStuInfo
* 说    明：显示所有学生信息，按学号升序
* 参    数: NODE * & headNode -
* 返 回 值: void
*/
void Service_ShowAllStuInfo_OrderByStuNum(NODE** headNode)
{
	//链表排序：按学号升序
	ListOrderByStuNumber(*headNode);

	//打印链表
	NODE* tempNode = (*headNode)->next;
	printf("[显示所有学生]\n");
	while (tempNode != NULL)
	{
		printf("学号=%08d\t名字=%s\t性别=%s\t班级=%s\t成绩一=%0.2f\t成绩二=%0.2f\t成绩三=%0.2f\t成绩四=%0.2f\t成绩五=%0.2f\t总分=%4.0f\t平均成绩=%0.2f\n",
			tempNode->data.student_number,
			tempNode->data.student_name,
			tempNode->data.sex,
			tempNode->data.score3lass,
			tempNode->data.score1,
			tempNode->data.score2,
			tempNode->data.score3,
			tempNode->data.score4,
			tempNode->data.score5,
			tempNode->data.all,
			tempNode->data.aver
		);
		tempNode = tempNode->next;
	}
}
/**
* 函 数 名: ShowAllStuInfo
* 说    明：显示所有学生信息，按总分升序
* 参    数: NODE * & headNode -
* 返 回 值: void
*/
void Service_ShowAllStuInfo_OrderByTotalScore(NODE** headNode)
{
	//链表排序：按总分升序
	ListOrderByTotalScore(*headNode);

	//打印链表
	NODE* tempNode = (*headNode)->next;
	printf("[显示所有学生]\n");
	while (tempNode != NULL)
	{
		printf("学号=%08d\t名字=%s\t性别=%s\t班级=%s\t成绩一=%0.2f\t成绩二=%0.2f\t成绩三=%0.2f\t成绩四=%0.2f\t成绩五=%0.2f\t总分=%4.0f\t平均成绩=%0.2f\n",
			tempNode->data.student_number,
			tempNode->data.student_name,
			tempNode->data.sex,
			tempNode->data.score3lass,
			tempNode->data.score1,
			tempNode->data.score2,
			tempNode->data.score3,
			tempNode->data.score4,
			tempNode->data.score5,
			tempNode->data.all,
			tempNode->data.aver
		);
		tempNode = tempNode->next;
	}
}
/**
* 函 数 名: AddStuInfo
* 说    明：新增学生
* 参    数: NODE * & headNode -
* 返 回 值: void
*/
void Service_AddStuInfo(NODE** headNode)
{
	int count = 0;
	printf("\t\t请输入你要录入学生信息的个数：");
	scanf("%d", &count);

	//
	int i = 0;
	for (i = 0; i < count; i++)
	{
		NODE* newNode;
		ListInit(&newNode);

		printf("\t\t请录入学生的名字：");
		scanf("%s", newNode->data.student_name);
		printf("\t\t请录入学生的性别：");
		scanf("%s", newNode->data.sex);
		printf("\t\t请录入学生的学号：");
		scanf("%d", &newNode->data.student_number);
		printf("\t\t请录入学生的班级：");
		scanf("%s", newNode->data.score3lass);
		printf("\t\t请录入学生的成绩一：");
		scanf("%f", &newNode->data.score1);
		printf("\t\t请录入学生的成绩二：");
		scanf("%f", &newNode->data.score2);
		printf("\t\t请录入学生的成绩三：");
		scanf("%f", &newNode->data.score3);
		printf("\t\t请录入学生的成绩四：");
		scanf("%f", &newNode->data.score4);
		printf("\t\t请录入学生的成绩五：");
		scanf("%f", &newNode->data.score5);

		//计算总分、平局分
		newNode->data.all = newNode->data.score1 + newNode->data.score2 + newNode->data.score3 + newNode->data.score4 + newNode->data.score5;
		newNode->data.aver = newNode->data.all / 5;

		//插入链表末尾
		ListAppend(headNode, &newNode);
	}
}
/**
* 函 数 名: SaveData
* 说    明：将链表保存至文件
* 参    数: NODE * headNode -
* 返 回 值: void
*/
void SaveData(NODE* headNode)
{
	//打开文件
	FILE* pFile = fopen("exam.dat", "w"); //打开用于写入的空文件。 如果给定文件存在，则其内容会被销毁。
	if (pFile == NULL) { printf("【error】pFile is null...\n"); return; }

	//写入学生信息至文件
	NODE* tempNode = headNode->next;
	while (tempNode != NULL)
	{
		fwrite(&tempNode->data, sizeof(STUDENT), 1., pFile);
		tempNode = tempNode->next;
	}

	//关闭文件
	fclose(pFile);
	printf("[保存学生数据成功]\n");
	return;
}

/**
* 函 数 名: LoadData
* 说    明：从文件加载信息至链表
* 参    数: NODE * headNode -
* 返 回 值: void
*/
void LoadData(NODE* headNode)
{
	//打开文件
	FILE* pFile = fopen("exam.dat", "r"); //打开以便读取。 如果文件不存在或无法找到fopen调用失败。
	if (pFile == NULL) { return; }		//如果文件不存在，说明本系统没有任何学生记录

	//读取
	NODE* newNode;
	ListInit(&newNode);
	while (fread(&newNode->data, sizeof(STUDENT), 1., pFile) != 0)
	{
		ListAppend(&headNode, &newNode);
		ListInit(&newNode);
	}

	//关闭文件
	fclose(pFile);
	printf("保存学生数据成功！\n");
	return;
}

/**
* 函 数 名: ListLocateByStuNum
* 说    明：通过学号查找节点的逻辑位置
* 参    数: NODE * headNode -
* 参    数: int studentNumber -
* 参    数: int & pos - 返回逻辑位置
* 返 回 值: bool
*/
bool ListLocateByStuNum(NODE* headNode, int studentNumber, int& pos)
{
	NODE* tempNode = headNode;
	pos = 1;
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.student_number == studentNumber)
		{
			return true;
		}
		tempNode = tempNode->next;
		pos++;
	}
	pos = 0;
	return false;
}


/**
* 函 数 名: Service_AlterStuInfoByStuNumber
* 说    明：修改学生信息：根据学号
* 参    数: NODE * headNode -
* 返 回 值: void
*/
void Service_AlterStuInfoByStuNumber(NODE* headNode)
{
	int destStuNumber = 0;
	printf("\t\t请输入要修改的学生的学号：");
	scanf("%d", &destStuNumber);
	//查找此学号所在节点的逻辑位置
	int pos = 0;
	if (ListLocateByStuNum(headNode, destStuNumber, pos))
	{
		//根据节点的逻辑位置获取节点
		NODE* destNode;
		ListGetNodeByPos(headNode, pos, &destNode);

		//录入新的学生信息
		printf("\t\t请录入学生的名字：");
		scanf("%s", destNode->data.student_name);
		printf("\t\t请录入学生的性别：");
		scanf("%s", destNode->data.sex);
		printf("\t\t请录入学生的班级：");
		scanf("%s", destNode->data.score3lass);
		printf("\t\t请录入学生的成绩一：");
		scanf("%f", &destNode->data.score1);
		printf("\t\t请录入学生的成绩二：");
		scanf("%f", &destNode->data.score2);
		printf("\t\t请录入学生的成绩三：");
		scanf("%f", &destNode->data.score3);
		printf("\t\t请录入学生的成绩四：");
		scanf("%f", &destNode->data.score4);
		printf("\t\t请录入学生的成绩五：");
		scanf("%f", &destNode->data.score5);

		//计算总分、平局分
		destNode->data.all = destNode->data.score1 + destNode->data.score2 + destNode->data.score3 + destNode->data.score4 + destNode->data.score5;
		destNode->data.aver = destNode->data.all / 5;

		printf("[修改学生信息成功]\n");
		return;
	}

	printf("[修改失败，找不到此学号]\n");
	return;

}

/**
* 函 数 名: Service_SearchByStuName
* 说    明：根据姓名查询学生信息
* 参    数: NODE * headNode -
* 返 回 值: void
*/
void Service_SearchByStuName(NODE* headNode)
{
	char destStuName[10] = { 0 };
	printf("请输入要查询的学生的姓名：");
	scanf("%s", destStuName);

	//遍历链表，查找指定学号的节点逻辑位置
	int pos = 0;
	if (ListLocateByStuName(headNode, destStuName, pos))
	{
		//根据节点逻辑位置，获取节点
		NODE* tempNode;
		ListGetNodeByPos(headNode, pos, &tempNode);

		//打印节点的数据域
		printf("名字=%s\t\n性别=%s\t\n学号=%d\t\n班级=%s\t\n成绩一=%0.2f\t\n成绩二=%0.2f\t\n成绩三=%0.2f\n成绩四=%0.2f\n成绩五=%0.2f\n\n",
			tempNode->data.student_name,
			tempNode->data.sex,
			tempNode->data.student_number,
			tempNode->data.score3lass,
			tempNode->data.score1,
			tempNode->data.score2,
			tempNode->data.score3,
			tempNode->data.score4,
			tempNode->data.score5);
		return;
	}
	printf("[查询失败，找不到此学生姓名]\n");
	return;
}
/**
* 函 数 名: Service_SearchByStuNumber
* 说    明：根据学号查询学生信息
* 参    数: NODE * headNode -
* 返 回 值: void
*/
void Service_SearchByStuNumber(NODE* headNode)
{
	int destStuNumber = 0;
	printf("请输入要查询的学生的学号：");
	scanf("%d", &destStuNumber);

	//遍历链表，查找指定学号的节点逻辑位置
	int pos = 0;
	if (ListLocateByStuNum(headNode, destStuNumber, pos))
	{
		//根据节点逻辑位置，获取节点
		NODE* tempNode;
		ListGetNodeByPos(headNode, pos, &tempNode);

		//打印节点的数据域
		printf("名字=%s\t\n性别=%s\t\n学号=%d\t\n班级=%s\t\n成绩一=%0.2f\t\n成绩二=%0.2f\t\n成绩三=%0.2f\n成绩四=%0.2f\n成绩五=%0.2f\n\n",
			tempNode->data.student_name,
			tempNode->data.sex,
			tempNode->data.student_number,
			tempNode->data.score3lass,
			tempNode->data.score1,
			tempNode->data.score2,
			tempNode->data.score3,
			tempNode->data.score4,
			tempNode->data.score5);
		return;
	}
	printf("[查询失败，找不到此学号]\n");
	return;
}

/**
* 函 数 名: Service_DropStuInfoByStuNumber
* 说    明：通过学号移除学生信息
* 参    数: NODE * headNode -
* 返 回 值: void
*/
void Service_DropStuInfoByStuNumber(NODE* headNode)
{
	int destStuNumber = 0;
	printf("请输入要删除的学生的学号：");
	scanf("%d", &destStuNumber);

	//遍历链表，查找指定学号的节点逻辑位置
	int pos = 0;
	if (ListLocateByStuNum(headNode, destStuNumber, pos))
	{
		//删除该节点
		ListDeleteByPos(&headNode, pos);
		printf("[删除成功]\n");
		return;
	}
	printf("[删除失败，找不到此学号]\n");
	return;
}

/**
* 函 数 名: ListGetLength
* 说    明：获取链表长度
* 参    数: NODE * headNode -
* 返 回 值: int
*/
int ListGetLength(NODE* headNode)
{
	int length = 1;
	NODE* tempNode = headNode;
	while (tempNode->next != NULL)
	{
		length++;
		tempNode = tempNode->next;
	}
	return length;
}

/**
* 函 数 名: ListLocateByStuName
* 说    明：通过学号查找节点的逻辑位置
* 参    数: NODE * headNode -
* 参    数: char * destNumber -
* 参    数: int & pos -
* 返 回 值: bool
*/
bool ListLocateByStuName(NODE* headNode, char* destNumber, int& pos)
{
	NODE* tempNode = headNode;
	pos = 1;
	while (tempNode->next != NULL)
	{
		if (strcmp(tempNode->next->data.student_name, destNumber) == 0)
		{
			return true;
		}
		tempNode = tempNode->next;
		pos++;
	}
	pos = 0;
	return false;
}

/**
* 函 数 名: ListSortByStuNumber
* 说    明：链表排序：按学号升序
* 参    数: NODE * headNode -
* 返 回 值: void
*/
void ListOrderByStuNumber(NODE* headNode)
{
	int i = 0;
	int j = 0;

	//获取链表总长度
	int length = ListGetLength(headNode);

	//去掉头节点，得到链表有效节点的个数
	length--;

	//冒泡排序
	for (i = 0; i < length - 1; i++)
	{
		NODE* tempNode_i = headNode->next;
		NODE* tempNode_j = tempNode_i;
		for (j = 0; j < length - 1 - i; j++)
		{
			if (tempNode_j->data.student_number > tempNode_j->next->data.student_number)
			{
				//仅交换数据域，指针域不变
				STUDENT tempData = tempNode_j->data;
				tempNode_j->data = tempNode_j->next->data;
				tempNode_j->next->data = tempData;
			}
			tempNode_j = tempNode_j->next;
		}
	}
}
/**
* 函 数 名: ListOrderByTotalScore
* 说    明：链表排序：按总分升序
* 参    数: NODE * headNode -
* 返 回 值: void
*/
void ListOrderByTotalScore(NODE* headNode)
{
	int i = 0;
	int j = 0;

	//获取链表总长度
	int length = ListGetLength(headNode);

	//去掉头节点，得到链表有效节点的个数
	length--;

	//冒泡排序
	for (i = 0; i < length - 1; i++)
	{
		NODE* tempNode_i = headNode->next;
		NODE* tempNode_j = tempNode_i;
		for (j = 0; j < length - 1 - i; j++)
		{
			if (tempNode_j->data.all > tempNode_j->next->data.all)
			{
				//仅交换数据域，指针域不变
				STUDENT tempData = tempNode_j->data;
				tempNode_j->data = tempNode_j->next->data;
				tempNode_j->next->data = tempData;
			}
			tempNode_j = tempNode_j->next;
		}
	}
}
//7每科的平均分并输出
void ev_grade(NODE* headNode)
{
	//计算每科的总分
	float totalScore[5] = { 0 };
	NODE* tempNode = headNode;
	while (tempNode->next != NULL)
	{
		totalScore[0] += tempNode->next->data.score1;
		totalScore[1] += tempNode->next->data.score2;
		totalScore[2] += tempNode->next->data.score3;
		totalScore[3] += tempNode->next->data.score4;
		totalScore[4] += tempNode->next->data.score5;
		tempNode = tempNode->next;
	}
	//获取学生人数
	float studentCount = ListGetLength(headNode) - 1;

	//计算并打印每科的平均分
	float avgScore[5] = { 0 };
	int i = 0;
	for (i = 0; i < 5; i++)
	{
		avgScore[i] = totalScore[i] / studentCount;
		printf("第%d门的平均成绩为：%3.2f\n", i + 1, avgScore[i]);
	}

	//打印低于平均分的学生名单
	printf("第1门科目低于平均分人员名单:\n");
	tempNode = headNode;
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.score1 < avgScore[0])
		{
			printf("名字=%s\t性别=%s\t学号=%d\t本门课成绩=%0.2f\t\n",
				tempNode->next->data.student_name,
				tempNode->next->data.sex,
				tempNode->next->data.student_number,
				tempNode->next->data.score1
			);
		}
		tempNode = tempNode->next;
	}

	printf("第2门科目低于平均分人员名单:\n");
	tempNode = headNode;
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.score2 < avgScore[1])
		{
			printf("名字=%s\t性别=%s\t学号=%d\t本门课成绩=%0.2f\t\n",
				tempNode->next->data.student_name,
				tempNode->next->data.sex,
				tempNode->next->data.student_number,
				tempNode->next->data.score2
			);
		}
		tempNode = tempNode->next;
	}
	printf("第3门科目低于平均分人员名单:\n");
	tempNode = headNode;
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.score3 < avgScore[2])
		{
			printf("名字=%s\t性别=%s\t学号=%d\t本门课成绩=%0.2f\t\n",
				tempNode->next->data.student_name,
				tempNode->next->data.sex,
				tempNode->next->data.student_number,
				tempNode->next->data.score3
			);
		}
		tempNode = tempNode->next;
	}
	printf("第4门科目低于平均分人员名单:\n");
	tempNode = headNode;
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.score4 < avgScore[3])
		{
			printf("名字=%s\t性别=%s\t学号=%d\t本门课成绩=%0.2f\t\n",
				tempNode->next->data.student_name,
				tempNode->next->data.sex,
				tempNode->next->data.student_number,
				tempNode->next->data.score4
			);
		}
		tempNode = tempNode->next;
	}

	printf("第5门科目低于平均分人员名单:\n");
	tempNode = headNode;
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.score5 < avgScore[4])
		{
			printf("名字=%s\t性别=%s\t学号=%d\t本门课成绩=%0.2f\t\n",
				tempNode->next->data.student_name,
				tempNode->next->data.sex,
				tempNode->next->data.student_number,
				tempNode->next->data.score5
			);
		}
		tempNode = tempNode->next;
	}

}

//8统计每门科目90分以上的同学及不及格同学
void evsub_ave(NODE* headNode)
{
	NODE* tempNode = headNode;

	printf("科目一90分以上的同学有：\n");
	tempNode = headNode;
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.score1 > 90)
		{
			printf("名字=%s\t性别=%s\t学号=%d\t成绩=%0.2f\t\n",
				tempNode->next->data.student_name,
				tempNode->next->data.sex,
				tempNode->next->data.student_number,
				tempNode->next->data.score1
			);
		}
		tempNode = tempNode->next;
	}
	printf("科目一不及格同学有：\n");
	tempNode = headNode;
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.score1 < 60)
		{
			printf("名字=%s\t性别=%s\t学号=%d\t成绩=%0.2f\t\n",
				tempNode->next->data.student_name,
				tempNode->next->data.sex,
				tempNode->next->data.student_number,
				tempNode->next->data.score1
			);
		}
		tempNode = tempNode->next;
	}
	printf("科目二90分以上的同学有：\n");
	tempNode = headNode;
	tempNode = headNode;
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.score2 > 90)
		{
			printf("名字=%s\t性别=%s\t学号=%d\t成绩=%0.2f\t\n",
				tempNode->next->data.student_name,
				tempNode->next->data.sex,
				tempNode->next->data.student_number,
				tempNode->next->data.score2
			);
		}
		tempNode = tempNode->next;
	}
	printf("科目二不及格同学有：\n");
	tempNode = headNode;
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.score2 < 60)
		{
			printf("名字=%s\t性别=%s\t学号=%d\t成绩=%0.2f\t\n",
				tempNode->next->data.student_name,
				tempNode->next->data.sex,
				tempNode->next->data.student_number,
				tempNode->next->data.score2
			);
		}
		tempNode = tempNode->next;
	}
	printf("科目三90分以上的同学有：\n");
	tempNode = headNode;
	tempNode = headNode;
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.score3 > 90)
		{
			printf("名字=%s\t性别=%s\t学号=%d\t成绩=%0.2f\t\n",
				tempNode->next->data.student_name,
				tempNode->next->data.sex,
				tempNode->next->data.student_number,
				tempNode->next->data.score3
			);
		}
		tempNode = tempNode->next;
	}
	printf("科目三不及格同学有：\n");
	tempNode = headNode;
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.score3 < 60)
		{
			printf("名字=%s\t性别=%s\t学号=%d\t成绩=%0.2f\t\n",
				tempNode->next->data.student_name,
				tempNode->next->data.sex,
				tempNode->next->data.student_number,
				tempNode->next->data.score3
			);
		}
		tempNode = tempNode->next;
	}
	printf("科目四90分以上的同学有：\n");
	tempNode = headNode;
	tempNode = headNode;
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.score4 > 90)
		{
			printf("名字=%s\t性别=%s\t学号=%d\t成绩=%0.2f\t\n",
				tempNode->next->data.student_name,
				tempNode->next->data.sex,
				tempNode->next->data.student_number,
				tempNode->next->data.score4
			);
		}
		tempNode = tempNode->next;
	}
	printf("科目四不及格同学有：\n");
	tempNode = headNode;
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.score4 < 60)
		{
			printf("名字=%s\t性别=%s\t学号=%d\t成绩=%0.2f\t\n",
				tempNode->next->data.student_name,
				tempNode->next->data.sex,
				tempNode->next->data.student_number,
				tempNode->next->data.score4
			);
		}
		tempNode = tempNode->next;
	}
	printf("科目五90分以上的同学有：\n");
	tempNode = headNode;
	tempNode = headNode;
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.score5 > 90)
		{
			printf("名字=%s\t性别=%s\t学号=%d\t成绩=%0.2f\t\n",
				tempNode->next->data.student_name,
				tempNode->next->data.sex,
				tempNode->next->data.student_number,
				tempNode->next->data.score5
			);
		}
		tempNode = tempNode->next;
	}
	printf("科目五不及格同学有：\n");
	tempNode = headNode;
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.score5 < 60)
		{
			printf("名字=%s\t性别=%s\t学号=%d\t成绩=%0.2f\t\n",
				tempNode->next->data.student_name,
				tempNode->next->data.sex,
				tempNode->next->data.student_number,
				tempNode->next->data.score5
			);
		}
		tempNode = tempNode->next;
	}
}

void menu()
{
	system("cls");
	printf("\t\t************************\n");
	printf("\t\t**学生成绩管理系统\n");
	printf("\t\t*1.增加学生信息\n");
	printf("\t\t*2.删除学生信息\n");
	printf("\t\t*3.修改学生信息\n");
	printf("\t\t*4.查找学生信息：根据学号\n");
	printf("\t\t*5.查找学生信息：根据姓名\n");
	printf("\t\t*6.浏览所有学生信息：按学号升序\n");
	printf("\t\t*7.浏览所有学生信息：按总分升序\n");
	printf("\t\t*8.计算每科的平均分并输出低于平均分的学生 \n");
	printf("\t\t*9.统计90分以上的同学及不及格同学 \n");
	printf("\t\t*10.保存至文件\n");
	printf("\t\t************************\n");
}

int main()
{
	//登录验证
	char user[] = "liuhuashagou";
	char key[] = "123";
	char user2[100], key2[100];
	printf("请输入用户名：\n");
	scanf("%s", user2);
	printf("请输入密码：\n");
	scanf("%s", key2);

	if (strcmp(user, user2) != 0 || strcmp(key, key2) != 0)
	{
		printf("用户名或密码错误！\n");
		system("pause");
		//return 0;
	}
	system("cls");

	//链表初始化
	NODE* headNode;
	ListInit(&headNode);

	//从文件中读取记录
	LoadData(headNode);

	while (true)
	{
		//打印主菜单
		menu();

		int option = 0;
		scanf("%d", &option);
		switch (option)
		{
			case 1:Service_AddStuInfo(&headNode);							break;
			case 2:Service_DropStuInfoByStuNumber(headNode);				break;
			case 3:Service_AlterStuInfoByStuNumber(headNode);				break;
			case 4:Service_SearchByStuNumber(headNode);						break;
			case 5:Service_SearchByStuName(headNode);						break;
			case 6:Service_ShowAllStuInfo_OrderByStuNum(&headNode);			break;
			case 7:Service_ShowAllStuInfo_OrderByTotalScore(&headNode);		break;
			case 8:ev_grade(headNode);										break;
			case 9:evsub_ave(headNode);										break;
			case 10:SaveData(headNode);										break;
			default:break;
		}

		system("pause");
		getchar();
	}
}
