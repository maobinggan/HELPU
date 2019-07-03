#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include<stdio.h>
#include<string.h>
#include<stdlib.h>

#define MAXSIZE 100	/*链表中结构体数组的最大值*/

/*员工信息*/
struct EMPLOYEE
{
	int id;			//唯一标识
	int eCode;		//员工号
	char name[20];	//姓名
};

/*链表*/
typedef struct NODE
{
	EMPLOYEE data;
	NODE* next;
}NODE, * LINKLIST;

/*链表基本操作*/
int ListGetLength(NODE* headNode);									//获取链表总长度(包含头节点)
void ListInit(NODE*& headNode);										//链表的初始化
void ListAppend(NODE* headNode, EMPLOYEE newData);					//增加节点(在末尾追加)
bool ListDeleteByPos(NODE* headNode, int pos);						//删除节点(根据逻辑位置)
bool ListGetNodeByPos(NODE* headNode, int pos, NODE*& node);		//查找节点(根据逻辑位置)
bool ListLocateByCode(NODE* headNode, int eCode, int& pos);			//获取逻辑位置(根据学号)
void ListOrderByCode(NODE* headNode);								//链表排序(根据学号、冒泡排序)

/*文件读写操作*/
void SaveData(NODE* headNode);
void LoadData(NODE* headNode);
/**
* 函 数 名: ListInit
* 说    明：链表初始化
* 参    数: LINKLIST & headNode -
* 返 回 值: void
*/
void ListInit(NODE*& headNode)
{
	headNode = (NODE*)malloc(sizeof(NODE));			//为头节点分配内存
	memset(&headNode->data, 0x0, sizeof(EMPLOYEE));	//将头节点的数据域清零
	headNode->next = NULL;							//将头节点的指针域置空
	return;
}

/**
* 函 数 名: ListGetNodeByPos
* 说    明：根据逻辑位置序号获取节点
* 参    数: LINKLIST & headNode -
* 参    数: int pos - 逻辑位置（从1开始）
* 参    数: NODE & node - 获取的节点（OUT）
* 返 回 值: bool
*/
bool ListGetNodeByPos(NODE* headNode, int pos, NODE*& node)
{
	//判断逻辑位置是否越界
	if (pos < 1 || pos > ListGetLength(headNode)) { printf("【error】逻辑位置越界\n"); return false; }

	//获取该位置的节点
	NODE* tempNode = headNode;
	int count = 1;
	while (count < pos && tempNode->next != NULL)
	{
		tempNode = tempNode->next;
		count++;
	}
	node = tempNode;
	return true;
}


/**
* 函 数 名: ListAppend
* 说    明：增加节点（从链表末尾追加）
* 参    数: NODE * & headNode -
* 参    数: NODE * & newNode -
* 返 回 值: void
*/
void ListAppend(NODE* headNode, EMPLOYEE newData)
{

	//初始化一个新节点
	NODE* newNode;
	ListInit(newNode);

	//赋值
	newNode->data = newData;

	//插入到链表末尾
	NODE* tempNode = headNode;
	while (tempNode->next != NULL)
	{
		tempNode = tempNode->next;
	}

	tempNode->next = newNode;
	newNode->next = NULL;
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
* 函 数 名: ListDeleteByPos
* 说    明：根据逻辑位置序号删除节点
* 参    数: NODE * & headNode -
* 参    数: int pos - 逻辑位置（从1开始，1是头节点，不允许通过此函数删除头节点）
* 返 回 值: bool
*/
bool ListDeleteByPos(NODE* headNode, int pos)
{
	//判断逻辑位置是否越界
	if (pos > ListGetLength(headNode)) 
	{ 
		printf("【error】逻辑位置越界 \n"); 
		return false; 
	}

	if (pos < 2) 
	{
		printf("【error】头节点不允许删除 \n"); 
		return false; 
	}

	//查找指定逻辑位置的前驱节点
	NODE* preNode;
	ListGetNodeByPos(headNode, pos - 1, preNode);

	//删除节点：即修改目标节点的前驱节点的指针域
	preNode->next = preNode->next->next;
	return true;
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
	FILE* pFile = fopen("stu.txt", "wb"); //打开用于写入的空文件。 如果给定文件存在，则其内容会被销毁。
	if (pFile == NULL)
	{ 
		printf("【error】pFile is null...\n"); 
		return; 
	}

	//写入学生信息至文件
	NODE* tempNode = headNode->next;
	while (tempNode != NULL)
	{
		fwrite(&tempNode->data, sizeof(EMPLOYEE), 1, pFile);
		tempNode = tempNode->next;
	}

	//关闭文件
	fclose(pFile);
	printf("[写入文件成功]\n");
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
	FILE* pFile = fopen("stu.txt", "rb"); //打开以便读取。 如果文件不存在或无法找到fopen调用失败。
	if (pFile == NULL) 
	{ 
		return; 
	}		//如果文件不存在，说明本系统没有任何学生记录

	//读取
	EMPLOYEE newData;
	while (fread(&newData, sizeof(EMPLOYEE), 1, pFile) != 0)
	{
		ListAppend(headNode, newData);
	}

	//关闭文件
	fclose(pFile);
	printf("[读取文件成功]\n");
	return;
}


/**
* 函 数 名: ListLocateByCode
* 说    明：查找节点的逻辑位置（通过编号）
* 参    数: NODE * headNode -
* 参    数: int studentNumber -
* 参    数: int & pos - 返回逻辑位置（OUT）
* 返 回 值: bool
*/
bool ListLocateByCode(NODE* headNode, int eCode, int& pos)
{
	NODE* tempNode = headNode;
	pos = 2;//逻辑位置从2开始查找（即头节点的下一节点，因为头节点不存数据）
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.eCode == eCode)
		{
			return true;
		}
		tempNode = tempNode->next;
		pos++;
	}

	pos = 0;//查不到，置零
	return false;
}

/**
* 函 数 名: ListOrderByCode
* 说    明：链表排序：按编号升序（冒泡排序）
* 参    数: NODE * headNode -
* 返 回 值: void
*/
void ListOrderByCode(NODE* headNode)
{
	//获取链表总长度
	int length = ListGetLength(headNode);

	//长度减一，去掉头节点，得到链表有效节点的个数
	length--;

	//冒泡排序
	int i = 0; int j = 0;
	for (i = 0; i < length - 1; i++)
	{
		NODE* tempNode_i = headNode->next;
		NODE* tempNode_j = tempNode_i;
		for (j = 0; j < length - 1 - i; j++)
		{
			if (tempNode_j->data.eCode > tempNode_j->next->data.eCode)
			{
				//交换：仅交换节点数据域即可，指针域不变
				EMPLOYEE tempData = tempNode_j->data;
				tempNode_j->data = tempNode_j->next->data;
				tempNode_j->next->data = tempData;
			}

			tempNode_j = tempNode_j->next;
		}
	}
}


/**
* 函 数 名: Service_AddInfo
* 说    明：增
* 参    数: NODE * & headNode -
* 返 回 值: void
*/
void Service_AddInfo(NODE*& headNode)
{

	//录入学生信息
	EMPLOYEE newData;
	printf("员工编号：");
	scanf("%d", &newData.eCode);
	printf("名字：");
	scanf("%s", newData.name);
	int pos = 0;
	if (ListLocateByCode(headNode, newData.eCode, pos) != NULL) 
	{ 
		printf("[录入失败，此员工编号已存在]\n");
		return; 
	}

	//插入链表末尾
	ListAppend(headNode, newData);
	printf("[录入成功]\n");
}


/**  
* 函 数 名: Service_DropInfoByCode 
* 说    明：删（通过编号）
* 参    数: NODE * headNode - 
* 返 回 值: void 
*/
void Service_DropInfoByCode(NODE* headNode)
{
	int destSCode = 0;
	printf("请输入要删除的员工编号：");
	scanf("%d", &destSCode);

	//遍历链表，查找此编号的节点逻辑位置
	int pos = 0;
	if (ListLocateByCode(headNode, destSCode, pos))
	{
		//删除该节点
		ListDeleteByPos(headNode, pos);
		printf("[删除成功]\n");
		return;
	}
	printf("[删除失败，找不到此编号]\n");
	return;
}

/**  
* 函 数 名: Service_AlterInfoByCode 
* 说    明：改（通过编号）
* 参    数: NODE * headNode - 
* 返 回 值: void 
*/
void Service_AlterInfoByCode(NODE* headNode)
{
	int destSCode = 0;
	printf("请输入要修改的员工编号：");
	scanf("%d", &destSCode);

	//查找此编号所在节点的逻辑位置
	int pos = 0;
	if (ListLocateByCode(headNode, destSCode, pos))
	{
		//根据节点的逻辑位置获取节点、直接修改此节点即可
		NODE* destNode;
		ListGetNodeByPos(headNode, pos, destNode);

		//录入新的信息
		printf("新的姓名：");
		scanf("%s", destNode->data.name);

		printf("[修改信息成功]\n");
		return;
	}

	printf("[修改信息失败，找不到此编号]\n");
	return;
}

/**  
* 函 数 名: Service_SearchInfoByCode 
* 说    明：查：通过编号
* 参    数: NODE * headNode - 
* 返 回 值: void 
*/
void Service_SearchInfoByCode(NODE* headNode)
{
	int destSCode = 0;
	printf("请输入要查询的员工编号：");
	scanf("%d", &destSCode);

	//查找指定编号的节点逻辑位置
	int pos = 0;
	if (ListLocateByCode(headNode, destSCode, pos))
	{
		//根据节点逻辑位置，获取节点
		NODE* tempNode;
		ListGetNodeByPos(headNode, pos, tempNode);

		//打印节点的数据域
		printf("员工编号=%d\t姓名=%s\t\n", tempNode->data.eCode, tempNode->data.name);
		return;
	}

	printf("[查询失败，找不到此编号]\n");
	return;
}

/**  
* 函 数 名: Service_ShowAllStu_OrderByCode 
* 说    明：排序输出(按编号升序)
* 参    数: NODE * & headNode - 
* 返 回 值: void 
*/
void Service_ShowAllStu_OrderByCode(NODE*& headNode)
{
	//链表排序：按编号升序
	ListOrderByCode(headNode);

	//打印链表
	NODE* tempNode = headNode->next;
	printf("[排序所有员工信息(按编号升序)]\n");
	while (tempNode != NULL)
	{
		printf("编号=%08d\t姓名=%s\n", tempNode->data.eCode, tempNode->data.name);
		tempNode = tempNode->next;
	}
}

int main()
{
	//链表初始化
	NODE* headNode;
	ListInit(headNode);

	//从文件中读取记录
	LoadData(headNode);

	while (true)
	{
		//主菜单
		system("cls");
		printf("\t\t************************\n");
		printf("\t\t**员工管理系统\n");
		printf("\t\t*1.增加员工信息\n");
		printf("\t\t*2.删除员工信息\n");
		printf("\t\t*3.修改员工信息\n");
		printf("\t\t*4.查询员工信息(按编号)\n");
		printf("\t\t*5.排序员工信息(按编号升序)\n");
		printf("\t\t*6.保存至文件\n");
		printf("\t\t************************\n");

		int option = 0;
		scanf("%d", &option);
		switch (option)
		{
			case 1:
			{
				Service_AddInfo(headNode);					
				break;
			}
			case 2:
			{
				Service_DropInfoByCode(headNode);
				break;
			}
			case 3:
			{
				Service_AlterInfoByCode(headNode);
				break;
			}
			case 4:
			{
				Service_SearchInfoByCode(headNode);
				break;
			}
			case 5:
			{
				Service_ShowAllStu_OrderByCode(headNode);
				break;
			}
			case 6:
			{
				SaveData(headNode);
				break;
			}
			default:break;
		}

		system("pause");
		getchar();
	}


}
