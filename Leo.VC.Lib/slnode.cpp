#include "stdafx.h"
#include "slnode.h"

int locateElem(SLinkList s, ElemType e)
{
	int r = 1;
	int i = s[0].cur;
	while (i>=0)
	{
		if (s[i].data == e) 
		{
			break;
		}
		i = s[i].cur;
		r++;
	}
	if (i<0)
	{
		return 0;
	}
	else
	{
		return r;
	}
}