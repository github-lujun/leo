// Leo.VC.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "stdlib.h"
#include "sqlist.h"
#include "lnode.h"
#include "slnode.h"

void act1(ElemType e)
{
	printf(" %d", e);
}

int main()
{
	#pragma region program
	#pragma region sqlist
	/*SqList sq;
	initList(sq);
	listInsert(sq,1, 1);
	listInsert(sq, 2, 2);
	listInsert(sq, 3, 3);
	listInsert(sq, 2, 4);
	ElemType e;
	listDelete(sq, 1, e);
	printf("the elem deleted is %d\n", e);
	int index = locateElem(sq,2);
	printf("the index of 2 is %d\n", index);//2
	ElemType e1 = getElem(sq,index);
	printf("the elem in %d is %d\n", index, e1);
	printf("\nthe elems is :");
	action act = act1;
	travelList(sq, act);
	SqList sq1;
	initList(sq1);
	listInsert(sq1, 1, 3);
	listInsert(sq1, 2, 2);
	listInsert(sq1, 3, 5);
	printf("\nthe elems is :");
	travelList(sq1, act);
	listUnion(sq, sq1);
	printf("\nthe elems is :");
	travelList(sq, act);
	SqList s1, s2, s3;
	initList(s1);
	initList(s2);
	listInsert(s1, 1, 4);
	listInsert(s1, 2, 6);
	listInsert(s1, 3, 8);
	listInsert(s1, 4, 9);
	listInsert(s2, 1, 0);
	listInsert(s2, 2, 4);
	listInsert(s2, 3, 5);
	listInsert(s2, 4, 7);
	listInsert(s2, 5, 9);
	listMerge(s1, s2, s3);
	printf("\nthe elems is :");
	travelList(s1, act);
	printf("\nthe elems is :");
	travelList(s2, act);
	printf("\nthe elems is :");
	travelList(s3, act);
	destroyList(sq1);
	destroyList(sq);*/
	#pragma endregion
	#pragma region linklist
	#pragma region dlinklist
	/*LinkList L;
	initLinkedList(L);
	for (int i = 1; i <= 10; i++)
	{
		nodeInsert(L, i,i);
	}
	LNode* node = getNode(L, 5);
	nodeDelete(L, 5);
	node = getNode(L, 5);*/
	/*LinkList la,lb, lc;
	LNode *pa, *pb, *pc;
	initLinkedList(la);
	nodeInsert(la, 1, 1);
	nodeInsert(la, 2, 3);
	nodeInsert(la, 3, 5);
	nodeInsert(la, 4, 7);
	initLinkedList(lb);
	nodeInsert(lb, 1, 0);
	nodeInsert(lb, 2, 2);
	nodeInsert(lb, 3, 4);
	nodeInsert(lb, 4, 8);
	pa = la->next;
	pb = lb->next;
	lc = pc = la;
	while (pa&&pb)
	{
		if (pa->data <= pb->data)
		{
			pc->next = pa;
			pc = pa;
			pa = pa->next;
		}
		else
		{
			pc->next = pb;
			pc = pb;
			pb = pb->next;
		}
	}
	pc->next = pa ? pa : pb;*/
	#pragma endregion
	#pragma region slinklist
	SLinkList s;
	component c;
	c.data = 0;
	c.cur = 1;
	s[0] = c;
	for (int i = 1; i <= 9; i++)
	{
		c.data = i;
		c.cur = i+1;
		s[i] = c;
		s[0].data++;
	}
	c.data = 10;
	c.cur = 11;
	s[10] = c;
	component r;
	int j = 1;
	for (int i = 1; i <= 4; i++)
	{
		r = s[j];
		j = r.cur;
	}
	s[10].cur = s[r.cur].cur;
	s[r.cur].cur = 10;
	s[0].data++;
	int ir = locateElem(s, c.data);
	printf("%d",ir);
	#pragma endregion 
	#pragma endregion
    return 0;
	#pragma endregion
}