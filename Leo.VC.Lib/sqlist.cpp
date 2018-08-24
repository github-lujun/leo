#include "stdafx.h"
#include "stdlib.h"
#include "sqlist.h"

Sq::Sq()
{
	sqList.elem = (ElemType *)malloc(LIST_INIT_SIZE * sizeof(ElemType));

	if (!sqList.elem) exit(0);

	this->sqList.length = 0;
	this->sqList.listsize = LIST_INIT_SIZE;
}

ElemType Sq::getElem(int i)
{
	if (i<1 || i>sqList.length) return ElemType();

	ElemType elem = sqList.elem[i - 1];

	return elem;
}

bool Sq::listInsert(int i, ElemType e)
{
	if (i<1 || i>sqList.length + 1) return false;

	if (sqList.length >= sqList.listsize)
	{
		ElemType *newbase = (ElemType *)realloc(sqList.elem, (sqList.listsize + LISTINCREMENT) * sizeof(ElemType));
		if (!newbase) exit(0);
		sqList.elem = newbase;
		sqList.listsize += LISTINCREMENT;
	}

	for (int j = sqList.length - 1; j >= i; j++)
	{
		sqList.elem[j + 1] = sqList.elem[j];
	}

	sqList.elem[i - 1] = e;
	++sqList.length;
	return true;
}

bool Sq::listDelete(int i, ElemType &e)
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