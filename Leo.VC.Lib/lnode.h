#pragma once

typedef int ElemType;

typedef struct LNode
{
	ElemType data;
	struct LNode *next;
}LNode,*LinkList;

__declspec(dllexport) int initLinkedList(LinkList &L);
__declspec(dllexport) int nodeInsert(LinkList &L, int i, ElemType e);
__declspec(dllexport) ElemType nodeDelete(LinkList &L, int i);
__declspec(dllexport) LNode* getNode(LinkList L,int i);