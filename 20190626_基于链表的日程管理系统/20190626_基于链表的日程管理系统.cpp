// 20190626_基于链表的日程管理系统.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//
#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include<stdio.h>
#include<string.h>
#include<stdlib.h>
#include<time.h>
#define MAXSIZE 100	/*链表中结构体数组的最大值*/
/*日程表*/
struct SCHEDULE
{
	int id;
	int userId;
	char content[20];

	int year_start;
	int month_start;
	int day_start;
	int year_end;
	int month_end;
	int day_end;
	int year_create;
	int month_create;
	int day_create;
};

/*用户表*/
struct USER
{
	int id;
	char name[20];
	char password[20];
};

/*链表1:用户*/
typedef struct NODE_USER
{
	USER data;
	NODE_USER* next;
}NODE_USER, * LINKLIST_USER;

/*链表2:日程*/
typedef struct NODE_SCHEDULE
{
	SCHEDULE data;
	NODE_SCHEDULE* next;
}NODE_SCHEDULE, * LINKLIST_SCHEDULE;

int ListGetLength_USER(NODE_USER* headNode);
void ListInit_USER(NODE_USER*& headNode);
void ListAppend_USER(NODE_USER*& headNode, NODE_USER*& newNode);
bool ListDeleteByPos_USER(NODE_USER*& headNode, int pos);
bool ListGetNodeByPos_USER(NODE_USER* headNode, int pos, NODE_USER*& node);
bool ListLocateByName_USER(NODE_USER* headNode, char* userName, int& pos);

void SaveData_USER(NODE_USER* headNode);
void LoadData_USER(NODE_USER* headNode);

int ListGetLength_SCHEDULE(NODE_SCHEDULE* headNode);
void ListInit_SCHEDULE(NODE_SCHEDULE*& headNode);
void ListAppend_SCHEDULE(NODE_SCHEDULE*& headNode, NODE_SCHEDULE*& newNode);
bool ListDeleteByPos_SCHEDULE(NODE_SCHEDULE*& headNode, int pos);
bool ListGetNodeByPos_SCHEDULE(NODE_SCHEDULE* headNode, int pos, NODE_SCHEDULE*& node);
bool ListLocateById_SCHEDULE(NODE_SCHEDULE* headNode, int id, int& pos);

void SaveData_SCHEDULE(NODE_SCHEDULE* headNode);
void LoadData_SCHEDULE(NODE_SCHEDULE*& headNode);


bool SignIn(NODE_USER*& headNode, USER& user)
{
	USER inPutser;
	printf("用户名：\n");
	scanf("%s", inPutser.name);
	printf("密 码：\n");
	scanf("%s", inPutser.password);
	int length = ListGetLength_USER(headNode);

	NODE_USER* tempNode = headNode;
	while (tempNode->next != NULL)
	{
		if (strcmp(tempNode->next->data.name, inPutser.name) == 0
			&& strcmp(tempNode->next->data.password, inPutser.password) == 0)
		{
			user = tempNode->next->data;
			printf("[成功登录]");
			system("pause");
			return true;
		}
		tempNode = tempNode->next;
	}
	printf("[用户名或密码错误]\n");
	return false;

}
void SignUp(NODE_USER*& headNode)
{
	while (1)
	{
		USER inPutser;
		printf("注册用户名：\n");
		scanf("%s", inPutser.name);
		printf("注册密码：\n");
		scanf("%s", inPutser.password);

		int pos;
		if (ListLocateByName_USER(headNode, inPutser.name, pos))
		{
			printf("[注册失败，用户名已存在，请换一个用户名]\n");
			system("pause");
			continue;
		}

		NODE_USER* newNode;
		NODE_USER* preNode;
		ListInit_USER(newNode);
		int length = ListGetLength_USER(headNode);
		if (length > 1)
		{
			ListGetNodeByPos_USER(headNode, length, preNode);
			inPutser.id = preNode->data.id + 1;
		}
		else { inPutser.id = 1; }
		newNode->data = inPutser;
		ListAppend_USER(headNode, newNode);

		SaveData_USER(headNode);
		printf("[注册成功]\n");
		return;
	}


}

void Menu_Login(NODE_USER*& headNode, USER& user)
{
	while (true)
	{
		//主菜单
		system("cls");
		printf("\t\t************************\n");
		printf("\t\t**日程管理系统-登陆界面\n");
		printf("\t\t*1.登录\n");
		printf("\t\t*2.注册\n");
		printf("\t\t************************\n");
		int option = 0;
		scanf("%d", &option);
		switch (option)
		{
			case 1:
			{
				if (SignIn(headNode, user)) { return; }
				break;
			}
			case 2:
			{
				SignUp(headNode);
				break;
			}
			default:break;
		}

		system("pause");
		getchar();
	}
}

void ShowMyScheduleByContidion(NODE_SCHEDULE*& headNode, USER user)
{

	time_t timep;
	struct tm* p;
	time(&timep);
	p = gmtime(&timep);
	int year = 1900 + p->tm_year;
	int month = 1 + p->tm_mon;
	int day = p->tm_mday;

	NODE_SCHEDULE* tempNode = headNode;
	printf("[打印未超过的日程安排]\n");
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.userId == user.id)
		{
			if (year > tempNode->next->data.year_end)
			{
				tempNode = tempNode->next;
				continue;
			}
			else if (month > tempNode->next->data.month_end )
			{
				tempNode = tempNode->next;
				continue;
			}
			else if (month == tempNode->next->data.month_end &&day > tempNode->next->data.day_end)
			{
				tempNode = tempNode->next;
				continue;
			}

			printf("日程ID=%d，日程安排时间=从%d年%d月%d日至%d年%d月%d日，日程安排内容=%s，创建时间=%d年%d月%d日,所属用户名=%s \n",
				tempNode->next->data.id,
				tempNode->next->data.year_start,
				tempNode->next->data.month_start,
				tempNode->next->data.day_start,
				tempNode->next->data.year_end,
				tempNode->next->data.month_end,
				tempNode->next->data.day_end,
				tempNode->next->data.content,
				tempNode->next->data.year_create,
				tempNode->next->data.month_create,
				tempNode->next->data.day_create,
				user.name

			);
		}
		tempNode = tempNode->next;
	}
}
void ShowAllSchedule(NODE_SCHEDULE*& headNode, USER user)
{
	NODE_SCHEDULE* tempNode = headNode;
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.userId == user.id)
		{
			printf("日程ID=%d，日程安排时间=从%d年%d月%d日至%d年%d月%d日，日程安排内容=%s，创建时间=%d年%d月%d日,所属用户名=%s \n",
				tempNode->next->data.id,
				tempNode->next->data.year_start,
				tempNode->next->data.month_start,
				tempNode->next->data.day_start,
				tempNode->next->data.year_end,
				tempNode->next->data.month_end,
				tempNode->next->data.day_end,
				tempNode->next->data.content,
				tempNode->next->data.year_create,
				tempNode->next->data.month_create,
				tempNode->next->data.day_create,
				user.name

			);
		}
		tempNode = tempNode->next;
	}
}


void DropSchedule(NODE_SCHEDULE*& headNode, USER user) 
{
	int destId;
	printf("输入要删除的日程ID：");
	scanf("%d", &destId);
	int pos;
	if (!ListLocateById_SCHEDULE(headNode, destId, pos))
	{
		printf("[删除失败，不存在此日程]");
		return;
	}
	ListDeleteByPos_SCHEDULE(headNode, pos);
	printf("[删除成功]\n");
	return;

}
void CreateSchedule(NODE_SCHEDULE*& headNode, USER user)
{

	SCHEDULE inputSchedule;

	printf("设置日程安排的开始时间(年)：");
	scanf("%d", &inputSchedule.year_start);
	printf("设置日程安排的开始时间(月)：");
	scanf("%d", &inputSchedule.month_start);
	printf("设置日程安排的开始时间(日)：");
	scanf("%d", &inputSchedule.day_start);


	printf("输入日程安排的结束时间(年)：");
	scanf("%d", &inputSchedule.year_end);
	printf("输入日程安排的结束时间(月)：");
	scanf("%d", &inputSchedule.month_end);
	printf("输入日程安排的结束时间(日)：");
	scanf("%d", &inputSchedule.day_end);


	printf("输入日程内容：");
	scanf("%s", inputSchedule.content);

	time_t timep;
	struct tm* p;
	time(&timep);
	p = gmtime(&timep);
	inputSchedule.year_create = 1900 + p->tm_year;
	inputSchedule.month_create = 1 + p->tm_mon;
	inputSchedule.day_create = p->tm_mday;

	printf("[创建日程成功!]\n");
	printf("[当前日程创建时间为：%d年%d月%d日 ]\n",
		inputSchedule.year_create,
		inputSchedule.month_create,
		inputSchedule.day_create
	);
	printf("[当前日程安排为：%d年%d月%d日 - %d年%d月%d日 ] \n",
		inputSchedule.year_start,
		inputSchedule.month_start,
		inputSchedule.day_start,
		inputSchedule.year_end,
		inputSchedule.month_end,
		inputSchedule.day_end
	);
	printf("[当前日程内容为：%s ] \n", inputSchedule.content);


	NODE_SCHEDULE* newNode;
	NODE_SCHEDULE* preNode;
	ListInit_SCHEDULE(newNode);

	int length = ListGetLength_SCHEDULE(headNode);
	if (length > 1)
	{
		ListGetNodeByPos_SCHEDULE(headNode, length, preNode);
		inputSchedule.id = preNode->data.id + 1;
	}
	else { inputSchedule.id = 1; }
	inputSchedule.userId = user.id;
	newNode->data = inputSchedule;

	ListAppend_SCHEDULE(headNode, newNode);
	SaveData_SCHEDULE(headNode);


}

void Menu_Main(NODE_SCHEDULE*& headNode, USER user)
{
	while (true)
	{
		//主菜单
		system("cls");
		printf("[当前登录]用户ID=%d   用户名=%s \n", user.id, user.name);
		printf("\t\t************************\n");
		printf("\t\t**日程管理系统\n");
		printf("\t\t*1.新建日程\n");
		printf("\t\t*2.查看我的所有未过时的日程\n");
		printf("\t\t*3.查看我的所有历史日程\n");
		printf("\t\t*4.删除日程\n");
		printf("\t\t************************\n");
		int option = 0;
		scanf("%d", &option);
		switch (option)
		{
			case 1:CreateSchedule(headNode, user); break;
			case 2:ShowMyScheduleByContidion(headNode, user); break;
			case 3:ShowAllSchedule(headNode, user); break;
			case 4:DropSchedule(headNode, user); break;
			default:break;
		}

		system("pause");
		getchar();
	}
}


int main()
{
	//初始化
	NODE_USER* headNode_USER;
	NODE_SCHEDULE* headNode_SCHEDULE;
	ListInit_USER(headNode_USER);
	ListInit_SCHEDULE(headNode_SCHEDULE);

	//从文件中读取记录
	LoadData_USER(headNode_USER);
	LoadData_SCHEDULE(headNode_SCHEDULE);


	//登陆界面
	USER user;
	Menu_Login(headNode_USER, user);

	//主菜单界面
	Menu_Main(headNode_SCHEDULE, user);


	system("pause");
	getchar();

}

void ListInit_USER(NODE_USER*& headNode)
{
	headNode = (NODE_USER*)malloc(sizeof(NODE_USER));			//为头节点分配内存
	memset(&headNode->data, 0x0, sizeof(USER));	
	headNode->next = NULL;							
	return;
}


bool ListGetNodeByPos_USER(NODE_USER* headNode, int pos, NODE_USER*& node)
{
	if (pos < 1) { return false; }
	if (pos > ListGetLength_USER(headNode)) { return false; }

	//获取该位置的节点
	NODE_USER* tempNode = headNode;
	int count = 1;
	while (count < pos && tempNode->next != NULL)
	{
		tempNode = tempNode->next;
		count++;
	}
	node = tempNode;
	return true;
}



void ListAppend_USER(NODE_USER*& headNode, NODE_USER*& newNode)
{
	NODE_USER* tempNode = headNode;
	while (tempNode->next != NULL)
	{
		tempNode = tempNode->next;
	}
	tempNode->next = newNode;
	newNode->next = NULL;
}

int ListGetLength_USER(NODE_USER* headNode)
{
	int length = 1;
	NODE_USER* tempNode = headNode;
	while (tempNode->next != NULL)
	{
		length++;
		tempNode = tempNode->next;
	}
	return length;
}

bool ListDeleteByPos_USER(NODE_USER*& headNode, int pos)
{
	//判断逻辑位置是否越界
	if (pos > ListGetLength_USER(headNode)) { return false; }

	NODE_USER* preNode;
	ListGetNodeByPos_USER(headNode, pos - 1, preNode);

	preNode->next = preNode->next->next;
	return true;
}

void SaveData_USER(NODE_USER* headNode)
{
	//打开文件
	FILE* pFile = fopen("user.txt", "wb"); //打开用于写入的空文件。 如果给定文件存在，则其内容会被销毁。
	if (pFile == NULL) { printf("【error】pFile is null...\n"); return; }

	NODE_USER* tempNode = headNode->next;
	while (tempNode != NULL)
	{
		fwrite(&tempNode->data, sizeof(USER), 1, pFile);
		tempNode = tempNode->next;
	}

	//关闭文件
	fclose(pFile);
	printf("[写入文件成功]\n");
	return;
}

void LoadData_USER(NODE_USER* headNode)
{
	//打开文件
	FILE* pFile = fopen("user.txt", "rb"); //打开以便读取。 如果文件不存在或无法找到fopen调用失败。
	if (pFile == NULL) { return; }		

	//读取
	NODE_USER* newNode;
	ListInit_USER(newNode);
	while (fread(&newNode->data, sizeof(USER), 1, pFile) != 0)
	{
		ListAppend_USER(headNode, newNode);
		ListInit_USER(newNode);
	}

	fclose(pFile);
	printf("[读取文件成功]\n");
	return;
}

bool ListLocateByName_USER(NODE_USER* headNode, char* userName, int& pos)
{
	NODE_USER* tempNode = headNode;
	pos = 1;
	while (tempNode->next != NULL)
	{
		if (strcmp(tempNode->next->data.name, userName) == 0)
		{
			return true;
		}
		tempNode = tempNode->next;
		pos++;
	}
	pos = 0;
	return false;
}



void ListInit_SCHEDULE(NODE_SCHEDULE*& headNode)
{
	headNode = (NODE_SCHEDULE*)malloc(sizeof(NODE_SCHEDULE));			//为头节点分配内存
	memset(&headNode->data, 0x0, sizeof(SCHEDULE));	//将头节点的数据域清零
	headNode->next = NULL;							//将头节点的指针域置空
	return;
}


bool ListGetNodeByPos_SCHEDULE(NODE_SCHEDULE* headNode, int pos, NODE_SCHEDULE*& node)
{
	if (pos < 1) { return false; }
	if (pos > ListGetLength_SCHEDULE(headNode)) { return false; }

	NODE_SCHEDULE* tempNode = headNode;
	int count = 1;
	while (count < pos && tempNode->next != NULL)
	{
		tempNode = tempNode->next;
		count++;
	}
	node = tempNode;
	return true;
}


void ListAppend_SCHEDULE(NODE_SCHEDULE*& headNode, NODE_SCHEDULE*& newNode)
{
	NODE_SCHEDULE* tempNode = headNode;
	while (tempNode->next != NULL)
	{
		tempNode = tempNode->next;
	}
	tempNode->next = newNode;
	newNode->next = NULL;
}


int ListGetLength_SCHEDULE(NODE_SCHEDULE* headNode)
{
	int length = 1;
	NODE_SCHEDULE* tempNode = headNode;
	while (tempNode->next != NULL)
	{
		length++;
		tempNode = tempNode->next;
	}
	return length;
}

bool ListDeleteByPos_SCHEDULE(NODE_SCHEDULE*& headNode, int pos)
{
	if (pos > ListGetLength_SCHEDULE(headNode)) { return false; }

	NODE_SCHEDULE* preNode;
	ListGetNodeByPos_SCHEDULE(headNode, pos - 1, preNode);

	preNode->next = preNode->next->next;
	return true;
}

void SaveData_SCHEDULE(NODE_SCHEDULE* headNode)
{
	//打开文件
	FILE* pFile = fopen("schedule.txt", "wb"); 
	if (pFile == NULL) { printf("【error】pFile is null...\n"); return; }

	
	NODE_SCHEDULE* tempNode = headNode->next;
	while (tempNode != NULL)
	{
		fwrite(&tempNode->data, sizeof(SCHEDULE), 1, pFile);
		tempNode = tempNode->next;
	}

	//关闭文件
	fclose(pFile);
	printf("[写入文件成功]\n");
	return;
}

void LoadData_SCHEDULE(NODE_SCHEDULE*& headNode)
{
	//打开文件
	FILE* pFile = fopen("schedule.txt", "rb"); //打开以便读取。 如果文件不存在或无法找到fopen调用失败。
	if (pFile == NULL) { return; }		//如果文件不存在，说明本系统没有任何学生记录

	//读取
	NODE_SCHEDULE* newNode;
	ListInit_SCHEDULE(newNode);
	while (fread(&newNode->data, sizeof(SCHEDULE), 1, pFile) != 0)
	{
		ListAppend_SCHEDULE(headNode, newNode);
		ListInit_SCHEDULE(newNode);
	}

	//关闭文件
	fclose(pFile);
	printf("[读取文件成功]\n");
	return;
}

bool ListLocateById_SCHEDULE(NODE_SCHEDULE* headNode, int userName, int& pos)
{
	NODE_SCHEDULE* tempNode = headNode;
	pos = 2;
	while (tempNode->next != NULL)
	{
		if (tempNode->next->data.id == userName)
		{
			return true;
		}
		tempNode = tempNode->next;
		pos++;
	}
	pos = 0;
	return false;
}