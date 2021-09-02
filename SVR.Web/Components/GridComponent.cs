﻿using SVR.Shared.Parameters;
using SVR.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVR.Web.Components
{
    public class GridComponent:BaseComponent
    {
        protected int[] AllowedPageSizes = new int[] { 15, 30, 50 };

        protected bool ShowFilterRow = false;
        //protected LoadResult EmptyResult()
        //{
        //    return new LoadResult()
        //    {
        //        data = null,
        //        totalCount = 0
        //    };
        //}

        protected async Task<FilterParameter> ConfigureParametersAsync(DataSourceLoadOptionsBase options, int pageSize, List<object> defaultOptions = null )
        {
            if (options.Filter == null)
            {
                options.Filter = defaultOptions;
            }

            FilterParameter = await GetParametersAsync(options, PageIndex, pageSize).ConfigureAwait(false);
 
            return FilterParameter;
        }

        #region Grid Events

        protected void OnPageCountChanged(int newPageCount)
        {
            PageCount = newPageCount;
        }

        protected void OnPageIndexChanged(int newPageIndex)
        {
            PageIndex = newPageIndex;
        }

        protected void OnShowFilterRow( )
        {
            ShowFilterRow = !ShowFilterRow;
        }

        #endregion Grid Events

        protected FilterParameter FilterParameter { get; set; }

        protected int PageCount { get; set; }

        protected int PageIndex { get; set; }

        protected int RecordCount { get; set; }
    }
}
