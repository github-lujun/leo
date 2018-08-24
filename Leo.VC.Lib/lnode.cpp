#include "stdafx.h"
#include "stdlib.h"
#include "lnode.h"

int initLinkedList(LinkList &linkedList)
{
	linkedList = (LinkList)malloc(sizeof(LinkList));
	if (!linkedList) exit(0);
	linkedList->data = 0;
	linkedList->next = NULL;
	return 1;
}

int nodeInsert(LinkList &L, int i, ElemType e)
{
	if (i<1 || i>L->data + 1) return 0;
	LNode* node=(LNode*)malloc(sizeof(LNode));
	node->data = e;
	if (i == 1)
	{
		node->next = L->next==NULL?L->next:L->next->next;
		L->next = node;
	}
	else
	{
		LNode * pre = getNode(L, i-1);
		node->next = pre->next;
		pre->next = node;
	}
	(L->data)++;
	return 1;
}

ElemType nodeDelete(LinkList &L, int i)
{
	if (i<1 || i>L->data + 1) return 0;
	LNode* pre = getNode(L, i - 1);
	LNode* q = pre->next;
	pre->next = q->next;
	ElemType r = q->data;
	free(q);
	(L->data)--;
	return r;
}

LNode* getNode(LinkList L, int i)
{
	int j = 1;
	LNode *r = L->next;
	while (j != i)
	{
		r = r->next;
		j++;
	}
	return r;
}