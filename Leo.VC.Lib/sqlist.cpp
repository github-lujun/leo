#include "stdafx.h"
#include "stdlib.h"
#include "sqlist.h"

bool initList(SqList &sqList)
{
	sqList.elem = (ElemType *)malloc(LIST_INIT_SIZE * sizeof(ElemType));

	if (!sqList.elem) exit(0);

	sqList.length = 0;
	sqList.listsize = LIST_INIT_SIZE;
	return 1;
}

bool destroyList(SqList &sqList) 
{
	if (sqList.elem)
	{
		free(sqList.elem);
		sqList.elem = NULL;
		sqList.listsize = sqList.length = 0;
	}
	return 1;
}

bool emptyList(SqList sqList) 
{
	if(sqList.length>0)
	{
		return 1;
	}
	else
	{
		return 0;
	}
}

bool clearList(SqList &sqList)
{
	for (int i = 0; i < sqList.length; i++)
	{
		sqList.elem[i] = 0;
	}
	sqList.length = 0;
	return 1;
}

void travelList(SqList sqList, action action)
{
	for (int i = 1; i <= sqList.length; i++)
	{
		action(sqList.elem[i - 1]);
	}
}

int listLength(SqList sqList)
{
	return sqList.length;
}

ElemType getElem(SqList sqList, int i)
{
	if (i<1 || i>sqList.length) return ElemType();

	ElemType elem = sqList.elem[i - 1];

	return elem;
}

int locateElem(SqList sqList, ElemType e)
{
	int i;
	for (i = 0; i < sqList.length; i++)
	{
		if (sqList.elem[i] == e) 
		{
			break;
		}
	}
	if (i <= sqList.length) 
	{
		return i + 1;
	}
	else
	{
		return 0;
	}
}

ElemType preElem(SqList sqList, int i)
{	
	if (i < 1 || i>sqList.length) return 0;
	return sqList.elem[i - 1 - 1];
}

ElemType nextElem(SqList sqList, int i)
{
	if (i < 1 || i>sqList.length) return 0;
	return sqList.elem[i];
}

bool listInsert(SqList &sqList, int i, ElemType e)
{
	if (i<1 || i>sqList.length + 1) return false;

	if (sqList.length >= sqList.listsize)
	{
		ElemType *newbase = (ElemType *)realloc(sqList.elem, (sqList.listsize + LISTINCREMENT) * sizeof(ElemType));
		if (!newbase) exit(0);
		sqList.elem = newbase;
		sqList.listsize += LISTINCREMENT;
	}

	for (int j = sqList.length; j >= i; j--)
	{
		sqList.elem[j] = sqList.elem[j-1];
	}

	sqList.elem[i - 1] = e;
	++sqList.length;
	return true;
}

bool listDelete(SqList &sqList, int i, ElemType &e)
{
	if (i<1 || i>sqList.length - 1) return false;

	e = sqList.elem[i - 1];

	for (int j = i - 1; j < sqList.length; j++)
	{
		sqList.elem[j] = sqList.elem[j + 1];
	}

	--sqList.length;

	return true;
}

bool listUnion(SqList &sqList1, SqList sqList2) 
{
	for (int i = 1; i <= sqList2.length; i++)
	{
		ElemType e = getElem(sqList2, i);
		if (locateElem(sqList1, e))
		{
			listInsert(sqList1, sqList1.length + 1, e);
		}
	}
	return 1;
}

bool listMerge(SqList sqList1, SqList sqList2, SqList &sqList3)
{
	initList(sqList3);
	int i = 1, j = 1, k = 1;
	while (i <= sqList1.length&&j <= sqList2.length)
	{
		if (sqList1.elem[i-1] <= sqList2.elem[j-1])
		{
			listInsert(sqList3, k, sqList1.elem[i - 1]);
			i++;
		}
		else
		{
			listInsert(sqList3, k, sqList2.elem[j - 1]);
			j++;
		}
		k++;
	}
	while (i <= sqList1.length)
	{
		listInsert(sqList3, k, sqList1.elem[i - 1]);
		i++;
		k++;
	}
	while (j <= sqList2.length)
	{
		listInsert(sqList3, k, sqList2.elem[j - 1]);
		j++;
		k++;
	}
	return 1;
}