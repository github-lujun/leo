// Leo.VC.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "stdlib.h"
#include "sqlist.h"
#include "lnode.h"

int main()
{
	/*SqList sq;
	initList(sq);
	listInsert(sq,1, 1);
	listInsert(sq, 2, 2);
	listInsert(sq, 3, 3);
	listInsert(sq, 2, 4);
	for (int i = 1; i <= sq.length; i++)
	{
		ElemType elem = getElem(sq, i);
		printf("%d\n",elem);
	}

	ElemType e;
	int locate = locateElem(sq, 5);
	printf("%d", locate);
	listDelete(sq, 4, e);
	printf("%d\n", e);
	e = getElem(sq, 4);
	printf("%d\n", e);
	ElemType *elem=NULL;
	//destroyList(sq,elem);
	e = getElem(sq, 1);
	printf("%d\n", e);
	SqList sq1;
	initList(sq1);
	listInsert(sq1, 1, 99);
	listInsert(sq1, 2, 98);
	SqList sq2;
	mergeList(sq, sq1, sq2);
	listUnion(sq, sq1);*/
	LinkList L;
	initLinkedList(L);
	for (int i = 1; i <= 10; i++)
	{
		nodeInsert(L, i,i);
	}
	LNode* node = getNode(L, 5);
	nodeDelete(L, 5);
	node = getNode(L, 5);
    return 0;
}