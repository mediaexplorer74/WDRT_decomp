﻿using System;
using System.Collections.Generic;
using Microsoft.Data.OData.Query.SyntacticAst;

namespace Microsoft.Data.OData.Query
{
	// Token: 0x020000D7 RID: 215
	internal static class QueryOptionUtils
	{
		// Token: 0x0600053D RID: 1341 RVA: 0x00011E34 File Offset: 0x00010034
		internal static string GetQueryOptionValueAndRemove(this List<CustomQueryOptionToken> queryOptions, string queryOptionName)
		{
			CustomQueryOptionToken customQueryOptionToken = null;
			for (int i = 0; i < queryOptions.Count; i++)
			{
				if (queryOptions[i].Name == queryOptionName)
				{
					if (customQueryOptionToken != null)
					{
						throw new ODataException(Strings.QueryOptionUtils_QueryParameterMustBeSpecifiedOnce(queryOptionName));
					}
					customQueryOptionToken = queryOptions[i];
					queryOptions.RemoveAt(i);
					i--;
				}
			}
			if (customQueryOptionToken != null)
			{
				return customQueryOptionToken.Value;
			}
			return null;
		}
	}
}
