// Leo.VC.cpp: 定义控制台应用程序的入口点。
//

/*#include "stdafx.h"
#include "sqlist.h"

int main()
{
	Sq sq;
	for (int i = 1; i <= 102; i++)
	{
		if (i == 100)
		{
			printf("%d", sq.sqList.length);
		}
		sq.listInsert(i, i);
	}
	for (int i = sq.sqList.listsize; i <= sq.sqList.length; i++)
	{
		ElemType elem = sq.getElem(i);
		printf("%d\n",elem);
	}

	//ElemType e;
	//listDelete(sq, 1,e);
	//printf("%d\n", e);
	//elem = getElem(sq, 1);
	//printf("%d\n", elem);
    return 0;
}*/

#include "stdafx.h"

typedef struct
{
	int elem[2];
}SqList;

int main()
{
	/* 我的第一个 C 程序 */
	printf("Hello, World! \n");
	SqList sl;
	printf("%d\n", sizeof(sl));
	for (int i = 0; i<6; i++)
	{
		sl.elem[i] = i;
		printf("%d ", sizeof(i));
		printf("%d\n", sl.elem[i]);
	}
	return 0;
}