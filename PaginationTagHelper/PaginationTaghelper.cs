using System;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Collections.Generic;
using GenericTagHelper.MethodHelpers;
using PaginationTagHelper.Pagination;

namespace PaginationTagHelper
{
    [HtmlTargetElement("pagination")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;


        public PaginationTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }

        [HtmlAttributeNotBound]
        public IUrlHelper urlHelper
        {
            get
            {
                return urlHelperFactory.GetUrlHelper(ViewContext);
            }
        }


        // Get Current ViewContext
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public string AttributesValidationSummary { get; set; }

        /*-----------------------Must Be Fullfill-------------------------*/
        public IPagingObject PagingModel { get; set; }

        public bool ActiveCustomQueryOptions { get; set; } = false;

        public int TotalItems { get; set; }

        private int TotalPages
        {
            get
            {
                if (PagingModel.ItemPerPage <= 0)
                {
                    PagingModel.ItemPerPage = 5;
                }
                return (int)Math.Ceiling((decimal)
                    TotalItems / PagingModel.ItemPerPage);
            }
        }

        public string CurrentPageParameter { get; set; } = "page";

        public string PageQueryList { get; set; }

        private Dictionary<string, string> QueryOptions
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(PageQueryList);
            }
        }
        private Dictionary<string, string> QueryListDict { get; set; } = new Dictionary<string, string>();


        public bool ActiveQueryOptions { get; set; }

        public string PageAction { get; set; } = "";

        public string PageController { get; set; } = "";

        public string PageStyleClass { get; set; } = "pagination";

        public string PageActiveClass { get; set; } = "active";

        public string PageDisableClass { get; set; } = "disabled";

        public int PageMiddleLength { get; set; } = 2;

        public int PageTopBottomLength { get; set; } = 5;

        public string PagePreviousIcon { get; set; } = "Previous";

        public string PageNextIcon { get; set; } = "Next";

        public string PageFirstIcon { get; set; } = "First";

        public string PageLastIcon { get; set; } = "Last";

        public bool PageShowFirst { get; set; } = true;

        public bool PageShowLast { get; set; } = true;

        public string PageBetweenIcon { get; set; } = "...";

        public bool PageShowBetweenIcon { get; set; } = true;

        public bool PageExchangePreviousFirstBtn { get; set; }

        public bool PageExchangeNextLastBtn { get; set; }

        public bool ActivePagination { get; set; }



        public override void Process(
            TagHelperContext context, TagHelperOutput output)
        {
            if (TotalPages <= 1)
            {
                return;
            }

            // <ul class="pagination"></ul>
            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass(PageStyleClass);

            // Show Middle Page Button
            for (int i = 1; i <= TotalPages; ++i)
            {

                TagBuilder list_li = PageButton(
                    has_link: true,
                    page_action: i,
                    icon: i.ToString(),
                    is_disabled: false,
                    active_page: i == PagingModel.Page);

                TagBuilder first_li = PageButton(
                    has_link: PagingModel.Page > 1,
                    page_action: i,
                    icon: PageFirstIcon,
                    is_disabled: PagingModel.Page == 1,
                    active_page: false);

                TagBuilder last_li = PageButton(
                    has_link: PagingModel.Page < TotalPages,
                    page_action: i,
                    icon: PageLastIcon,
                    is_disabled: PagingModel.Page == TotalPages,
                    active_page: false);

                TagBuilder dot_li = PageButton(
                    has_link: false,
                    page_action: i,
                    icon: PageBetweenIcon,
                    is_disabled: true,
                    active_page: false);

                /*-----------------------Show First and Previous Page Button-------------------------*/

                // Show previous and first btn in different location
                if (PageExchangePreviousFirstBtn)
                {
                    // Show First Page Btn
                    if (i == 1 && PageShowFirst)
                    {
                        ul.InnerHtml.AppendHtml(first_li);
                    }

                    // Show Previous Page Btn
                    if (i == 1)
                    {
                        var pre_li = PageButton(
                            has_link: (PagingModel.Page - 1) >= 1,
                            page_action: PagingModel.Page - 1,
                            icon: PagePreviousIcon,
                            is_disabled: PagingModel.Page == 1,
                            active_page: false);

                        ul.InnerHtml.AppendHtml(pre_li);
                        // if current page is bigger than 3 
                        // TotalPage can't be same as PageMiddleLength 
                        if (PagingModel.Page > PageMiddleLength + 1 &&
                            TotalPages > (1 + PageMiddleLength * 2) &&
                            PageShowBetweenIcon)
                        {
                            ul.InnerHtml.AppendHtml(dot_li);
                        }
                    }
                }
                else
                {
                    // Show Previous Btn
                    if (i == 1)
                    {
                        var pre_li = PageButton(
                            has_link: (PagingModel.Page - 1) >= 1,
                            page_action: PagingModel.Page - 1,
                            icon: PagePreviousIcon,
                            is_disabled: PagingModel.Page == 1,
                            active_page: false);

                        ul.InnerHtml.AppendHtml(pre_li);
                    }

                    // Show First Page
                    if (i == 1 && PageShowFirst)
                    {
                        ul.InnerHtml.AppendHtml(first_li);
                        // if current page is bigger than 3 
                        if (PagingModel.Page > PageMiddleLength + 1 &&
                            TotalPages > (1 + PageMiddleLength * 2) &&
                            PageShowBetweenIcon)
                        {
                            ul.InnerHtml.AppendHtml(dot_li);
                        }
                    }

                }


                /*-----------------------Middle Page Button-------------------------*/

                // Check if bottom page length is override to top page length
                // and only show page once.
                bool checkPageRepeated = true;
                // Show Middle Pages
                // if current page in the bottom then show 5 pages
                // Show pages less than 5 && show pages if bigger than current page-3

                if (i <= PageTopBottomLength &&
                    i >= PagingModel.Page - PageMiddleLength)
                {
                    checkPageRepeated = false;
                    ul.InnerHtml.AppendHtml(list_li);
                }



                // Show page number after bottom and top pages
                // which is middle pages
                if (i > PageTopBottomLength &&
                    i <= TotalPages - PageTopBottomLength &&
                    i >= PagingModel.Page - PageMiddleLength &&
                    i <= PagingModel.Page + PageMiddleLength)
                {
                    ul.InnerHtml.AppendHtml(list_li);
                }

                // Show page larger than total page -5,
                // if current page in the top then show 5 pages
                // and total pages must be bigger than 5
                if (i > TotalPages - PageTopBottomLength &&
                    i <= PagingModel.Page + PageMiddleLength &&
                    checkPageRepeated)
                {
                    ul.InnerHtml.AppendHtml(list_li);
                }


                /*-----------------------Show Next And Last Page Button-------------------------*/


                if (PageExchangeNextLastBtn)
                {
                    // Show Next Page Btn 
                    if (i == TotalPages)
                    {
                        var next_li = PageButton(
                            has_link: (PagingModel.Page + 1) <= TotalPages,
                            page_action: PagingModel.Page + 1,
                            icon: PageNextIcon,
                            is_disabled: PagingModel.Page == TotalPages,
                            active_page: false);
                        // if current page is smaller than total page minus five 
                        if ((PagingModel.Page < TotalPages - PageMiddleLength) &&
                            TotalPages > (1 + PageMiddleLength * 2)
                            && PageShowBetweenIcon)
                        {
                            ul.InnerHtml.AppendHtml(dot_li);
                        }

                        ul.InnerHtml.AppendHtml(next_li);
                    }

                    // Show Last Page Btn
                    if (i == TotalPages && PageShowLast)
                    {
                        ul.InnerHtml.AppendHtml(last_li);
                    }

                }
                else
                {
                    // Show Last Page Btn
                    if (i == TotalPages && PageShowLast)
                    {
                        // if current page is smaller than total page minus five 
                        if ((PagingModel.Page < TotalPages - PageMiddleLength) &&
                            TotalPages > (1 + PageMiddleLength * 2) &&
                            PageShowBetweenIcon)
                        {
                            ul.InnerHtml.AppendHtml(dot_li);
                        }

                        ul.InnerHtml.AppendHtml(last_li);
                    }

                    // Show Next Page Btn
                    if (i == TotalPages)
                    {
                        var next_li = PageButton(
                            has_link: (PagingModel.Page + 1) <= TotalPages,
                            page_action: PagingModel.Page + 1,
                            icon: PageNextIcon,
                            is_disabled: PagingModel.Page == TotalPages,
                            active_page: false);


                        ul.InnerHtml.AppendHtml(next_li);
                    }
                }

            }


            output.TagName = "nav";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Content.SetHtmlContent(ul);

        }


        // Show Page Icon
        // <span aria-hidden="true">{{ icon  }}</span>
        public TagBuilder PageIcon(string icon)
        {
            TagBuilder span = new TagBuilder("span");
            span.MergeAttribute("aria-hidden", "true");
            span.InnerHtml.AppendHtml(icon);
            return span;
        }

        // Show Page Link
        // <a href="/action?query"></a>
        public TagBuilder PageLink(
            TagBuilder a,
            int page_action)
        {
            if (String.IsNullOrWhiteSpace(PageController))
            {
                if (!String.IsNullOrEmpty(PageQueryList))
                {
                    foreach (var item in QueryOptions)
                    {
                        QueryListDict[item.Key] = item.Value;
                    }
                }

                QueryListDict[CurrentPageParameter] = page_action.ToString();
                a.Attributes["href"] = urlHelper.Action(
                     PageAction, QueryListDict);
            }
            else
            {

                if (!String.IsNullOrEmpty(PageQueryList))
                {
                    foreach (var item in QueryOptions)
                    {
                        QueryListDict[item.Key] = item.Value;
                    }
                }

                QueryListDict[CurrentPageParameter] = page_action.ToString();
                a.Attributes["href"] = urlHelper.Action(
                                     PageAction, PageController,
                                     QueryListDict);
            }



            return a;
        }

        // Show Page Button
        // <li disabled>
        //  <a aria-label="{{ icon }}" herf="">
        //      <span>{{ icon }}</span>
        //  </a>
        // </li>
        public TagBuilder PageButton(
            bool has_link,
            int page_action,
            string icon,
            bool is_disabled,
            bool active_page)
        {
            TagBuilder li = new TagBuilder("li");
            TagBuilder a = new TagBuilder("a");

            a.Attributes["aria-label"] = icon;

            if (has_link)
            {
                a = PageLink(a, page_action);
            }

            a.InnerHtml.AppendHtml(PageIcon(icon));
            li.InnerHtml.AppendHtml(a);

            if (is_disabled)
            {
                li.AddCssClass(PageDisableClass);
            }

            if (active_page)
            {
                a.AddCssClass(PageActiveClass);
                li.AddCssClass(PageActiveClass);
            }

            return li;
        }
    }
}
